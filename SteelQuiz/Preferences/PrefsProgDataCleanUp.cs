﻿/*
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
using System.Threading;

namespace SteelQuiz.Preferences
{
    public partial class PrefsProgDataCleanUp : AutoThemeableUserControl
    {

        public PrefsProgDataCleanUp()
        {
            InitializeComponent();

            SetTheme();
        }

        public override void SetTheme()
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

        private void Btn_analyze_Click(object sender, EventArgs e)
        {
            var t = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    ParentForm.Enabled = false;
                    btn_analyze.Text = "Please wait...";
                }));

                var toRemove = QuizProgDatasToRemove();
                var count = toRemove.Count();

                this.Invoke(new Action(() =>
                {
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

                    btn_analyze.Text = "Analyze";
                    ParentForm.Enabled = true;
                }));
            });
            t.Start();
        }

        private void Btn_cleanUp_Click(object sender, EventArgs e)
        {
            var t = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    ParentForm.Enabled = false;
                    btn_cleanUp.Text = "Please wait...";
                }));

                var bkp = QuizCore.BackupProgress(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION));
                if (!bkp)
                {
                    return;
                }

                CleanUp();

                this.Invoke(new Action(() =>
                {
                    lbl_analysisResult.Text = "Clean up finished!";
                    lbl_analysisResult.Visible = true;

                    btn_cleanUp.Text = "Clean up";
                    ParentForm.Enabled = true;
                }));
            });
            t.Start();
        }

        private void CleanUp()
        {
            IEnumerable<Guid> guidsToRemove = QuizProgDatasToRemove();
            QuizProgDataRoot progDataRoot;
            using (var reader = new StreamReader(QuizCore.PROGRESS_FILE_PATH))
            {
                progDataRoot = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
            }

            var progDatasToRemove = new List<QuizProgData>();

            foreach (var quizProg in progDataRoot.QuizProgDatas)
            {
                var guid = quizProg.QuizGUID;
                if (guidsToRemove.Contains(guid))
                {
                    progDatasToRemove.Add(quizProg);
                }
            }

            foreach (var quizProg in progDatasToRemove)
            {
                progDataRoot.QuizProgDatas.Remove(quizProg);
            }

            using (var writer = new StreamWriter(QuizCore.PROGRESS_FILE_PATH, false))
            {
                writer.Write(JsonConvert.SerializeObject(progDataRoot, Formatting.Indented));
            }
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