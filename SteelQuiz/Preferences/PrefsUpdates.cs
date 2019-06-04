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
            rdo_autoUpdate.Checked = ConfigManager.Config.UpdateConfig.AutoUpdate;
            rdo_notifyUpdate.Checked = !rdo_autoUpdate.Checked;
            nud_buttonEnableDelay.Value = ConfigManager.Config.UpdateConfig.UpdateAvailableButtonEnableDelay_s;
            rdo_chStable.Checked = ConfigManager.Config.UpdateConfig.UpdateChannel == ConfigData.UpdateChannel.Stable;
            rdo_chDev.Checked = ConfigManager.Config.UpdateConfig.UpdateChannel == ConfigData.UpdateChannel.Development;
        }

        private void Rdo_autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            ConfigManager.Config.UpdateConfig.AutoUpdate = rdo_autoUpdate.Checked;
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
    }
}