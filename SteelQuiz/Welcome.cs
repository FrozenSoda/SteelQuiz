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
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
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

        public Welcome()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";
            SetControlStates();
            SetTheme();

            ChkUpdate();
        }

        public void SetTheme()
        {
            this.BackColor = WelcomeTheme.GetBackColor();

            lbl_welcome.ForeColor = WelcomeTheme.GetMainLabelForeColor();

            btn_createQuiz.BackColor = WelcomeTheme.GetMainButtonBackColor();
            btn_loadQuiz.BackColor = WelcomeTheme.GetMainButtonBackColor();
            btn_importQuizFromSite.BackColor = WelcomeTheme.GetMainButtonBackColor();
            btn_continueLast.BackColor = WelcomeTheme.GetMainButtonBackColor();

            //btn_createQuiz.ForeColor = WelcomeTheme.GetMainButtonForeColor();
            //btn_loadQuiz.ForeColor = WelcomeTheme.GetMainButtonForeColor();
            //btn_importQuizFromSite.ForeColor = WelcomeTheme.GetMainButtonForeColor();
            //btn_continueLast.ForeColor = WelcomeTheme.GetMainButtonForeColor();

            btn_createQuiz.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_loadQuiz.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_importQuizFromSite.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_continueLast.ForeColor = WelcomeTheme.GetButtonForeColor();

            lbl_copyright.ForeColor = WelcomeTheme.GetBackgroundLabelForeColor();

            btn_chkUpdates.BackColor = WelcomeTheme.GetButtonBackColor();
            btn_preferences.BackColor = WelcomeTheme.GetButtonBackColor();

            btn_chkUpdates.ForeColor = WelcomeTheme.GetButtonForeColor();
            btn_preferences.ForeColor = WelcomeTheme.GetButtonForeColor();
        }

        public void ChkUpdate()
        {
            if (SUtil.InternetConnectionAvailable())
            {
                try
                {
                    if (SUtil.IsDirectoryWritable(Path.GetDirectoryName(Application.ExecutablePath)))
                    {
                        // if application has write permissions to application folder, admin is not required
                        AutoUpdater.RunUpdateAsAdmin = false;
                    }
                    AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during the update/update check:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SetControlStates()
        {
            if (ConfigManager.Config.LastQuiz != Guid.Empty)
            {
                btn_continueLast.Enabled = true;
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
        }

        private void btn_loadQuiz_Click(object sender, EventArgs e)
        {
            ofd_loadQuiz.InitialDirectory = QuizCore.QUIZ_FOLDER;
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
            ConfigManager.SaveConfig();
            Application.Exit();
        }

        private void btn_continueLast_Click(object sender, EventArgs e)
        {
            try
            {
                var load = QuizCore.Load(ConfigManager.Config.LastQuiz);
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

            Hide();
            Program.frmInQuiz = new InQuiz();
            Program.frmInQuiz.Show();
        }

        public void OpenQuizEditor(Quiz quiz = null, string quizPath = null)
        {
            var quizEditor = new QuizEditor.QuizEditor();
            if (quiz != null)
            {
                quizEditor.LoadQuiz(quiz, quizPath);
            }
            quizEditor.Show();
            Hide();
        }

        private void btn_createQuiz_Click(object sender, EventArgs e)
        {
            OpenQuizEditor();
        }

        private void Tmr_chkUpdate_Tick(object sender, EventArgs e)
        {
            CheckForUpdatesNotification();
            tmr_chkUpdate.Interval = 120000;
        }

        private void UpdateNotificationClick(NotifyIcon notifyIcon)
        {
            ChkUpdate();
            Dispose(notifyIcon);
        }

        private void Dispose(NotifyIcon notifyIcon)
        {
            // do not check for updates again for 1 hour if one was found
            tmr_chkUpdate.Interval = 1 * 60 * 60 * 1000;
            notifyIcon.Dispose();
        }

        public void CheckForUpdatesMsgBox()
        {
            tmr_chkUpdate.Stop();

            AutoUpdater.CheckForUpdateEvent += CheckUpdatesMessageBox;
            AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
        }

        public void CheckForUpdatesNotification()
        {
            AutoUpdater.CheckForUpdateEvent += CheckUpdatesNotification;
            AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
        }

        private void CheckUpdatesNotification(UpdateInfoEventArgs uargs)
        {
            if (uargs != null)
            {
                if (uargs.IsUpdateAvailable)
                {
                    var notifyIcon = new NotifyIcon
                    {
                        Visible = true,
                        Icon = Properties.Resources.Logo
                    };
                    notifyIcon.BalloonTipTitle = "SteelQuiz";
                    notifyIcon.BalloonTipText = "A software update is available. Click here for more info";
                    notifyIcon.BalloonTipClosed += (sender, args) => Dispose(notifyIcon);
                    notifyIcon.BalloonTipClicked += (sender, args) => UpdateNotificationClick(notifyIcon);
                    notifyIcon.ShowBalloonTip(10000);
#warning the update window is minimized when it opens
                }
            }
            AutoUpdater.CheckForUpdateEvent -= CheckUpdatesNotification;
        }

        private void CheckUpdatesMessageBox(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    ChkUpdate();
                }
                else
                {
                    MessageBox.Show($"No updates are available\r\n\r\nYou are running SteelQuiz v{Application.ProductVersion}", @"SteelQuiz",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(
                        @"There was a problem reaching the update server. Please check your internet connection and try again later",
                        @"Update check failed - SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AutoUpdater.CheckForUpdateEvent -= CheckUpdatesMessageBox;
            tmr_chkUpdate.Start();
        }

        private void Btn_chkUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdatesMsgBox();
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
        }
    }
}
