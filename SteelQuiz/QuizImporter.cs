using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizData;

namespace SteelQuiz
{
    public static class QuizImporter
    {
        public static bool FromStudentlitteratur(string url, string lang1, string lang2, string filename)
        {
            var wclient = new WebClient();
            string quizEncoded;
            try
            {
                quizEncoded = wclient.DownloadString(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while downloading the quiz:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var foundStr = "";
            var inString = false;

            var inWord1 = false;
            var inWord2 = false;
            var word1 = "";
            var word2 = "";

            var wordPairs = new List<WordPair>();

            for (int i = 0; i < quizEncoded.Length; ++i)
            {
                var ch = quizEncoded[i];
                if (ch == '"')
                {
                    inString = !inString;
                    if (!inString)
                    {
                        //process found string
                        if (inWord1)
                        {
                            word1 = FixString(foundStr);
                            inWord1 = false;
                        }
                        else if (inWord2)
                        {
                            word2 = FixString(foundStr);
                            wordPairs.Add(new WordPair(word1, word2, WordPair.Rules.IgnoreCapitalization | WordPair.Rules.IgnoreExclamation));
                            word1 = "";
                            word2 = "";
                            inWord2 = false;
                        }
                        else
                        {
                            if (foundStr == "text")
                            {
                                inWord1 = true;
                            }
                            else if (foundStr == "correct")
                            {
                                inWord2 = true;
                            }
                        }

                        foundStr = "";
                    }
                }
                else if (inString)
                {
                    foundStr += ch;
                }
            }

            if (wordPairs.Count == 0)
            {
                MessageBox.Show("No quiz could be found in the quiz url specified. Make sure you selected the correct quiz source, and entered the URL correctly",
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var quiz = new Quiz(lang1, lang2, MetaData.QUIZ_FILE_FORMAT_VERSION);
            quiz.WordPairs = wordPairs.ToArray();
            QuizEngine.Load(quiz);
            
            if (filename == "")
            {
                filename = QuizEngine.Quiz.GUID.ToString();
            }
            QuizEngine.SaveQuiz(filename + ".json");

            return true;
        }

        public static string FixString(string str)
        {
            return str
                .Replace(@"\u00e5", "å")
                .Replace(@"\u00e4", "ä")
                .Replace(@"\u00f6", "ö");
        }
    }
}
