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

            rdo_answerFront.Text = Quiz.CardFrontType;
            rdo_answerBack.Text = Quiz.CardBackType;

            rdo_answerFront.Checked = Quiz.ProgressData.AnswerCardSide == QuizProgressData.CardSide.Front;
            rdo_answerBack.Checked = Quiz.ProgressData.AnswerCardSide == QuizProgressData.CardSide.Back;
            chk_intelligentLearning.Checked = !Quiz.ProgressData.FullTestInProgress;
            chk_randomOrderQuestions.Checked = Quiz.ProgressData.AskQuestionsInRandomOrder;

            rdo_answerFront.CheckedChanged += Rdo_answerFront_CheckedChanged;
            chk_randomOrderQuestions.CheckedChanged += Chk_randomOrderQuestions_CheckedChanged;
            chk_intelligentLearning.CheckedChanged += Chk_intelligentLearning_CheckedChanged;
        }

        private void Rdo_answerFront_CheckedChanged(object sender, EventArgs e)
        {
            Quiz.ProgressData.AnswerCardSide = rdo_answerFront.Checked ? QuizProgressData.CardSide.Front : QuizProgressData.CardSide.Back;
            CardPicker.NewRound(Quiz);
            Program.frmInQuiz.SetCard();
            QuizCore.SaveQuizProgress(Quiz);
        }

        private void Chk_intelligentLearning_CheckedChanged(object sender, EventArgs e)
        {
            Quiz.ProgressData.FullTestInProgress = !chk_intelligentLearning.Checked;
            CardPicker.NewRound(Quiz);
            Program.frmInQuiz.SetCard();
            QuizCore.SaveQuizProgress(Quiz);
        }

        private void Btn_advanced_Click(object sender, EventArgs e)
        {
            var frm = new QuizPractiseConfigAdvanced(Quiz);
            frm.ShowDialog();
        }

        private void Chk_randomOrderQuestions_CheckedChanged(object sender, EventArgs e)
        {
            Quiz.ProgressData.AskQuestionsInRandomOrder = chk_randomOrderQuestions.Checked;

            CardPicker.NewRound(Quiz);
            Program.frmInQuiz.SetCard();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
