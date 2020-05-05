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

using SteelQuiz.QuizData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizPractise
{
    public partial class QuizPractiseConfig : AutoThemeableForm
    {
        private Quiz Quiz { get; set; }

        public QuizPractiseConfig(Quiz quiz)
        {
            InitializeComponent();
            SetTheme();

            Quiz = quiz;

            cmb_cardAnswerSide.Items.Add(Quiz.CardFrontType);
            cmb_cardAnswerSide.Items.Add(Quiz.CardBackType);

            cmb_cardAnswerSide.SelectedItem = Quiz.ProgressData.AnswerCardSide == QuizProgressData.CardSide.Front ? Quiz.CardFrontType : Quiz.CardBackType;

            if (Quiz.ProgressData.FullTestInProgress)
            {
                btn_switchTestMode.Text = "Enable Intelligent Learning";
            }
            else
            {
                btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
            }

            if (Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount == 3)
            {
                rdo_last3attemptsIntelligentLearning.Checked = true;
            }
            else if (Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount == 0)
            {
                rdo_allAttemptsIntelligentLearning.Checked = true;
            }
            else
            {
                rdo_lastNattemptsIntelligentLearning.Checked = true;
                nud_intelligentLearningAttempsCount.Value = Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount;
            }

            nud_minAnsTriesSkip.Value = Quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion;

            chk_randomOrderQuestions.Checked = Quiz.ProgressData.AskQuestionsInRandomOrder;

            cmb_cardAnswerSide.SelectedIndexChanged += new EventHandler(Cmb_cardAnswerSide_SelectedIndexChanged);
            rdo_last3attemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_last3attemptsIntelligentLearning_CheckedChanged);
            rdo_allAttemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_allAttemptsIntelligentLearning_CheckedChanged);
            rdo_lastNattemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_lastNattemptsIntelligentLearning_CheckedChanged);
            nud_intelligentLearningAttempsCount.ValueChanged += new EventHandler(Nud_intelligentLearningAttempsCount_ValueChanged);
            nud_minAnsTriesSkip.ValueChanged += new EventHandler(nud_minAnsTriesSkip_ValueChanged);
            chk_randomOrderQuestions.CheckedChanged += Chk_randomOrderQuestions_CheckedChanged;
        }

        private void Btn_dontAgree_Click(object sender, EventArgs e)
        {
            //Program.frmInQuiz.FixQuizErrors();
        }

        private void Btn_switchTestMode_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Warning: The state of the current round will be lost (current word, word count etc).\r\n\r\nProceed?",
                "Switch mode - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                Quiz.ProgressData.FullTestInProgress = !Quiz.ProgressData.FullTestInProgress;

                QuestionSelector.NewRound(Quiz);
                Program.frmInQuiz.SetCard();

                if (Quiz.ProgressData.FullTestInProgress)
                {
                    btn_switchTestMode.Text = "Enable Intelligent Learning";
                }
                else
                {
                    btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
                }
            }
        }

        private void Cmb_cardAnswerSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Quiz.ProgressData.AnswerLanguage = cmb_langAns.SelectedItem.ToString();
            if (cmb_cardAnswerSide.SelectedItem.ToString() == Quiz.CardFrontType)
            {
                Quiz.ProgressData.AnswerCardSide = QuizProgressData.CardSide.Front;
            }
            else if (cmb_cardAnswerSide.SelectedItem.ToString() == Quiz.CardBackType)
            {
                Quiz.ProgressData.AnswerCardSide = QuizProgressData.CardSide.Back;
            }

            QuizCore.SaveQuizProgress(Quiz);

            QuestionSelector.NewRound(Quiz);
            Program.frmInQuiz.SetCard();
        }

        private void Rdo_last3attemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_last3attemptsIntelligentLearning.Checked)
            {
                Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount = 3;

                if (!Quiz.ProgressData.FullTestInProgress)
                {
                    QuestionSelector.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                }
            }
        }

        private void Rdo_allAttemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_allAttemptsIntelligentLearning.Checked)
            {
                Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount = 0;

                if (!Quiz.ProgressData.FullTestInProgress)
                {
                    QuestionSelector.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                }
            }
        }

        private void Rdo_lastNattemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_lastNattemptsIntelligentLearning.Checked)
            {
                Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount = (int)nud_intelligentLearningAttempsCount.Value;

                if (!Quiz.ProgressData.FullTestInProgress)
                {
                    QuestionSelector.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                }
            }
        }

        private void Nud_intelligentLearningAttempsCount_ValueChanged(object sender, EventArgs e)
        {
            if (rdo_lastNattemptsIntelligentLearning.Checked)
            {
                Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount = (int)nud_intelligentLearningAttempsCount.Value;

                if (!Quiz.ProgressData.FullTestInProgress)
                {
                    QuestionSelector.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                }
            }
        }

        private void Chk_randomOrderQuestions_CheckedChanged(object sender, EventArgs e)
        {
            Quiz.ProgressData.AskQuestionsInRandomOrder = chk_randomOrderQuestions.Checked;

            QuestionSelector.NewRound(Quiz);
            Program.frmInQuiz.SetCard();
        }

        private void nud_minAnsTriesSkip_ValueChanged(object sender, EventArgs e)
        {
            Quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion = (int)nud_minAnsTriesSkip.Value;

            if (!Quiz.ProgressData.FullTestInProgress)
            {
                QuestionSelector.NewRound(Quiz);
                Program.frmInQuiz.SetCard();
            }
        }
    }
}
