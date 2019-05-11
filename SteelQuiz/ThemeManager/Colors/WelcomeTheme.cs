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

        public Color GetTitleForeColor()
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

        public override Color GetLabelForeColor()
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

        public Color GetMainButtonBackColor()
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
                return Color.FromArgb(150, 150, 150);
            }
        }
    }
}
