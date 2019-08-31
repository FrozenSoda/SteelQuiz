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
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizData;
using System.IO;
using SteelQuiz.QuizProgressData;

namespace SteelQuiz
{
    public partial class QuizProgressInfo : AutoThemeableUserControl
    {
        public QuizIdentity QuizIdentity { get; private set; }

        public QuizProgressInfo(QuizIdentity quizIdentity)
        {
            InitializeComponent();

            QuizIdentity = quizIdentity;
            lbl_quizNameHere.Text = Path.GetFileNameWithoutExtension(QuizIdentity.FindQuizPath());

            SetTheme(new WelcomeTheme());
            LoadLearningProgressPercentage();
            LoadWordPairs();
        }

        private void LoadLearningProgressPercentage()
        {
            /*
            if (!QuizCore.Load(QuizIdentity.QuizGuid))
            {
                return;
            }
            */

            //lbl_learningProgressPercentage.Text = Math.Round(QuizCore.QuizProgress.GetSuccessRate() * 100D, 1).ToString() + " %";
            cpb_learningProgress.Value = (int)Math.Floor(QuizCore.QuizProgress.GetSuccessRateStrict() * 100D);
            cpb_learningProgress.Text = cpb_learningProgress.Value.ToString() + " %";
        }

        private void LoadWordPairs()
        {
            var controls = new List<DashboardQuizWordPair>();
            foreach (var wordPair in QuizCore.Quiz.WordPairs)
            {
                controls.Add(new DashboardQuizWordPair(wordPair));
            }

            controls = controls.OrderBy(x => x.LearningProgress).ToList();

            foreach (var c in controls)
            {
                flp_words.Controls.Add(c);
            }
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null || theme.GetType() != typeof(WelcomeTheme))
            {
                theme = new WelcomeTheme();
            }

            base.SetTheme(theme);

            btn_deleteQuiz.ForeColor = Color.LightCoral;
        }

        private void Btn_practiseQuiz_Click(object sender, EventArgs e)
        {
            (ParentForm as Welcome).LoadQuiz(QuizIdentity.FindQuizPath());
        }
    }
}
