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
    public partial class QuizPractiseConfigAdvanced : AutoThemeableForm
    {
        private Quiz Quiz { get; set; }

        public QuizPractiseConfigAdvanced(Quiz quiz)
        {
            InitializeComponent();
            SetTheme();

            Quiz = quiz;

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

            rdo_last3attemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_last3attemptsIntelligentLearning_CheckedChanged);
            rdo_allAttemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_allAttemptsIntelligentLearning_CheckedChanged);
            rdo_lastNattemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_lastNattemptsIntelligentLearning_CheckedChanged);
            nud_intelligentLearningAttempsCount.ValueChanged += new EventHandler(Nud_intelligentLearningAttempsCount_ValueChanged);
            nud_minAnsTriesSkip.ValueChanged += new EventHandler(nud_minAnsTriesSkip_ValueChanged);
        }

        private void Rdo_last3attemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_last3attemptsIntelligentLearning.Checked)
            {
                Quiz.ProgressData.IntelligentLearningLastAnswersBasisCount = 3;

                if (!Quiz.ProgressData.FullTestInProgress)
                {
                    CardPicker.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                    QuizCore.SaveQuizProgress(Quiz);
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
                    CardPicker.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                    QuizCore.SaveQuizProgress(Quiz);
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
                    CardPicker.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                    QuizCore.SaveQuizProgress(Quiz);
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
                    CardPicker.NewRound(Quiz);
                    Program.frmInQuiz.SetCard();
                    QuizCore.SaveQuizProgress(Quiz);
                }
            }
        }

        private void nud_minAnsTriesSkip_ValueChanged(object sender, EventArgs e)
        {
            Quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion = (int)nud_minAnsTriesSkip.Value;

            if (!Quiz.ProgressData.FullTestInProgress)
            {
                CardPicker.NewRound(Quiz);
                Program.frmInQuiz.SetCard();
                QuizCore.SaveQuizProgress(Quiz);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
