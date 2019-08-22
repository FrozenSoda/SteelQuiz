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
    /// Thrown when AtomicRead cannot retrieve the file specified, which is caused either by (I) no write operation to the file has ever finished or (II)
    ///  the file doesn't exist
    /// </summary>
    public class AtomicException : Exception
    {
        public AtomicException() : base()
        {

        }

        public AtomicException(string message) : base(message)
        {

        }

        public AtomicException(string message, Exception inner) : base(message, inner)
        {

        }
    }

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
            if (!ConfigManager.Config.AdvancedConfig.AtomicIOEnabled)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllBytes(path, data);

                return;
            }

            string atomicPath = path + ".atomic_copy";

            File.WriteAllBytes(atomicPath, data);

            string pathOrig = path + ".atomic_orig";

            if (File.Exists(path))
            {
                File.Move(path, pathOrig);
            }

            File.Move(atomicPath, path);

            if (File.Exists(pathOrig))
            {
                File.Delete(pathOrig);
            }
        }

        /// <summary>
        /// Reads data from a text file. If the AtomicWrite operation to the file was interrupted, the intact copy will be read instead of the exact path
        /// </summary>
        /// <param name="path">The path to the text file</param>
        /// <returns>Returns the data from the text file specified</returns>
        /// <exception cref="AtomicException">Thrown if no intact file could be found, or if path doesn't exist</exception>
        public static string AtomicRead(string path)
        {
            if (!ConfigManager.Config.AdvancedConfig.AtomicIOEnabled)
            {
                return File.ReadAllText(path);
            }

            string atomicPath = path + ".atomic_copy";
            string pathOrig = path + ".atomic_orig";

            if (File.Exists(atomicPath))
            {
                // AtomicWrite operation was interrupted

                if (File.Exists(path))
                {
                    // Operation was interrupted while writing to atomic copy, so remove it

                    File.Delete(atomicPath);
                }
                else
                {
                    if (File.Exists(pathOrig))
                    {
                        // Operation was interrupted while swapping atomic copy and original, but atomic copy is finished, so use atomic copy

                        File.Delete(pathOrig);
                        File.Move(atomicPath, path);
                    }
                    else
                    {
                        // Operation was interrupted while writing to atomic copy, and no original file exists, so there's no file to read

                        throw new AtomicException(
                            "Last atomic write operation to this file was interrupted while writing to atomic copy, " +
                            "and no original file exists, so there's no file to read");
                    }
                }
            }
            else
            {
                if (!File.Exists(path))
                {
                    // Write operation didn't even finish, or file doesn't exist

                    throw new AtomicException(
                        "Last atomic write operation to this file didn't finish, or file doesn't exist");
                }
            }

            string text = File.ReadAllText(path);

            return text;
        }
    }
}
