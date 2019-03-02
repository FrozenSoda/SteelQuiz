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

#warning BROKEN
        public int[] WrongChIndexes(string comp, TranslationMode translationMode)
        {
            // find common sequences
            var incorrectIndexes = new List<int>();
            var subsequences = new List<int>();
            string word = null;
            if (translationMode == TranslationMode.L1_to_L2)
            {
                word = Word2;
            }
            else if (translationMode == TranslationMode.L2_to_L1)
            {
                word = Word1;
            }

            for (int i = 0; i < word.Length; ++i)
            {
                var correct = false;

                if (TranslationRules.HasFlag(Rules.IgnoreExclamation) && word[i] == '!')
                {
                    continue;
                }

                for (int j = 0; j < comp.Length; ++j)
                {
                    if (TranslationRules.HasFlag(Rules.IgnoreCapitalization) && char.ToUpper(word[i]) == char.ToUpper(comp[j]))
                    {
                        if (!subsequences.Contains(j))
                        {
                            subsequences.Add(j);
                            correct = true;
                        }
                    }
                    else if (word[i] == comp[j])
                    {
                        if (!subsequences.Contains(j))
                        {
                            subsequences.Add(j);
                            correct = true;
                        }
                    }

                    if (!correct)
                    {
                        incorrectIndexes.Add(j);
                        correct = true;
                    }
                }

                if (!correct)
                {
                    incorrectIndexes.Add(0);
                }
            }

            return incorrectIndexes.ToArray();
        }

        /*
         * Synonyms should be implemented
         */
        /*
       public int[] CorrectChIndexes(string comp, TranslationMode translationMode)
       {
           // find common sequences
           var subsequences = new List<int>();
           string word = null;
           if (translationMode == TranslationMode.L1_to_L2)
           {
               word = Word2;
           }
           else if (translationMode == TranslationMode.L2_to_L1)
           {
               word = Word1;
           }

           for (int i = 0; i < word.Length; ++i)
           {
               if (TranslationRules.HasFlag(Rules.IgnoreExclamation) && word[i] == '!')
               {
                   continue;
               }

               for (int j = 0; j < comp.Length; ++j)
               {
                   if (TranslationRules.HasFlag(Rules.IgnoreCapitalization) && char.ToUpper(word[i]) == char.ToUpper(comp[j]))
                   {
                       if (!subsequences.Contains(j))
                       {
                           subsequences.Add(j);
                       }
                   }
                   else if (word[i] == comp[j])
                   {
                       if (!subsequences.Contains(j))
                       {
                           subsequences.Add(j);
                       }
                   }
               }
           }

           return subsequences.ToArray();
       }
       */
    }
}