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

using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;
using Microsoft.CSharp.RuntimeBinder;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;
using System.Net;

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

        public static IEnumerable<T> Clone<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone());
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

        public static bool InternetConnectionAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }

        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || !list.Any();
        }
    }
}