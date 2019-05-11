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

namespace SteelQuiz
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";
            SetControlStates();

            ChkUpdate();
        }

        public void ChkUpdate(bool unobtrusive = false)
        {
            // if unobtrusive == true, an update dialog should not be showed, but a notification message should instead be shown to not distrupt the user

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

            Program.frmInQuiz = new InQuiz();
            Program.frmInQuiz.Show();
            Hide();
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
            // ChkUpdate(true);
            // disabled until update notification system is implemented
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    AutoUpdater.ShowUpdateForm();
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
            AutoUpdater.CheckForUpdateEvent -= AutoUpdaterOnCheckForUpdateEvent;
            tmr_chkUpdate.Start();
        }

        private void Btn_chkUpdates_Click(object sender, EventArgs e)
        {
            tmr_chkUpdate.Stop();

            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
        }

        private void Btn_preferences_Click(object sender, EventArgs e)
        {
            var pref = new Preferences.Preferences();
            pref.ShowDialog();
        }
    }
}
