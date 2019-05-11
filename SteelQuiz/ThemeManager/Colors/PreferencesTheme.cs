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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static SteelQuiz.ThemeManager.ThemeCore;

namespace SteelQuiz.ThemeManager.Colors
{
    public class PreferencesTheme : GeneralTheme
    {

        public Color GetPrefCatPanelBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(70, 70, 70);
            }
            else
            {
                return Color.FromArgb(214, 214, 214);
            }
        }

        public Color GetPrefBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(70, 70, 70);
            }
            else
            {
                return Color.FromArgb(214, 214, 214);
            }
        }

        public Color GetPrefForeColor()
        {
            return GetButtonForeColor();
        }

        public Color GetPrefSelectedBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(80, 80, 80);
            }
            else
            {
                return Color.FromArgb(204, 204, 204);
            }
        }

        public Color GetPreferenceHoverBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(75, 75, 75);
            }
            else
            {
                return Color.FromArgb(209, 209, 209);
            }
        }

        public Color GetPrefSelectedHoverBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(85, 85, 85);
            }
            else
            {
                return Color.FromArgb(199, 199, 199);
            }
        }
    }
}
