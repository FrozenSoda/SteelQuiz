/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

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

using SteelQuiz.ThemeManager.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Preferences
{
    public partial class Preferences : AutoThemeableForm
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();

        public Preferences()
        {
            InitializeComponent();
            pnl_prefs.Controls.Add(new PrefsGeneral());
            var catRoot = new CategoriesRoot();
            pnl_prefCategories.Controls.Add(catRoot);
            catRoot.Show();

            SetTheme();
        }

        protected override void SetTheme()
        {
            base.SetTheme();

            pnl_prefCategories.BackColor = PreferencesTheme.GetPrefCatPanelBackColor();
        }

        private void Apply()
        {
            foreach (var _prefs in pnl_prefs.Controls)
            {
                if (_prefs is PrefsGeneral)
                {
                    var prefs = _prefs as PrefsGeneral;

                    if (prefs.rdo_themeDark.Checked)
                    {
                        ConfigManager.Config.Theme = ThemeManager.ThemeCore.Theme.Dark;
                    }
                    else if (prefs.rdo_themeLight.Checked)
                    {
                        ConfigManager.Config.Theme = ThemeManager.ThemeCore.Theme.Light;
                    }

                    Program.frmWelcome.SetTheme();
                }
            }

            ConfigManager.SaveConfig();
        }

        public void SwitchCategoryCollection(Type category)
        {
            var found = false;
            foreach (var cat in pnl_prefCategories.Controls.OfType<CategoryCollection>())
            {
                if (cat.GetType() == category)
                {
                    cat.Show();
                    cat.BringToFront();
                    cat.InvokeSelectedEvent();
                    found = true;
                }
            }

            if (!found)
            {
                var cat = (CategoryCollection)Activator.CreateInstance(category);
                pnl_prefCategories.Controls.Add(cat);
                cat.Show();
                cat.BringToFront();
                cat.InvokeSelectedEvent();
            }
        }

        public void PopCategoryCollection(CategoryCollection categoryCollection)
        {
            var collections = pnl_prefCategories.Controls.OfType<CategoryCollection>();
            var currCollection = collections.ElementAt(collections.Count() - 1);
            categoryCollection.Hide(true);
            currCollection.InvokeSelectedEvent();
        }

        public void SwitchCategory(Type category)
        {
            var found = false;
            foreach (var prefs in pnl_prefs.Controls.OfType<UserControl>())
            {
                if (prefs.GetType() == category)
                {
                    prefs.Show();
                    found = true;
                }
                else
                {
                    prefs.Hide();
                }
            }

            if (!found)
            {
                pnl_prefs.Controls.Add((UserControl)Activator.CreateInstance(category));
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            Apply();
            DialogResult = DialogResult.OK;
        }
    }
}
