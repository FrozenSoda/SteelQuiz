using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteelQuiz.ThemeManager.ThemeCore;

namespace SteelQuiz.ThemeManager.ThemeColors
{
    public static partial class Colors
    {
        public static Color GetBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(60, 60, 60);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
