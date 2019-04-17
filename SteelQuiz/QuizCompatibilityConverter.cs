/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;

namespace SteelQuiz
{
    public static class QuizCompatibilityConverter
    {
        /*
         * Returns quiz if quiz doesn't need to be converted, or if it was converted successfully. Otherwise it returns null
         */
        public static Quiz ChkUpgradeQuiz(Quiz quiz, string path, bool askToUpgrade = true)
        {
            Version fromVer;

            var V2 = new Version(1, 1, 0); // changed wordpair synonyms default value from null to new List<string>(), renamed QuizFileFormatVersion to FileFormatVersion
            var V3 = new Version(2, 0, 0); // implemented wordpair ID system, to avoid storing the whole quiz in the progress file

            var fileFormatVersionDefined = SUtil.PropertyDefined(quiz.FileFormatVersion);
            if (fileFormatVersionDefined)
            {
                fromVer = new Version(quiz.FileFormatVersion);
            }
            else
            {
                fromVer = new Version(1, 0, 0);
            }

            BackupQuiz(path, fromVer);

            if (fromVer.CompareTo(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION)) < 0)
            {
                //conversion required

                if (askToUpgrade)
                {
                    /*
                    var msg = MessageBox.Show("The quiz file you have selected was made for an older version of SteelQuiz and must be converted to "
                        + "the current format to load it. A backup will be created automatically, meaning that you won't lose anything when converting.\r\n\r\n"
                        + "Warning! The quiz will probably be incompatible with older versions of SteelQuiz after the conversion. To use the quiz with "
                        + "older versions of SteelQuiz after the conversion, you must use the backup quiz, which is created automatically."
                        + "\r\n\r\nProceed with conversion?", "Quiz conversion required - SteelQuiz",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        */
                    var msg = MessageBox.Show("Quiz conversion required due to updated file format. A backup will be created automatically. Convert now?",
                    "Quiz conversion required - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.No)
                    {
                        return null;
                    }
                }

                var bkp = BackupQuiz(path, fromVer);
                if (!bkp)
                {
                    return null;
                }
            }
            else
            {
                return quiz;
            }

            if (V2.CompareTo(fromVer) > 0)
            {
                // initialize synonyms (ver x --> 1.0.1)
                // synonyms in v1.0.0 were string arrays initialized to null
                // should now be string lists initialized to new List<string>()
                // QuizFileFormatVersion is renamed to FileFormatVersion

                foreach (var wp in quiz.WordPairs)
                {
                    if (wp.Word1Synonyms == null)
                    {
                        wp.Word1Synonyms = new List<string>();
                    }

                    if (wp.Word2Synonyms == null)
                    {
                        wp.Word2Synonyms = new List<string>();
                    }
                }

                quiz.FileFormatVersion = V3.ToString();
            }

            if (V3.CompareTo(fromVer) > 0)
            {
                // add wordpairs to quiz wordpairs
                for (int i = 0; i < quiz.WordPairs.Count; ++i)
                {
                    quiz.WordPairs[i].ID = (ulong)i;
                }
            }

            if (quiz != null)
            {
                quiz.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
            }

            QuizCore.SaveQuiz(quiz, path);

            return quiz;
        }

        /*
         * QuizCore.Quiz must be set and converted before calling this function
         */ 
        public static QuizProgDataRoot ChkUpgradeProgressData(dynamic _cfgQuizzesProgressData)
        {
            var cfgQuizzesProgressData = _cfgQuizzesProgressData;

            Version fromVer;
            fromVer = new Version(cfgQuizzesProgressData.FileFormatVersion.ToString());

            if (fromVer.CompareTo(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION)) >= 0)
            {
                //conversion not required
                return JsonConvert.DeserializeObject<QuizProgDataRoot>(JsonConvert.SerializeObject(cfgQuizzesProgressData, Formatting.Indented));
            }

            var V3 = new Version(2, 0, 0); // implemented wordpair ID system, to avoid storing the whole quiz in the progress file

