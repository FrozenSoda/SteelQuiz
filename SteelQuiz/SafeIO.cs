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
    public static class SafeIO
    {
        /// <summary>
        /// Writes to a file, by first writing to a temp file then renaming it, to prevent corruption during a computer crash for instance.
        /// </summary>
        /// <param name="path">The path to save the file to. If it already exists, it will be overwritten</param>
        /// <param name="data">The string data to write to the file</param>
        public static void SafeWrite(string path, string data)
        {
            SafeWrite(path, Encoding.Default.GetBytes(data));
        }

        /// <summary>
        /// Writes to a file, by first writing to a temp file then renaming it, to prevent corruption during a computer crash for instance.
        /// </summary>
        /// <param name="path">The path to save the file to. If it already exists, it will be overwritten</param>
        /// <param name="data">The data to write to the file</param>
        public static void SafeWrite(string path, byte[] data)
        {
            string tempPath = path + ".safe.tmp";

            File.WriteAllBytes(tempPath, data);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.Move(tempPath, path);
        }
    }
}
