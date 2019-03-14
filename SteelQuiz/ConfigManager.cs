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
            QuizCore.CheckInitDirectories();

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
            QuizCore.CheckInitDirectories();

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