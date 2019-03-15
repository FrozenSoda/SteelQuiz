using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";
        }

        private void btn_importQuizFromSite_Click(object sender, EventArgs e)
        {
            var import = new ImportQuizFromSite();
            if (import.ShowDialog() == DialogResult.OK)
            {
                var inQuiz = new InQuiz();
                inQuiz.Show();
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
