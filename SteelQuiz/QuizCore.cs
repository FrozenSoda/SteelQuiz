using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;
using Newtonsoft.Json;

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

        public static bool QuizRandomized { get; set; } = false;
        public static List<WordProgData> originalWordProgDataCollection = null;

        public static void Load(string quizPath)
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
            Load(quiz);
        }

        public static void Load(Quiz quiz)
        {
            if (!Directory.Exists(APP_CFG_FOLDER))
            {
                Directory.CreateDirectory(APP_CFG_FOLDER);
            }
            if (!Directory.Exists(QUIZ_FOLDER))
            {
                Directory.CreateDirectory(QUIZ_FOLDER);
            }

            Quiz = quiz;
            LoadProgressData();
        }

        private static void LoadProgressData()
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

        public static void SaveQuiz(string filename)
        {
            using (var writer = new StreamWriter(Path.Combine(QUIZ_FOLDER, filename), false))
            {
                var quizDz = JsonConvert.SerializeObject(Quiz, Formatting.Indented);
                writer.Write(quizDz);
            }
        }

        public static void QuizRandomize(this IList<WordProgData> list)
        {
            originalWordProgDataCollection = list.Clone();
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