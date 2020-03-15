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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.Extensions;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;
using SteelQuiz.ThemeManager.Colors;
using static SteelQuiz.Welcome;

namespace SteelQuiz.QuizPractise
{
    public partial class InQuiz : AutoThemeableForm
    {
        private GeneralTheme GeneralTheme = new GeneralTheme();

        private QuizPractiseMode GameMode { get; set; }
        private WordPair CurrentWordPair { get; set; } = null;
        private string CurrentInput { get; set; } = "";

        public bool ExitAppOnClose { get; set; } = true;
        private bool PerformOnCloseEvents { get; set; } = true;

        private bool WaitingForEnter { get; set; } = false;
        private bool UserCopyingWord { get; set; } = false;
        private bool CountThisTranslationToProgress { get; set; } = true; // false if the user clicked Fix Quiz Errors, as the answer is displayed there. Will become true as a new word is selected
        private bool ShowingW1synonyms { get; set; } = false;

        private MultiAnswer MultiAns { get; set; } = null;

        public InQuiz(QuizPractiseMode quizPractiseMode, bool welcomeLocationInitialized = true)
        {
            InitializeComponent();

            WindowState = Program.frmWelcome.WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                Size = Program.frmWelcome.Size;
            }
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

            GameMode = quizPractiseMode;

            lbl_lang1.Text = QuizCore.QuizProgress.QuestionLanguage;
            lbl_lang2.Text = QuizCore.QuizProgress.AnswerLanguage;

