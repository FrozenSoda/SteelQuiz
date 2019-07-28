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
            AtomicWrite(path, Encoding.Default.GetBytes(data));
        }

        /// <summary>
        /// Writes to a file, by first writing to a temp file then renaming it, to prevent corruption during a computer crash for instance.
        /// </summary>
        /// <param name="path">The path to save the file to. If it already exists, it will be overwritten</param>
        /// <param name="data">The data to write to the file</param>
        public static void AtomicWrite(string path, byte[] data)
        {
            string tempPath = path + ".atomic_copy";

            File.WriteAllBytes(tempPath, data);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.Move(tempPath, path);
        }

        /// <summary>
        /// Reads data from a text file. If the AtomicWrite operation to the file was interrupted, the intact copy will be read instead of the exact path
        /// </summary>
        /// <param name="path">The path to the text file</param>
        /// <returns>Returns the data from the text file specified</returns>
        public static string AtomicRead(string path)
        {
            string tempPath = path + ".atomic_copy";

            if (File.Exists(tempPath))
            {
                // AtomicWrite operation was interrupted, return atomic_copy

                string data = File.ReadAllText(tempPath);

                // Delete corrupted file
                File.Delete(path);

                return data;
            }
            else
            {
                string data = File.ReadAllText(path);

                return data;
            }
        }
    }
}
