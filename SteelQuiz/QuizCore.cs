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
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace SteelQuiz
{
    public static class QuizCore
    {
        public const string QUIZ_EXTENSION = ".steelquiz";
        public static readonly string APP_CFG_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SteelQuiz");
        public static readonly string BACKUP_FOLDER = Path.Combine(APP_CFG_FOLDER, "Backups");
        public static readonly string QUIZ_FOLDER = Path.Combine(APP_CFG_FOLDER, "Quizzes");
        public static readonly string QUIZ_RECOVERY_FOLDER = Path.Combine(QUIZ_FOLDER, "Recovery");
        public static readonly string QUIZ_BACKUP_FOLDER = Path.Combine(QUIZ_FOLDER, "Backups");
        public static readonly string PROGRESS_FILE_PATH = Path.Combine(APP_CFG_FOLDER, "QuizProgress.json");

        public static Quiz Quiz { get; set; }
        public static QuizProgData QuizProgress { get; set; }
        public static string QuizPath { get; set; }

        public static bool QuizRandomized { get; set; } = false;
        public static List<WordProgData> originalWordProgDataCollection = null;

        public static bool Load(string quizPath)
        {
            if (!File.Exists(quizPath))
            {
                throw new FileNotFoundException("The quiz file cannot be found");
            }

            if (Path.GetDirectoryName(quizPath) != QUIZ_FOLDER)
            {
                var msg = MessageBox.Show($"Import quiz '{quizPath}'?", "SteelQuiz", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.OK)
                {
                    return ImportLocalQuiz(quizPath);
                }
                else
                {
                    return false;
                }
            }

            dynamic quiz;
            using (var reader = new StreamReader(quizPath))
            {
                quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
            }

            QuizPath = quizPath;

            var quizVer = SUtil.PropertyDefined(quiz.FileFormatVersion) && quiz.FileFormatVersion != null
                    ? new Version((string)quiz.FileFormatVersion) : new Version(1, 0, 0);
            var currVer = new Version(MetaData.QUIZ_FILE_FORMAT_VERSION);
            int cmp = currVer.CompareTo(quizVer);
            if (cmp > 0)
            {
                var msg = MessageBox.Show("The quiz must be converted to load it. A backup will be created automatically.\r\nConvert?",
                    "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                {
                    return false;
                }
            }
            else if (cmp < 0)
            {
                var msg = MessageBox.Show("SteelQuiz must be updated to load this quiz.\r\n\r\nUpdating will make sure you get the latest features, " +
                    "improvements and bug fixes.\r\n\r\nUpdate now? (recommended)",
                    "Update required - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    if (AutoUpdaterDotNET.AutoUpdater.DownloadUpdate())
                    {
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while updating", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return false;
            }

            return Load(quiz);
        }

        public static bool Load(Guid quizGuid)
        {
            Quiz quiz;

            foreach (var file in Directory.GetFiles(QUIZ_FOLDER).Where(x => x.EndsWith(QUIZ_EXTENSION)))
            {
                using (var reader = new StreamReader(file))
                {
                    quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
                }

                if (quiz != null && quiz.GUID == quizGuid)
                {
                    return Load(file);
                }
            }

            MessageBox.Show("The quiz file could not be found", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static bool ImportLocalQuiz(string quizPath)
        {
            // find quiz filename that does not exist
            string importedPath;
            int untitledCounter = 1;
            importedPath = Path.Combine(QuizCore.QUIZ_FOLDER, $"{Path.GetFileNameWithoutExtension(quizPath)}.steelquiz");
            while (File.Exists(importedPath))
            {
                ++untitledCounter;
                importedPath = Path.Combine(QuizCore.QUIZ_FOLDER,
                        $"{Path.GetFileNameWithoutExtension(quizPath)}_{ untitledCounter.ToString() }.steelquiz");
            }

            try
            {
                File.Copy(quizPath, importedPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while copying the quiz file:\r\n\r\n{ex.ToString()}", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show($"Success! The quiz has been imported to '{importedPath}'", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return Load(importedPath);
        }

        public static bool CheckInitDirectories()
        {
            try
            {
                Directory.CreateDirectory(APP_CFG_FOLDER);
                Directory.CreateDirectory(BACKUP_FOLDER);
                Directory.CreateDirectory(QUIZ_FOLDER);
                Directory.CreateDirectory(QUIZ_BACKUP_FOLDER);
                Directory.CreateDirectory(QUIZ_RECOVERY_FOLDER);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the application directories. The application will now shut down.\r\nError:\r\n\r\n" + ex.ToString(),
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }

            return true;
        }

        public static bool Load(Quiz quiz, string quizPath = null)
        {
            ResetTotalWordsThisRoundCountMemo();
            ResetWordsAskedThisRoundMemo();

            var dirInit = CheckInitDirectories();
            if (!dirInit)
            {
                return false;
            }

            Quiz = quiz;

            if (quizPath != null)
            {
                QuizPath = quizPath;
            }

            ConfigManager.Config.LastQuiz = quiz.GUID;
            ConfigManager.SaveConfig();

            if (new Version(MetaData.QUIZ_FILE_FORMAT_VERSION).CompareTo(new Version(Quiz.FileFormatVersion)) > 0)
            {
                Quiz.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
                SaveQuiz();
            }

            return LoadProgressData();
        }

        public enum ChkUpgradeProgressDataResult
        {
            UpgradedDowngraded,
            NotRequired,
            Fail
        }

        public static ChkUpgradeProgressDataResult ChkUpgradeProgressData()
        {
            dynamic cfgDz;
            using (var reader = new StreamReader(PROGRESS_FILE_PATH))
            {
                cfgDz = JsonConvert.DeserializeObject(reader.ReadToEnd());
            }
            var progressVer = SUtil.PropertyDefined(cfgDz.FileFormatVersion) && cfgDz.FileFormatVersion != null
                ? new Version((string)cfgDz.FileFormatVersion) : new Version(1, 0, 0);
            var currVer = new Version(MetaData.QUIZ_FILE_FORMAT_VERSION);
            int cmp = currVer.CompareTo(progressVer);
            if (cmp > 0)
            {
                var msg = MessageBox.Show("Due to major changes in the quiz progress format, your quiz progress data has to be reset to work with the new version." +
                        " The old format contained unfixable problems, and a conversion would have been too complex and buggy.\r\n\r\nA backup will automatically" +
                        " be created in case you wish to revert to an older version later.\r\n\r\nReset progress data?", "SteelQuiz", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (msg == DialogResult.No)
                {
                    return ChkUpgradeProgressDataResult.Fail;
                }

                var bkp = BackupProgress(progressVer);
                if (!bkp)
                {
                    return ChkUpgradeProgressDataResult.Fail;
                }

                File.Delete(PROGRESS_FILE_PATH);

                return ChkUpgradeProgressDataResult.UpgradedDowngraded;
            }
            else if (cmp < 0)
            {
                var msg = MessageBox.Show("Your progress data file is made for a newer version of SteelQuiz. Revert progress data from backup?",
                    "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (msg == DialogResult.No)
                {
                    return ChkUpgradeProgressDataResult.Fail;
                }

                bool bkp = BackupProgress(progressVer);
                if (!bkp)
                {
                    return ChkUpgradeProgressDataResult.Fail;
                }

                // find backup
                int latestBackupNum = -1;
                string latestBackup = null;
                foreach (var file in Directory.GetFiles(BACKUP_FOLDER).Where(x => Path.GetFileName(x).StartsWith("QuizProgress")
                    && x.Contains(MetaData.QUIZ_FILE_FORMAT_VERSION)))
                {
                    string bkpNumStr = Path.GetFileNameWithoutExtension(file).Split('_').Last();
                    int bkpNum;
                    if (int.TryParse(bkpNumStr, out bkpNum))
                    {
                        if (bkpNum > latestBackupNum)
                        {
                            latestBackupNum = bkpNum;
                            latestBackup = file;
                        }
                    }
                    else
                    {
                        // the first backup does not have a number (xxxxxxx_2.0.0_num)
                        latestBackupNum = 1;
                        latestBackup = file;
                    }
                }

                if (latestBackup != null)
                {
                    File.Delete(PROGRESS_FILE_PATH);
                    File.Copy(latestBackup, PROGRESS_FILE_PATH);
                }
                else
                {
                    var msg2 = MessageBox.Show("A backup could not be found. Try looking for them yourselves in %appdata%\\SteelQuiz\\Backups. " +
                        "Start over with a new progress data?",
                        "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (msg2 == DialogResult.No)
                    {
                        return ChkUpgradeProgressDataResult.Fail;
                    }

                    File.Delete(PROGRESS_FILE_PATH);
                }
                return ChkUpgradeProgressDataResult.UpgradedDowngraded;
            }
            else
            {
                return ChkUpgradeProgressDataResult.NotRequired;
            }
        }

        private static bool LoadProgressData()
        {
            if (File.Exists(PROGRESS_FILE_PATH))
            {
                var upg = ChkUpgradeProgressData();
                if (upg == ChkUpgradeProgressDataResult.UpgradedDowngraded)
                {
                    return LoadProgressData();
                }
                else if (upg == ChkUpgradeProgressDataResult.Fail)
                {
                    return false;
                }
                QuizProgDataRoot quizProgDataRoot;
                using (var reader = new StreamReader(PROGRESS_FILE_PATH))
                {
                    quizProgDataRoot = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
                }

                //find progress for current quiz
                bool found = false;
                foreach (QuizProgData progData in quizProgDataRoot.QuizProgDatas)
                {
                    if (progData.QuizGUID.Equals(Quiz.GUID))
                    {
                        QuizProgress = progData;
                        QuizProgress.MasterNoticeShowed = false;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    QuizProgress = new QuizProgData(Quiz);
                    SaveQuizProgress();
                }
            }
            else
            {
                QuizProgress = new QuizProgData(Quiz);
                SaveQuizProgress();
            }

            return FixQuizProgressData();
        }

        /*
         * Updates changes to word pairs in quiz progress data, and removes progress data from word pairs that were removed from the quiz
         */ 
        public static bool FixQuizProgressData()
        {
            // REMOVE WORD PAIRS FROM PROGRESS DATA THAT WERE REMOVED FROM THE QUIZ
            var findCurrent = FindWordPairInQuiz(QuizProgress.CurrentWordPair);
            QuizProgress.CurrentWordPair = findCurrent;

            var toRemove = new List<WordProgData>();
            foreach (var wordProgData in QuizProgress.WordProgDatas)
            {
                var find = FindWordPairInQuiz(wordProgData.WordPair);
                if (find == null)
                {
                    toRemove.Add(wordProgData);
                }
                else
                {
                    wordProgData.WordPair = find;
                }
            }

            foreach (var rm in toRemove)
            {
                QuizProgress.WordProgDatas.Remove(rm);
            }

            // ADD WORD PAIRS TO PROGRESS DATA THAT WERE ADDED TO THE QUIZ
            foreach (var wordPair in Quiz.WordPairs)
            {
                if (!WordPairExistsInProgressData(wordPair))
                {
                    QuizProgress.WordProgDatas.Add(new WordProgData(wordPair));
                }
            }

            SaveQuizProgress();

            return true;
        }

        private static WordPair FindWordPairInQuiz(WordPair _wordPair)
        {
            foreach (var wordPair in Quiz.WordPairs)
            {
                if (wordPair.Equals(_wordPair, true, true))
                {
                    return wordPair;
                }
            }

            return null;
        }

        private static bool WordPairExistsInProgressData(WordPair _wordPair)
        {
            foreach (var wordProgData in QuizProgress.WordProgDatas)
            {
                if (wordProgData.WordPair.Equals(_wordPair, true, true))
                {
                    return true;
                }
            }

            return false;
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
                MessageBox.Show("An error occurred while backing up the quiz progress:\r\n\r\n" + ex.ToString(),
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

        public static void SaveQuizProgress()
        {
            /*
            List<WordProgData> bkpOfCurrent = null;
            if (QuizRandomized)
            {
                RevertWordProgDataCollection(out bkpOfCurrent);
            }
            */

            // DESERIALIZE AND PROCESS
            QuizProgDataRoot cfgDz;
            if (File.Exists(PROGRESS_FILE_PATH))
            {
                using (var reader = new StreamReader(PROGRESS_FILE_PATH))
                {
                    cfgDz = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
                }

                //find progress for current quiz
                bool found = false;
                for (int i = 0; i < cfgDz.QuizProgDatas.Count; ++i)
                {
                    if (cfgDz.QuizProgDatas[i].QuizGUID.Equals(Quiz.GUID))
                    {
                        cfgDz.QuizProgDatas[i] = QuizProgress;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    cfgDz.QuizProgDatas.Add(QuizProgress);
                }
            }
            else
            {
                cfgDz = new QuizProgDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);
                cfgDz.QuizProgDatas.Add(QuizProgress);
            }

            // SERIALIZE AND SAVE
            var cfgSz = JsonConvert.SerializeObject(cfgDz, Formatting.Indented);
            using (var writer = new StreamWriter(PROGRESS_FILE_PATH, false))
            {
                writer.Write(cfgSz);
            }

            /*
            if (QuizRandomized)
            {
                QuizProgress.WordProgDatas = bkpOfCurrent.Clone();
            }
            */
        }

        public static void SaveQuiz()
        {
            SaveQuiz(Quiz, QuizPath);
        }

        public static void SaveQuiz(Quiz quiz, string path)
        {
            using (var writer = new StreamWriter(path, false))
            {
                var quizDz = JsonConvert.SerializeObject(quiz, Formatting.Indented);
                writer.Write(quizDz);
            }
        }

        public static void QuizRandomize(this IList<WordProgData> list)
        {
            //originalWordProgDataCollection = list.Clone();
            QuizRandomized = true;

            var rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                --n;
                int k = rnd.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static void RevertWordProgDataCollection(out List<WordProgData> bkpOfCurrent)
        {
            bkpOfCurrent = QuizProgress.WordProgDatas.Clone().ToList();
            QuizProgress.WordProgDatas = originalWordProgDataCollection.Clone().ToList();
        }

        private static int totalWordsThisRoundMemo = -1;
        public static int GetTotalWordsThisRound()
        {
            if (totalWordsThisRoundMemo != -1)
            {
                return totalWordsThisRoundMemo;
            }

            var counter = 0;
            foreach (var word in QuizProgress.WordProgDatas)
            {
                if (!word.SkipThisRound)
                {
                    ++counter;
                }
            }

            totalWordsThisRoundMemo = counter;
            return counter;
        }

        private static int wordsAskedThisRoundMemo = -1;
        public static int GetWordsAskedThisRound()
        {
            if (wordsAskedThisRoundMemo != -1)
            {
                return wordsAskedThisRoundMemo;
            }

            var counter = 0;
            foreach (var word in QuizProgress.WordProgDatas)
            {
                if (word.AskedThisRound)
                {
                    ++counter;
                }
            }

            wordsAskedThisRoundMemo = counter;
            return counter;
        }

        public static void ResetTotalWordsThisRoundCountMemo()
        {
            totalWordsThisRoundMemo = -1;
        }

        public static void ResetWordsAskedThisRoundMemo()
        {
            wordsAskedThisRoundMemo = -1;
        }
    }
}