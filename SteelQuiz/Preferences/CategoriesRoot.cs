/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

        private void Pcat_quizEditor_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsQuizEditor));
        }

        private void Pcat_updates_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsUpdates));
        }

        private void Pcat_storage_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsStorage));
        }

        private void Pcat_advanced_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsAdvanced));
        }

        private void pcat_about_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsAbout));
        }
    }
}
