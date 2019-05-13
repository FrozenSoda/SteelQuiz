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
        private const int BUTTON_ENABLE_DELAY_S = 3;
        private int secondsSinceStart = 0;

        public UpdateAvailable(Version installedVersion, Version newVersion)
        {
            InitializeComponent();
            SetTheme();

            lbl_top.Text = $"A new version of SteelQuiz is available (v{newVersion.ToString()})";
            lbl_installedVer.Text = $"Current version: v{installedVersion.ToString()}";
            using (var client = new WebClient())
            {
                try
                {
                    string releaseNotes = client.DownloadString("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/release_notes.txt");
                    rtf_releaseNotes.Text = releaseNotes;
                }
                catch
                {
                    System.Diagnostics.Debug.Print("Release notes could not be downloaded");
                    rtf_releaseNotes.Text = "Release notes could not be downloaded";
                }
            }
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
            if (secondsSinceStart < BUTTON_ENABLE_DELAY_S)
            {
                e.Cancel = true;
                MessageBox.Show($"Please wait {BUTTON_ENABLE_DELAY_S - secondsSinceStart}s before closing", "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (DialogResult == DialogResult.Cancel)
            {
                Program.frmWelcome.tmr_chkUpdate.Interval = 2 * 60 * 60 * 1000; // if user does not update, wait 2h before showing update alert again
            }
        }

        private void Tmr_btnEnable_Tick(object sender, EventArgs e)
        {
            ++secondsSinceStart;
            if (secondsSinceStart >= BUTTON_ENABLE_DELAY_S)
            {
                btn_update.Text = "Update now (recommended)";
                btn_update.Enabled = true;

                btn_notNow.Text = "Not now";
                btn_notNow.Enabled = true;

                tmr_btnEnable.Stop();
            }
            else
            {
                btn_update.Text = $"({BUTTON_ENABLE_DELAY_S - secondsSinceStart}s) Update now (recommended)";
                btn_notNow.Text = $"({BUTTON_ENABLE_DELAY_S - secondsSinceStart}s) Not now";
            }
        }
    }
}