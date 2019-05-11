﻿/*
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteelQuiz.ThemeManager.ThemeCore;

namespace SteelQuiz.ThemeManager.Colors
{
    public class GeneralTheme
    {
        public virtual Color GetBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(64, 64, 64);
            }
            else
            {
                return Color.FromArgb(224, 224, 224);
            }
        }

        public virtual Color GetButtonBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(80, 80, 80);
            }
            else
            {
                return Color.FromArgb(192, 192, 192);
            }
        }

        public virtual Color GetButtonForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(255, 255, 255);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
        }

        public virtual Color GetMainLabelForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(255, 255, 255);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
        }

        public virtual Color GetBackgroundLabelForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(211, 211, 211);
            }
            else
            {
                return Color.FromArgb(105, 105, 105);
            }
        }

        public virtual Color GetTextBoxBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(70, 70, 70);
            }
            else
            {
                return Color.FromArgb(255, 255, 255);
            }
        }

        public virtual Color GetTextBoxForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(255, 255, 255);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
        }
    }
}
