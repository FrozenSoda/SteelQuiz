/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
using SteelQuiz.Util;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace SteelQuiz
{
    public static class QuizCore
    {
        public const string QUIZ_EXTENSION = "steelquiz";
        public static readonly string APP_CFG_DIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SteelQuiz");
        public static readonly string BACKUP_FOLDER = Path.Combine(APP_CFG_DIR, "Backups");
        public static readonly string QUIZ_FOLDER_DEFAULT = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SteelQuiz");
        public static readonly string QUIZ_RECOVERY_FOLDER = Path.Combine(QUIZ_FOLDER_DEFAULT, "Recovery");
        public static readonly string QUIZ_BACKUP_FOLDER = Path.Combine(QUIZ_FOLDER_DEFAULT, "Backups");
        public static readonly string PROGRESS_FILE_DEFAULT = Path.Combine(APP_CFG_DIR, "QuizProgress.json");

        public static Dictionary<Guid, QuizIdentity> QuizIdentities { get; set; } = new Dictionary<Guid, QuizIdentity>();
        public static Dictionary<Guid, DateTime> QuizAccessTimes { get; set; } = new Dictionary<Guid, DateTime>();

        /// <summary>
        /// Loads a quiz file from the specified path.
        /// </summary>
        /// <param name="path">The path to the quiz file.</param>
        /// <returns>Returns the quiz file, with its progress data and path.</returns>
        public static Quiz LoadQuiz(string path)
        {
            try
            {
                return InternalLoadQuiz(path);
            }
            catch (VersionNotSupportedException ex)
            {
                if (ex.Reason == VersionNotSupportedException.NotSupportedReason.AppVersionTooOld)
                {
                    var msg = MessageBox.Show("A newer version of SteelQuiz is required to load this quiz.\r\n\r\nUpdate now?", "Update Required - SteelQuiz",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (msg == DialogResult.Yes)
                    {
                        Updater.Update(Updater.UpdateMode.Force);
                    }
                }
                else
                {
                    MessageBox.Show("This quiz is designed for an older version of SteelQuiz and cannot be loaded", "Too Old Quiz - SteelQuiz",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        private class VersionNotSupportedException : Exception
        {
            public enum NotSupportedReason
            {
                AppVersionTooNew,
                AppVersionTooOld
            }

            public NotSupportedReason Reason { get; set; }

            public VersionNotSupportedException(NotSupportedReason reason)
            {
                Reason = reason;
            }

            public VersionNotSupportedException(NotSupportedReason reason, string message)
                : base(message)
            {
                Reason = reason;
            }

            public VersionNotSupportedException(NotSupportedReason reason, string message, Exception innerException)
                : base(message, innerException)
            {
                Reason = reason;
            }
        }

        private static Quiz InternalLoadQuiz(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Quiz file does not exist!");
            }

            string quizRaw = AtomicIO.AtomicRead(path);
            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(quizRaw);

            Version quizVersion;
            if (quiz.FileFormatVersion == null)
            {
                quizVersion = null;
            }
            else
            {
                quizVersion = new Version(quiz.FileFormatVersion);
            }

            quiz.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;

            if (quizVersion != null && quizVersion.CompareTo(MetaData.GetLatestQuizVersion()) > 0)
            {
                throw new VersionNotSupportedException(VersionNotSupportedException.NotSupportedReason.AppVersionTooOld);
            }

            quiz.QuizIdentity = new QuizIdentity(quiz.GUID, path);
            quiz.ProgressData = LoadQuizProgressData(quiz);

            if (quiz.ProgressData == null)
            {
                // Progress data for quiz does not exist - create new
                quiz.ProgressData = new QuizProgress(quiz);
            }

            QuizIdentities[quiz.GUID] = quiz.QuizIdentity;
            QuizAccessTimes[quiz.GUID] = DateTime.Now;

            SaveQuizAccessData();

            if (quizVersion.CompareTo(new Version(4, 0, 0, 1)) < 0)
            {
                SaveQuiz(quiz, path);
            }

            return quiz;
        }

        public static void SaveQuiz(Quiz quiz, string path)
        {
            string quizRaw = JsonConvert.SerializeObject(quiz, Formatting.Indented);
            AtomicIO.AtomicWrite(path, quizRaw);
        }

        /// <summary>
        /// Retrieves the quiz progress data object for the specified quiz.
        /// </summary>
        /// <param name="quiz">The quiz whose quiz progress data to load.</param>
        /// <returns>The QuizProgData object belonging to the quiz.</returns>
        private static QuizProgress LoadQuizProgressData(Quiz quiz)
        {
            string dataRaw = AtomicIO.AtomicRead(ConfigManager.Config.StorageConfig.QuizProgressFile);
            var dataRoot = JsonConvert.DeserializeObject<QuizProgressDataRoot>(dataRaw);

            var progress = dataRoot.QuizProgressData.Where(x => x.QuizGUID == quiz.GUID).FirstOrDefault();

            if (progress != null)
            {
                // Remove cards from CurrentCards that has been deleted from the quiz
                progress.CurrentCards = progress.CurrentCards.Where(x => quiz.Cards.Select(y => y.Guid).Contains(x)).ToList();

                // Remove progress from cards that have been removed from the quiz
                progress.CardProgress = progress.CardProgress.Where(x => quiz.Cards.Select(y => y.Guid).Contains(x.CardGuid)).ToList();

                // Issue #45 fix - "Learning Progress still 100 % after adding card to quiz without having answered it"
                foreach (var card in quiz.Cards)
                {
                    if (!progress.CardProgress.Select(x => x.CardGuid).Contains(card.Guid))
                    {
                        // CardProgress does not exist for card, create it
                        progress.CardProgress.Add(new CardProgress(card.Guid));
                    }
                }
            }

            return progress;
        }

        /// <summary>
        /// Saves the quiz progress data contained in the specified quiz.
        /// </summary>
        /// <param name="quiz">The Quiz object containing the progress data</param>
        public static void SaveQuizProgress(Quiz quiz)
        {
            string dataRaw = AtomicIO.AtomicRead(ConfigManager.Config.StorageConfig.QuizProgressFile);
            var dataRoot = JsonConvert.DeserializeObject<QuizProgressDataRoot>(dataRaw);

            if (dataRoot.FileFormatVersion == null || new Version(dataRoot.FileFormatVersion).CompareTo(MetaData.GetLatestQuizVersion()) < 0)
            {
                // Existing quiz file has an older file format - backup before upgrade
                BackupProgress();
            }

            dataRoot.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;

            var data = dataRoot.QuizProgressData.Where(x => x.QuizGUID == quiz.GUID).FirstOrDefault();

            if (data != null)
            {
                dataRoot.QuizProgressData[dataRoot.QuizProgressData.IndexOf(data)] = quiz.ProgressData;
            }
            else
            {
                dataRoot.QuizProgressData.Add(quiz.ProgressData);
            }

#if DEBUG
            dataRaw = JsonConvert.SerializeObject(dataRoot, Formatting.Indented);
#else
            dataRaw = JsonConvert.SerializeObject(dataRoot);
#endif
            AtomicIO.AtomicWrite(ConfigManager.Config.StorageConfig.QuizProgressFile, dataRaw);
        }

        /// <summary>
        /// Loads QuizAccessTimes and QuizIdentities from the progress data file.
        /// </summary>
        public static void LoadQuizAccessData()
        {
            if (!File.Exists(ConfigManager.Config.StorageConfig.QuizProgressFile))
            {
                return;
            }

            string dataRaw = AtomicIO.AtomicRead(ConfigManager.Config.StorageConfig.QuizProgressFile);
            var dataRoot = JsonConvert.DeserializeObject<QuizProgressDataRoot>(dataRaw);

            QuizAccessTimes = dataRoot.QuizAccessTimes;
            QuizIdentities = dataRoot.QuizIdentities;
        }

        /// <summary>
        /// Saves QuizAccessTimes and QuizIdentities to the progress data file.
        /// </summary>
        public static void SaveQuizAccessData()
        {
            Directory.CreateDirectory(APP_CFG_DIR);

            QuizProgressDataRoot dataRoot;
            string dataRaw;
            if (File.Exists(ConfigManager.Config.StorageConfig.QuizProgressFile))
            {
                dataRaw = AtomicIO.AtomicRead(ConfigManager.Config.StorageConfig.QuizProgressFile);
                dataRoot = JsonConvert.DeserializeObject<QuizProgressDataRoot>(dataRaw);

                if (dataRoot.FileFormatVersion == null || new Version(dataRoot.FileFormatVersion).CompareTo(MetaData.GetLatestQuizVersion()) < 0)
                {
                    // Existing quiz file has an older file format - backup before upgrade
                    BackupProgress();
                }

                dataRoot.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
            }
            else
            {
                dataRoot = new QuizProgressDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);
            }

            dataRoot.QuizAccessTimes = QuizAccessTimes;
            dataRoot.QuizIdentities = QuizIdentities;

#if DEBUG
            dataRaw = JsonConvert.SerializeObject(dataRoot, Formatting.Indented);
#else
            dataRaw = JsonConvert.SerializeObject(dataRoot);
#endif
            AtomicIO.AtomicWrite(ConfigManager.Config.StorageConfig.QuizProgressFile, dataRaw);
        }

        public static void QuizRandomize(Quiz quiz)
        {
            //quiz.QuizRandomized = true;

            var rnd = new Random();
            int n = quiz.ProgressData.CardProgress.Count;
            while (n > 1)
            {
                --n;
                int k = rnd.Next(n + 1);
                var value = quiz.ProgressData.CardProgress[k];
                quiz.ProgressData.CardProgress[k] = quiz.ProgressData.CardProgress[n];
                quiz.ProgressData.CardProgress[n] = value;
            }
        }

        public static void BackupProgress()
        {
            if (!File.Exists(ConfigManager.Config.StorageConfig.QuizProgressFile))
            {
                return;
            }

            string destDir = Path.Combine(Path.GetDirectoryName(ConfigManager.Config.StorageConfig.QuizProgressFile), "SteelQuiz Progress Backups");
            BackupHelper.BackupFile(ConfigManager.Config.StorageConfig.QuizProgressFile, destDir);
        }
    }
}