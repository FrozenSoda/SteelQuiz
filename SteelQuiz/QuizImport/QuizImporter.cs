/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

namespace SteelQuiz.QuizImport
{
    public static class QuizImporter
    {
        public enum ImportSource
        {
            Studentlitteratur
        }

        public static IEnumerable<WordPair> FromStudentlitteratur(string url, bool multipleTranslationsAsDifferentWordPairs)
        {
            string quizEncoded;
            using (var wclient = new WebClient())
            {
                try
                {
                    quizEncoded = wclient.DownloadString(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while downloading the quiz:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
            }

            List<WordPair> wordPairs = null;

            if (quizEncoded.Contains("_____"))
            {
                wordPairs = FromStudentlitteratur_VocabularyBank(quizEncoded, multipleTranslationsAsDifferentWordPairs).ToList();
            }
            else
            {
                wordPairs = FromStudentlitteratur_Spelling(quizEncoded, multipleTranslationsAsDifferentWordPairs).ToList();
            }
            

            if (wordPairs.Count == 0)
            {
                MessageBox.Show("No quiz could be found in the quiz url specified. Make sure you selected the correct quiz source, and entered the URL correctly",
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (wordPairs.Count == 1)
            {
                var msg = MessageBox.Show("SteelQuiz might not be able to import this particular quiz correctly. It looks like the import failed.\r\n\r\nTry anyway?",
                    "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                {
                    return null;
                }
            }

            return wordPairs;

            /*
            var langSelector = new QuizLanguageSelector(wordPairs);
            if (langSelector.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            var quiz = new Quiz(langSelector.Language1, langSelector.Language2, MetaData.QUIZ_FILE_FORMAT_VERSION);
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
            */
        }

        [Flags]
        private enum InString
        {
            DoubleQuote = 1 << 3,
            SingleQuote = 1 << 2,
            Colon = 1 << 1,
            None = 1 << 0
        }

        private static Dictionary<char, InString> InStringForChars = new Dictionary<char, InString>()
        {
            { '"', InString.DoubleQuote },
            { '\'', InString.SingleQuote },
            { ':', InString.Colon }
        };

        private static IEnumerable<WordPair> FromStudentlitteratur_VocabularyBank(string quizEncoded, bool multipleTranslationsAsDifferentWordPairs)
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
                        inString &= ~InString.Colon;
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
                                wordPairs.ChkAddWordPair(word1, word2,
                                    StringComp.Rules.None, multipleTranslationsAsDifferentWordPairs);
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

            return wordPairs;
        }

        private static IEnumerable<WordPair> FromStudentlitteratur_Spelling(string quizEncoded, bool multipleTranslationsAsDifferentWordPairs)
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
                            wordPairs.ChkAddWordPair(word1, word2,
                                StringComp.Rules.None, multipleTranslationsAsDifferentWordPairs);
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

            return wordPairs;
        }

        private static void ChkAddWordPair(this IList<WordPair> wpList, string word1, string word2, StringComp.Rules rules, bool multipleTranslationsAsDifferentWordPairs)
        {
            foreach (var wp in wpList)
            {
                if (word1 == wp.Word1)
                {
                    if (word2 == wp.Word2)
                    {
                        return;
                    }
                    else if (!multipleTranslationsAsDifferentWordPairs)
                    {
                        wp.Word2Synonyms.Add(word2);
                        return;
                    }
                }
                else if (word2 == wp.Word2 && !multipleTranslationsAsDifferentWordPairs)
                {
                    wp.Word1Synonyms.Add(word1);
                    return;
                }
            }

            var wordPair = new WordPair(QuizDataUtil.GenerateID(wpList), word1, word2, rules);
            wpList.Add(wordPair);
        }

        /*
         * Convert string with encoded unicode characters (for instance \u00f6), also remove unnecessary escape signs (in C#), to construct a readable string
         */
        private static string FixString(string str)
        {
            const int UNICODE_LENGTH = 6; // \uFFFF

            var foundUnicodeChars = new List<string>();
            var foundString = "";
            var inBackslash = false;
            var inUnicodeChar = false;

            for (int i = 0; i < str.Length; ++i)
            {
                var ch = str[i];

                if (ch == '\\')
                {
                    inBackslash = !inBackslash;
                    if (inUnicodeChar)
                    {
                        foundUnicodeChars.Add(foundString);
                        inUnicodeChar = false;
                    }
                    foundString = "";
                }
                else if (inBackslash && ch == 'u')
                {
                    inUnicodeChar = true;
                    inBackslash = false;
                    foundString += "\\u";
                }
                else if (inUnicodeChar && foundString.Length < UNICODE_LENGTH)
                {
                    foundString += ch;
                }
                else
                {
                    inBackslash = false;
                    if (foundString.Length == UNICODE_LENGTH)
                    {
                        foundUnicodeChars.Add(foundString);
                        foundString = "";
                        inUnicodeChar = false;
                    }
                }
            }

            // if the unicode character was the last character in the string, add it, as it won't be added in the for loop
            if (foundString.Length == UNICODE_LENGTH)
            {
                foundUnicodeChars.Add(foundString);
            }

            foreach (var unicodeChar in foundUnicodeChars)
            {
                var unicodeCodeStr = unicodeChar.Substring(2); // remove \u from unicodeChar
                var unicodeCode = int.Parse(unicodeCodeStr, System.Globalization.NumberStyles.AllowHexSpecifier);
                var unicodeCh = char.ConvertFromUtf32(unicodeCode);

                str = str.Replace(unicodeChar, unicodeCh.ToString());
            }

            str = str.Replace(@"\/", "/"); // remove (in C#) unnecessary escape

            return str;
        }
    }
}