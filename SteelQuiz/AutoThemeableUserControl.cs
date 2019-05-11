using SteelQuiz.ThemeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public class AutoThemeableUserControl : UserControl
    {
        public virtual void SetTheme()
        {
            AutoTheme.AutoSetTheme(this);
        }
    }
}
