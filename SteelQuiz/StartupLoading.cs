using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class StartupLoading : AutoThemeableForm
    {
        public StartupLoading()
        {
            InitializeComponent();
            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                pic_loading.Image = Properties.Resources.Dual_Ring_1s_80px_white;
            }
            else
            {
                pic_loading.Image = Properties.Resources.Dual_Ring_1s_80px_black;
            }
            SetTheme();
        }
    }
}
