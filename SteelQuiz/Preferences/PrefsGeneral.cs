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
using Microsoft.Win32;

namespace SteelQuiz.Preferences
{
    public partial class PrefsGeneral : AutoThemeableUserControl, IPreferenceCategory
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();
        private bool skipConfigApply = true;

        public PrefsGeneral()
        {
            InitializeComponent();

            LoadPreferences();
            //chk_win10themeSync.Enabled = Program.Win10AppThemeSupported();
            chk_win10themeSync.Enabled = Util.WinVer.WindowsVersion().Major >= 10;
            if (!chk_win10themeSync.Enabled)
            {
                chk_win10themeSync.Checked = false;
            }
            SetTheme();
            skipConfigApply = false;
        }

        public void LoadPreferences()
        {
            switch (ConfigManager.Config.Theme)
            {
                case ThemeManager.ThemeCore.Theme.Dark:
                    rdo_themeDark.Checked = true;
                    break;

                case ThemeManager.ThemeCore.Theme.Light:
                    rdo_themeLight.Checked = true;
                    break;
            }

            rdo_showNameOnWelcome.Checked = ConfigManager.Config.ShowNameOnWelcomeScreen;
            rdo_dontShowNameOnWelcome.Checked = !rdo_showNameOnWelcome.Checked;
            txt_name.Text = ConfigManager.Config.FullName;
            chk_win10themeSync.Checked = ConfigManager.Config.SyncWin10Theme;
        }

        private void Rdo_themeLight_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            if (rdo_themeLight.Checked)
            {
                ConfigManager.Config.Theme = ThemeManager.ThemeCore.Theme.Light;
            }
            else
            {
                ConfigManager.Config.Theme = ThemeManager.ThemeCore.Theme.Dark;
            }

            ConfigManager.SaveConfig();

            if (ConfigManager.Config.SyncWin10Theme)
            {
                SetWin10Theme();
            }

            Program.frmWelcome.SetThemeAll();
            //reshow preferences window, to use new theme
            Program.frmPreferences.DialogResult = DialogResult.OK;
            Program.frmWelcome.ShowPreferences();
        }

        private void Txt_name_TextChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            ConfigManager.Config.FullName = txt_name.Text;
            if (txt_name.Text == "")
            {
                rdo_dontShowNameOnWelcome.Checked = true;
            }
        }

        private void Rdo_showNameOnWelcome_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            if (rdo_showNameOnWelcome.Checked && txt_name.Text == "")
            {
                MessageBox.Show("Please enter your name first", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdo_dontShowNameOnWelcome.Checked = true;
                return;
            }

            ConfigManager.Config.ShowNameOnWelcomeScreen = rdo_showNameOnWelcome.Checked;
            ConfigManager.SaveConfig();
            Program.frmWelcome.UpdateCfg();
        }

        private void Txt_name_Leave(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            ConfigManager.SaveConfig();
            Program.frmWelcome.UpdateCfg();
        }

        private void Txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ConfigManager.SaveConfig();
                Program.frmWelcome.UpdateCfg();
            }
        }

        /// <summary>
        /// Sets the Windows 10 app theme
        /// </summary>
        public void SetWin10Theme()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true))
            {
                if (key == null)
                {
                    return;
                }

                object lightStr = key.GetValue("AppsUseLightTheme");

                if (lightStr == null)
                {
                    // User don't have Windows 10, or the Windows 10 build is too old for app theme
                    return;
                }

                int light = Convert.ToInt32(ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Light);
                key.SetValue("AppsUseLightTheme", light, RegistryValueKind.DWord);
            }
        }

        private void Chk_win10themeSync_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            ConfigManager.Config.SyncWin10Theme = chk_win10themeSync.Checked;
            ConfigManager.SaveConfig();

            if (ConfigManager.Config.SyncWin10Theme)
            {
                // Set app theme to Win10 theme

                var theme = Program.GetWin10Theme();
                if (theme == ThemeManager.ThemeCore.Theme.Light)
                {
                    rdo_themeLight.Checked = true;
                }
                else if (theme == ThemeManager.ThemeCore.Theme.Dark)
                {
                    rdo_themeDark.Checked = true;
                }
            }
        }
    }
}