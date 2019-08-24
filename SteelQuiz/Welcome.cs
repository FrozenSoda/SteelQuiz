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
using SteelQuiz.Extensions;
using SteelQuiz.QuizData;
using SteelQuiz.QuizImport;
using SteelQuiz.QuizImport.Guide;
using SteelQuiz.QuizPractise;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class Welcome : Form, ThemeManager.IThemeable
    {
        private WelcomeTheme WelcomeTheme = new WelcomeTheme();
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

        public Welcome()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += " PRE-RELEASE";
            }

            SetControlStates();

            ofd_loadQuiz.InitialDirectory = ConfigManager.Config.SyncConfig.QuizFolders[0];

            if (Util.WinVer.WindowsVersion().Major >= 10) // if user runs Windows 10
            {
                if (ConfigManager.Config.SyncWin10Theme)
                {
                    PullWin10Theme();
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

            foreach (var quizAccessTimePair in QuizCore.QuizAccessTimes.OrderByDescending(x => x.Value.Ticks))
            {
                var quizIdentity = QuizCore.QuizIdentities[quizAccessTimePair.Key];

                var dashboardQuiz = new DashboardQuiz(quizIdentity);
                flp_lastQuizzes.Controls.Add(dashboardQuiz);
            }
        }

        public void SwitchQuizProgressInfo(QuizIdentity quizIdentity)
        {
            foreach (var q in pnl_quizInfo.Controls.OfType<QuizProgressInfo>())
            {
                if (q.QuizIdentity.QuizGuid == quizIdentity.QuizGuid)
                {
                    q.Show();
                    q.BringToFront();

                    return;
                }
            }

            var quizProgressInfo = new QuizProgressInfo(quizIdentity);
            pnl_quizInfo.Controls.Add(quizProgressInfo);
            quizProgressInfo.Show();
            quizProgressInfo.BringToFront();
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
        public void PullWin10Theme()
        {
            ThemeManager.ThemeCore.Theme? theme = Program.GetWin10Theme();

            if (theme == null)
            {
                // User don't have Windows 10, or the Windows 10 build is too old for app theme
                return;
            }

            ConfigManager.Config.Theme = (ThemeManager.ThemeCore.Theme)theme;
            ConfigManager.SaveConfig();

            SetThemeAll();
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
            this.BackColor = WelcomeTheme.GetBackColor();

            lbl_welcome.ForeColor = WelcomeTheme.GetMainLabelForeColor();
            lbl_recentQuizzes.ForeColor = WelcomeTheme.GetMainLabelForeColor();

            btn_addQuiz.BackColor = WelcomeTheme.GetMainButtonBackColor();
            btn_createQuiz.BackColor = WelcomeTheme.GetMainButtonBackColor();
            btn_loadQuizFromFile.BackColor = WelcomeTheme.GetMainButtonBackColor();
            btn_importQuiz.BackColor = WelcomeTheme.GetMainButtonBackColor();
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

            btn_chkUpdates.BackColor = WelcomeTheme.GetButtonBackColor();
            btn_preferences.BackColor = WelcomeTheme.GetButtonBackColor();

            btn_chkUpdates.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_preferences.ForeColor = WelcomeTheme.GetButtonForeColor();

            foreach (var uc in this.GetAllChildrenRecursive().OfType<AutoThemeableUserControl>())
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
            var import = new QuizImportGuide();
            if (import.ShowDialog() == DialogResult.OK)
            {
                Program.frmInQuiz = new InQuiz();
                Program.frmInQuiz.Show();
                Hide();
            }

            AddQuizButtonsExpanded = false;
        }

        private void btn_loadQuiz_Click(object sender, EventArgs e)
        {
            //ofd_loadQuiz.InitialDirectory = QuizCore.QUIZ_FOLDER_DEFAULT;
            if (ofd_loadQuiz.ShowDialog() == DialogResult.OK)
            {
                /*
                if (Path.GetDirectoryName(ofd_loadQuiz.FileName) != QuizCore.QUIZ_FOLDER)
                {
                    MessageBox.Show("Quizzes can only be opened from %appdata%\\Quizzes", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                */

                LoadQuiz(ofd_loadQuiz.FileName);
            }

            AddQuizButtonsExpanded = false;
        }

        private void LoadQuiz(string quizPath)
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

            Program.frmInQuiz = new InQuiz();
            Program.frmInQuiz.Show();
            Hide();
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            themeMonitor?.Stop();
            ConfigManager.SaveConfig();
            Application.Exit();
        }

        private void btn_continueLast_Click(object sender, EventArgs e)
        {
#if !DEBUG
            try
            {
#endif
                var load = QuizCore.Load(ConfigManager.Config.LastQuiz);
                if (!load)
                {
                    return;
                }
#if !DEBUG
            }
            catch (Exception ex)
            {
                MessageBox.Show("The quiz file could not be loaded:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
#endif

            Hide();
            Program.frmInQuiz = new InQuiz();
            Program.frmInQuiz.Show();
        }

        public void OpenQuizEditor(Quiz quiz = null, string quizPath = null)
        {
            Hide();
            Program.OpenQuizEditor(quiz, quizPath);
        }

        private void btn_createQuiz_Click(object sender, EventArgs e)
        {
            OpenQuizEditor();

            AddQuizButtonsExpanded = false;
        }

        private void Tmr_chkUpdate_Tick(object sender, EventArgs e)
        {
            tmr_chkUpdate.Interval = 120000;
            Updater.Update(Updater.UpdateMode.Notification);
        }

        public void ShowPreferences(Type selectedCategory = null, Type selectedCategoryCollection = null)
        {
            Program.frmPreferences?.Dispose();
            this.Focus();
            Program.frmPreferences = new Preferences.Preferences(selectedCategory, selectedCategoryCollection);
            Program.frmPreferences.ShowDialog();
        }

        private void Btn_preferences_Click(object sender, EventArgs e)
        {
            ShowPreferences();

            AddQuizButtonsExpanded = false;
        }

        private void Btn_chkUpdates_Click(object sender, EventArgs e)
        {
            Updater.Update(Updater.UpdateMode.Verbose);

            AddQuizButtonsExpanded = false;
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

                btn_createQuiz.Visible = AddQuizButtonsExpanded;
                btn_loadQuizFromFile.Visible = AddQuizButtonsExpanded;
                btn_importQuiz.Visible = AddQuizButtonsExpanded;
                btn_preferences.Visible = AddQuizButtonsExpanded;
                btn_chkUpdates.Visible = AddQuizButtonsExpanded;

                if (AddQuizButtonsExpanded)
                {
                    btn_addQuiz.Text = "←";
                }
                else
                {
                    btn_addQuiz.Text = "+";
                }
            }
        }

        private void Btn_addQuiz_Click(object sender, EventArgs e)
        {
            AddQuizButtonsExpanded = !AddQuizButtonsExpanded;
        }
    }
}
