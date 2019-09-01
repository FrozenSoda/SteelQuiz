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
    public partial class DashboardQuizWordPair : AutoThemeableUserControl
    {
        private WelcomeTheme WelcomeTheme { get; set; } = new WelcomeTheme();
        public WordPair WordPair { get; set; }
        public double LearningProgress { get; set; }

        public DashboardQuizWordPair(WordPair wordPair)
        {
            InitializeComponent();
            SetTheme(WelcomeTheme);

            WordPair = wordPair;
            var wordProgData = WordPair.GetWordProgData();
            LearningProgress = wordProgData.GetSuccessRate();

            //cpb_learningProgress.Value = (int)Math.Floor(LearningProgress * 100d);
            //cpb_learningProgress.Text = cpb_learningProgress.Value.ToString() + " %";

            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * LearningProgress), lbl_learningProgress_bar.Size.Height);
            lbl_learningProgress.Text = Math.Floor(LearningProgress * 100D).ToString() + " %";

            lbl_word1.Text = WordPair.Word1;
            lbl_word2.Text = WordPair.Word2;
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

            //cpb_learningProgress.BackColor = theme.GetBackColor();
            //cpb_learningProgress.InnerColor = theme.GetBackColor();
            //cpb_learningProgress.ForeColor = theme.GetMainLabelForeColor();
        }

        public void UpdateLearningProgressBar()
        {
            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * LearningProgress), lbl_learningProgress_bar.Size.Height);
        }

        private void Lbl_learningProgress_bar_SizeChanged(object sender, EventArgs e)
        {
            //double progress = lbl_learningProgress_bar.Size.Width / (double)Size.Width;
            double progress = LearningProgress;

            lbl_learningProgress_bar.ForeColor = Color.FromArgb(
                255,
                (int)Math.Floor(255 - progress * 255),
                (int)Math.Floor(progress * 255),
                0);
        }

        private void DashboardQuizWordPair_SizeChanged(object sender, EventArgs e)
        {
            UpdateLearningProgressBar();

            lbl_word1.Size = new Size(Size.Width / 2 - 20, lbl_word1.Size.Height);
            lbl_word2.Size = new Size(Size.Width / 2 - 20, lbl_word2.Size.Height);
            lbl_word2.Location = new Point(lbl_word1.Right + 32, lbl_word2.Location.Y);
        }
    }
}
