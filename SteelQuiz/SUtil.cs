using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}