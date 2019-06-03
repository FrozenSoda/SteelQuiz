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
using AutoUpdaterDotNET;

namespace SteelQuiz.Preferences
{
    public partial class PrefsTroubleshooting : AutoThemeableUserControl
    {
        public PrefsTroubleshooting()
        {
            InitializeComponent();

            SetTheme();
            CheckForUpdates();
        }

        public void CheckForUpdates()
        {
            Program.frmWelcome.tmr_chkUpdate.Stop();

            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            //AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
            Updater.Update(Updater.UpdateMode.Manual);
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    this.Invoke(new Action(() =>
                    {
                        btn_update.Enabled = true;
                        btn_update.Text = "Continue";
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        lbl_update.Text = "Force update SteelQuiz";
                        btn_update.Enabled = true;
                        btn_update.Text = "Continue";
                    }));
                }
            }
            else
            {
                MessageBox.Show(
                        @"There was a problem reaching the update server. Please check your internet connection and try again later",
                        @"Update check failed - SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke(new Action(() =>
                {
                    btn_update.Text = "Error";
                    btn_update.Enabled = false;
                }));
            }
            AutoUpdater.CheckForUpdateEvent -= AutoUpdaterOnCheckForUpdateEvent;
            Program.frmWelcome.tmr_chkUpdate.Start();
        }

        private void Btn_resetAppConfig_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Are you sure you want to reset the application config? This will undo ALL changes you have made to the settings",
                "Reset Application Config - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var bkp = QuizCore.BackupConfig(new Version(ConfigManager.Config.FileFormatVersion));
                if (!bkp)
                {
                    return;
                }

                var msg2 = MessageBox.Show("Keep statistics (launch count etc.)? This is recommended unless you still experience problems. If you are unsure, select Yes",
                    "Keep Statistics - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                ConfigData.Statistics statistics = null;
                if (msg2 == DialogResult.Yes)
                {
                    statistics = ConfigManager.Config.Statistics;
                }

                (ParentForm as Preferences).SaveConfig = false;

                ConfigManager.Config = new ConfigData.Config();

                if (statistics != null)
                {
                    ConfigManager.Config.Statistics = statistics;
                }

                ConfigManager.SaveConfig();
                Application.Restart();
            }
        }

        private void Btn_resetProgData_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Are you sure you want to reset the quiz progress data? This will remove ALL progress for ALL quizzes. " +
                "Intelligent Learning will forget EVERYTHING you have done",
                "Reset Quiz Progress Data - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var bkp = QuizCore.BackupProgress(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION));
                if (!bkp)
                {
                    return;
                }

                try
                {
                    System.IO.File.Delete(ConfigManager.Config.SyncConfig.QuizProgressPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while resetting quiz progress data:\r\n\r\n{ex.ToString()}", "SteelQuiz",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Application.Restart();
            }
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            //AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
            Updater.Update(Updater.UpdateMode.Force);
        }
    }
}
