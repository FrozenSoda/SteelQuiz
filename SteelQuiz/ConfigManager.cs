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
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SteelQuiz
{
    public static class ConfigManager
    {
        public static readonly string CONFIG_PATH = Path.Combine(QuizCore.APP_CFG_FOLDER, "Config.json");

        public static Config Config { get; set; }

        public static void LoadConfig()
        {
            var dirInit = QuizCore.CheckInitDirectories();
            if (!dirInit)
            {
                return;
            }

            if (File.Exists(CONFIG_PATH))
            {
                try
                {
                    using (var reader = new StreamReader(CONFIG_PATH))
                    {
                        Config = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the config:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
            }
            else
            {
                Config = new Config();
                SaveConfig();
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
    }
}