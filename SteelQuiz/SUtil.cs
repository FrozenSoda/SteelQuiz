using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    public static class SUtil
    {
        public static int RandomNext(int min, int maxExcl, int[] exclusions)
        {
            var excl = new HashSet<int>(exclusions);
            var range = Enumerable.Range(min, maxExcl).Where(i => !excl.Contains(i));
            var rand = new Random();
            int index = rand.Next(0, maxExcl - excl.Count);
            return range.ElementAt(index);
        }
    }
}
