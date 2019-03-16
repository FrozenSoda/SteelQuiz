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
                            //wordPairs.Add(new WordPair(word1, word2, WordPair.Rules.IgnoreCapitalization | WordPair.Rules.IgnoreExclamation));
                            wordPairs.ChkAddWordPair(word1, word2, StringComp.Rules.IgnoreCapitalization | StringComp.Rules.IgnoreExclamation);
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

            if (wordPairs.Count == 1 && wordPairs[0].Word2 == "points")
            {
                MessageBox.Show("This exercise cannot be imported to SteelQuiz. Only spelling exercises can be imported from Studentlitteratur",
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var quiz = new Quiz(lang1, lang2, MetaData.QUIZ_FILE_FORMAT_VERSION);
            quiz.WordPairs = wordPairs.ToArray();
            
            if (filename == "")
            {
                filename = QuizCore.Quiz.GUID.ToString();
            }
            QuizCore.Load(quiz, Path.Combine(QuizCore.QUIZ_FOLDER, filename + QuizCore.QUIZ_EXTENSION));
            QuizCore.SaveQuiz();

            return true;
        }

        private static void ChkAddWordPair(this IList<WordPair> wpList, string word1, string word2, StringComp.Rules rules)
        {
            foreach (var wp in wpList)
            {
                if (word1 == wp.Word1)
                {
                    if (word2 == wp.Word2)
                    {
                        return;
                    }
                    else
                    {
                        wp.Word2Synonyms.Add(word2);
                        return;
                    }
                }
                else if (word2 == wp.Word2)
                {
                    wp.Word1Synonyms.Add(word1);
                    return;
                }
            }

            var wordPair = new WordPair(word1, word2, rules);
            wpList.Add(wordPair);
        }

        private static string FixString(string str)
        {
            return str
                .Replace(@"\u00e5", "å")
                .Replace(@"\u00e4", "ä")
                .Replace(@"\u00f6", "ö")
                .Replace(@"\u00e9", "é");
        }
    }
}
