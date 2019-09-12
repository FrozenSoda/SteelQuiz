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
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Xml;

namespace SteelQuizDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Running SteelQuizDeploy from 'SteelQuiz\SteelQuizDeploy\bin\Release'? (y/n)");
            if (char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                return;
            }
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
            Console.Write("\n");
            Console.WriteLine("Release notes updated? (y/n)");
            if (char.ToLower(Console.ReadKey().KeyChar) != 'y')
            {
                return;
            }
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
            }
            else
            {
                Console.WriteLine("(!) Deployment failed (!)");
            }
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("\n\nPress ENTER to exit");
            Console.ReadLine();
        }

        private static bool Deploy()
        {
            string solutionRoot = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location, "..", "..", "..", ".."));


            Console.Write("Creating SteelQuizPortable.zip ...");

            string portableZipPath = Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\SteelQuizPortable.zip");
            string[] portableZipFiles =
            {
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\SteelQuiz.exe"),
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\AutoUpdater.NET.dll"),
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\Fastenshtein.dll"),
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\Newtonsoft.Json.dll"),
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

            string updatePkgPath = Path.Combine(solutionRoot, @"Updater\update_pkg.zip");
            string[] updatePkgFiles =
            {
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\SteelQuiz.exe"),
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\AutoUpdater.NET.dll"),
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\Fastenshtein.dll"),
                Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\Newtonsoft.Json.dll"),
                Path.Combine(solutionRoot, @"Setup\Uninstall.exe"),
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

            
            Console.Write("\nGetting manifest version ...");

            /*
            string manifestPath = Path.Combine(solutionRoot, @"SteelQuiz\Properties\AssemblyInfo.cs");

            string[] manifest = File.ReadAllLines(manifestPath);
            string steelQuizVersion = null;
            bool inComment = false;
            foreach (var line in manifest)
            {
                if (line.Contains("/*"))
                {
                    inComment = true;
                }

                if (line.StartsWith("[assembly: AssemblyVersion(\""))
                {
                    steelQuizVersion = line.Split(new string[] { "[assembly: AssemblyVersion(\"" }, StringSplitOptions.None)[1]
                        .Split('"')[0];
                }
            }

            if (steelQuizVersion == null)
            {
                Console.WriteLine(" FAIL");
                Console.WriteLine("Could not find SteelQuiz assembly version!");
                return false;
            }
            */

            string steelQuizVersion = FileVersionInfo.GetVersionInfo(Path.Combine(solutionRoot, @"SteelQuiz\bin\Release\SteelQuiz.exe")).ProductVersion;

            Console.WriteLine(" OK!");
            Console.WriteLine("Found SteelQuiz version: " + steelQuizVersion);


            Console.Write("\nSetting version in setup.nsi ...");

            string setupNsiPath = Path.Combine(solutionRoot, @"Setup\setup.nsi");
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

            File.WriteAllLines(setupNsiPath, nsi);

            if (!nsiSuccess)
            {
                Console.WriteLine(" FAIL");
                Console.WriteLine("Could not find '!define PRODUCT_VERSION'");
                return false;
            }

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

            string updateMetaPath = Path.Combine(solutionRoot, @"Updater\update_meta.xml");

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
