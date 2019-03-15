using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;

namespace SteelQuiz
{
    public static class QuizCompatibilityConverter
    {
        public static void UpgradeQuiz()
        {
            var fromVer = new Version(QuizCore.Quiz.QuizFileFormatVersion);

            var V2 = new Version(1, 1, 0); // changed wordpair synonyms default value from null to new List<string>()

            if (V2.CompareTo(fromVer) > 0)
            {
                // initialize synonyms (ver x --> 1.0.1)
                // synonyms in v1.0.0 were string arrays initialized to null
                // should now be string lists initialized to new List<string>()

                foreach (var wp in QuizCore.Quiz.WordPairs)
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
            }

            QuizCore.Quiz.QuizFileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
            QuizCore.SaveQuiz();
        }
    }
}