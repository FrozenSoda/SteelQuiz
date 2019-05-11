using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SteelQuiz.ThemeManager
{
    public static partial class ThemeCore
    {
        public static Color GetPreferenceBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(70, 70, 70);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static Color GetPreferenceSelectedBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(80, 80, 80);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static Color GetPreferenceHoverBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(75, 75, 75);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static Color GetPreferenceSelectedHoverBackColor()
        {
            if (ConfigManager.Config == null || ConfigManager.Config.Theme == Theme.Dark)
            {
                return Color.FromArgb(85, 85, 85);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
