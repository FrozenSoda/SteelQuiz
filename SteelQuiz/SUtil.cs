using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;

namespace SteelQuiz
{
    public static class SUtil
    {
        public static int[] RandomUnique(this Random rnd, int min, int maxExcl, int count)
        {
            var nums = new List<int>();
            for (int i = 0; i < count; ++i)
            {
                nums.Add(rnd.RandomNext(min, maxExcl, nums.ToArray()));
            }

            return nums.ToArray();
        }

        public static int RandomNext(this Random rnd, int min, int maxExcl, int[] exclusions)
        {
            var excl = new HashSet<int>(exclusions);
            var range = Enumerable.Range(min, maxExcl).Where(i => !excl.Contains(i));
            int index = rnd.Next(0, maxExcl - excl.Count);
            return range.ElementAt(index);
        }

        public static bool NextBool(this Random rand, double trueProb)
        {
            return rand.NextDouble() < trueProb;
        }

        public static List<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /*
         * Returns an array with the indexes of the characters in input which matches cmp.
         * For instance, if cmp is "hello" and input is "_hello", the function will return { 1, 2, 3, 4, 5 } (the "_" index is not in the array)
         */
         /*
        public static int[] SubsequenceIndexes(string cmp, string input, StringComp.Rules rules)
        {
            var jCurrent = 0;
            var subseq = new List<int>();

            for (int i = 0; i < cmp.Length; ++i)
            {
                for (int j = jCurrent; j < input.Length; ++j)
                {
                    if (cmp[i] == input[j])
                    {
                        subseq.Add(j);
                        ++jCurrent;
                    }
                    else
                    {
                        if (rules.HasFlag(WordPair.Rules.IgnoreCapitalization))
                        {
                            if (char.ToUpper(cmp[i]) == char.ToUpper(input[j]))
                            {
                                subseq.Add(j);
                                ++jCurrent;
                            }
                        }

                        if (rules.HasFlag(WordPair.Rules.IgnoreExclamation))
                        {
                            if (cmp[i] == '!')
                            {
                                subseq.Add(j);
                                ++jCurrent;
                            }
                        }
                    }
                }
            }

            return subseq.ToArray();
        }
        */
    }
}