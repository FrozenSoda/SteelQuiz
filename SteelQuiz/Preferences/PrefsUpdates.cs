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

namespace SteelQuiz.Preferences
{
    public partial class PrefsUpdates : AutoThemeableUserControl, IPreferenceCategory
    {
        private bool skipConfigApply = true;

        public PrefsUpdates()
        {
            InitializeComponent();

            LoadPreferences();
            SetTheme();
            skipConfigApply = false;
        }

        public void LoadPreferences()
        {
            switch (ConfigManager.Config.UpdateConfig.AutoUpdateMode)
            {
                case ConfigData.AutomaticUpdateMode.CheckDownloadInstall:
                    rdo_autoUpdate.Checked = true;
                    break;

                case ConfigData.AutomaticUpdateMode.CheckOnly:
                    rdo_notifyUpdate.Checked = true;
                    break;

                case ConfigData.AutomaticUpdateMode.Disabled:
                    rdo_doNotUpdate.Checked = true;
                    break;
            }

            rdo_notifyUpdate.Checked = !rdo_autoUpdate.Checked;
            nud_buttonEnableDelay.Value = ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s;
            rdo_chStable.Checked = ConfigManager.Config.UpdateConfig.UpdateChannel == ConfigData.UpdateChannel.Stable;
            rdo_chDev.Checked = ConfigManager.Config.UpdateConfig.UpdateChannel == ConfigData.UpdateChannel.Development;
        }

        private void ApplyAutomaticUpdatesMode()
        {
            if (rdo_autoUpdate.Checked)
            {
                ConfigManager.Config.UpdateConfig.AutoUpdateMode = ConfigData.AutomaticUpdateMode.CheckDownloadInstall;
            }
            else if (rdo_notifyUpdate.Checked)
            {
                ConfigManager.Config.UpdateConfig.AutoUpdateMode = ConfigData.AutomaticUpdateMode.CheckOnly;
            }
            else if (rdo_doNotUpdate.Checked)
            {
                ConfigManager.Config.UpdateConfig.AutoUpdateMode = ConfigData.AutomaticUpdateMode.Disabled;
            }

            ConfigManager.SaveConfig();
        }

        private void Nud_buttonEnableDelay_ValueChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s = (int)nud_buttonEnableDelay.Value;
            ConfigManager.SaveConfig();
        }

        private bool updateModeChkChangedEvent = true;

        private void Rdo_chDev_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            if (!updateModeChkChangedEvent)
            {
                updateModeChkChangedEvent = true;
                return;
            }

            if (rdo_chDev.Checked)
            {
                var msg = MessageBox.Show("By changing the update channel to development, you might receive new features and updates faster, but the stability of the " +
                    "application might be worsened. Expect bugs, issues, data loss, and other bad things. Do not use this channel for production usage." +
                    "\r\n\r\nIf you change your mind later on, or when receiving new updates, you might need to reset all settings and progress data.\r\n\r\n" +
                    "SteelQuiz will be downgraded/upgraded to the latest release for the selected channel when switching.\r\n\r\nContinue?",
                    "Switch to dev update channel - SteelQuiz",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (msg != DialogResult.Yes)
                {
                    updateModeChkChangedEvent = false;
                    rdo_chStable.Checked = true;
                    return;
                }
                ConfigManager.Config.UpdateConfig.UpdateChannel = ConfigData.UpdateChannel.Development;
            }
            else
            {
                var msg = MessageBox.Show("SteelQuiz will be downgraded/upgraded to the latest release for the selected channel when switching." +
                    "\r\n\r\nChanging update channel to one with an older update might cause issues. If you do experience problems, reset the config and" +
                    " the quiz progress data.\r\n\r\nSwitch update channel to the stable channel?",
                    "Switch to stable update channel - SteelQuiz",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (msg != DialogResult.Yes)
                {
                    updateModeChkChangedEvent = false;
                    rdo_chDev.Checked = true;
                    return;
                }
                ConfigManager.Config.UpdateConfig.UpdateChannel = ConfigData.UpdateChannel.Stable;
            }

            ConfigManager.SaveConfig();

            var msg2 = MessageBox.Show("An update must be performed to switch update channels. Update now (highly recommended)?", "SteelQuiz", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (msg2 == DialogResult.Yes)
            {
                Updater.Update(Updater.UpdateMode.Force);
            }
        }

        private RadioButton lastAutoUpdateModeSelected;

        private void Rdo_autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                if (rdo_autoUpdate.Checked)
                {
                    lastAutoUpdateModeSelected = rdo_autoUpdate;
                }
                return;
            }

            if (rdo_autoUpdate.Checked)
            {
                ApplyAutomaticUpdatesMode();
                lastAutoUpdateModeSelected = rdo_autoUpdate;
            }
        }

        private void Rdo_notifyUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                if (rdo_notifyUpdate.Checked)
                {
                    lastAutoUpdateModeSelected = rdo_notifyUpdate;
                }
                return;
            }

            if (rdo_notifyUpdate.Checked)
            {
                ApplyAutomaticUpdatesMode();
                lastAutoUpdateModeSelected = rdo_notifyUpdate;
            }
        }

        private void Rdo_doNotUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                if (rdo_doNotUpdate.Checked)
                {
                    lastAutoUpdateModeSelected = rdo_doNotUpdate;
                }
                return;
            }

            if (rdo_doNotUpdate.Checked)
            {
                var msg = MessageBox.Show("Disabling automatic update checking is NOT recommended. " +
                    "Doing so prevents you from receiving updates including but not limited to:" +
                    "\r\n  - Security fixes" +
                    "\r\n  - Bug fixes" +
                    "\r\n  - Improvements" +
                    "\r\n  - New features" +
                    "\r\n\r\nRunning old versions may also prevent you from loading quizzes made for a newer version of SteelQuiz, and may cause issues with the quiz " +
                    "importer." +
                    "\r\n\r\nOne of the few valid reasons to run old versions is if you experience problems with newer versions." +
                    "\r\n\r\nAre you sure you want to disable automatic checking for updates?", "Disable Automatic Updates - SteelQuiz", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                {
                    lastAutoUpdateModeSelected.Checked = true;
                }
            }

            if (rdo_doNotUpdate.Checked)
            {
                ApplyAutomaticUpdatesMode();
                lastAutoUpdateModeSelected = rdo_doNotUpdate;
            }
        }
    }
}