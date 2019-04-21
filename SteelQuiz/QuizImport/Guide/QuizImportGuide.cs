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
using System.Text.RegularExpressions;

namespace SteelQuiz.QuizImport.Guide
{
    public partial class QuizImportGuide : Form
    {
        private int _step = -1;
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

        private QuizImporter.ImportSource ImportSource { get; set; }
        private bool MultipleTranslationsAsDifferentWordPairs { get; set; }
        private IEnumerable<WordPair> WordPairs { get; set; }
        private string QuizPath { get; set; }
        private string Language1 { get; set; }
        private string Language2 { get; set; }

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
                if (uc.rdo_studentlitteratur.Checked)
                {
                    ImportSource = QuizImporter.ImportSource.Studentlitteratur;
                }
                else
                {
                    throw new NotImplementedException("Hmm... A radio button for import site source was selected that was not implemented in the code");
                }
            }
            else if (Step == 2)
            {
                var uc = pnl_steps.Controls[Step] as Step2;
                MultipleTranslationsAsDifferentWordPairs = uc.rdo_multipleTranslationsAsDifferentWordPairs.Checked;
            }
            else if (Step == 3)
            {
                var uc = pnl_steps.Controls[Step] as Step3;
                string url = uc.txt_url.Text;
                IEnumerable<WordPair> wordPairs;
                if (ImportSource == QuizImporter.ImportSource.Studentlitteratur)
                {
                    wordPairs = QuizImporter.FromStudentlitteratur(url, MultipleTranslationsAsDifferentWordPairs);
                }
                else
                {
                    throw new NotImplementedException("Hmm... A radio button for import site source was selected that was not implemented in the code (enum)");
                }

                if (wordPairs == null)
                {
                    return;
                }

                WordPairs = wordPairs;
            }
            else if (Step == 4)
            {
                var uc = pnl_steps.Controls[Step] as Step4;
                var quizFilename = uc.txt_quizName.Text;
                if (quizFilename == "")
                {
                    var msg = MessageBox.Show("Quiz name cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var forbiddenCharacters = Path.GetInvalidFileNameChars();
                var isValid = quizFilename.IndexOfAny(forbiddenCharacters) < 0;
                if (!isValid)
                {
                    var msg = MessageBox.Show("Quiz name contains forbidden characters",
                        "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var quizPath = Path.Combine(QuizCore.QUIZ_FOLDER, quizFilename) + QuizCore.QUIZ_EXTENSION;

                if (File.Exists(quizPath))
                {
                    var msg = MessageBox.Show("A quiz with this name already exists. Replace?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.No)
                    {
                        return;
                    }
                }

                QuizPath = quizPath;
            }
            else if (Step == 5)
            {
                var uc = pnl_steps.Controls[Step] as Step5;
                if (uc.Language1 == "")
                {
                    MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Language1 = uc.Language1;
            }
            else if (Step == 6)
            {
                var uc = pnl_steps.Controls[Step] as Step6;
                if (uc.Language2 == "")
                {
                    MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Language2 = uc.Language2;

                Finish();
                return;
            }
            /*
            if (Step == 0)
            {
                var uc = pnl_steps.Controls[Step] as Step0_old;
                var quizFilename = uc.txt_quizName.Text;
                if (quizFilename == "")
                {
                    var msg = MessageBox.Show("Quiz name cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var quizPath = Path.Combine(QuizCore.QUIZ_FOLDER, quizFilename) + QuizCore.QUIZ_EXTENSION;

                if (File.Exists(quizPath))
                {
                    var msg = MessageBox.Show("A quiz with this name already exists. Replace?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.No)
                    {
                        return;
                    }
                }

                QuizPath = quizPath;

                var url = uc.txt_url.Text;
                IEnumerable<WordPair> wordPairs;
                if (uc.rdo_studentlitteratur.Checked)
                {
                    wordPairs = QuizImporter.FromStudentlitteratur(url, quizFilename, uc.rdo_multipleTranslationsAsDifferentWordPairs.Checked);
                }
                else
                {
                    throw new NotImplementedException("Hmm... A radio button for import site source was selected that was not implemented in the code");
                }

                if (wordPairs == null)
                {
                    return;
                }

                WordPairs = wordPairs;
            }
            else if (Step == 1)
            {
                var uc = pnl_steps.Controls[Step] as Step5;
                if (uc.Language1 == "")
                {
                    MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Language1 = uc.Language1;
            }
            else if (Step == 2)
            {
                var uc = pnl_steps.Controls[Step] as Step6;
                if (uc.Language2 == "")
                {
                    MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Language2 = uc.Language2;

                Finish();
                return;
            }
            */

            ++Step;
        }

        private void btn_prevCancel_Click(object sender, EventArgs e)
        {
            --Step;
        }

        private void Finish()
        {
            var quiz = new Quiz(Language1, Language2, MetaData.QUIZ_FILE_FORMAT_VERSION);
            quiz.WordPairs = WordPairs.ToList();
            QuizCore.Load(quiz, QuizPath);
            QuizCore.SaveQuiz();
            DialogResult = DialogResult.OK;
        }

        private void UpdateNavText()
        {
            if (Step > 0)
            {
                btn_prevCancel.Text = "Previous";
            }
            else
            {
                btn_prevCancel.Text = "Cancel";
            }

            if (Step == 6)
            {
                btn_next.Text = "Finish";
            }
            else
            {
                btn_next.Text = "Next";
            }
        }

        private void SwitchStep()
        {
            if (Step == -1)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                InitStep(Step);
            }

            UpdateNavText();

            pnl_steps.Focus();
            if (Step == 1)
            {
                (pnl_steps.Controls[Step] as Step1).Focus();
            }
            else if (Step == 2)
            {
                (pnl_steps.Controls[Step] as Step2).Focus();
            }
            else if (Step == 3)
            {
                (pnl_steps.Controls[Step] as Step3).txt_url.Focus();
            }
            else if (Step == 4)
            {
                (pnl_steps.Controls[Step] as Step4).txt_quizName.Focus();
            }
            else if (Step == 5)
            {
                (pnl_steps.Controls[Step] as Step5).txt_lang.Focus();
            }
            else if (Step == 6)
            {
                (pnl_steps.Controls[Step] as Step6).txt_lang.Focus();
            }
        }

        private void InitStep(int step)
        {
            foreach (UserControl ctrl in pnl_steps.Controls)
            {
                ctrl.Hide();
            }

            /*
            foreach (IStep s in pnl_steps.Controls.OfType<IStep>())
            {
                if (s.GetStepNumber() == step)
                {
                    // the step usercontrol already exists, so show it instead of creating a new
                    (s as UserControl).Show();
                    return;
                }
            }
            */

            if (step < pnl_steps.Controls.Count)
            {
                // the step usercontrol already exists, so show it instead of creating a new
                (pnl_steps.Controls[step] as UserControl).Show();
                return;
            }

            if (step == 0)
            {
                var step0 = new Step0();
                pnl_steps.Controls.Add(step0);
            }
            else if (step == 1)
            {
                var step1 = new Step1();
                pnl_steps.Controls.Add(step1);
            }
            else if (step == 2)
            {
                var step2 = new Step2();
                pnl_steps.Controls.Add(step2);
            }
            else if (step == 3)
            {
                var step3 = new Step3(ImportSource);
                pnl_steps.Controls.Add(step3);
            }
            else if (step == 4)
            {
                var step4 = new Step4();
                pnl_steps.Controls.Add(step4);
            }
            else if (step == 5)
            {
                var step5 = new Step5(WordPairs);
                pnl_steps.Controls.Add(step5);
            }
            else if (step == 6)
            {
                var step6 = new Step6(WordPairs);
                pnl_steps.Controls.Add(step6);
            }
        }

        private void QuizImportGuide_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                // do not show confirmation dialog, if the dialogresult is OK (which means that the exit has been called from the 'Finish' button)
                return;
            }

            var msg = MessageBox.Show("Are you sure you want to cancel?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                e.Cancel = true;
                if (Step == -1)
                {
                    Step = 0;
                }
            }
        }
    }
}
