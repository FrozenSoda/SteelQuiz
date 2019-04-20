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

namespace SteelQuiz.QuizImport.Guide
{
    public partial class QuizImportGuide : Form
    {
        private int _step = 0;
        private int Step
        {
            get
            {
                return _step;
            }

            set
            {
                _step = value;
                SwitchStep();
            }
        }

        private Quiz Quiz { get; set; }

        public QuizImportGuide()
        {
            InitializeComponent();
            //this.Text += $" | v{Application.ProductVersion}";
            ++Step;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Step == 1)
            {
                var uc = pnl_steps.Controls[Step] as Step1;
                var quizFilename = uc.txt_quizName.Text;
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

                var url = uc.txt_url.Text;
                var success = false;
                if (uc.rdo_studentlitteratur.Checked)
                {
                    success = QuizImporter.FromStudentlitteratur(url, quizFilename, uc.rdo_multipleTranslationsAsDifferentWordPairs.Checked);
                }

                if (success)
                {
                    ++Step;
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            --Step;
        }

        private void SwitchStep()
        {
            if (Step == 0)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                InitStep(Step);
            }
        }

        private void InitStep(int step)
        {
            foreach (UserControl ctrl in pnl_steps.Controls)
            {
                ctrl.Hide();
            }

            foreach (IStep s in pnl_steps.Controls.OfType<IStep>())
            {
                if (s.GetStepNumber() == step)
                {
                    (s as UserControl).Show();
                    return;
                }
            }

            if (step == 1)
            {
                var step1 = new Step1();
                pnl_steps.Controls.Add(step1);
            }
            else if (step == 2)
            {
                var step2 = new Step3();
                pnl_steps.Controls.Add(step2);
            }
        }
    }
}
