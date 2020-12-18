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
        private bool MultipleTranslationsAsDifferentCards { get; set; }
        private IEnumerable<Card> Cards { get; set; } = null;
        public string QuizPath { get; set; }
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
                else if (uc.rdo_plainTextImport.Checked)
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
                    MultipleTranslationsAsDifferentCards = uc.rdo_multipleDefinitionsAsSeparateCards.Checked;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step2;
                    MultipleTranslationsAsDifferentCards = uc.rdo_multipleDefinitionsAsSeparateCards.Checked;
                }
            }
            else if (Step == 3)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    var uc = GetStep(Step, ImportSource) as TextImport.Step3;

                    string quizText = uc.rtf_text.Text;
                    string termDelimeter = Regex.Unescape(uc.txt_chBetweenTerms.Text);
                    string lineDelimeter = Regex.Unescape(uc.txt_chBetweenLines.Text);

                    var cards = new List<Card>();

                    try
                    {
                        foreach (string line in quizText.Split(new string[] { lineDelimeter }, StringSplitOptions.None))
                        {
                            string[] terms = line.Split(new string[] { termDelimeter }, StringSplitOptions.None);

                            var term1card = cards.Where(x => x.Front == terms[0]).FirstOrDefault();
                            var term2card = cards.Where(x => x.Back == terms[1]).FirstOrDefault();

                            if (!MultipleTranslationsAsDifferentCards && term1card != null)
                            {
                                term1card.BackSynonyms.Add(terms[1]);
                            }
                            else if (!MultipleTranslationsAsDifferentCards && term2card != null)
                            {
                                term2card.FrontSynonyms.Add(terms[0]);
                            }
                            else
                            {
                                var card = new Card(terms[0], terms[1], StringComp.SMART_RULES);
                                cards.Add(card);
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Text does not match delimiter settings (term/line break)", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Cards != null && !Cards.SequenceEqual(cards))
                    {
                        // if another quiz was selected, reset steps afterwards
                        ResetSteps(4);
                    }

                    Cards = cards;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step3;
                    string url = uc.txt_url.Text;
                    IEnumerable<Card> cards;
                    if (ImportSource == ImportSource.Studentlitteratur)
                    {
                        cards = FromStudentlitteratur(url, MultipleTranslationsAsDifferentCards);
                    }
                    else
                    {
                        throw new NotImplementedException("Hmm... A radio button for import site source was selected that was not implemented in the code (enum)");
                    }

                    if (cards == null)
                    {
                        return;
                    }

                    if (Cards != null && !Cards.SequenceEqual(cards))
                    {
                        // if another quiz was selected, reset steps afterwards
                        ResetSteps(4);
                    }

                    Cards = cards;
                }
            }
            else if (Step == 4)
            {
                if (ImportSource == ImportSource.TextImport)
                {
                    var uc = GetStep(Step, ImportSource) as TextImport.Step4;
                    if (uc.Language1 == "")
                    {
                        MessageBox.Show("Language/type cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Language1 = uc.Language1;
                }
                else if (ImportSource == ImportSource.Studentlitteratur)
                {
                    var uc = GetStep(Step, ImportSource) as Studentlitteratur.Step4;
                    if (uc.Language1 == "")
                    {
                        MessageBox.Show("Language/type cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Language/type cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Language/type cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            sfd_quiz.InitialDirectory = ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder;

            if (sfd_quiz.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            QuizPath = sfd_quiz.FileName;

            var quiz = new Quiz(Language1, Language2, MetaData.QUIZ_FILE_FORMAT_VERSION);
            quiz.Cards = Cards.ToList();

            QuizCore.SaveQuiz(quiz, QuizPath);

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
                    var step4 = new TextImport.Step4(Cards);
                    pnl_steps.Controls.Add(step4);
                }
                else if (step == 5)
                {
                    var step5 = new TextImport.Step5(Cards);
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
                    var step4 = new Studentlitteratur.Step4(Cards);
                    pnl_steps.Controls.Add(step4);
                }
                else if (step == 5)
                {
                    var step5 = new Studentlitteratur.Step5(Cards);
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
