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
    public partial class RoundCompleted : AutoThemeableUserControl
    {
        public RoundCompleted(Quiz quiz)
        {
            InitializeComponent();
            SetTheme();

            int cardsShown = quiz.Cards.Where(x => x.GetProgressData(quiz).AskedThisRound).Count();
            double successRate = (double)quiz.ProgressData.CorrectAnswersThisRound / cardsShown;

            lbl_cardsShown.Text = cardsShown.ToString();
            lbl_successRate.Text = Math.Round(successRate * 100).ToString();
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            base.SetTheme(theme);

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                lbl_title.ForeColor = Color.MediumSpringGreen;
            }
            else
            {
                lbl_title.ForeColor = Color.DarkGreen;
            }
        }
    }
}
