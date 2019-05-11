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
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
            pnl_prefs.Controls.Add(new PrefsUI());
        }

        private void Apply()
        {
            throw new NotImplementedException();
        }

        private void SwitchCategory(Type category)
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

        private void Prefs_UI_OnPrefSelected(object sender, EventArgs e)
        {
            SwitchCategory(typeof(PrefsUI));
        }
    }
}
