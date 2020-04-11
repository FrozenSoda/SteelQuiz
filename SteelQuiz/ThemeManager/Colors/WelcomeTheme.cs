/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteelQuiz.ThemeManager.ThemeCore;

namespace SteelQuiz.ThemeManager.Colors
{
    public class WelcomeTheme : GeneralTheme
    {
        public override Color GetBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(80, 80, 80);
            }
            else
            {
                return Color.FromArgb(224, 224, 224);
            }
        }

        public override Color GetMainLabelForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(245, 245, 245);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
        }

        public Color GetMainButtonBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                //return Color.FromArgb(65, 105, 225);
                return Color.FromArgb(106, 90, 205);
            }
            else
            {
                //return Color.FromArgb(100, 149, 237);
                return Color.FromArgb(106, 90, 205);
            }
        }

        public Color GetMainButtonForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(245, 245, 245);
            }
            else
            {
                return Color.FromArgb(245, 245, 245);
            }
        }

        public override Color GetButtonBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(100, 100, 100);
            }
            else
            {
                return Color.FromArgb(192, 192, 192);
            }
        }

        public Color GetButtonRedForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.LightCoral;
            }
            else
            {
                return Color.Red;
            }
        }
    }
}
