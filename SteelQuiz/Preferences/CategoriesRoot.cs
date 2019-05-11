using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Preferences
{
    public partial class CategoriesRoot : AutoThemeableUserControl
    {
        public CategoriesRoot()
        {
            InitializeComponent();

            SetTheme();
        }

        private void Prefs_UI_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsUI));
        }

        private void Prefs_updates_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsProgDataCleanUp));
        }
    }
}
