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

            var quizConverted = QuizCompatibilityConverter.ChkUpgradeQuiz(quiz, QuizPath);
            if (quizConverted != null)
            {
                //return Load(quiz);
                return Load(quizConverted);
            }
            else
            {
                return false;
            }
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

            //SaveQuiz();

            return LoadProgressData();
        }

        private static bool LoadProgressData()
        {
            dynamic cfgDz;

            if (File.Exists(PROGRESS_FILE_PATH))
            {
                using (var reader = new StreamReader(PROGRESS_FILE_PATH))
                {
                    cfgDz = JsonConvert.DeserializeObject(reader.ReadToEnd());
                }
                var progressVer = SUtil.PropertyDefined(cfgDz.FileFormatVersion) && cfgDz.FileFormatVersion != null
                    ? new Version((string)cfgDz.FileFormatVersion) : new Version(1, 0, 0);
                var currVer = new Version(MetaData.QUIZ_FILE_FORMAT_VERSION);
                if (currVer.CompareTo(progressVer) > 0)
                {
                    //conversion required

                    /*
                    var msg = MessageBox.Show("The progress data files for SteelQuiz on the computer was made for an older version of SteelQuiz and must be converted to "
                        + "the current format to load it. A backup will be created automatically, meaning that you won't lose anything when converting.\r\n\r\n"
                        + "Warning! Every quiz in the quiz folder will be upgraded as well, as it is required for the conversion.\r\nTo use older version of SteelQuiz, you must revert the files in %appdata%\\SteelQuiz to the corresponding backups, which are "
                        + "created automatically in %appdata%\\SteelQuiz\\Backups"
                        + "\r\n\r\nProceed with conversion?", "Quiz conversion required - SteelQuiz",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        */
                    var msg = MessageBox.Show("Config conversion, progress data conversion & conversion of all quizzes required due to updated file formats. " +
                        "Backups will be created automatically. Convert now?",
                        "Quiz conversion required - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msg == DialogResult.No)
                    {
                        return false;
                    }

                    var bkp = QuizCompatibilityConverter.BackupProgress(progressVer);
                    if (!bkp)
                    {
                        return false;
                    }

                    
                }

                /*
                CfgQuizzesProgressData cfgDz;
                using (var reader = new StreamReader(PROGRESS_FILE_PATH))
                {
                    cfgDz = JsonConvert.DeserializeObject<CfgQuizzesProgressData>(reader.ReadToEnd());
                }
                cfgDz.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
                */

                cfgDz = QuizCompatibilityConverter.ChkUpgradeProgressData(cfgDz);
                if (cfgDz == null)
                {
                    MessageBox.Show("Quiz progress conversion error", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();
                    return false;
                }

                //find progress for current quiz
                bool found = false;
                foreach (dynamic progData in cfgDz.QuizProgDatas)
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
                cfgDz = new QuizProgDataRoot();
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
            bkpOfCurrent = QuizProgress.WordProgDatas.Clone();
            QuizProgress.WordProgDatas = originalWordProgDataCollection.Clone();
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

        public static void ResetTotalWordCountMemo()
        {
            totalWordsThisRoundMemo = -1;
        }

        public static void ResetWordsAskedMemo()
        {
            wordsAskedThisRoundMemo = -1;
        }
    }
}