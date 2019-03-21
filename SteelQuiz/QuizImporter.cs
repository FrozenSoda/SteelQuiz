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

            WordPair[] wordPairs = null;

            if (quizEncoded.Contains("_____"))
            {
                wordPairs = FromStudentlitteratur_VocabularyBank(quizEncoded);
            }
            else
            {
                wordPairs = FromStudentlitteratur_Wordmatch(quizEncoded);
            }
            

            if (wordPairs.Length == 0)
            {
                MessageBox.Show("No quiz could be found in the quiz url specified. Make sure you selected the correct quiz source, and entered the URL correctly",
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (wordPairs.Length == 1)
            {
                var msg = MessageBox.Show("SteelQuiz might not be able to import this particular quiz correctly. It might contain errors.\r\n\r\nTry anyway?",
                    "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                if (msg == DialogResult.No)
                {
                    return false;
                }
            }

            var quiz = new Quiz(lang1, lang2, MetaData.QUIZ_FILE_FORMAT_VERSION);
            quiz.WordPairs = wordPairs;
            
            if (filename == "")
            {
                //filename = QuizCore.Quiz.GUID.ToString();
                filename = quiz.GUID.ToString();
            }
            var path = Path.Combine(QuizCore.QUIZ_FOLDER, filename + QuizCore.QUIZ_EXTENSION);
            QuizCore.Load(quiz, path);
            QuizCore.SaveQuiz();

            return true;
        }

        [Flags]
        private enum InString
        {
            DoubleQuote = 2 << 3,
            SingleQuote = 2 << 2,
            Colon = 2 << 1,
            None = 2 << 0
        }

        private static Dictionary<char, InString> InStringForChars = new Dictionary<char, InString>()
        {
            { '"', InString.DoubleQuote },
            { '\'', InString.SingleQuote },
            { ':', InString.Colon }
        };

        private static WordPair[] FromStudentlitteratur_VocabularyBank(string quizEncoded)
        {
            var foundStr = "";
            var inString = InString.None;

            var inQuiz = false;
            var inWordChk = false;
            var word1 = "";
            var word2 = "";
            var inWord = false;

            var wordPairs = new List<WordPair>();

            for (int i = 0; i < quizEncoded.Length; ++i)
            {
                var ch = quizEncoded[i];
                if (ch == '"' || (!inString.HasFlag(InString.DoubleQuote) && (ch == ':' || ch == ',')))
                {
                    if (ch == ',')
                    {
                        if (ch == ',')
                        {
                            inString &= ~InString.Colon;
                        }
                    }
                    else
                    {
                        if (inString.HasFlag(InStringForChars[ch]))
                        {
                            inString &= ~InStringForChars[ch];
                            if (ch == '"')
                            {
                                inString &= ~InString.Colon;
                            }
                        }
                        else
                        {
                            inString |= InStringForChars[ch];
                            if (ch == '"')
                            {
                                foundStr = foundStr.Replace("{", "").Replace("[", "");
                            }
                        }
                    }

                    if (inString == InString.None)
                    {
                        if (inWordChk)
                        {
                            if (foundStr == "true")
                            {
                                wordPairs.ChkAddWordPair(word1, word2, StringComp.Rules.IgnoreCapitalization | StringComp.Rules.IgnoreExclamation);
                                word2 = "";
                            }
                            inWordChk = false;
                        }
                        else if (inWord)
                        {
                            if (foundStr.Contains("_____") && foundStr.Contains("(<i>"))
                            {
                                word1 = FixString(foundStr.Split(new string[] { "(<i>" }, StringSplitOptions.None)[1]
                                        .Split(new string[] { @"<\/i>)" }, StringSplitOptions.None)[0]);
                            }
                            else
                            {
                                word2 = FixString(foundStr);
                            }
                            inWord = false;
                        }
                        else
                        {
                            if (foundStr == "parts")
                            {
                                inQuiz = true;
                            }
                            else if (inQuiz)
                            {
                                if (foundStr == "text")
                                {
                                    inWord = true;
                                }
                                else if (foundStr == "correct")
                                {
                                    inWordChk = true;
                                }
                            }
                        }

                        foundStr = "";
                    }
                }
                else if (inString != InString.None)
                {
                    foundStr += ch;
                }
            }

            return wordPairs.ToArray();
        }

        private static WordPair[] FromStudentlitteratur_Wordmatch(string quizEncoded)
        {
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

            return wordPairs.ToArray();
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
