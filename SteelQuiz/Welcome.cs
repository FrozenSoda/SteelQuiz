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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Microsoft.Win32;
using RegistryUtils;
using SteelQuiz.Animations;
using SteelQuiz.Extensions;
using SteelQuiz.QuizData;
using SteelQuiz.QuizImport;
using SteelQuiz.QuizImport.Guide;
using SteelQuiz.QuizPractise;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class Dashboard : Form, ThemeManager.IThemeable
    {
        private WelcomeTheme WelcomeTheme;
        private WelcomeMessage[] welcomeMessages = new WelcomeMessage[]
        {
            new WelcomeMessage(@"Hi \firstname!",
                new Func<bool>(() => { return ConfigManager.Config.ShowNameOnWelcomeScreen; })),
            new WelcomeMessage(@"Hello \firstname!",
                new Func<bool>(() => { return ConfigManager.Config.ShowNameOnWelcomeScreen; })),
            new WelcomeMessage(@"Ready for some studying \firstname?",
                null),
            new WelcomeMessage(@"Welcome \firstname!",
                null, new Func<bool>(() => { return Program.frmWelcome == null || !Program.frmWelcome.firstWelcomeMsgEvalCompleted; })),
            new WelcomeMessage(@"Welcome back \firstname!",
                new Func<bool>(() => { return ConfigManager.Config.Statistics.LaunchCount.Data > 1; }),
                new Func<bool>(() => { return Program.frmWelcome == null || !Program.frmWelcome.firstWelcomeMsgEvalCompleted; })),
            new WelcomeMessage(@"Good morning \firstname!",
                new Func<bool>(() => { return DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 12; })),
            new WelcomeMessage(@"Good afternoon \firstname!",
                new Func<bool>(() => { return DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17; })),
            new WelcomeMessage(@"Good evening \firstname!",
                new Func<bool>(() => { return DateTime.Now.Hour > 17 && DateTime.Now.Hour <= 22; }))
        };
        private WelcomeMessage CurrentWelcomeMessage { get; set; }
        public bool firstWelcomeMsgEvalCompleted = false;

        private RegistryMonitor themeMonitor;

        public Dashboard()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += " PRE-RELEASE";
            }

            SetControlStates();

            ofd_loadQuiz.InitialDirectory = ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder;

            if (Util.WinVer.WindowsVersion().Major >= 10) // if user runs Windows 10
            {
                if (ConfigManager.Config.SyncWin10Theme)
                {
                    if (!PullWin10Theme())
                    {
                        SetTheme();
                    }
                }
                else
                {
                    SetTheme();
                }

                themeMonitor = new RegistryMonitor(RegistryHive.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
                themeMonitor.RegChanged += ThemeMonitor_RegChanged;
                themeMonitor.Error += ThemeMonitor_Error;
                themeMonitor.Start();
            }
            else
            {
                SetTheme();
            }

            Updater.Update(Updater.UpdateMode.Normal);

            ConfigManager.ChkSetupForFirstUse();

            UpdateCfg();

            QuizCore.LoadQuizAccessData();
            PopulateQuizList();
        }

        public void PopulateQuizList()
        {
            foreach (var c in flp_lastQuizzes.Controls.OfType<Control>())
            {
                c.Dispose();
            }
            flp_lastQuizzes.Controls.Clear();

            foreach (var q in pnl_quizInfo.Controls.OfType<QuizOverview>())
            {
                q.Dispose();
            }

            pnl_quizInfo.Controls.Clear();
            pnl_quizInfo.Controls.Add(pnl_welcome);

            foreach (var quizAccessTimePair in QuizCore.QuizAccessTimes.OrderByDescending(x => x.Value.Ticks))
            {
                var quizIdentity = QuizCore.QuizIdentities[quizAccessTimePair.Key];

                var recentQuiz = new RecentQuiz(quizIdentity);
                flp_lastQuizzes.Controls.Add(recentQuiz);
            }
        }

        /// <summary>
        /// Removes a quiz from the list
        /// </summary>
        public void RemoveQuiz(Guid quizGuid, bool save = true)
        {
            QuizCore.QuizAccessTimes.Remove(quizGuid);

            if (save)
            {
                QuizCore.SaveQuizData();
            }
            
            foreach (var c in flp_lastQuizzes.Controls.OfType<RecentQuiz>())
            {
                if (c.QuizIdentity.QuizGuid == quizGuid)
                {
                    flp_lastQuizzes.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }

            foreach (var c in pnl_quizInfo.Controls.OfType<QuizOverview>())
            {
                if (c.QuizIdentity.QuizGuid == quizGuid)
                {
                    pnl_quizInfo.Controls.Remove(c);
                    c.Dispose();
                    break;
                }
            }
        }

        public bool SwitchQuizProgressInfo(QuizIdentity quizIdentity)
        {
            var quizPath = quizIdentity.FindQuizPath();
            if (quizPath == null)
            {
                return false;
            }

            if (!QuizCore.Load(quizPath))
            {
                return false;
            }

            foreach (var q in pnl_quizInfo.Controls.OfType<QuizOverview>())
            {
                if (q.QuizIdentity.QuizGuid == quizIdentity.QuizGuid)
                {
                    q.Size = pnl_quizInfo.Size;
                    q.UpdateLearningProgressBar();
                    q.Show();
                    q.BringToFront();

                    return true;
                }
            }

            var quizProgressInfo = new QuizOverview(quizIdentity);
            pnl_quizInfo.Controls.Add(quizProgressInfo);
            quizProgressInfo.Size = pnl_quizInfo.Size;
            quizProgressInfo.Show();
            quizProgressInfo.BringToFront();

            return true;
        }

        /// <summary>
        /// Finds the QuizProgressInfo UserControl for a specified quiz
        /// </summary>
        /// <param name="quizGuid">The Guid of the quiz whose QuizProgressInfo to return</param>
        /// <returns>Returns the QuizProgressInfo if found, otherwise null</returns>
        public QuizOverview FindQuizProgressInfo(Guid quizGuid)
        {
            foreach (var q in pnl_quizInfo.Controls.OfType<QuizOverview>())
            {
                if (q.QuizIdentity.QuizGuid == quizGuid)
                {
                    return q;
                }
            }

            return null;
        }

        private void ThemeMonitor_Error(object sender, ErrorEventArgs e)
        {
            throw e.GetException();
        }

        private void ThemeMonitor_RegChanged(object sender, EventArgs e)
        {
            if (!ConfigManager.Config.SyncWin10Theme)
            {
                return;
            }

            Invoke(new Action(() =>
            {
                PullWin10Theme();
            }));
        }

        /// <summary>
        /// Sets and applies the app theme according to Windows 10 theme
        /// </summary>
        public bool PullWin10Theme()
        {
            ThemeManager.ThemeCore.Theme? theme = Program.GetWin10Theme();

            if (theme == null)
            {
                // User don't have Windows 10, the Windows 10 build is too old for app theme, or the user has never set the app theme
                return false;
            }

            ConfigManager.Config.Theme = (ThemeManager.ThemeCore.Theme)theme;
            ConfigManager.SaveConfig();

            SetThemeAll();

            return true;
        }

        /// <summary>
        /// Updates ALL forms and user controls with the colors for the set theme
        /// </summary>
        public void SetThemeAll()
        {
            foreach (var frm in Application.OpenForms.OfType<AutoThemeableForm>())
            {
                // Call the potentially overriden SetTheme() method
                dynamic frmT = Convert.ChangeType(frm, frm.GetType());
                frmT.Invoke(new Action(() =>
                {
                    frmT.SetTheme(null);
                }));

                foreach (var uc in frm.GetAllChildrenRecursive().OfType<AutoThemeableUserControl>())
                {
                    // Call the potentially overriden SetTheme() method
                    dynamic ucT = Convert.ChangeType(uc, uc.GetType());
                    ucT.Invoke(new Action(() =>
                    {
                        ucT.SetTheme(null);
                    }));

                    //uc.SetTheme();
                }

                //frm.SetTheme();
            }

            this.SetTheme();
        }

        public void UpdateCfg()
        {
            GenerateWelcomeMsg();
        }

        public void GenerateWelcomeMsg()
        {
            CurrentWelcomeMessage = welcomeMessages.SelectWelcomeMessage();
            lbl_welcome.Text = CurrentWelcomeMessage.Message;
            firstWelcomeMsgEvalCompleted = true;
        }

        /// <summary>
        /// Updates this form with the colors for the set theme
        /// </summary>
        public void SetTheme()
        {
            if (WelcomeTheme == null)
            {
                WelcomeTheme = new WelcomeTheme();
            }

            this.BackColor = WelcomeTheme.GetBackColor();
            pnl_left.BackColor = Color.FromArgb(BackColor.A, BackColor.R - 10, BackColor.G - 10, BackColor.B - 10);

            lbl_welcome.ForeColor = WelcomeTheme.GetMainLabelForeColor();
            lbl_recentQuizzes.ForeColor = WelcomeTheme.GetMainLabelForeColor();
            lbl_toBegin.ForeColor = WelcomeTheme.GetMainLabelForeColor();

            btn_addQuiz.BackColor = WelcomeTheme.GetButtonBackColor();
            btn_createQuiz.BackColor = WelcomeTheme.GetButtonBackColor();
            btn_loadQuizFromFile.BackColor = WelcomeTheme.GetButtonBackColor();
            btn_importQuiz.BackColor = WelcomeTheme.GetButtonBackColor();
            //btn_continueLast.BackColor = WelcomeTheme.GetMainButtonBackColor();

            //btn_createQuiz.ForeColor = WelcomeTheme.GetMainButtonForeColor();
            //btn_loadQuiz.ForeColor = WelcomeTheme.GetMainButtonForeColor();
            //btn_importQuizFromSite.ForeColor = WelcomeTheme.GetMainButtonForeColor();
            //btn_continueLast.ForeColor = WelcomeTheme.GetMainButtonForeColor();

            btn_addQuiz.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_createQuiz.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_loadQuizFromFile.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_importQuiz.ForeColor = WelcomeTheme.GetButtonForeColor();
            //btn_continueLast.ForeColor = WelcomeTheme.GetButtonForeColor();

            //lbl_copyright.ForeColor = WelcomeTheme.GetBackgroundLabelForeColor();

            var btnbc = WelcomeTheme.GetButtonBackColor();
            btn_chkUpdates.BackColor = Color.FromArgb(btnbc.A, btnbc.R - 10, btnbc.G - 10, btnbc.B - 10);
            btn_preferences.BackColor = Color.FromArgb(btnbc.A, btnbc.R - 10, btnbc.G - 10, btnbc.B - 10);

            btn_chkUpdates.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_preferences.ForeColor = WelcomeTheme.GetButtonForeColor();

            foreach (var uc in this.GetAllChildrenRecursiveDerives(typeof(AutoThemeableUserControl)))
            {
                // Call the potentially overriden SetTheme() method
                dynamic ucT = Convert.ChangeType(uc, uc.GetType());
                ucT.Invoke(new Action(() =>
                {
                    ucT.SetTheme(null);
                }));

                //uc.SetTheme();
            }
        }

        public void SetControlStates()
        {
            if (ConfigManager.Config.LastQuiz != Guid.Empty)
            {
                //btn_continueLast.Enabled = true;
            }
        }

        private void btn_importQuizFromSite_Click(object sender, EventArgs e)
        {
            AddQuizButtonsExpanded = false;

            var import = new QuizImportGuide();
            if (import.ShowDialog() == DialogResult.OK)
            {
                //Program.frmInQuiz = new InQuiz(QuizPractiseMode.Writing);
                //#warning implement selector
                //Program.frmInQuiz.Show();
                //Hide();
                if (!QuizCore.Load(import.QuizPath))
                {
                    return;
                }
                PopulateQuizList();
                SwitchQuizProgressInfo(flp_lastQuizzes.Controls.Cast<RecentQuiz>()
                    .Where(x => x.QuizIdentity.FindQuizPath() == import.QuizPath)
                    .Select(x => x.QuizIdentity)
                    .First());
            }
        }

        private void btn_loadQuiz_Click(object sender, EventArgs e)
        {
            // The ShowDialog is performance intensive, so skip animation to prevent lag
            SkipAddQuizButtonsExpandedAnimation = true;
            AddQuizButtonsExpanded = false;

            if (ofd_loadQuiz.ShowDialog() == DialogResult.OK)
            {
                //LoadQuiz(ofd_loadQuiz.FileName, QuizPractiseMode.Writing);
                //#warning add selector

                if (!QuizCore.Load(ofd_loadQuiz.FileName))
                {
                    return;
                }
                PopulateQuizList();
                SwitchQuizProgressInfo(flp_lastQuizzes.Controls.Cast<RecentQuiz>()
                    .Where(x => x.QuizIdentity.FindQuizPath() == ofd_loadQuiz.FileName)
                    .Select(x => x.QuizIdentity)
                    .First());
            }
        }

        public enum QuizPractiseMode
        {
            Writing,
            Flashcards,
        }

        public void LoadQuiz(string quizPath, QuizPractiseMode quizPractiseMode)
        {
            try
            {
                var load = QuizCore.Load(quizPath);
                if (!load)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The quiz file could not be loaded:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.frmInQuiz = new InQuiz(quizPractiseMode);
            Program.frmInQuiz.Show();
            Hide();
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            themeMonitor?.Stop();
            ConfigManager.SaveConfig();
            Application.Exit();
        }

        public void OpenQuizEditor(Quiz quiz = null, string quizPath = null)
        {
            Hide();
            Program.OpenQuizEditor(quiz, quizPath);
        }

        private void btn_createQuiz_Click(object sender, EventArgs e)
        {
            AddQuizButtonsExpanded = false;

            OpenQuizEditor();
        }

        private void Tmr_chkUpdate_Tick(object sender, EventArgs e)
        {
            tmr_chkUpdate.Interval = 120000;
            Updater.Update(Updater.UpdateMode.Notification);
        }

        public void ShowPreferences(Type selectedCategory = null, Type selectedCategoryCollection = null)
        {
            Program.frmPreferences?.Dispose();
            this.Activate();
            //this.Focus();
            Program.frmPreferences = new Preferences.Preferences(selectedCategory, selectedCategoryCollection);
            Program.frmPreferences.ShowDialog();
        }

        private void Btn_preferences_Click(object sender, EventArgs e)
        {
            AddQuizButtonsExpanded = false;

            ShowPreferences();

            ofd_loadQuiz.InitialDirectory = ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder;
        }

        private void Btn_chkUpdates_Click(object sender, EventArgs e)
        {
            AddQuizButtonsExpanded = false;

            Updater.Update(Updater.UpdateMode.Verbose);
        }

        private void Welcome_Shown(object sender, EventArgs e)
        {
            Activate();
        }

        private void Tmr_welcomeMsg_Tick(object sender, EventArgs e)
        {
            if (!CurrentWelcomeMessage.Conditions())
            {
                GenerateWelcomeMsg();
            }
        }

        private bool SkipAddQuizButtonsExpandedAnimation { get; set; }

        private bool __addQuizButtonsExpanded = false;
        private bool AddQuizButtonsExpanded
        {
            get
            {
                return __addQuizButtonsExpanded;
            }

            set
            {
                __addQuizButtonsExpanded = value;

                var btn_createQuiz_loc = btn_createQuiz.Location;
                var btn_loadQuizFromFile_loc = btn_loadQuizFromFile.Location;
                var btn_importQuiz_loc = btn_importQuiz.Location;
                var btn_preferences_loc = btn_preferences.Location;
                var btn_chkUpdates_loc = btn_chkUpdates.Location;

                if (AddQuizButtonsExpanded)
                {
                    flp_lastQuizzes.Enabled = false;

                    btn_createQuiz.Visible = true;
                    btn_loadQuizFromFile.Visible = true;
                    btn_importQuiz.Visible = true;
                    btn_preferences.Visible = true;
                    btn_chkUpdates.Visible = true;

                    if (!SkipAddQuizButtonsExpandedAnimation)
                    {
                        btn_createQuiz.Location = btn_addQuiz.Location;
                        btn_loadQuizFromFile.Location = btn_addQuiz.Location;
                        btn_importQuiz.Location = btn_addQuiz.Location;
                        btn_preferences.Location = btn_addQuiz.Location;
                        btn_chkUpdates.Location = btn_addQuiz.Location;

                        ControlMove.SmoothMove(btn_createQuiz, btn_createQuiz_loc, 80);
                        ControlMove.SmoothMove(btn_loadQuizFromFile, btn_loadQuizFromFile_loc, 80);
                        ControlMove.SmoothMove(btn_importQuiz, btn_importQuiz_loc, 80);
                        ControlMove.SmoothMove(btn_preferences, btn_preferences_loc, 80);
                        ControlMove.SmoothMove(btn_chkUpdates, btn_chkUpdates_loc, 80);
                    }
                    else
                    {
                        btn_createQuiz.Location = btn_createQuiz_loc;
                        btn_loadQuizFromFile.Location = btn_loadQuizFromFile_loc;
                        btn_importQuiz.Location = btn_importQuiz_loc;
                        btn_preferences.Location = btn_preferences_loc;
                        btn_chkUpdates.Location = btn_chkUpdates_loc;
                    }
                }
                else
                {
                    flp_lastQuizzes.Enabled = true;

                    if (!SkipAddQuizButtonsExpandedAnimation)
                    {
                        ControlMove.SmoothMove(btn_createQuiz, btn_addQuiz.Location, 80, () =>
                        {
                            btn_createQuiz.Visible = false;

                            btn_createQuiz.Location = btn_createQuiz_loc;
                        });
                        ControlMove.SmoothMove(btn_loadQuizFromFile, btn_addQuiz.Location, 80, () =>
                        {
                            btn_loadQuizFromFile.Visible = false;

                            btn_loadQuizFromFile.Location = btn_loadQuizFromFile_loc;
                        });
                        ControlMove.SmoothMove(btn_importQuiz, btn_addQuiz.Location, 80, () =>
                        {
                            btn_importQuiz.Visible = false;

                            btn_importQuiz.Location = btn_importQuiz_loc;
                        });
                        ControlMove.SmoothMove(btn_preferences, btn_addQuiz.Location, 80, () =>
                        {
                            btn_preferences.Visible = false;

                            btn_preferences.Location = btn_preferences_loc;
                        });
                        ControlMove.SmoothMove(btn_chkUpdates, btn_addQuiz.Location, 80, () =>
                        {
                            btn_chkUpdates.Visible = false;

                            btn_chkUpdates.Location = btn_chkUpdates_loc;
                        });
                    }
                    else
                    {
                        btn_createQuiz.Visible = false;
                        btn_loadQuizFromFile.Visible = false;
                        btn_importQuiz.Visible = false;
                        btn_preferences.Visible = false;
                        btn_chkUpdates.Visible = false;

                        btn_createQuiz.Location = btn_createQuiz_loc;
                        btn_loadQuizFromFile.Location = btn_loadQuizFromFile_loc;
                        btn_importQuiz.Location = btn_importQuiz_loc;
                        btn_preferences.Location = btn_preferences_loc;
                        btn_chkUpdates.Location = btn_chkUpdates_loc;
                    }
                }

                if (AddQuizButtonsExpanded)
                {
                    btn_addQuiz.Text = "←";
                }
                else
                {
                    btn_addQuiz.Text = "+";
                }

                SkipAddQuizButtonsExpandedAnimation = false;
            }
        }

        private void Btn_addQuiz_Click(object sender, EventArgs e)
        {
            AddQuizButtonsExpanded = !AddQuizButtonsExpanded;
        }

        private void Welcome_SizeChanged(object sender, EventArgs e)
        {
            //lbl_welcome.Size = new Size(Size.Width - 230, Size.Height - 63);
            pnl_quizInfo.Size = new Size(Size.Width - 230, Size.Height - 63);
            pnl_welcomeText.Location =
                new Point(pnl_quizInfo.Width / 2 - pnl_welcomeText.Size.Width / 2,
                pnl_quizInfo.Height / 2 - pnl_welcomeText.Size.Height / 2);
            foreach (var c in pnl_quizInfo.Controls.OfType<Control>())
            {
                c.Size = pnl_quizInfo.Size;
            }
            flp_lastQuizzes.Size = new Size(flp_lastQuizzes.Size.Width, Size.Height - 143);
        }

        private void pnl_left_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms_recentQuizzes.Show(Cursor.Position);
            }
        }

        private void lbl_recentQuizzes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms_recentQuizzes.Show(Cursor.Position);
            }
        }

        private void clearRecentQuizzesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show($"Are you sure you want to clear the recent quizzes list? The quiz files will not be removed.",
                "Clear Recent Quizzes - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg != DialogResult.Yes)
            {
                return;
            }

            var recentQuizzes = flp_lastQuizzes.Controls.Cast<RecentQuiz>().Select(x => x.QuizIdentity.QuizGuid).ToList();
            foreach (var quizGuid in recentQuizzes)
            {
                RemoveQuiz(quizGuid, false);
            }

            QuizCore.SaveQuizData();
        }

        private void Dashboard_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = ((string[])e.Data.GetData(DataFormats.FileDrop)).Where(x => x.EndsWith(".steelquiz"));
                if (!files.Any())
                {
                    return;
                }

                foreach (var file in files)
                {
                    QuizCore.Load(file);
                }

                PopulateQuizList();
                SwitchQuizProgressInfo(flp_lastQuizzes.Controls.Cast<RecentQuiz>()
                    .Select(x => x.QuizIdentity)
                    .First());
            }
        }

        private void Dashboard_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = ((string[])e.Data.GetData(DataFormats.FileDrop)).Where(x => x.EndsWith(".steelquiz"));
                if (files.Any())
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
    }
}
