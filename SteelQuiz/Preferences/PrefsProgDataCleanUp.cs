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
using SteelQuiz.Extensions;
using SteelQuiz.QuizProgressData;
using System.IO;
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.Preferences
{
    public partial class PrefsProgDataCleanUp : AutoThemeableUserControl, IPreferenceCategory
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();

        public PrefsProgDataCleanUp()
        {
            InitializeComponent();

            LoadPreferences();
            SetTheme();
        }

        protected override void SetTheme()
        {
            base.SetTheme();

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                lbl_analysisResult.ForeColor = Color.FromArgb(0, 191, 255);
            }
            else
            {
                lbl_analysisResult.ForeColor = Color.FromArgb(0, 191, 255);
            }
        }

        public void LoadPreferences()
        {
            
        }

        private void Btn_analyze_Click(object sender, EventArgs e)
        {
            var toRemove = QuizProgDatasToRemove();
            var count = toRemove.Count();
            if (count == 0)
            {
                lbl_analysisResult.Text = "Analysis result: Progress data for 0 quizzes can be removed";
            }
            else if (count == 1)
            {
                lbl_analysisResult.Text = "Analysis result: Progress data for 1 quiz can be removed";
            }
            else if (count > 1)
            {
                lbl_analysisResult.Text = $"Analysis result: Progress data for {count} quizzes can be removed";
            }
            lbl_analysisResult.Visible = true;
        }

        private void Btn_cleanUp_Click(object sender, EventArgs e)
        {

        }

        private IEnumerable<Guid> QuizProgDatasToRemove()
        {
            List<Guid> toRemove = new List<Guid>();

            QuizProgDataRoot progDataRoot;
            using (var reader = new StreamReader(QuizCore.PROGRESS_FILE_PATH))
            {
                progDataRoot = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
            }

            foreach (var quizProg in progDataRoot.QuizProgDatas)
            {
                var guid = quizProg.QuizGUID;
                var quizFound = false;

                foreach (var quizFile in Directory.GetFiles(QuizCore.QUIZ_FOLDER, $"*{QuizCore.QUIZ_EXTENSION}", SearchOption.TopDirectoryOnly))
                {
                    Quiz quiz;
                    using (var reader = new StreamReader(quizFile))
                    {
                        quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
                    }

                    if (quiz.GUID.Equals(guid))
                    {
                        quizFound = true;
                        break;
                    }
                }

                if (!quizFound)
                {
                    toRemove.Add(guid);
                }
            }

            return toRemove;
        }
    }
}
