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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class UpdateAvailable : AutoThemeableForm
    {
        private int secondsSinceStart = 0;
        private bool skipConfigApply = true;

        public UpdateAvailable(Version installedVersion, Version newVersion)
        {
            InitializeComponent();
            SetTheme();

            LoadPreferences();
            skipConfigApply = true;

            if (ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s == 0)
            {
                btn_update.Text = "Update now (recommended)";
                btn_update.Enabled = true;

                btn_notNow.Text = "Not now";
                btn_notNow.Enabled = true;

                tmr_btnEnable.Stop();
            }

            lbl_top.Text = $"A new version of SteelQuiz is available (v{newVersion.ToString()})";
            lbl_installedVer.Text = $"Installed version: v{installedVersion.ToString()}";
            using (var client = new WebClient())
            {
                try
                {
                    string releaseNotes = client.DownloadString("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/release_notes.txt");
                    rtf_releaseNotes.Text = releaseNotes;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Release notes could not be downloaded: " + ex.ToString());
                    rtf_releaseNotes.Text = "Release notes could not be downloaded";
                }
            }
        }

        private void LoadPreferences()
        {
            chk_autoUpdateInFuture.Checked = ConfigManager.Config.UpdateConfig.AutoUpdate;
        }

        private void Btn_notNow_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void UpdateAvailable_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Focus();
        }

        private void UpdateAvailable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (secondsSinceStart < ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s)
            {
                e.Cancel = true;
                MessageBox.Show($"Please wait {ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s - secondsSinceStart}s before closing", "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Tmr_btnEnable_Tick(object sender, EventArgs e)
        {
            ++secondsSinceStart;
            if (secondsSinceStart >= ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s)
            {
                btn_update.Text = "Update now (recommended)";
                btn_update.Enabled = true;

                btn_notNow.Text = "Not now";
                btn_notNow.Enabled = true;

                tmr_btnEnable.Stop();
            }
            else
            {
                btn_update.Text = $"({ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s - secondsSinceStart}s) Update now (recommended)";
                btn_notNow.Text = $"({ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s - secondsSinceStart}s) Not now";
            }
        }

        private void Chk_autoUpdateInFuture_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            ConfigManager.Config.UpdateConfig.AutoUpdate = chk_autoUpdateInFuture.Checked;
            ConfigManager.SaveConfig();
        }
    }
}