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
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteelQuiz.ConfigData;
using SteelQuiz.Extensions;

namespace SteelQuiz
{
    public static class ConfigManager
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public static readonly string CONFIG_FILE = Path.Combine(QuizCore.APP_CFG_DIR, "Config.json");
        public static readonly string CONFIG_BKP_DIR = Path.Combine(QuizCore.APP_CFG_DIR, "Config Backup");

        public static Config Config { get; set; } = null;

        public static bool LoadConfig()
        {
            Directory.CreateDirectory(QuizCore.APP_CFG_DIR);

            if (!File.Exists(CONFIG_FILE))
            {
                Config = new Config();
                SaveConfig();
                return true;
            }

            bool corrupt = false;
            try
            {
                Config = JsonConvert.DeserializeObject<Config>(AtomicIO.AtomicRead(CONFIG_FILE));
            }
            catch (AtomicException)
            {
                corrupt = true;
            }

            if (Config == null)
            {
                corrupt = true;
            }

            if (corrupt)
            {
                var msg = MessageBox.Show("The configuration file for SteelQuiz is corrupt, and must be reset. Reset configuration?", "SteelQuiz", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (msg == DialogResult.Yes)
                {
                    BackupConfig();
                    File.Delete(CONFIG_FILE);
                    return LoadConfig();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static void SaveConfig()
        {
            Directory.CreateDirectory(QuizCore.APP_CFG_DIR);
            AtomicIO.AtomicWrite(CONFIG_FILE, JsonConvert.SerializeObject(Config, Formatting.Indented));
        }

        public static void BackupConfig()
        {
            BackupHelper.BackupFile(CONFIG_FILE, CONFIG_BKP_DIR);
        }

        public static void Configure()
        {
            if (MetaData.PRE_RELEASE)
            {
                Config.UpdateConfig.UpdateChannel = UpdateChannel.Development;
            }

            if (!Directory.Exists(Config.StorageConfig.DefaultQuizSaveFolder))
            {
                Directory.CreateDirectory(Config.StorageConfig.DefaultQuizSaveFolder);
            }

            SaveConfig();
        }

        /// <summary>
        /// Finalizes the initial installation if required; registers file associations upon upgrade to v5.0.
        /// </summary>
        public static void GetThingsReady()
        {
            if (!((!Program.IsPortable() && !Config.FileAssociationsOfferedOrRegistered) || Config.FullName == null))
            {
                return;
            }

            var startupLoading = new StartupLoading("Getting things ready...", "This should take no longer than one minute\r\nDo not close SteelQuiz", 8000);
            startupLoading.RunInNewThread(true);

            if (Config.FullName == null)
            {
                GrabUserName();
            }

            string installInfoPath = "InstallInfo.json";
            if (!Program.IsPortable() && !Config.FileAssociationsOfferedOrRegistered)
            {
                if (!File.Exists(installInfoPath))
                {
                    RegisterFileAssociations();
                }
                else
                {
                    var installInfoRaw = File.ReadAllText(installInfoPath);
                    var installInfo = JObject.Parse(installInfoRaw);
                    var regFileAssocOffered = installInfo["reg_file_assoc_offered"];

                    if (regFileAssocOffered == null || !(bool)regFileAssocOffered)
                    {
                        RegisterFileAssociations();
                    }
                }

                Config.FileAssociationsOfferedOrRegistered = true;
                SaveConfig();
            }

            void RegisterFileAssociations()
            {
                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\.steelquiz", true))
                {
                    key.SetValue("", "SteelQuiz_Quiz_File");
                }

                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\SteelQuiz_Quiz_File", true))
                {
                    key.SetValue("", "SteelQuiz Quiz");
                }

                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\SteelQuiz_Quiz_File\DefaultIcon", true))
                {
                    key.SetValue("", Application.ExecutablePath);
                }

                using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\SteelQuiz_Quiz_File\shell\open\command", true))
                {
                    key.SetValue("", string.Format("\"{0}\" \"%1\"", Application.ExecutablePath));
                }

                // Notify Windows that file associations have changed
                SHChangeNotify(0x08000000, 0, IntPtr.Zero, IntPtr.Zero);
            }

            void GrabUserName()
            {
                try
                {
                    var givenName = UserPrincipal.Current.GivenName;
                    var surname = UserPrincipal.Current.Surname;
                    if (givenName != null && surname != null)
                    {
                        Config.FullName = givenName + " " + surname;
                    }
                    else if (givenName != null)
                    {
                        Config.FullName = givenName;
                    }
                    else
                    {
                        Config.FullName = UserPrincipal.Current.DisplayName;
                    }
                }
                catch (EntryPointNotFoundException)
                {
                    // Can't access user info, if running in Wine for instance
                    ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not get full name from username:\r\n\r\n{ex.ToString()}", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (Config.FullName == null)
                {
                    Config.FullName = "";
                    Config.ShowNameOnWelcomeScreen = false;
                }

                SaveConfig();
            }

            startupLoading.SafeDispose();
        }
    }
}