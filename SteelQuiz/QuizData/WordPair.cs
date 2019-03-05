using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class WordPair
    {
        public string Word1 { get; set; }
        public string[] Word1Synonyms { get; set; }

        public string Word2 { get; set; }
        public string[] Word2Synonyms { get; set; }

        public Rules TranslationRules { get; set; }

        public WordPair(string word1, string word2, Rules translationRules, string[] word1Synonyms = null, string[] word2Synonyms = null)
        {
            Word1 = word1;
            Word2 = word2;
            TranslationRules = translationRules;
            Word1Synonyms = word1Synonyms;
            Word2Synonyms = word2Synonyms;
        }

        [Flags]
        public enum Rules
        {
            IgnoreCapitalization,
            IgnoreExclamation
        }

        public enum TranslationMode
        {
            L1_to_L2,
            L2_to_L1
        }

        public bool Equals(WordPair wp2)
        {
            if (wp2 == null)
            {
                return false;
            }

            return
                this.Word1 == wp2.Word1 &&
                this.Word1Synonyms == wp2.Word1Synonyms &&
                this.Word2 == wp2.Word2 &&
                this.Word2Synonyms == wp2.Word2Synonyms &&
                this.TranslationRules == wp2.TranslationRules;
        }

        public WordProgData GetWordProgData()
        {
            foreach (var wordProgData in QuizCore.QuizProgress.WordProgDatas)
            {
                if (wordProgData.WordPair.Equals(this))
                {
                    return wordProgData;
                }
            }

            throw new Exception("No word progress data could be found for this word pair");
        }

        /*
         * Synonyms should be implemented
         */
        public int[] WrongChIndexes(string comp, TranslationMode translationMode, bool updateProgress = true)
        {
            var incorrectIndexes = new List<int>();
            string word = null;
            if (translationMode == TranslationMode.L1_to_L2)
            {
                word = Word2;
            }
            else if (translationMode == TranslationMode.L2_to_L1)
            {
                word = Word1;
            }

            int woffset = 0; //word offset
            int coffset = 0; //comp offset
            for (int _i = 0; _i < word.Length; ++_i)
            {
                int wi = _i + woffset;
                int ci = _i + coffset;

                if (ci < comp.Length)
                {
                    if (word[wi] != comp[ci])
                    {
                        if (TranslationRules.HasFlag(Rules.IgnoreCapitalization) && char.ToUpper(word[wi]) != char.ToUpper(comp[ci]))
                        {
                            if (TranslationRules.HasFlag(Rules.IgnoreExclamation))
                            {
                                if (word[wi] == '!')
                                {
                                    ++woffset;
                                    if (word.Length >= wi && word[wi + 1] == ' ')
                                    {
                                        //offset for whitespace after excl mark
                                        ++woffset;
                                    }
                                }
                                else if (comp[ci] == '!')
                                {
                                    ++coffset;
                                    if (comp.Length >= ci && comp[ci + 1] == ' ')
                                    {
                                        //offset for whitespace after excl mark
                                        ++coffset;
                                    }
                                }
                                else
                                {
                                    incorrectIndexes.Add(ci);
                                }
                            }
                            else
                            {
                                incorrectIndexes.Add(ci);
                            }
                        }
                    }
                }
                else
                {
                    incorrectIndexes.Add(ci);
                }
            }

            // if comp is longer than word
            for (int i = word.Length; i < comp.Length; ++i)
            {
                if (TranslationRules.HasFlag(Rules.IgnoreExclamation))
                {
                    if (comp[i] != '!')
                    {
                        incorrectIndexes.Add(i);
                    }
                }
                else
                {
                    incorrectIndexes.Add(i);
                }
            }

            if (updateProgress)
            {
                ++GetWordProgData().TriesCount;
                if (incorrectIndexes.Count == 0)
                {
                    ++GetWordProgData().SuccessCount;
                }
                QuizCore.SaveProgress();
            }

            if (incorrectIndexes.Count == 0)
            {
                GetWordProgData().AskedThisRound = true;
                QuizCore.QuizProgress.SetCurrentWordPair(null);
            }

            return incorrectIndexes.ToArray();
        }
    }
}