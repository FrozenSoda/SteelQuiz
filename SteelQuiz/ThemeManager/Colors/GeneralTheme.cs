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
                return Color.FromArgb(60, 60, 60);
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
    }
}
