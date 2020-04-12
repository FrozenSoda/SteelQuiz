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

using SteelQuiz.Extensions;
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

        public bool SaveConfig { get; set; } = true;

        public Preferences(Type selectedCategory = null, Type selectedCategoryCollection = null)
        {
            InitializeComponent();
            pnl_prefs.Controls.Add(new PrefsGeneral());
            var catRoot = new CategoriesRoot();
            pnl_prefCategories.Controls.Add(catRoot);
            catRoot.Show();

            SetTheme(null);

            /*
            this.Text += $" | v{Application.ProductVersion}";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += " PRE-RELEASE";
            }
            */
            if (MetaData.PRE_RELEASE)
            {
                this.Text += $" v{Application.ProductVersion} PRE-RELEASE";
            }

            if (selectedCategory != null)
            {
                SwitchCategoryCollection(selectedCategoryCollection);
                SwitchCategory(selectedCategory);
            }
        }

        public override void SetTheme(GeneralTheme theme)
        {
            base.SetTheme();

            pnl_prefCategories.BackColor = PreferencesTheme.GetPrefCatPanelBackColor();
        }

        /// <summary>
        /// Switches category collection
        /// </summary>
        /// <param name="category">The category collection type to switch to</param>
        public void SwitchCategoryCollection(Type category)
        {
            var found = false;
            foreach (var pcatc in pnl_prefCategories.Controls.OfType<CategoryCollection>())
            {
                if (pcatc.GetType() == category)
                {
                    pcatc.Show();
                    pcatc.BringToFront();
                    pcatc.InvokeSelectedEvent();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                var pcatc = (CategoryCollection)Activator.CreateInstance(category);
                pnl_prefCategories.Controls.Add(pcatc);
                pcatc.Show();
                pcatc.BringToFront();
                pcatc.InvokeSelectedEvent();
            }
        }

        /// <summary>
        /// Returns from a category collection to the previous one
        /// </summary>
        /// <param name="categoryCollection">The category collection to return from</param>
        public void PopCategoryCollection(CategoryCollection categoryCollection)
        {
            var deselect = categoryCollection.InvokeDeselectedEvent();
            if (!deselect)
            {
                return;
            }
            var collections = pnl_prefCategories.Controls.OfType<CategoryCollection>();
            var currCollection = collections.ElementAt(collections.Count() - 1);
            categoryCollection.Hide(true);
            currCollection.InvokeSelectedEvent();
        }


        /// <summary>
        /// Switches preferences category
        /// </summary>
        /// <param name="category">The category type to switch to</param>
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

        /// <summary>
        /// Saves the configuration for categories requiring custom save procedures
        /// </summary>
        /// <param name="category">The category whose configuration to save. The category MUST implement ICustomSaveCategory! If null, configuration for all 
        /// ICustomSaveCategory categories will be saved</param>
        public bool Save(Type category = null)
        {
            if (!SaveConfig)
            {
                return true;
            }

            bool result = true;

            if (category != null && !typeof(ICustomSaveCategory).IsAssignableFrom(category))
            {
                throw new ArgumentException("Save category must implement ICustomSaveCategory");
            }

            bool found = false;
            foreach (var prefs in pnl_prefs.Controls.OfType<ICustomSaveCategory>())
            {
                if (category == null || category == prefs.GetType())
                {
                    bool s = prefs.Save(false);
                    if (result)
                    {
                        result = s;
                    }
                    found = true;
                }
            }

            if (category != null && !found)
            {
                throw new Exception("Save category could not be found");
            }

            bool save = ConfigManager.SaveConfig();
            if (result)
            {
                result = save;
            }

            return result;
        }

        private void Preferences_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            Program.frmWelcome.UpdateCfg();
        }
    }
}
