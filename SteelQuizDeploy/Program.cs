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
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;

namespace SteelQuizDeploy
{
    class Program
    {
        static string SolutionRoot { get; set; }
        static bool DevRelease { get; set; }

        static void Main(string[] args)
        {
            SolutionRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            while (new List<string>(Directory.GetFiles(SolutionRoot)).Where(x => Path.GetFileName(x) == "SteelQuiz.sln").Count() == 0)
            {
                if (new DirectoryInfo(SolutionRoot).Parent == null)
                {
                    Console.WriteLine("Solution root directory cannot be found. Make sure you run the deployment tool from within the solution directory.\n");
                    SolutionRoot = "";
                    break;
                }
                SolutionRoot = Path.GetFullPath(Path.Combine(SolutionRoot, ".."));
            }


            if (!string.IsNullOrWhiteSpace(SolutionRoot))
            {
                Console.WriteLine($"Is this solution root directory correct: '{SolutionRoot}'? (y/n)");
            }
            if (string.IsNullOrWhiteSpace(SolutionRoot) || char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                string dir = "";
                while (!Directory.Exists(dir))
                {
                    if (dir != "")
                    {
                        Console.WriteLine("Directory doesn't exist");
                    }

                    Console.WriteLine("\nEnter the correct solution root directory: ");
                    dir = Console.ReadLine();
                    if (dir == "")
                    {
                        // exit
                        return;
                    }
                }
                SolutionRoot = dir;
            }
            Console.Write("\n");
            string updateChannel = "";
            while (updateChannel != "stable" && updateChannel != "dev")
            {
                Console.WriteLine("Which update channel to release for? (stable/dev)");
                updateChannel = Console.ReadLine().ToLower();
                if (updateChannel != "stable" && updateChannel != "dev")
                {
                    if (updateChannel == "exit" || updateChannel == "quit")
                    {
                        // exit
                        return;
                    }
                    Console.WriteLine("Invalid choice");
                }
            }
            DevRelease = updateChannel == "dev";

            Console.Write("\n");
            Console.WriteLine("Version number set in manifest? (y/n)");
            if (char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                return;
            }
            Console.Write("\n");
            Console.WriteLine("Release build finished? (y/n)");
            if (char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                return;
            }
            /*
            Console.Write("\n");
            Console.WriteLine("Release notes updated? (y/n)");
            if (char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                return;
            }
            */
            Console.Clear();
            Console.WriteLine("Deploy? (y/n)");
            if (char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                return;
            }
            Console.Clear();

            bool success = false;
            try
            {
                success = Deploy();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n\n\n-------------------------------------------------------");
                Console.WriteLine("Deployment failed with an exception:\r\n\r\n" + ex.ToString());
            }

            Console.WriteLine("\n\n\n\n-------------------------------------------------------");
            if (success)
            {
                Console.WriteLine("Deployment finished successfully!");
                Console.WriteLine("-------------------------------------------------------");

                Console.Write("\n");
                Console.WriteLine("Open GitHub release page and app directories? (y/n)");
                if (char.ToLower(Console.ReadKey().KeyChar) == 'y')
                {
                    //Process.Start("https://github.com/steel9/SteelQuiz/releases/new");
                    var github = new Process();
                    github.StartInfo.UseShellExecute = true;
                    github.StartInfo.FileName = "https://github.com/steel9/SteelQuiz/releases/new";
                    github.Start();
                    Process.Start("explorer.exe", Path.Combine(SolutionRoot, "Setup"));
                    Process.Start("explorer.exe", Path.Combine(SolutionRoot, "SteelQuiz", "bin", "Release"));
                    Process.Start("notepad.exe", Path.Combine(SolutionRoot, "Updater", "release_notes.txt"));
                }
            }
            else
            {
                Console.WriteLine("(!) Deployment failed (!)");
                Console.WriteLine("-------------------------------------------------------");
            }

            Console.WriteLine("\n\nPress ENTER to exit");
            Console.ReadLine();
        }

        private static bool Deploy()
        {
            //string solutionRoot = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "..", "..", "..", ".."));
            
            Console.Write("Creating SteelQuizPortable.zip ...");

            string portableZipPath = Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\SteelQuizPortable.zip");
            string[] portableZipFiles =
            {
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\SteelQuiz.exe"),
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\AutoUpdater.NET.dll"),
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\Fastenshtein.dll"),
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\Newtonsoft.Json.dll"),
                Path.Combine(SolutionRoot, @"Portable Extras\README.txt"),
            };

            File.Delete(portableZipPath);
            using (var fileStream = new FileStream(portableZipPath, FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in portableZipFiles)
                    {
                        var fileBytes = File.ReadAllBytes(file);
                        var zipArchiveEntry = archive.CreateEntry(Path.GetFileName(file), CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open())
                            zipStream.Write(fileBytes, 0, fileBytes.Length);
                    }
                }
            }

