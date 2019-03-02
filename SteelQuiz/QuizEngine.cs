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
    public static class QuizEngine
    {
        public static readonly string APP_CFG_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SteelQuiz");
        public static readonly string QUIZ_FOLDER = Path.Combine(APP_CFG_FOLDER, "Quizzes");
        public static readonly string PROGRESS_CFG_PATH = Path.Combine(APP_CFG_FOLDER, "QuizProgress.json");

        public static Quiz Quiz { get; set; }
        public static QuizProgData QuizProgress { get; set; }

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
                foreach (QuizProgData progData in cfgDz.QuizStates)
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
                    QuizProgress = new QuizProgData();
                    QuizProgress.QuizGUID = Quiz.GUID;
                }
            }
            else
            {
                QuizProgress = new QuizProgData();
                QuizProgress.QuizGUID = Quiz.GUID;
            }

            SaveProgress();
        }

        public static void SaveProgress()
        {
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
                for (int i = 0; i < cfgDz.QuizStates.Count; ++i)
                {
                    if (cfgDz.QuizStates[i].QuizGUID.Equals(Quiz.GUID))
                    {
                        cfgDz.QuizStates[i] = QuizProgress;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    cfgDz.QuizStates.Add(QuizProgress);
                }
            }
            else
            {
                cfgDz = new CfgQuizzesProgressData();
                cfgDz.QuizStates.Add(QuizProgress);
            }

            // SERIALIZE AND SAVE
            var cfgSz = JsonConvert.SerializeObject(cfgDz, Formatting.Indented);
            using (var writer = new StreamWriter(PROGRESS_CFG_PATH, false))
            {
                writer.Write(cfgSz);
            }
        }

        public static void SaveQuiz(string filename)
        {
            using (var writer = new StreamWriter(Path.Combine(QUIZ_FOLDER, filename), false))
            {
                var quizDz = JsonConvert.SerializeObject(Quiz, Formatting.Indented);
                writer.Write(quizDz);
            }
        }
    }
}