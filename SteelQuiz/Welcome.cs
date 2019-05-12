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

            Updater.Update(Updater.UpdateMode.Startup);
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
        }

        private void Btn_chkUpdates_Click(object sender, EventArgs e)
        {
            Updater.Update(Updater.UpdateMode.Verbose);
        }
    }
}
