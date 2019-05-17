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

using SteelQuiz.QuizPractise;
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

namespace SteelQuiz
{
    public partial class TermsOfUse : AutoThemeableForm
    {
        private const int AGREE_UNLOCK_DELAY_S = 20;
        private int unlockTimerCount = 0;
        private bool showForm = true;

        public TermsOfUse()
        {
            if (ConfigManager.Config.AcceptedTermsOfUse)
            {
                showForm = false;
                OpenApplication();
            }
            else
            {
                InitializeComponent();
                this.Text += $" | v{Application.ProductVersion}";
                SetTheme();
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(!value ? value : showForm);
            // if form should be hidden (value is false), then hide it, no setting prevents hiding it
            // but it the form should be shown, only show it if showForm is true
        }

        private void OpenApplication()
        {
            Program.frmWelcome = new Welcome();
            if (Program.Args.Length > 0 && File.Exists(Program.Args[0]) && Program.Args[0].EndsWith(".steelquiz"))
            {
                LoadQuiz(Program.Args[0]);
            }
            else
            {
                Program.frmWelcome.Show();
            }

            if (!QuizCore.ChkCreateQuizProgress())
            {
                // open troubleshooting
                Program.frmWelcome.ShowPreferences(typeof(Preferences.PrefsTroubleshooting), typeof(Preferences.CategoriesMaintenance));
            }
            else
            {
                var progDataUpgrade = QuizCore.ChkUpgradeProgressData();
                if (progDataUpgrade == QuizCore.ChkUpgradeProgressDataResult.Fail)
                {
                    return;
                }
            }

            Hide();
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

            Program.frmInQuiz = new InQuiz(false);
            Program.frmInQuiz.Show();
        }

        private void timer_agree_unlock_Tick(object sender, EventArgs e)
        {
            ++unlockTimerCount;
            btn_agree.Text = "I agree (" + (AGREE_UNLOCK_DELAY_S - unlockTimerCount) + " s)";
            if (unlockTimerCount >= AGREE_UNLOCK_DELAY_S)
            {
                btn_agree.Text = "I agree";
                btn_agree.Enabled = true;
                timer_agree_unlock.Stop();
            }
        }

        private void TermsOfUse_Load(object sender, EventArgs e)
        {
            btn_agree.Text = "I agree (" + AGREE_UNLOCK_DELAY_S + " s)";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_agree_Click(object sender, EventArgs e)
        {
            ConfigManager.Config.AcceptedTermsOfUse = true;
            ConfigManager.SaveConfig();

            OpenApplication();
        }
    }
}
