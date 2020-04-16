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
using SteelQuiz.QuizData;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class DashboardQuizCard : AutoThemeableUserControl
    {
        private WelcomeTheme WelcomeTheme { get; set; } = new WelcomeTheme();
        public Card Card { get; set; }
        public double SuccessRate { get; set; }

        public DashboardQuizCard(Quiz quiz, Card card)
        {
            InitializeComponent();
            SetTheme(WelcomeTheme);

            Card = card;
            var cardProgressData = Card.GetProgressData(quiz);
            SuccessRate = cardProgressData.GetSuccessRate();

            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * SuccessRate), lbl_learningProgress_bar.Size.Height);
            lbl_learningProgress.Text = Math.Floor(SuccessRate * 100D).ToString() + " %";

            lbl_cardFront.Text = Card.Front;
            lbl_cardBack.Text = Card.Back;
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null || theme.GetType() != typeof(WelcomeTheme))
            {
                theme = new WelcomeTheme();
            }

            var lbl_learningProgress_bar_color = lbl_learningProgress_bar.ForeColor;
            var bc = BackColor;

            base.SetTheme(theme);

            // Revert backcolor (it's handled in QuizProgressInfo)
            BackColor = bc;

            // Revert learning progress bar color (it should not be changed)
            lbl_learningProgress_bar.ForeColor = lbl_learningProgress_bar_color;
        }

        public void UpdateLearningProgressBar()
        {
            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * SuccessRate), lbl_learningProgress_bar.Size.Height);
        }

        private void Lbl_learningProgress_bar_SizeChanged(object sender, EventArgs e)
        {
            //double progress = lbl_learningProgress_bar.Size.Width / (double)Size.Width;
            double progress = SuccessRate;

            lbl_learningProgress_bar.ForeColor = Color.FromArgb(
                255,
                (int)Math.Floor(255 - progress * 255),
                (int)Math.Floor(progress * 255),
                0);
        }

        private void DashboardQuizCard_SizeChanged(object sender, EventArgs e)
        {
            UpdateLearningProgressBar();

            lbl_cardFront.MinimumSize = new Size(Size.Width / 2 - 20, lbl_cardFront.MinimumSize.Height);
            lbl_cardBack.MinimumSize = new Size(Size.Width / 2 - 20, lbl_cardBack.MinimumSize.Height);

            lbl_cardFront.MaximumSize = new Size(Size.Width / 2 - 20, 0);
            lbl_cardBack.MaximumSize = new Size(Size.Width / 2 - 20, 0);

            lbl_cardBack.Location = new Point(lbl_cardFront.Right + 32, lbl_cardBack.Location.Y);
        }

        private void Lbl_card_SizeChanged(object sender, EventArgs e)
        {
            int maxBottom = Math.Max(lbl_cardFront.Bottom, lbl_cardBack.Bottom);
            Size = new Size(Size.Width, maxBottom + 40);
        }
    }
}
