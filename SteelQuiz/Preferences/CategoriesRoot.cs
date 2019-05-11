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
    public partial class CategoriesRoot : CategoryCollection
    {

        public CategoriesRoot()
        {
            InitializeComponent();

            SetTheme();
        }

        private void Prefs_general_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsGeneral));
        }

        private void Prefs_maintenance_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategoryCollection(typeof(CategoriesMaintenance));
        }
    }
}
