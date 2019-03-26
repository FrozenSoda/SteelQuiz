using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace SteelQuiz
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";

            try
            {
                AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during the update/update check:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_importQuizFromSite_Click(object sender, EventArgs e)
        {
            var import = new ImportQuizFromSite();
            if (import.ShowDialog() == DialogResult.OK)
            {
                Program.inQuiz = new InQuiz();
                Program.inQuiz.Show();
                Hide();
            }
        }

        private void btn_loadQuiz_Click(object sender, EventArgs e)
        {
            ofd_loadQuiz.InitialDirectory = QuizCore.QUIZ_FOLDER;
            if (ofd_loadQuiz.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var load = QuizCore.Load(ofd_loadQuiz.FileName);
                    if (!load)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The quiz file could not be loaded:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Program.inQuiz = new InQuiz();
                Program.inQuiz.Show();
                Hide();
            }
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigManager.SaveConfig();
            Application.Exit();
        }
    }
}
