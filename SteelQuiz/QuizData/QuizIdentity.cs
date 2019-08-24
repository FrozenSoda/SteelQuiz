using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    /// <summary>
    /// Contains identification data for a quiz, so that it can be found quickly, and even when it's moved.
    /// </summary>
    public class QuizIdentity
    {
        [JsonProperty]
        /// <summary>
        /// The GUID of the quiz. This will not change if the quiz is moved.
        /// </summary>
        public Guid QuizGuid { get; private set; }

        [JsonProperty]
        /// <summary>
        /// The last known path to the quiz. If the quiz at this path doesn't match QuizGuid, this property will be ignored.
        /// </summary>
        private string QuizPath { get; set; }

        public QuizIdentity(Guid quizGuid, string quizPath)
        {
            QuizGuid = quizGuid;
            QuizPath = quizPath;
        }

        /// <summary>
        /// Finds the quiz path, even when the quiz has been moved to a different location in a quiz folder.
        /// </summary>
        /// <returns>Returns the path of the quiz. Returns null if it can't be found.</returns>
        public string FindQuizPath()
        {
            if (File.Exists(QuizPath))
            {
                Quiz quiz = JsonConvert.DeserializeObject<Quiz>(AtomicIO.AtomicRead(QuizPath));
                if (quiz.GUID == QuizGuid)
                {
                    // QuizPath is correct
                    return QuizPath;
                }
            }

            // QuizPath is incorrect
            var path = QuizCore.FindQuizPath(QuizGuid);
            QuizPath = path;
            return path;
        }
    }
}
