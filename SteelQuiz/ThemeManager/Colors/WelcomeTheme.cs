using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteelQuiz.ThemeManager.ThemeCore;

namespace SteelQuiz.ThemeManager.Colors
{
    public static class WelcomeTheme
    {
        public static Color GetBackColor()
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

        public static Color GetTitleForeColor()
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

        public static Color GetLabelForeColor()
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

        public static Color GetMainButtonBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(65, 105, 225);
            }
            else
            {
                return Color.FromArgb(100, 149, 237);
            }
        }

        public static Color GetMainButtonForeColor()
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

        public static Color GetButtonBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(100, 100, 100);
            }
            else
            {
                return Color.FromArgb(150, 150, 150);
            }
        }

        public static Color GetButtonForeColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(255, 255, 255);
            }
            else
            {
                return Color.FromArgb(255, 255, 255);
            }
        }
    }
}
