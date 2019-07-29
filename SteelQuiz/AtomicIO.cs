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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    /// <summary>
    /// This class provides functions for atomic write/read, to prevent file corruption/data loss during crashes
    /// </summary>
    public static class AtomicIO
    {
        /// <summary>
        /// Writes to a file, by first writing to a temp file then renaming it, to prevent corruption during a computer crash for instance.
        /// </summary>
        /// <param name="path">The path to save the file to. If it already exists, it will be overwritten</param>
        /// <param name="data">The string data to write to the file</param>
        public static void AtomicWrite(string path, string data)
        {
            AtomicWrite(path, Encoding.UTF8.GetBytes(data));
        }

        /// <summary>
        /// Writes to a file, by first writing to a temp file then renaming it, to prevent corruption during a computer crash for instance.
        /// </summary>
        /// <param name="path">The path to save the file to. If it already exists, it will be overwritten</param>
        /// <param name="data">The data to write to the file</param>
        public static void AtomicWrite(string path, byte[] data)
        {
            string atomicPath = path + ".atomic_copy";

            File.WriteAllBytes(atomicPath, data);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.Move(atomicPath, path);
        }

        /// <summary>
        /// Reads data from a text file. If the AtomicWrite operation to the file was interrupted, the intact copy will be read instead of the exact path
        /// </summary>
        /// <param name="path">The path to the text file</param>
        /// <returns>Returns the data from the text file specified</returns>
        public static string AtomicRead(string path)
        {
            string atomicPath = path + ".atomic_copy";

            if (File.Exists(atomicPath))
            {
                if (File.Exists(path))
                {
                    // AtomicWrite operation was interrupted when writing to atomic copy, remove atomic copy

                    File.Delete(atomicPath);
                }
                else
                {
                    // AtomicWrite operation was interrupted when replacing original file with atomic copy (but atomic copy is finished), 
                    //  move atomic copy to original path
#warning if path never existed, then this might potentially return a corrupt atomic copy
                    File.Move(atomicPath, path);
                }
            }

            string text = File.ReadAllText(path);

            return text;
        }
    }
}