            Console.WriteLine(" OK!");


            Console.Write("\nCreating update_pkg.zip ...");

            string updatePkgPath;
            if (!DevRelease)
            {
                updatePkgPath = Path.Combine(SolutionRoot, @"Updater\update_pkg.zip");
            }
            else
            {
                updatePkgPath = Path.Combine(SolutionRoot, @"Updater\channel_dev\update_pkg.zip");
            }
            string[] updatePkgFiles =
            {
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\SteelQuiz.exe"),
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\AutoUpdater.NET.dll"),
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\Fastenshtein.dll"),
                Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\Newtonsoft.Json.dll"),
                Path.Combine(SolutionRoot, @"Setup\Uninstall.exe"),
            };

            File.Delete(updatePkgPath);
            using (var fileStream = new FileStream(updatePkgPath, FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in updatePkgFiles)
                    {
                        var fileBytes = File.ReadAllBytes(file);
                        var zipArchiveEntry = archive.CreateEntry(Path.GetFileName(file), CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open())
                            zipStream.Write(fileBytes, 0, fileBytes.Length);
                    }
                }
            }

            Console.WriteLine(" OK!");

            
            Console.Write("\nGetting SteelQuiz manifest version ...");

            string steelQuizVersion = FileVersionInfo.GetVersionInfo(Path.Combine(SolutionRoot, @"SteelQuiz\bin\Release\SteelQuiz.exe")).ProductVersion;

            Console.WriteLine(" OK!");
            Console.WriteLine("Found SteelQuiz version: " + steelQuizVersion);


            Console.Write("\nSetting version in setup.nsi ...");

            string setupNsiPath = Path.Combine(SolutionRoot, @"Setup\setup.nsi");
            string[] nsi = File.ReadAllLines(setupNsiPath);

            bool nsiSuccess = false;
            for (int i = 0; i < nsi.Length; ++i)
            {
                if (nsi[i].StartsWith("!define PRODUCT_VERSION"))
                {
                    nsi[i] = $"!define PRODUCT_VERSION \"{steelQuizVersion}\"";
                    nsiSuccess = true;
                    break;
                }
            }

            if (!nsiSuccess)
            {
                Console.WriteLine(" FAIL");
                Console.WriteLine("Could not find '!define PRODUCT_VERSION'");
                return false;
            }

            File.WriteAllLines(setupNsiPath, nsi);

            Console.WriteLine(" OK!");


            Console.WriteLine("\nCompiling setup.nsi ...");
            Console.WriteLine("-------------------------------------------------------");

            var makeNsis = new Process();
            //makeNsis.StartInfo.UseShellExecute = true;
            //makeNsis.StartInfo.RedirectStandardOutput = true;
            makeNsis.StartInfo.FileName = @"C:\Program Files (x86)\NSIS\makensis.exe";
            makeNsis.StartInfo.Arguments = $"\"{setupNsiPath}\"";
            makeNsis.Start();
            makeNsis.WaitForExit();
            Console.WriteLine("-------------------------------------------------------");

            if (makeNsis.ExitCode != 0)
            {
                Console.WriteLine("Compiling setup.nsi ... FAIL");
                Console.WriteLine("makensis returned with exit code: " + makeNsis.ExitCode);
                return false;
            }

            Console.WriteLine("Compiling setup.nsi ... OK!");


            Console.Write("\nCalculating SHA512 sum of update_pkg.zip ...");

            string sha512hash = null;
            using (var sha512 = SHA512.Create())
            {
                using (var stream = File.OpenRead(updatePkgPath))
                {
                    byte[] sha512hashBytes = sha512.ComputeHash(stream);
                    sha512hash = BitConverter.ToString(sha512hashBytes).Replace("-", "").ToLowerInvariant();
                }
            }

            if (string.IsNullOrWhiteSpace(sha512hash))
            {
                Console.WriteLine(" FAIL");
                return false;
            }

            Console.WriteLine(" OK!");
            Console.WriteLine($"SHA512 sum: {sha512hash}");


            Console.Write("\nUpdating update_meta.xml ...");

            string updateMetaPath;
            if (!DevRelease)
            {
                updateMetaPath = Path.Combine(SolutionRoot, @"Updater\update_meta.xml");
            }
            else
            {
                updateMetaPath = Path.Combine(SolutionRoot, @"Updater\channel_dev\update_meta.xml");
            }

            var xml = new XmlDocument();
            xml.Load(updateMetaPath);

            xml.SelectSingleNode("/item/version").InnerText = steelQuizVersion;
            xml.SelectSingleNode("/item/checksum").InnerText = sha512hash;

            xml.Save(updateMetaPath);

            Console.WriteLine(" OK!");


            return true;
        }
    }
}
