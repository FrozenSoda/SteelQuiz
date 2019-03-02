using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class Quiz
    {
        public Guid GUID { get; set; }
        public Version QuizFileFormatVersion { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public WordPair[] WordPairs { get; set; }

        public Quiz(string lang1, string lang2, Version quizFileFormatVersion)
        {
            GUID = Guid.NewGuid();
            Language1 = lang1;
            Language2 = lang2;
            QuizFileFormatVersion = quizFileFormatVersion;
        }
    }
}