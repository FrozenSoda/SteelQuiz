/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
    /// A Helper class for backup related operations.
    /// </summary>
    public static class BackupHelper
    {
        /// <summary>
        /// Creates a backup of the specified file, to the specified directory.
        /// </summary>
        /// <param name="fileToBackup">The file to make a backup of.</param>
        /// <param name="destinationDir">The directory where the backup will be stored.</param>
        /// <param name="throwOnFileMissing">True if an exception should be thrown if the file to backup does not exist.</param>
        public static void BackupFile(string fileToBackup, string destinationDir, bool throwOnFileMissing = true)
        {
            string destinationFileNameStart = Path.GetFileNameWithoutExtension(fileToBackup);
            BackupFile(fileToBackup, destinationDir, destinationFileNameStart, throwOnFileMissing);
        }

        /// <summary>
        /// Creates a backup of the specified file, to the specified directory, with the file name starting with the specified string.
        /// </summary>
        /// <param name="fileToBackup">The file to make a backup of.</param>
        /// <param name="destinationDir">The directory where the backup will be stored.</param>
        /// <param name="destinationFileNameStart">The start of the filename for the backups. An additional part will then be added, to make the filename unique.</param>
        /// <param name="throwOnFileMissing">True if an exception should be thrown if the file to backup does not exist; False if the method should just return.</param>
        public static void BackupFile(string fileToBackup, string destinationDir, string destinationFileNameStart, bool throwOnFileMissing = true)
        {
            if (!File.Exists(fileToBackup))
            {
                if (throwOnFileMissing)
                {
                    throw new FileNotFoundException($"File to backup does not exist: {fileToBackup}");
                }
                else
                {
                    return;
                }
            }

            Directory.CreateDirectory(destinationDir);

            // Find vacant name for backup
            int maxNum = -1;
            foreach (var file in Directory.GetFiles(destinationDir))
            {
                try
                {
                    int num = Convert.ToInt32(Path.GetFileNameWithoutExtension(file).Split(new string[] { destinationFileNameStart + "_" }, StringSplitOptions.None)[1]);
                    if (num > maxNum)
                    {
                        maxNum = num;
                    }
                }
                catch (FormatException)
                {
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }

            string backupFile = Path.Combine(destinationDir, destinationFileNameStart + "_" + (maxNum + 1).ToString() + Path.GetExtension(fileToBackup));
            File.Copy(fileToBackup, backupFile);
        }
    }
}