            if (V3.CompareTo(fromVer) > 0)
            {
                // change wordpairs to IDs, for each quiz

                var qpdList = new List<QuizProgData>();

                bool acceptQuizProgRemovals = false;
                foreach (var quizProg in cfgQuizzesProgressData.QuizProgDatas)
                {
                    Quiz correspondingQuiz = FindQuiz(quizProg);
                    if (correspondingQuiz == null && !acceptQuizProgRemovals)
                    {
                        var msg = MessageBox.Show("Some quizzes referenced by the progress data could not be found. Remove these quizzes from the progress data? " +
                            "(required)\r\n\r\nIf you have quizzes whose progress data you want to keep, please select No, place them in %appdata%\\SteelQuiz\\Quizzes, " +
                            "and start the conversion again.\r\n\r\nIf you select No, the conversion will not proceed.", "SteelQuiz",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            acceptQuizProgRemovals = true;
                            continue;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (correspondingQuiz == null && acceptQuizProgRemovals)
                    {
                        continue;
                    }
                    var newQuizProgData = new QuizProgData(correspondingQuiz, false);
                    var wordPair = GetQuizWordPairCompat(correspondingQuiz, quizProg.CurrentWordPair);
                    if (wordPair != null)
                    {
                        newQuizProgData.CurrentWordPairID = wordPair.ID;
                    }
                    newQuizProgData.FullTestInProgress = quizProg.FullTestInProgress;
                    //newQuizProgData.MasterNoticeShowed = quizProg.MasterNoticeShowed;
                    newQuizProgData.MasterNoticeShowed = false; // should reset after each application restart, so set it to false
                    newQuizProgData.QuizGUID = quizProg.QuizGUID;

                    foreach (var wpData in quizProg.WordProgDatas)
                    {
                        var newWp = new WordProgData(GetQuizWordPairCompat(correspondingQuiz, wpData.WordPair).ID);
                        newWp.AskedThisRound = wpData.AskedThisRound;
                        newWp.SkipThisRound = wpData.SkipThisRound;
                        newWp.WordTries = wpData.WordTries.ToObject<List<WordTry>>();

                        newQuizProgData.WordProgDatas.Add(newWp);
                    }

                    qpdList.Add(newQuizProgData);
                }

                cfgQuizzesProgressData = new QuizProgDataRoot();
                cfgQuizzesProgressData.QuizProgDatas = qpdList;
            }

            if (cfgQuizzesProgressData != null)
            {
                cfgQuizzesProgressData.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
            }

            if (cfgQuizzesProgressData != null)
            {
                SaveWholeProgress(cfgQuizzesProgressData);
            }

            return cfgQuizzesProgressData;
        }

        public static void SaveWholeProgress(QuizProgDataRoot progressData)
        {
            using (var writer = new StreamWriter(QuizCore.PROGRESS_FILE_PATH, false))
            {
                writer.Write(JsonConvert.SerializeObject(progressData, Formatting.Indented));
            }
        }

        private static Quiz FindQuiz(dynamic quizProgData)
        {
            foreach (var quizPath in Directory.GetFiles(QuizCore.QUIZ_FOLDER, $"*{QuizCore.QUIZ_EXTENSION}", SearchOption.TopDirectoryOnly))
            {
                Quiz quiz;
                using (var reader = new StreamReader(quizPath))
                {
                    quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
                }

                if (quiz == null || !SUtil.PropertyDefined(quiz.GUID))
                {
                    continue;
                }

                if (quiz.GUID == Guid.Parse(quizProgData.QuizGUID.ToString()))
                {
                    return ChkUpgradeQuiz(quiz, quizPath, false);
                }
            }

            return null;
        }

        private static WordPair GetQuizWordPairCompat(Quiz quiz, dynamic wordPair)
        {
            if (wordPair == null)
            {
                return null;
            }

            foreach (var wp in quiz.WordPairs)
            {
                if (wp.Word1 == wordPair.Word1.ToString()
                    && wp.Word2 == wordPair.Word2.ToString()
                    &&
                        ((wp.Word1Synonyms == null && wordPair.Word1Synonyms == null) ||
                        wp.Word1Synonyms.SequenceEqual((List<string>)wordPair.Word1Synonyms.ToObject<List<string>>()))
                    && ((wp.Word2Synonyms == null && wordPair.Word2Synonyms == null) ||
                        wp.Word2Synonyms.SequenceEqual((List<string>)wordPair.Word2Synonyms.ToObject<List<string>>()))
                    && wp.TranslationRules == wordPair.TranslationRules.ToObject<StringComp.Rules>())
                {
                    return wp;
                }
            }

            return null;
        }

        public static bool BackupQuiz(string quizPath, Version quizVer)
        {
            var extStartIndex = quizPath.Length - QuizCore.QUIZ_EXTENSION.Length;
            var bkpQuizPath = Path.Combine(
                QuizCore.QUIZ_BACKUP_FOLDER,
                Path.GetFileNameWithoutExtension(quizPath) + "_" + quizVer.ToString() + QuizCore.QUIZ_EXTENSION);
            var exCount = 1;
            while (File.Exists(bkpQuizPath))
            {
                ++exCount;
                //newQuizPath = QuizPath.Insert(extStartIndex, "_" + quizVer.ToString() + "_" + exCount);
                bkpQuizPath = Path.Combine(
                    QuizCore.QUIZ_BACKUP_FOLDER,
                    Path.GetFileNameWithoutExtension(quizPath) + "_" + quizVer.ToString() + "_" + exCount + QuizCore.QUIZ_EXTENSION);
            }

            try
            {
                File.Copy(quizPath, bkpQuizPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the quiz, the conversion will not run:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool BackupProgress(Version progressVer)
        {
            var extStartIndex = QuizCore.PROGRESS_FILE_PATH.Length - ".json".Length;
            var bkpProgressPath = Path.Combine(
                QuizCore.BACKUP_FOLDER,
                Path.GetFileNameWithoutExtension(QuizCore.PROGRESS_FILE_PATH) + "_" + progressVer.ToString() + ".json");
            var exCount = 1;
            while (File.Exists(bkpProgressPath))
            {
                ++exCount;
                bkpProgressPath = Path.Combine(
                    QuizCore.BACKUP_FOLDER,
                    Path.GetFileNameWithoutExtension(QuizCore.PROGRESS_FILE_PATH) + "_" + progressVer.ToString() + "_" + exCount + ".json");
            }

            try
            {
                File.Copy(QuizCore.PROGRESS_FILE_PATH, bkpProgressPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the quiz progress, the conversion will not run:\r\n\r\n" + ex.ToString(),
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool BackupConfig(Version cfgVer)
        {
            var extStartIndex = ConfigManager.CONFIG_PATH.Length - ".json".Length;
            var bkpCfgPath = Path.Combine(
                QuizCore.BACKUP_FOLDER,
                Path.GetFileNameWithoutExtension(ConfigManager.CONFIG_PATH) + "_" + cfgVer.ToString() + ".json");
            var exCount = 1;
            while (File.Exists(bkpCfgPath))
            {
                ++exCount;
                bkpCfgPath = Path.Combine(
                    QuizCore.BACKUP_FOLDER,
                    Path.GetFileNameWithoutExtension(ConfigManager.CONFIG_PATH) + "_" + cfgVer.ToString() + "_" + exCount + ".json");
            }

            try
            {
                File.Copy(ConfigManager.CONFIG_PATH, bkpCfgPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the configuration file, the conversion will not run:\r\n\r\n" + ex.ToString(),
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}