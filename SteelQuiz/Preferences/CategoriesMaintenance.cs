using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz.Preferences
{
    public partial class CategoriesMaintenance : CategoryCollection
    {

        public CategoriesMaintenance()
        {
            InitializeComponent();

            SetTheme();
        }

        private void Prefs_cleanUp_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsProgDataCleanUp));
        }
    }
}
