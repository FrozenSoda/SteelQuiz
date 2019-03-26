/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  steel9apps

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

using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;
using Microsoft.CSharp.RuntimeBinder;

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

        public static bool PropertyDefined(dynamic property)
        {
            try
            {
                var x = property;
            }
            catch (RuntimeBinderException)
            {
                return false;
            }

            return true;
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