﻿/*
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
using System.Windows.Forms;
using SteelQuiz.QuizData;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz.QuizPractise
{
    public partial class InQuiz : AutoThemeableForm
    {
        private GeneralTheme GeneralTheme = new GeneralTheme();

        public bool ExitAppOnClose { get; set; } = true;
        private bool PerformOnCloseEvents { get; set; } = true;

        private WordPair CurrentWordPair { get; set; } = null;
        private string CurrentInput { get; set; } = "";
        //private WordPair.TranslationMode TranslationMode { get; set; } = WordPair.TranslationMode.L1_to_L2;

        private bool WaitingForEnter { get; set; } = false;
        private bool UserCopyingWord { get; set; } = false;
        private bool CountThisTranslationToProgress { get; set; } = true; // false if the user clicked Fix Quiz Errors, as the answer is displayed there. Will become true as a new word is selected
        private bool ShowingW1synonyms { get; set; } = false;
        //private int CorrectAnswersThisRound { get; set; } = 0;

        public InQuiz(bool welcomeLocationInitialized = true)
        {
            InitializeComponent();
            if (welcomeLocationInitialized)
            {
                this.Location = new Point(Program.frmWelcome.Location.X + (Program.frmWelcome.Size.Width / 2) - (this.Size.Width / 2),
                                  Program.frmWelcome.Location.Y + (Program.frmWelcome.Size.Height / 2) - (this.Size.Height / 2)
                                );
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            lbl_lang1.Text = QuizCore.Quiz.Language1;
            lbl_lang2.Text = QuizCore.Quiz.Language2;
            this.Text += $" | v{Application.ProductVersion}";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += " PRE-RELEASE";
            }
            NewWord();
            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                lbl_intelligentLearning.Text = "Intelligent learning: Disabled";
                //lbl_AI.ForeColor = Color.Gray;
            }
            else
            {
                lbl_intelligentLearning.Text = "Intelligent learning: Enabled";
                //lbl_AI.ForeColor = Color.DarkGreen;
            }

            if (CurrentWordPair != null && CurrentWordPair.Word1Synonyms.Count > 0)
            {
                btn_w1_synonyms.Enabled = true;
            }

            SetTheme(GeneralTheme);
        }

        public override void SetTheme(GeneralTheme theme)
        {
            base.SetTheme(theme);

            lbl_intelligentLearning.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_progress.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_lang1.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_lang2.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
        }

        public void NewWord()
        {
            WaitingForEnter = false;
            CountThisTranslationToProgress = true;
            lbl_lang1.Text = QuizCore.Quiz.Language1;
            CurrentWordPair = QuestionSelector.GenerateWordPair();

            if (CurrentWordPair == null)
            {
                NewRound();
                return;
            }

            if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
            {
                lbl_word1.Text = CurrentWordPair.Word1;
            }
            else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
            {
                lbl_word1.Text = CurrentWordPair.Word2;
            }
            CurrentInput = "";
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
            lbl_word2.Text = "Enter your answer...";
        }

        private bool skipNewRoundMsg = false;
        private void NewRound(bool newRoundMsg = true)
        {
            CountThisTranslationToProgress = true;
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                newRoundMsg = false;
            }

            QuizCore.QuizProgress.CorrectAnswersThisRound = 0;
            QuestionSelector.NewRound();

            if (newRoundMsg && !skipNewRoundMsg)
            {
                lbl_lang1.Text = "Info";
                lbl_word1.Text = "Round completed! Press ENTER to continue";
                WaitingForEnter = true;
            }
            else
            {
                skipNewRoundMsg = false;
                NewWord();
            }

            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
        }

        private void CheckWord()
        {
            lbl_lang1.Text = "Info";
            var mismatch = CurrentWordPair.CharacterMismatches(CurrentInput, !UserCopyingWord && CountThisTranslationToProgress);
            if (mismatch.Correct())
            {
                foreach (var c in lbl_word1.Controls.OfType<WrongAnswer>())
                {
                    c.Dispose();
                }

                if (!mismatch.AskingForSynonym)
                {
                    if (!UserCopyingWord)
                    {
                        ++QuizCore.QuizProgress.CorrectAnswersThisRound;
                    }
                    lbl_word1.Text = "Correct! Press ENTER to continue";
                    QuizCore.ResetWordsAskedThisRoundMemo();
                    lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";

                    if (QuizCore.QuizProgress.FullTestInProgress && QuizCore.GetWordsAskedThisRound() == QuizCore.GetTotalWordsThisRound())
                    {
                        if (QuizCore.QuizProgress.CorrectAnswersThisRound == QuizCore.GetTotalWordsThisRound())
                        {
                            MessageBox.Show($"Full test results:\r\nCorrect: {QuizCore.QuizProgress.CorrectAnswersThisRound} / {QuizCore.GetTotalWordsThisRound()}, congratulations!",
                                "Full test finished - SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var msg = MessageBox.Show($"Full test results:\r\nCorrect: {QuizCore.QuizProgress.CorrectAnswersThisRound} / {QuizCore.GetTotalWordsThisRound()}\r\n\r\n" +
                                $"Would you like to re-enable Intelligent Learning, to learn the missed words?",
                                "Full test finished - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msg == DialogResult.Yes)
                            {
                                SwitchIntelligentLearningMode(false);
                            }
                        }
                        QuizCore.QuizProgress.CorrectAnswersThisRound = 0;
                    }
                    WaitingForEnter = true;
                }
                else
                {
                    lbl_word1.Text = "Correct, but a synonym to this word is being asked for.\r\n\r\nPress ENTER to try again.\r\n\r\n(press ENTER then write the answer)";
                    WaitingForEnter = true;
                }
                UserCopyingWord = false;
            }
            else
            {
                string questionWord = null;
                string answerWord = null;

                if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
                {
                    questionWord = CurrentWordPair.Word1;
                    answerWord = CurrentWordPair.Word2;
                }
                else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
                {
                    questionWord = CurrentWordPair.Word2;
                    answerWord = CurrentWordPair.Word1;
                }

                var wrongAnswer = new WrongAnswer(questionWord, QuizCore.QuizProgress.QuestionLanguage, answerWord, QuizCore.QuizProgress.AnswerLanguage);
                lbl_word1.Controls.Add(wrongAnswer);
                wrongAnswer.Location = new Point(0, 0);
                wrongAnswer.Show();

                UserCopyingWord = true;
                CurrentInput = "";
                lbl_word2.Text = "Enter your answer...";
            }
        }

        private void InQuiz_KeyPress(object sender, KeyPressEventArgs e)
        {
            var updateInputLbl = true;

            if (e.KeyChar == '\u001b')
            {
                // ignore ESC
                return;
            }

            if (e.KeyChar == '\b')
            {
                // BACKSPACE
                if (CurrentInput.Length > 0)
                {
                    CurrentInput = CurrentInput.Remove(CurrentInput.Length - 1);
                }
            }
            else if (e.KeyChar == '\r')
            {
                e.Handled = true;

                // ENTER
                if (WaitingForEnter)
                {
                    WaitingForEnter = false;
                    NewWord();
                }
                else
                {
                    CheckWord();
                }

                updateInputLbl = false;
            }
            else if (!WaitingForEnter)
            {
                CurrentInput += e.KeyChar.ToString();
            }

            if (updateInputLbl)
            {
                lbl_word2.Text = CurrentInput;
            }
        }

        private void InQuiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PerformOnCloseEvents)
            {
                return;
            }

            QuizCore.SaveQuizProgress();
            ConfigManager.SaveConfig();

            if (ExitAppOnClose)
            {
                Application.Exit();
            }
        }

        public void SwitchIntelligentLearningMode(bool callGenerationFunctions = true)
        {
            skipNewRoundMsg = true;
            QuizCore.QuizProgress.MasterNoticeShowed = false;
            QuizCore.QuizProgress.FullTestInProgress = !QuizCore.QuizProgress.FullTestInProgress;
            QuestionSelector.SkipNextMasterNotice = !QuizCore.QuizProgress.FullTestInProgress;

            if (callGenerationFunctions)
            {
                QuestionSelector.NewRound();
                NewWord();
            }

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                lbl_intelligentLearning.Text = "Intelligent learning: Disabled";
                //lbl_AI.ForeColor = Color.Gray;
            }
            else
            {
                lbl_intelligentLearning.Text = "Intelligent learning: Enabled";
                //lbl_AI.ForeColor = Color.DarkGreen;
            }
        }

        private void lbl_word2_Click(object sender, EventArgs e)
        {
            lbl_word2.Focus();
        }

        private void lbl_word1_Click(object sender, EventArgs e)
        {
            lbl_word1.Focus();
        }

        private void btn_w1_synonyms_Click(object sender, EventArgs e)
        {
            ShowingW1synonyms = !ShowingW1synonyms;

            if (ShowingW1synonyms)
            {
                if (CurrentWordPair.Word1Synonyms.Count == 0)
                {
                    MessageBox.Show("No synonyms are added for this word!", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_word2.Focus();
                    return;
                }

                lbl_word1.Text += "\r\n\r\n---Synonyms---";

                foreach (var synonym in CurrentWordPair.Word1Synonyms)
                {
                    lbl_word1.Text += "\r\n" + synonym;
                }

                btn_w1_synonyms.Text = "<--";
            }
            else
            {
                lbl_word1.Text = CurrentWordPair.Word1;
                btn_w1_synonyms.Text = "Synonyms";
            }

            lbl_word2.Focus();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Hide();
            Program.frmWelcome.Location = new Point(Location.X + (Size.Width / 2) - (Program.frmWelcome.Size.Width / 2),
                              Location.Y + (Size.Height / 2) - (Program.frmWelcome.Size.Height / 2)
                            );
            Program.frmWelcome.PopulateQuizList();
            Program.frmWelcome.SetControlStates();
            Program.frmWelcome.GenerateWelcomeMsg();
            Program.frmWelcome.Show();
            QuizCore.SaveQuizProgress();
            ConfigManager.SaveConfig();
            PerformOnCloseEvents = false;
            Close();
            Program.frmInQuiz = null;
        }

        public void FixQuizErrors()
        {
            var msg = MessageBox.Show("If you continue, the translation of this word won't be counted this round to the score, to prevent cheating. Continue?",
                "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.No)
            {
                lbl_word2.Focus();
                return;
            }

            CountThisTranslationToProgress = false;
            var fixMenu = new FixQuizErrors(this, CurrentWordPair);
            var result = fixMenu.ShowDialog();
            if (result == DialogResult.OK)
            {
                QuizCore.SaveQuiz();

                if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
                {
                    lbl_word1.Text = CurrentWordPair.Word1;
                }
                else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
                {
                    lbl_word1.Text = CurrentWordPair.Word2;
                }

                QuizCore.FixQuizProgressData();
            }
            else if (result == DialogResult.Abort)
            {
                Close();
                Program.frmInQuiz.Dispose();
                Program.frmInQuiz = null;
            }
            lbl_word2.Focus();
        }

        private void InQuiz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.HasFlag(Keys.Oemplus) && e.Shift && e.Alt && e.Control)
            {
                CurrentInput += "¿";
                lbl_word2.Text = CurrentInput;
            }
            else if (e.KeyData.HasFlag(Keys.D1) && e.Shift && e.Alt && e.Control)
            {
                CurrentInput += "¡";
                lbl_word2.Text = CurrentInput;
            }
        }

        private void Btn_cfg_Click(object sender, EventArgs e)
        {
            var cfg = new QuizPractiseConfig();
            cfg.ShowDialog();

            lbl_word2.Focus();
        }
    }
}