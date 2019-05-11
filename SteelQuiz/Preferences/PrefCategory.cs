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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class PrefCategory : UserControl, ThemeManager.IThemeable
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();

        public event EventHandler OnPrefSelected;

        private bool _selected = false;
        public bool Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                if (value == _selected)
                {
                    // selection is already set
                    return;
                }

                // update color
                if (value)
                {
                    this.lbl_text.BackColor = PreferencesTheme.GetPrefSelectedBackColor();
                    this.lbl_selectedIndicator.BackColor = Color.FromArgb(255, 128, 0);

                    if (Parent != null)
                    {
                        // deselect other categories
                        foreach (var cat in Parent.Controls.OfType<PrefCategory>())
                        {
                            if (cat != this)
                            {
                                cat.Selected = false;
                            }
                        }
                    }

                    this.OnPrefSelected?.Invoke(this, null);
                }
                else
                {
                    this.lbl_text.BackColor = PreferencesTheme.GetPrefBackColor();
                    this.lbl_selectedIndicator.BackColor = PreferencesTheme.GetPrefBackColor();
                }

                _selected = value;
            }
        }

        public string PrefText
        {
            get
            {
                return this.lbl_text.Text;
            }

            set
            {
                this.lbl_text.Text = value;
            }
        }

        public PrefCategory()
        {
            InitializeComponent();
            SetTheme();
        }

        public void SetTheme()
        {
            lbl_text.BackColor = PreferencesTheme.GetPrefBackColor();
            lbl_text.ForeColor = PreferencesTheme.GetPrefForeColor();

            lbl_selectedIndicator.BackColor = PreferencesTheme.GetPrefBackColor();
        }

        private void StartHover()
        {
            if (Selected)
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPrefSelectedHoverBackColor();
            }
            else
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPreferenceHoverBackColor();
                this.lbl_selectedIndicator.BackColor = PreferencesTheme.GetPreferenceHoverBackColor();
            }
        }

        private void StopHover()
        {
            if (Selected)
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPrefSelectedBackColor();
            }
            else
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPrefBackColor();
                this.lbl_selectedIndicator.BackColor = PreferencesTheme.GetPrefBackColor();
            }
        }

        private void Lbl_text_MouseEnter(object sender, EventArgs e)
        {
            StartHover();
        }

        private void Lbl_text_MouseLeave(object sender, EventArgs e)
        {
            StopHover();
        }

        private void Lbl_selectedIndicator_MouseEnter(object sender, EventArgs e)
        {
            StartHover();
        }

        private void Lbl_selectedIndicator_MouseLeave(object sender, EventArgs e)
        {
            StopHover();
        }

        private void Lbl_text_Click(object sender, EventArgs e)
        {
            Selected = true;
        }

        private void Lbl_selectedIndicator_Click(object sender, EventArgs e)
        {
            Selected = true;
        }
    }
}
