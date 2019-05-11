using SteelQuiz.ThemeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public class AutoThemeableForm : Form
    {
        public virtual void SetTheme()
        {
            AutoTheme.AutoSetTheme(this);
        }
    }
}
