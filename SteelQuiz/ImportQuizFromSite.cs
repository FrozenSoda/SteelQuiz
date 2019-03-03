using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SteelQuiz.QuizData;

namespace SteelQuiz
{
    public partial class ImportQuizFromSite : Form
    {
        public ImportQuizFromSite()
        {
            InitializeComponent();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            var quizFilename = txt_quizName.Text;
            if (quizFilename == "")
            {
                var msg = MessageBox.Show("If you don't select a file name, a GUID will be used as the quiz name instead, which will make it hard to find."
                    + " Continue without choosing a name?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                {
                    return;
                }
            }

            if (File.Exists(Path.Combine(QuizCore.QUIZ_FOLDER, quizFilename + QuizCore.QUIZ_EXTENSION)))
            {
                var msg = MessageBox.Show("A quiz with this name already exists. Replace?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.No)
                {
                    return;
                }
            }

            var url = txt_url.Text;
            var success = false;
            if (rdo_studentlitteratur.Checked)
            {
                success = QuizImporter.FromStudentlitteratur(url, txt_lang1.Text, txt_lang2.Text, quizFilename);
            }

            if (success)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
