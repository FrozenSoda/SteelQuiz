using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    public static class ThemeManager
    {
        public enum Theme
        {
            Light,
            Dark
        }

        public static System.Drawing.Color GetPreferenceBackColor()
        {
            if (ConfigManager.Config.Theme == Theme.Dark)
            {
                return System.Drawing.Color.FromArgb(70, 70, 70);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static System.Drawing.Color GetPreferenceSelectedBackColor()
        {
            if (ConfigManager.Config.Theme == Theme.Dark)
            {
                return System.Drawing.Color.FromArgb(80, 80, 80);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
