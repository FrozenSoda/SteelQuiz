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
        public WordPair WordPair { get; set; }
        public double LearningProgress { get; set; }

        public DashboardQuizWordPair(WordPair wordPair)
        {
            InitializeComponent();
            SetTheme(new WelcomeTheme());

            WordPair = wordPair;
            LearningProgress = WordPair.GetWordProgData().GetSuccessRateStrict();

            cpb_learningProgress.Value = (int)Math.Floor(LearningProgress * 100d);
            cpb_learningProgress.Text = cpb_learningProgress.Value.ToString() + " %";

            lbl_word1.Text = WordPair.Word1;
            lbl_word2.Text = WordPair.Word2;
        }
    }
}
