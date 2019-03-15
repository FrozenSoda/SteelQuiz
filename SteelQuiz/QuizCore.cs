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
        public static readonly string QUIZ_FOLDER = Path.Combine(APP_CFG_FOLDER, "Quizzes");
        public static readonly string PROGRESS_CFG_PATH = Path.Combine(APP_CFG_FOLDER, "QuizProgress.json");

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

            Quiz quiz;
            using (var reader = new StreamReader(quizPath))
            {
                quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
            }
            QuizPath = quizPath;
            return Load(quiz);
        }

        public static void CheckInitDirectories()
        {
            if (!Directory.Exists(APP_CFG_FOLDER))
            {
                Directory.CreateDirectory(APP_CFG_FOLDER);
            }
            if (!Directory.Exists(QUIZ_FOLDER))
            {
                Directory.CreateDirectory(QUIZ_FOLDER);
            }
        }

        public static bool Load(Quiz quiz, string quizPath = null)
        {
            CheckInitDirectories();

            Quiz = quiz;

            if (quizPath != null)
            {
                QuizPath = quizPath;
            }

            var quizVer = new Version(Quiz.QuizFileFormatVersion);
            var currVer = new Version(MetaData.QUIZ_FILE_FORMAT_VERSION);

            if (currVer.CompareTo(quizVer) > 0)
            {
                //conversion required

                var msg = MessageBox.Show("The quiz file you have selected was made for an older version of SteelQuiz and must be converted to "
                    + "the current format to load it. A backup will be created automatically, meaning that you won't lose anything when converting.\r\n\r\n"
                    + "Warning! The quiz will probably be incompatible with older versions of SteelQuiz after the conversion. To use the quiz with "
                    + "older versions of SteelQuiz after the conversion, you must use the backup quiz, which is created automatically."
                    + "\r\n\r\nProceed with conversion?", "Quiz conversion required - SteelQuiz",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                {
                    return false;
                }

                var bkp = BackupQuiz(quizVer);
                if (!bkp)
                {
                    return false;
                }

                QuizCompatibilityConverter.UpgradeQuiz();
            }

            return LoadProgressData();
        }

        private static bool BackupQuiz(Version quizVer)
        {
            var extStartIndex = QuizPath.Length - QUIZ_EXTENSION.Length;
            var newQuizFileName = QuizPath.Insert(extStartIndex, "_" + quizVer.ToString());
            var exCount = 1;
            while (File.Exists(newQuizFileName)) {
                ++exCount;
                newQuizFileName = QuizPath.Insert(extStartIndex, "_" + quizVer.ToString() + "_" + exCount);
            }

            try
            {
                File.Copy(QuizPath, newQuizFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the quiz, the conversion will not run:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private static bool LoadProgressData()
        {
            CfgQuizzesProgressData cfgDz;

            if (File.Exists(PROGRESS_CFG_PATH))
            {
                using (var reader = new StreamReader(PROGRESS_CFG_PATH))
                {
                    cfgDz = JsonConvert.DeserializeObject<CfgQuizzesProgressData>(reader.ReadToEnd());
                }

                //find progress for current quiz
                bool found = false;
                foreach (QuizProgData progData in cfgDz.QuizProgDatas)
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
                    SaveProgress();
                }
            }
            else
            {
                QuizProgress = new QuizProgData(Quiz);
                SaveProgress();
            }

            return true;
        }

        public static void SaveProgress()
        {
            /*
            List<WordProgData> bkpOfCurrent = null;
            if (QuizRandomized)
            {
                RevertWordProgDataCollection(out bkpOfCurrent);
            }
            */

            // DESERIALIZE AND PROCESS
            CfgQuizzesProgressData cfgDz;
            if (File.Exists(PROGRESS_CFG_PATH))
            {
                using (var reader = new StreamReader(PROGRESS_CFG_PATH))
                {
                    cfgDz = JsonConvert.DeserializeObject<CfgQuizzesProgressData>(reader.ReadToEnd());
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
                cfgDz = new CfgQuizzesProgressData();
                cfgDz.QuizProgDatas.Add(QuizProgress);
            }

            // SERIALIZE AND SAVE
            var cfgSz = JsonConvert.SerializeObject(cfgDz, Formatting.Indented);
            using (var writer = new StreamWriter(PROGRESS_CFG_PATH, false))
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
            using (var writer = new StreamWriter(QuizPath, false))
            {
                var quizDz = JsonConvert.SerializeObject(Quiz, Formatting.Indented);
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

        public static int GetTotalWordsThisRound()
        {
            var counter = 0;
            foreach (var word in QuizProgress.WordProgDatas)
            {
                if (!word.SkipThisRound)
                {
                    ++counter;
                }
            }

            return counter;
        }

        public static int GetWordsAskedThisRound()
        {
            var counter = 0;
            foreach (var word in QuizProgress.WordProgDatas)
            {
                if (word.AskedThisRound)
                {
                    ++counter;
                }
            }

            return counter;
        }
    }
}