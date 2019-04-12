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
using System.Windows.Forms;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizPractise
{
    public partial class InQuiz : Form
    {
        public bool ExitAppOnClose { get; set; } = true;

        private bool onCloseEvent = true;
        private ulong? currentWordPairID = null;
        private string currentInput = "";
        private WordPair.TranslationMode translationMode = WordPair.TranslationMode.L1_to_L2;
        private bool waitingForEnter = false;
        private bool userCopyWord = false;
        private bool countThisTranslationToProgress = true;
        private bool showingW1synonyms = false;

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
            NewWord();
            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                btn_switchTestMode.Text = "Enable Intelligent Learning";
                lbl_AI.Text = "Intelligent learning: Disabled";
                lbl_AI.ForeColor = Color.Gray;
            }
            else
            {
                btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
                lbl_AI.Text = "Intelligent learning: Enabled";
                lbl_AI.ForeColor = Color.DarkGreen;
            }
            if (currentWordPairID.GetWordPair().Word1Synonyms.Count > 0)
            {
                btn_w1_synonyms.Enabled = true;
            }
        }

        private void NewWord()
        {
            countThisTranslationToProgress = true;
            lbl_lang1.Text = QuizCore.Quiz.Language1;
            currentWordPairID = QuizAI.GenerateWordPair();

            if (currentWordPairID == null)
            {
                NewRound();
                return;
            }

            if (translationMode == WordPair.TranslationMode.L1_to_L2)
            {
                lbl_word1.Text = currentWordPairID.GetWordPair().Word1;
            }
            else if (translationMode == WordPair.TranslationMode.L2_to_L1)
            {
                lbl_word1.Text = currentWordPairID.GetWordPair().Word2;
            }
            currentInput = "";
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
            lbl_word2.Text = "Enter your answer...";
        }

        private void NewRound()
        {
            countThisTranslationToProgress = true;
            lbl_lang1.Text = "Info";
            lbl_word1.Text = "Round completed! Press enter to continue";
            waitingForEnter = true;
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
        }

        private void CheckWord()
        {
            lbl_lang1.Text = "Info";
            var mismatch = currentWordPairID.GetWordPair().CharacterMismatches(currentInput, translationMode, !userCopyWord && countThisTranslationToProgress);
            userCopyWord = false;
            if (mismatch.Correct())
            {
                lbl_word1.Text = "Correct! Press enter to continue";
                waitingForEnter = true;
            }
            else
            {
                if (translationMode == WordPair.TranslationMode.L1_to_L2)
                {
                    lbl_word1.Text = $"Wrong\r\n\r\n{QuizCore.Quiz.Language1} word:\r\n"
                        + $"{currentWordPairID.GetWordPair().Word1}\r\n\r\nCorrect {QuizCore.Quiz.Language2} word is:\r\n{currentWordPairID.GetWordPair().Word2}"
                        + $"\r\n\r\nType the {QuizCore.Quiz.Language2} word";
                }
                else if (translationMode == WordPair.TranslationMode.L2_to_L1)
                {
                    lbl_word1.Text = $"Wrong\r\n\r\n{QuizCore.Quiz.Language2} word:\r\n"
                        + $"{currentWordPairID.GetWordPair().Word2}\r\n\r\nCorrect {QuizCore.Quiz.Language1} word is:\r\n{currentWordPairID.GetWordPair().Word1}"
                        + $"\r\n\r\nType the {QuizCore.Quiz.Language1} word";
                }
                userCopyWord = true;
                currentInput = "";
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
                if (currentInput.Length > 0)
                {
                    currentInput = currentInput.Remove(currentInput.Length - 1);
                }
            }
            else if (e.KeyChar == '\r')
            {
                e.Handled = true;

                // ENTER
                if (waitingForEnter)
                {
                    waitingForEnter = false;
                    NewWord();
                }
                else
                {
                    CheckWord();
                }

                updateInputLbl = false;
            }
            else
            {
                currentInput += e.KeyChar.ToString();
            }

            if (updateInputLbl)
            {
                lbl_word2.Text = currentInput;
            }
        }

        private void InQuiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!onCloseEvent)
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

        private void btn_switchTestMode_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Warning: The state of the current round will be lost (current word, word count etc).\r\n\r\nProceed?",
                "Switch mode - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                SwitchAIMode();
            }
            lbl_word2.Focus();
        }

        public void SwitchAIMode()
        {
            QuizAI.SkipNextMasterNotice = true;
            QuizCore.QuizProgress.FullTestInProgress = !QuizCore.QuizProgress.FullTestInProgress;
            QuizAI.NewRound();
            NewWord();

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                btn_switchTestMode.Text = "Enable Intelligent Learning";
                lbl_AI.Text = "Intelligent learning: Disabled";
                lbl_AI.ForeColor = Color.Gray;
            }
            else
            {
                btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
                lbl_AI.Text = "Intelligent learning: Enabled";
                lbl_AI.ForeColor = Color.DarkGreen;
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
            showingW1synonyms = !showingW1synonyms;

            if (showingW1synonyms)
            {
                if (currentWordPairID.GetWordPair().Word1Synonyms.Count == 0)
                {
                    MessageBox.Show("No synonyms are added for this word!", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_word2.Focus();
                    return;
                }

                lbl_word1.Text += "\r\n\r\n---Synonyms---";

                foreach (var synonym in currentWordPairID.GetWordPair().Word1Synonyms)
                {
                    lbl_word1.Text += "\r\n" + synonym;
                }

                btn_w1_synonyms.Text = "<--";
            }
            else
            {
                lbl_word1.Text = currentWordPairID.GetWordPair().Word1;
                btn_w1_synonyms.Text = "Synonyms";
            }

            lbl_word2.Focus();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Program.frmWelcome.Location = new Point(Location.X + (Size.Width / 2) - (Program.frmWelcome.Size.Width / 2),
                              Location.Y + (Size.Height / 2) - (Program.frmWelcome.Size.Height / 2)
                            );
            Program.frmWelcome.SetControlStates();
            Program.frmWelcome.Show();
            QuizCore.SaveQuizProgress();
            ConfigManager.SaveConfig();
            onCloseEvent = false;
            Close();
            Program.frmInQuiz = null;
        }

        private void btn_dontAgree_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("If you continue, the translation of this word won't be counted this round to the score, to prevent cheating. Continue?",
                "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.No)
            {
                lbl_word2.Focus();
                return;
            }

            countThisTranslationToProgress = false;
            var fixMenu = new FixQuizErrors(this, currentWordPairID.GetWordPair());
            var result = fixMenu.ShowDialog();
            if (result == DialogResult.OK)
            {
                QuizCore.SaveQuiz();

                if (translationMode == WordPair.TranslationMode.L1_to_L2)
                {
                    lbl_word1.Text = currentWordPairID.GetWordPair().Word1;
                }
                else if (translationMode == WordPair.TranslationMode.L2_to_L1)
                {
                    lbl_word1.Text = currentWordPairID.GetWordPair().Word2;
                }
            }
            else if (result == DialogResult.Abort)
            {
                Close();
                Program.frmInQuiz.Dispose();
                Program.frmInQuiz = null;
            }
            lbl_word2.Focus();
        }
    }
}