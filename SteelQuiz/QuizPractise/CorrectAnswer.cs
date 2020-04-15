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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizPractise
{
    public partial class CorrectAnswer : AutoThemeableUserControl
    {
        public CorrectAnswer(Card card, Quiz quiz, StringComp.CorrectCertainty certainty)
        {
            InitializeComponent();
            SetTheme();

            lbl_cardQuestionSideType.Text = $"{(quiz.ProgressData.AnswerCardSide == QuizProgressData.CardSide.Front ? quiz.CardBackType : quiz.CardFrontType)}:";
            lbl_cardSideToAsk.Text = card.GetSideToAsk(quiz);
            toolTip1.SetToolTip(lbl_cardSideToAsk, card.GetSideToAsk(quiz));

            AutoShrinkFont(lbl_cardSideToAsk, 8);

            lbl_cardAnswerSideType.Text = $"{(quiz.ProgressData.AnswerCardSide == QuizProgressData.CardSide.Front ? quiz.CardFrontType : quiz.CardBackType)}:";
            lbl_cardSideToAnswer.Text = card.GetSideToAnswer(quiz);
            toolTip1.SetToolTip(lbl_cardSideToAnswer, card.GetSideToAnswer(quiz));

            AutoShrinkFont(lbl_cardSideToAnswer, 8);

            if (certainty == StringComp.CorrectCertainty.CompletelyCorrect)
            {
                lbl_certainty.Text = "Correct!";

                lbl_cardAnswerSideType.Visible = false;
                lbl_cardSideToAnswer.Visible = false;
            }
            else if (certainty == StringComp.CorrectCertainty.ProbablyCorrect)
            {
                lbl_certainty.Text = "Probably correct!";
            }
            else if (certainty == StringComp.CorrectCertainty.MaybeCorrect)
            {
                lbl_certainty.Text = "Might be correct!";
            }
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            base.SetTheme(theme);

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                lbl_certainty.ForeColor = Color.MediumSpringGreen;
            }
            else
            {
                lbl_certainty.ForeColor = Color.DarkGreen;
            }
        }

        private void AutoShrinkFont(Label lbl, int minimumSize)
        {
            // Method doesn't work without autosize
            bool disableAutoSize = false;
            if (!lbl.AutoSize)
            {
                lbl.AutoSize = true;
                disableAutoSize = true;
            }

            while (lbl.Width < TextRenderer.MeasureText(lbl.Text,
                new Font(lbl.Font.FontFamily, lbl.Font.Size, lbl.Font.Style)).Width && lbl.Font.Size > minimumSize)
            {
                lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size - 0.5f, lbl.Font.Style);
            }

            // Restore autosize to previous value
            if (disableAutoSize)
            {
                lbl.AutoSize = false;
            }
        }
    }
}
