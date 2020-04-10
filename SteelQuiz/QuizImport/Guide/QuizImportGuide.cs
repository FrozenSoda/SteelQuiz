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
using static SteelQuiz.QuizImport.QuizImporter;
using SteelQuiz.QuizPractise;

namespace SteelQuiz.QuizImport.Guide
{
    public partial class QuizImportGuide : AutoThemeableForm
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

        private ImportSource ImportSource { get; set; }
        private bool MultipleTranslationsAsDifferentWordPairs { get; set; }
        private IEnumerable<WordPair> WordPairs { get; set; } = null;
        private string QuizPath { get; set; }
        private string Language1 { get; set; }
        private string Language2 { get; set; }

        public QuizImportGuide()
        {
            InitializeComponent();
            //this.Text += $" | v{Application.ProductVersion}";
            ++Step;

            SetTheme();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (Step == 1)
            {
                var uc = GetStep(Step, ImportSource.NULL) as Step1;
                if (uc.rdo_studentlitteratur.Checked)
                {
                    ImportSource = ImportSource.Studentlitteratur;
                }
                else if (uc.rdo_textImport.Checked)
                {
                    ImportSource = ImportSource.TextImport;
                }
                else
                {
                    throw new NotImplementedException("Hmm... A radio button for import site source was selected that was not implemented in the code");
                }
            }
            else if (Step == 2)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    var uc = GetStep(Step, ImportSource) as TextImport.Step2;
                    MultipleTranslationsAsDifferentWordPairs = uc.rdo_multipleTranslationsAsDifferentWordPairs.Checked;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step2;
                    MultipleTranslationsAsDifferentWordPairs = uc.rdo_multipleTranslationsAsDifferentWordPairs.Checked;
                }
            }
            else if (Step == 3)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    var uc = GetStep(Step, ImportSource) as TextImport.Step3;

                    string quizText = uc.rtf_text.Text;
                    string wordDelimeter = Regex.Unescape(uc.txt_chBetweenWords.Text);
                    string lineDelimeter = Regex.Unescape(uc.txt_chBetweenLines.Text);

                    var wordPairs = new List<WordPair>();

                    try
                    {
                        foreach (string line in quizText.Split(new string[] { lineDelimeter }, StringSplitOptions.None))
                        {
                            string[] words = line.Split(new string[] { wordDelimeter }, StringSplitOptions.None);

                            var w1wordPair = wordPairs.Where(x => x.Word1 == words[0]).FirstOrDefault();
                            var w2wordPair = wordPairs.Where(x => x.Word2 == words[1]).FirstOrDefault();

                            if (!MultipleTranslationsAsDifferentWordPairs && w1wordPair != null)
                            {
                                w1wordPair.Word2Synonyms.Add(words[1]);
                            }
                            else if (!MultipleTranslationsAsDifferentWordPairs && w2wordPair != null)
                            {
                                w2wordPair.Word1Synonyms.Add(words[0]);
                            }
                            else
                            {
                                var wordPair = new WordPair(words[0], words[1], StringComp.SMART_RULES);
                                wordPairs.Add(wordPair);
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Pasted text does not match delimeter settings (word/line break)", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (WordPairs != null && !WordPairs.SequenceEqual(wordPairs))
                    {
                        // if another quiz was selected, reset steps afterwards
                        ResetSteps(4);
                    }

                    WordPairs = wordPairs;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step3;
                    string url = uc.txt_url.Text;
                    IEnumerable<WordPair> wordPairs;
                    if (ImportSource == ImportSource.Studentlitteratur)
                    {
                        wordPairs = FromStudentlitteratur(url, MultipleTranslationsAsDifferentWordPairs);
                    }
                    else
                    {
                        throw new NotImplementedException("Hmm... A radio button for import site source was selected that was not implemented in the code (enum)");
                    }

                    if (wordPairs == null)
                    {
                        return;
                    }

                    if (WordPairs != null && !WordPairs.SequenceEqual(wordPairs))
                    {
                        // if another quiz was selected, reset steps afterwards
                        ResetSteps(4);
                    }

                    WordPairs = wordPairs;
                }
            }
            else if (Step == 4)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    var uc = GetStep(Step, ImportSource) as TextImport.Step4;
                    if (uc.Language1 == "")
                    {
                        MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Language1 = uc.Language1;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step4;
                    if (uc.Language1 == "")
                    {
                        MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Language1 = uc.Language1;
                }
            }
            else if (Step == 5)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    var uc = GetStep(Step, ImportSource) as TextImport.Step5;
                    if (uc.Language2 == "")
                    {
                        MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Language2 = uc.Language2;

                    Finish();
                    return;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step5;
                    if (uc.Language2 == "")
                    {
                        MessageBox.Show("Language cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Language2 = uc.Language2;

                    Finish();
                    return;
                }
            }

            ++Step;
        }

        private void ResetSteps(int start)
        {
            var toRemove = new List<Control>();
            for (int i = start; i < pnl_steps.Controls.Count; ++i)
            {
                toRemove.Add(pnl_steps.Controls[i]);
            }

            foreach (var ctrl in toRemove)
            {
                ctrl.Dispose();
            }
        }

        private void btn_prevCancel_Click(object sender, EventArgs e)
        {
            --Step;
        }

        private void Finish()
        {
            if (sfd_quiz.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            QuizPath = sfd_quiz.FileName;

            var quiz = new Quiz(Language1, Language2, MetaData.QUIZ_FILE_FORMAT_VERSION);
            quiz.WordPairs = WordPairs.ToList();
            bool loadSuccess = QuizCore.Load(quiz, QuizPath);
            if (loadSuccess)
            {
                QuizCore.SaveQuiz();
                DialogResult = DialogResult.OK;
            }
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

            btn_next.Text = "Next";
        }

        private IStep GetStep(int step, ImportSource importSource)
        {
            return pnl_steps.Controls.OfType<IStep>().Where(x => x.Step == step && x.ImportSource == importSource).FirstOrDefault();
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
                (GetStep(Step, ImportSource.NULL) as Step1).Focus();
            }
            else if (Step == 2)
            {
                (GetStep(Step, ImportSource) as Control).Focus();
            }
            else if (Step == 3)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    (GetStep(Step, ImportSource) as TextImport.Step3).rtf_text.Focus();
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    (GetStep(Step, ImportSource) as Control as Studentlitteratur.Step3).txt_url.Focus();
                }
            }
            else if (Step == 4)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    (GetStep(Step, ImportSource) as TextImport.Step4).txt_lang.Focus();
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    (GetStep(Step, ImportSource) as Studentlitteratur.Step4).txt_lang.Focus();
                }
            }
            else if (Step == 5)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    (GetStep(Step, ImportSource) as TextImport.Step5).txt_lang.Focus();
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    (GetStep(Step, ImportSource) as Studentlitteratur.Step5).txt_lang.Focus();
                }
            }
        }

        private void InitStep(int step)
        {
            foreach (UserControl ctrl in pnl_steps.Controls)
            {
                ctrl.Hide();
            }

            /*
            if (step < pnl_steps.Controls.Count)
            {
                // the step usercontrol already exists, so show it instead of creating a new
                (GetStep(Step, ImportSource) as UserControl).Show();
                return;
            }
            */

            foreach (IStep s in pnl_steps.Controls.OfType<IStep>())
            {
                if ((s.ImportSource == ImportSource || s.ImportSource == ImportSource.NULL) && s.Step == step)
                {
                    ((Control)s).Show();
                    return;
                }
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
            if (ImportSource == ImportSource.TextImport)
            {
                if (step == 2)
                {
                    var step2 = new TextImport.Step2();
                    pnl_steps.Controls.Add(step2);
                }
                else if (step == 3)
                {
                    var step3 = new TextImport.Step3(ImportSource);
                    pnl_steps.Controls.Add(step3);
                }
                else if (step == 4)
                {
                    var step4 = new TextImport.Step4(WordPairs);
                    pnl_steps.Controls.Add(step4);
                }
                else if (step == 5)
                {
                    var step5 = new TextImport.Step5(WordPairs);
                    pnl_steps.Controls.Add(step5);
                }
            }
            else if (ImportSource == ImportSource.Studentlitteratur)
            {
                if (step == 2)
                {
                    var step2 = new Studentlitteratur.Step2();
                    pnl_steps.Controls.Add(step2);
                }
                else if (step == 3)
                {
                    var step3 = new Studentlitteratur.Step3(ImportSource);
                    pnl_steps.Controls.Add(step3);
                }
                else if (step == 4)
                {
                    var step4 = new Studentlitteratur.Step4(WordPairs);
                    pnl_steps.Controls.Add(step4);
                }
                else if (step == 5)
                {
                    var step5 = new Studentlitteratur.Step5(WordPairs);
                    pnl_steps.Controls.Add(step5);
                }
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

        private void QuizImportGuide_Shown(object sender, EventArgs e)
        {
            btn_next.Focus();
        }
    }
}
