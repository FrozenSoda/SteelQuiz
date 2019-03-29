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

        /// <summary>
        /// Test a directory for create file access permissions
        /// </summary>
        /// <param name="DirectoryPath">Full path to directory </param>
        /// <param name="AccessRight">File System right tested</param>
        /// <returns>State [bool]</returns>
        public static bool DirectoryHasPermission(string DirectoryPath, FileSystemRights AccessRight)
        {
            if (string.IsNullOrEmpty(DirectoryPath)) return false;

            try
            {
                AuthorizationRuleCollection rules = Directory.GetAccessControl(DirectoryPath)
                    .GetAccessRules(true, true, typeof(SecurityIdentifier));
                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (identity.Groups.Contains(rule.IdentityReference))
                    {
                        if ((AccessRight & rule.FileSystemRights) == AccessRight)
                        {
                            if (rule.AccessControlType == AccessControlType.Allow)
                                return true;
                        }
                    }
                }
            }
            catch { }
            return false;
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
    }
}