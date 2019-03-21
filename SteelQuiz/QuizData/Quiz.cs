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
        public string FileFormatVersion { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public WordPair[] WordPairs { get; set; }

        public Quiz(string lang1, string lang2, string quizFileFormatVersion, Guid? guid = null)
        {
            if (guid == null)
            {
                GUID = Guid.NewGuid();
            }
            else
            {
                GUID = (Guid)guid;
            }
            Language1 = lang1;
            Language2 = lang2;
            FileFormatVersion = quizFileFormatVersion;
        }
    }
}