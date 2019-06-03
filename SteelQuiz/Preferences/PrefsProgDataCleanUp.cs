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
using System.Threading;

namespace SteelQuiz.Preferences
{
    public partial class PrefsProgDataCleanUp : AutoThemeableUserControl
    {

        public PrefsProgDataCleanUp()
        {
            InitializeComponent();

            SetTheme();

#warning do not clean up cloud stored progress data for local quizzes on another computer
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
                        lbl_analysisResult.Text = "Analysis result: Clean up is not required - there is nothing to clean up";
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
            var msg = MessageBox.Show("Perform clean up?\r\n\r\nWarning: Quizzes removed from the quiz folder, will have their progress data removed", "SteelQuiz",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (msg == DialogResult.Cancel)
            {
                return;
            }

            var t = new Thread(() =>
            {
                this.Invoke(new Action(() =>
                {
                    ParentForm.Enabled = false;
                    btn_cleanUp.Text = "Please wait...";
                }));

                var bkp = QuizCore.BackupProgress(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION));
                if (bkp)
                {
                    int removalCount = CleanUp();

                    this.Invoke(new Action(() =>
                    {
                        if (removalCount == 0)
                        {
                            lbl_analysisResult.Text = $"Clean up not required - there is nothing to remove";
                        }
                        else if (removalCount == 1)
                        {
                            lbl_analysisResult.Text = $"Clean up finished! Progress data for {removalCount} quiz were removed";
                        }
                        else if (removalCount > 1)
                        {
                            lbl_analysisResult.Text = $"Clean up finished! Progress data for {removalCount} quizzes were removed";
                        }
                        lbl_analysisResult.Visible = true;

                        btn_cleanUp.Text = "Clean up";
                        ParentForm.Enabled = true;
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        lbl_analysisResult.Text = "Clean up could not start";
                        lbl_analysisResult.Visible = true;

                        btn_cleanUp.Text = "Clean up";
                        ParentForm.Enabled = true;
                    }));
                }
            });
            t.Start();
        }

        private int CleanUp()
        {
            IEnumerable<Guid> guidsToRemove = QuizProgDatasToRemove();
            QuizProgDataRoot progDataRoot;
            using (var reader = new StreamReader(ConfigManager.Config.SyncConfig.QuizProgressPath))
            {
                progDataRoot = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
            }

            var progDatasToRemove = new List<QuizProgData>();

            int removalCount = 0;
            foreach (var quizProg in progDataRoot.QuizProgDatas)
            {
                var guid = quizProg.QuizGUID;
                if (guidsToRemove.Contains(guid))
                {
                    progDatasToRemove.Add(quizProg);
                    ++removalCount;
                }
            }

            foreach (var quizProg in progDatasToRemove)
            {
                progDataRoot.QuizProgDatas.Remove(quizProg);
            }

            using (var writer = new StreamWriter(ConfigManager.Config.SyncConfig.QuizProgressPath, false))
            {
                writer.Write(JsonConvert.SerializeObject(progDataRoot, Formatting.Indented));
            }

            return removalCount;
        }

        private IEnumerable<Guid> QuizProgDatasToRemove()
        {
            List<Guid> toRemove = new List<Guid>();

            QuizProgDataRoot progDataRoot;
            using (var reader = new StreamReader(ConfigManager.Config.SyncConfig.QuizProgressPath))
            {
                progDataRoot = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
            }

            foreach (var quizProg in progDataRoot.QuizProgDatas)
            {
                var guid = quizProg.QuizGUID;
                var quizFound = false;

                var breakQuizFolders = false;
                foreach (var quizFolder in ConfigManager.Config.SyncConfig.QuizFolders)
                {
                    if (breakQuizFolders)
                    {
                        break;
                    }

                    foreach (var quizFile in Directory.GetFiles(quizFolder, $"*{QuizCore.QUIZ_EXTENSION}", SearchOption.TopDirectoryOnly))
                    {
                        Quiz quiz;
                        using (var reader = new StreamReader(quizFile))
                        {
                            quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
                        }

                        if (quiz.GUID.Equals(guid))
                        {
                            quizFound = true;
                            breakQuizFolders = true;
                            break;
                        }
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
