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
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SteelQuiz.ConfigData;
using SteelQuiz.Extensions;

namespace SteelQuiz
{
    public static class ConfigManager
    {
        public static readonly string CONFIG_PATH = Path.Combine(QuizCore.APP_CFG_FOLDER, "Config.json");

        public static Config Config { get; set; } = null;

        public static bool LoadConfig()
        {
            var dirInit = QuizCore.CheckInitDirectories();
            if (!dirInit)
            {
                return false;
            }

            if (File.Exists(CONFIG_PATH))
            {
                try
                {
                    using (var reader = new StreamReader(CONFIG_PATH))
                    {
                        Config = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
                    }
                    if (Config == null)
                    {
                        var msg = MessageBox.Show("The configuration file for SteelQuiz is corrupted, and must be reset. Reset configuration?", "SteelQuiz", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error);
                        if (msg == DialogResult.Yes)
                        {
                            var bkp = QuizCore.BackupConfig(new Version(0, 0, 0));
                            if (!bkp)
                            {
                                return false;
                            }
                            File.Delete(CONFIG_PATH);
                            return LoadConfig();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the config:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    return false;
                }
            }
            else
            {
                Config = new Config();
                SaveConfig();
                return true;
            }
        }

        public static void SaveConfig()
        {
            var dirInit = QuizCore.CheckInitDirectories();
            if (!dirInit)
            {
                return;
            }

            try
            {
                using (var writer = new StreamWriter(CONFIG_PATH, false))
                {
                    writer.Write(JsonConvert.SerializeObject(Config, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the config:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void ChkSetupForFirstUse()
        {
            if (Config.Name != null)
            {
                return;
            }

            var startupLoading = new StartupLoading("Getting things ready...");
            startupLoading.RunInNewThread(true);

            try
            {
                Config.Name = UserPrincipal.Current.DisplayName;
            }
            catch (EntryPointNotFoundException)
            {
                // Can't access user info, if running in Wine for instance
                Config.Name = "";
                Config.ShowNameOnWelcomeScreen = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not get full name from username:\r\n\r\n{ex.ToString()}", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Config.Name = "";
                Config.ShowNameOnWelcomeScreen = false;
            }

            SaveConfig();

            startupLoading.StopAnimation = true;
            while (!startupLoading.AnimationStopped)
            {
                Thread.Sleep(1);
            }
            startupLoading.Invoke(new Action(() =>
            {
                startupLoading.Dispose();
            }));
        }
    }
}