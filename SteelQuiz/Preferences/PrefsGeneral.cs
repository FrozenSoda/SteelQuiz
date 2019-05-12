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
    public partial class PrefsGeneral : AutoThemeableUserControl, IPreferenceCategory
    {
        private bool skipConfigApply = true;

        public PrefsGeneral()
        {
            InitializeComponent();

            LoadPreferences();
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
                ConfigManager.SaveConfig();

                Program.frmWelcome.SetTheme();
                //reshow preferences window, to use new theme
                Program.frmPreferences.DialogResult = DialogResult.OK;
                Program.frmWelcome.ShowPreferences();
            }
        }

        private void Rdo_themeDark_CheckedChanged(object sender, EventArgs e)
        {
            if (skipConfigApply)
            {
                return;
            }

            if (rdo_themeDark.Checked)
            {
                ConfigManager.Config.Theme = ThemeManager.ThemeCore.Theme.Dark;
                ConfigManager.SaveConfig();

                Program.frmWelcome.SetTheme();
                //reshow preferences window, to use new theme
                Program.frmPreferences.DialogResult = DialogResult.OK;
                Program.frmWelcome.ShowPreferences();
            }
        }
    }
}