            this.Text += $" | v{Application.ProductVersion}";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += " PRE-RELEASE";
            }
            NewWord(false);
            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                lbl_intelligentLearning.Text = "Intelligent Learning: Disabled";
            }
            else
            {
                lbl_intelligentLearning.Text = "Intelligent Learning: Enabled";
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

            btn_knewAnswerYES.BackColor = Color.Green;
            btn_knewAnswerNO.BackColor = Color.Maroon;

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                btn_cfg.BackgroundImage = Properties.Resources.gear_1077563_white_with_bigger_border_512x512;
            }
            else
            {
                btn_cfg.BackgroundImage = Properties.Resources.gear_1077563_black_with_bigger_border_512x512;
            }
        }

        public void NewWord(bool newRoundMsg = true)
        {
            Debug.WriteLine("InQuiz.NewWord()");

            WaitingForEnter = false;
            //lbl_lang1.Text = QuizCore.Quiz.Language1;
            lbl_lang1.Text = QuizCore.QuizProgress.QuestionLanguage;
            lbl_lang2.Text = QuizCore.QuizProgress.AnswerLanguage;
            lbl_word2.Text = "";

            foreach (var c in lbl_word1.Controls.OfType<WrongAnswer>())
            {
                c.Dispose();
            }
            foreach (var c in lbl_word1.Controls.OfType<ProbablyCorrectAnswer>())
            {
                c.Dispose();
            }

            if (MultiAns == null || MultiAns.AnswersProvided == CurrentWordPair.GetRequiredSynonyms().Count())
            {
                CountThisTranslationToProgress = true;
                MultiAns?.Dispose();
                MultiAns = null;

                CurrentWordPair = QuestionSelector.GenerateWordPair();
                if (CurrentWordPair == null)
                {
                    NewRound(newRoundMsg);
                    return;
                }

                lbl_word1.ForeColor = GeneralTheme.GetMainLabelForeColor();

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

                if (CurrentWordPair.GetRequiredSynonyms().Count() > 1)
                {
                    //AnswersAlreadyEntered?.Clear();
                    //AnswersAlreadyEntered = new List<string>();
                    MultiAns?.Dispose();
                    MultiAns = new MultiAnswer();
                    lbl_word2.Controls.Add(MultiAns);
                    MultiAns.Dock = DockStyle.Fill;
                    MultiAns.Location = new Point(0, 0);
                    if (GameMode == QuizPractiseMode.Flashcards)
                    {
                        MultiAns.Click += (sender, e) =>
                        {
                            MultiAnsReveal();
                        };
                        MultiAns.CurrentLabel.Click += (sender, e) =>
                        {
                            MultiAnsReveal();
                        };
                        MultiAns.CurrentLabel.Text = "Press here to reveal";
                    }
                    MultiAns.Show();

                    bool first = true;
                    bool found = false;
                    //foreach (var wp in CurrentWordPair.GetRequiredSynonyms().Where(x => x != CurrentWordPair && x.GetWordProgData().AskedThisRound))

                    // (Re)add correct answers to MultiAns list, as it's been disposed and recreated
                    foreach (var wp in CurrentWordPair.GetRequiredSynonyms().Where(x => x.GetWordProgData().AskedThisRound))
                    {
                        found = true;

                        if (first)
                        {
                            first = false;

                            MultiAns.CurrentLabel.Text = wp.Answer;
                            MultiAns.CurrentLabel.Show();
                        }
                        else
                        {
                            var lbl = MultiAns.CurrentLabel.Clone();
                            if (GameMode == QuizPractiseMode.Flashcards)
                            {
                                lbl.Click += (sender, e) =>
                                {
                                    MultiAnsReveal();
                                };
                            }
                            lbl.Text = wp.Answer;
                            lbl.Show();
                        }
                    }

                    if (found)
                    {
                        var lbl = MultiAns.CurrentLabel.Clone();
                        if (GameMode == QuizPractiseMode.Flashcards)
                        {
                            lbl.Click += (sender, e) =>
                            {
                                MultiAnsReveal();
                            };
                        }
                        if (GameMode == QuizPractiseMode.Writing)
                        {
                            lbl.Text = "Enter your answers...";
                        }
                        else if (GameMode == QuizPractiseMode.Flashcards)
                        {
                            lbl.Text = "Press here to reveal";
                        }
                        lbl.Show();
                    }
                }
                else
                {
                    if (GameMode == QuizPractiseMode.Writing)
                    {
                        lbl_word2.Text = "Enter your answer...";
                    }
                    else if (GameMode == QuizPractiseMode.Flashcards)
                    {
                        lbl_word2.Text = "Press here to reveal";
                    }
                }
            }
            else
            {
                lbl_word1.ForeColor = GeneralTheme.GetMainLabelForeColor();
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

                var lbl = MultiAns.CurrentLabel.Clone();
                if (GameMode == QuizPractiseMode.Writing)
                {
                    lbl.Text = "Enter your answers...";
                }
                else if (GameMode == QuizPractiseMode.Flashcards)
                {
                    lbl.Click += (sender, e) =>
                    {
                        MultiAnsReveal();
                    };
                    lbl.Text = "Press here to reveal";
                }
            }
        }

        private void NewRound(bool newRoundMsg = true)
        {
            Debug.WriteLine("InQuiz.NewRound()");

            CountThisTranslationToProgress = true;
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";

            foreach (var c in lbl_word1.Controls.OfType<WrongAnswer>())
            {
                c.Dispose();
            }
            foreach (var c in lbl_word1.Controls.OfType<ProbablyCorrectAnswer>())
            {
                c.Dispose();
            }

            MultiAns?.Dispose();
            MultiAns = null;

            lbl_word1.ForeColor = GeneralTheme.GetMainLabelForeColor();

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                newRoundMsg = false;
            }

            QuizCore.QuizProgress.CorrectAnswersThisRound = 0;
            QuestionSelector.NewRound();

            if (newRoundMsg)
            {
                lbl_lang1.Text = "Info";
                
                if (GameMode == QuizPractiseMode.Writing)
                {
                    lbl_word1.Text = "Round completed! Press ENTER to continue";
                }
                else if (GameMode == QuizPractiseMode.Flashcards)
                {
                    lbl_word1.Text = "Round completed! Click here to continue";
                }
                WaitingForEnter = true;
            }
            else
            {
                WaitingForEnter = false;

                NewWord(newRoundMsg);
            }

            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
        }

        /// <summary>
        /// Retrieves a collection of answers already entered in a multi-answer question
        /// </summary>
        /// <returns>Returns the collection</returns>
        private IEnumerable<WordPair> MultiAnswersAlreadyEntered()
        {
            return CurrentWordPair.GetRequiredSynonyms().Where(x => x.GetWordProgData().AskedThisRound);
        }

        private void CheckWord(bool flashcardsCorrect = false)
        {
            lbl_lang1.Text = "Info";

            WordPair.AnswerDiff ansDiff = null;
            if (GameMode == QuizPractiseMode.Writing)
            {
                if (MultiAns == null)
                {
                    ansDiff = CurrentWordPair.AnswerCheck(CurrentInput, null, CountThisTranslationToProgress && !UserCopyingWord);
                }
                else
                {
                    ansDiff = CurrentWordPair.AnswerCheck(CurrentInput, MultiAnswersAlreadyEntered().Select(x => x.Answer),
                        CountThisTranslationToProgress && !UserCopyingWord);
                }
            }

            if ((GameMode == QuizPractiseMode.Flashcards && flashcardsCorrect) || (GameMode == QuizPractiseMode.Writing && ansDiff.Correct()))
            {
                foreach (var c in lbl_word1.Controls.OfType<WrongAnswer>())
                {
                    c.Dispose();
                }
                foreach (var c in lbl_word1.Controls.OfType<ProbablyCorrectAnswer>())
                {
                    c.Dispose();
                }

                /*
                if (MultiAns != null)
                {
                    AnswersAlreadyEntered.Add(ansDiff.MostSimilarAnswer);
                }
                */

                if (GameMode == QuizPractiseMode.Writing)
                {
                    //if (!mismatch.AskingForSynonym)
                    if (!UserCopyingWord)
                    {
                        ++QuizCore.QuizProgress.CorrectAnswersThisRound;

                        QuizCore.SaveQuizProgress();
                    }

                    if (ansDiff.Certainty == StringComp.CorrectCertainty.CompletelyCorrect)
                    {
                        lbl_word1.Text = "Correct! Press ENTER to continue";
                        if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
                        {
                            lbl_word1.ForeColor = Color.MediumSpringGreen;
                        }
                        else
                        {
                            lbl_word1.ForeColor = Color.DarkGreen;
                        }
                    }
                    else if (ansDiff.Certainty == StringComp.CorrectCertainty.ProbablyCorrect)
                    {
                        var probablyCorrectAns = new ProbablyCorrectAnswer(CurrentWordPair.Question, QuizCore.QuizProgress.QuestionLanguage, ansDiff.WordPair.Answer, QuizCore.QuizProgress.AnswerLanguage,
                            "Probably correct!");
                        lbl_word1.Controls.Add(probablyCorrectAns);
                        probablyCorrectAns.Dock = DockStyle.Fill;
                        probablyCorrectAns.Location = new Point(0, 0);
                        probablyCorrectAns.Show();
                    }
                    else if (ansDiff.Certainty == StringComp.CorrectCertainty.MaybeCorrect)
                    {
                        var probablyCorrectAns = new ProbablyCorrectAnswer(CurrentWordPair.Question, QuizCore.QuizProgress.QuestionLanguage, ansDiff.WordPair.Answer, QuizCore.QuizProgress.AnswerLanguage,
                            "Might be correct!");
                        lbl_word1.Controls.Add(probablyCorrectAns);
                        probablyCorrectAns.Dock = DockStyle.Fill;
                        probablyCorrectAns.Location = new Point(0, 0);
                        probablyCorrectAns.Show();
                    }
                }
                else if (GameMode == QuizPractiseMode.Flashcards)
                {
                    ++QuizCore.QuizProgress.CorrectAnswersThisRound;
                    CurrentWordPair.GetWordProgData().AddWordTry(new WordTry(true));
                    //CurrentWordPair.GetWordProgData().AskedThisRound = true;
                    //CurrentWordPair.GetRequiredSynonyms().Where(x => !x.GetWordProgData().AskedThisRound).First().GetWordProgData().AskedThisRound = true;
                    CurrentWordPair.GetRequiredSynonyms().Select(x => x.GetWordProgData()).Where(x => !x.AskedThisRound).First().AskedThisRound = true;

                    if (CurrentWordPair.GetRequiredSynonyms().Select(x => x.GetWordProgData().AskedThisRound).All(x => x == true))
                    {
                        QuizCore.QuizProgress.SetCurrentWordPair(null);
                    }

                    QuizCore.SaveQuizProgress();
                }

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
                else if (!QuizCore.QuizProgress.FullTestInProgress && QuizCore.GetTotalWordsThisRound() == QuizCore.QuizProgress.CorrectAnswersThisRound)
                {
                    bool allLearned100 = true;
                    foreach (var word in QuizCore.QuizProgress.WordProgDatas)
                    {
                        if (word.GetLearningProgress() < 1 || word.GetWordTriesCount() < WordProgData.WORD_TRIES_FOR_LEARNING_PROGRESS_DEFAULT)
                        {
                            allLearned100 = false;
                        }
                    }

                    if (allLearned100)
                    {
                        if (QuestionSelector.SkipNextMasterNotice == 0)
                        {
                            QuizCore.QuizProgress.MasterNoticeShowed = true;
                            var msg = MessageBox.Show("Congratulations! It seems that you have mastered this quiz. " +
                                "Repeat it to make sure you don't forget it, and don't remember to do a full test of the words to make sure you still know them all."
                                + "\r\n\r\nPerform a full test now?",
                                "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (msg == DialogResult.Yes)
                            {
                                Program.frmInQuiz.SwitchIntelligentLearningMode();

                                WaitingForEnter = false;
                                UserCopyingWord = false;

                                return;
                            }
                            else
                            {
                                QuestionSelector.SkipNextMasterNotice += 2;
                            }
                        }
                        else
                        {
                            QuestionSelector.SkipNextMasterNotice -= 1;
                        }
                    }
                }

                if (GameMode == QuizPractiseMode.Writing)
                {
                    WaitingForEnter = true;
                    UserCopyingWord = false;
                }
            }
            else
            {
                foreach (var c in lbl_word1.Controls.OfType<WrongAnswer>())
                {
                    c.Dispose();
                }
                foreach (var c in lbl_word1.Controls.OfType<ProbablyCorrectAnswer>())
                {
                    c.Dispose();
                }

                if (GameMode == QuizPractiseMode.Writing)
                {
                    var wrongAnswer = new WrongAnswer(CurrentWordPair.Question, QuizCore.QuizProgress.QuestionLanguage, ansDiff.WordPair.Answer, QuizCore.QuizProgress.AnswerLanguage);
                    lbl_word1.Controls.Add(wrongAnswer);
                    wrongAnswer.Location = new Point(0, 0);
                    wrongAnswer.Dock = DockStyle.Fill;
                    wrongAnswer.Show();
                    
                    UserCopyingWord = true;
                    CurrentInput = "";

                    if (MultiAns == null)
                    {
                        if (GameMode == QuizPractiseMode.Writing)
                        {
                            lbl_word2.Text = "Enter your answer...";
                        }
                        else if (GameMode == QuizPractiseMode.Flashcards)
                        {
                            lbl_word2.Text = "Press here to reveal";
                        }
                    }
                    else
                    {
                        if (GameMode == QuizPractiseMode.Writing)
                        {
                            MultiAns.CurrentLabel.Text = "Enter your answer...";
                        }
                        else if (GameMode == QuizPractiseMode.Flashcards)
                        {
                            MultiAns.CurrentLabel.Text = "Press here to reveal";
                        }
                    }
                }
                else if (GameMode == QuizPractiseMode.Flashcards)
                {
                    CurrentWordPair.GetWordProgData().AddWordTry(new WordTry(false));
                    //CurrentWordPair.GetWordProgData().AskedThisRound = true;
                    //CurrentWordPair.GetRequiredSynonyms().Where(x => !x.GetWordProgData().AskedThisRound).First().GetWordProgData().AskedThisRound = true;
                    CurrentWordPair.GetRequiredSynonyms().Select(x => x.GetWordProgData()).Where(x => !x.AskedThisRound).First().AskedThisRound = true;

                    if (CurrentWordPair.GetRequiredSynonyms().Select(x => x.GetWordProgData().AskedThisRound).All(x => x == true))
                    {
                        QuizCore.QuizProgress.SetCurrentWordPair(null);
                    }

                    QuizCore.SaveQuizProgress();
                }
            }
        }

        private void InQuiz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GameMode != QuizPractiseMode.Writing)
            {
                return;
            }

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

            if (updateInputLbl && !WaitingForEnter)
            {
                if (MultiAns == null)
                {
                    lbl_word2.Text = CurrentInput;
                }
                else
                {
                    MultiAns.CurrentLabel.Text = CurrentInput;
                }
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
            //skipNewRoundMsg = true;
            QuizCore.QuizProgress.MasterNoticeShowed = false;
            QuizCore.QuizProgress.FullTestInProgress = !QuizCore.QuizProgress.FullTestInProgress;
            //QuestionSelector.SkipNextMasterNotice = !QuizCore.QuizProgress.FullTestInProgress;
            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                QuestionSelector.SkipNextMasterNotice += 2;
            }

            foreach (var c in lbl_word1.Controls.OfType<WrongAnswer>())
            {
                c.Dispose();
            }
            foreach (var c in lbl_word1.Controls.OfType<ProbablyCorrectAnswer>())
            {
                c.Dispose();
            }

            MultiAns?.Dispose();
            MultiAns = null;

            if (callGenerationFunctions)
            {
                QuestionSelector.NewRound();
                NewWord(false);
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
            if (GameMode == QuizPractiseMode.Flashcards && CurrentWordPair != null)
            {
                MultiAnsReveal();
            }

            lbl_word2.Focus();
        }

        private void lbl_word1_Click(object sender, EventArgs e)
        {
            if (WaitingForEnter)
            {
                WaitingForEnter = false;
                NewWord();
            }

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

            Program.frmWelcome.WindowState = WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                Program.frmWelcome.Size = Size;
            }
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
            if (GameMode != QuizPractiseMode.Writing)
            {
                return;
            }

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

        private void btn_knewAnswerYES_Click(object sender, EventArgs e)
        {
            CheckWord(true);
            NewWord();
            pnl_knewAnswer.Visible = false;
        }

        private void btn_knewAnswerNO_Click(object sender, EventArgs e)
        {
            CheckWord(false);
            NewWord();
            pnl_knewAnswer.Visible = false;
        }

        private void pnl_word2_Click(object sender, EventArgs e)
        {
            //if (GameMode == QuizPractiseMode.Flashcards && CurrentWordPair != null)
            if (GameMode == QuizPractiseMode.Flashcards)
            {
                MultiAnsReveal();
            }
        }

        private void MultiAnsReveal()
        {
            if (WaitingForEnter)
            {
                WaitingForEnter = false;
                NewWord();
                return;
            }

            if (MultiAns != null)
            {
                MultiAns.CurrentLabel.Text = CurrentWordPair.GetRequiredSynonyms().Where(x => !x.GetWordProgData().AskedThisRound).First().Answer;
            }
            else
            {
                lbl_word2.Text = CurrentWordPair.Answer;
            }
            pnl_knewAnswer.Visible = true;
        }

        private void InQuiz_SizeChanged(object sender, EventArgs e)
        {
            //flp_word1.Size = new Size(Size.Width - 598, Size.Height - 244);
            //flp_word2.Location = new Point(Size.Width - 469, flp_word2.Location.Y);
            //flp_word2.Size = new Size(Size.Width - 598, Size.Height - 244);
        }
    }
}