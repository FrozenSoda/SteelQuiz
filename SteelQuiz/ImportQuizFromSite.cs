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
            this.Text += $" | v{Application.ProductVersion}";
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

            var quizPath = Path.Combine(QuizCore.QUIZ_FOLDER, quizFilename) + QuizCore.QUIZ_EXTENSION;

            if (File.Exists(quizPath))
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

        private void btn_urlHowToFind_Click(object sender, EventArgs e)
        {
            if (rdo_studentlitteratur.Checked)
            {
                MessageBox.Show("1. Start the exercise.\r\n2. Open developer tools in your browser (Ctrl+Shift+I in Chrome).\r\n" + 
                    "3. Go to the Network tab.\r\n4. Write one word in the exercise and press ENTER.\r\n5. Double click the entry which appeared in the Network tab." +
                    "\r\n6. Copy the URL of the opened tab and paste it in the URL field in SteelQuiz.", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
