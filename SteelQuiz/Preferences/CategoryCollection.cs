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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Preferences
{
    public class CategoryCollection : AutoThemeableUserControl
    {
        //public event EventHandler OnCollectionDeselected;

        private Button backButton;

        private bool _isSubCategory = false;
        public bool IsSubCategory
        {
            get
            {
                return _isSubCategory;
            }

            set
            {
                if (value)
                {
                    this.backButton = new Button();
                    this.backButton.Click += BackButton_Click;
                    this.backButton.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
                    this.backButton.FlatAppearance.BorderSize = 0;
                    this.backButton.FlatStyle = FlatStyle.Flat;
                    this.backButton.ForeColor = System.Drawing.Color.White;
                    this.backButton.Location = new System.Drawing.Point(0, 13);
                    this.backButton.Name = "btn_back";
                    this.backButton.Size = new System.Drawing.Size(130, 23);
                    this.backButton.TabIndex = 14;
                    this.backButton.Text = "←";
                    this.backButton.UseVisualStyleBackColor = false;
                    Controls.Add(backButton);
                }
                else
                {
                    backButton.Dispose();
                    backButton = null;
                }
                _isSubCategory = value;
            }
        }

        private PreferencesTheme PreferencesTheme = new PreferencesTheme();

        /// <summary>
        /// A control used as a preference category collection in the category menu
        /// </summary>
        public CategoryCollection() : base()
        {
            Location = new System.Drawing.Point(Width, Location.Y);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            (ParentForm as Preferences).PopCategoryCollection(this);
        }

        public override void SetTheme()
        {
            base.SetTheme();

            BackColor = PreferencesTheme.GetPrefCatPanelBackColor();
            if (backButton != null)
            {
                backButton.BackColor = PreferencesTheme.GetPrefCatPanelBackColor();
            }
        }

        /// <summary>
        /// Invokes the event to be fired when selecting the category collection
        /// </summary>
        public void InvokeSelectedEvent()
        {
            foreach (var pcat in Controls.OfType<PrefCategoryItem>())
            {
                if (pcat.Selected)
                {
                    pcat.InvokePrefSelected();
                }
            }
        }

        /// <summary>
        /// Invokes the event to be fired when deselecting the category collection
        /// </summary>
        public void InvokeDeselectedEvent()
        {
            foreach (var pcat in Controls.OfType<PrefCategoryItem>())
            {
                if (pcat.Selected)
                {
                    pcat.InvokePrefDeselected();
                }
            }
        }

        /// <summary>
        /// Flips the page to the category collection (shows it), including the animation
        /// </summary>
        public new void Show()
        {
            Location = new System.Drawing.Point(Width, Location.Y);
            base.Show();

            // animation
            var tmr = new System.Timers.Timer
            {
                Interval = 1,
                SynchronizingObject = this
            };
            tmr.Elapsed += delegate
            {
                if (Location.X <= 0)
                {
                    Location = new System.Drawing.Point(0, Location.Y);
                    tmr.Stop();
                    return;
                }
                Location = new System.Drawing.Point(Location.X - 10, Location.Y);
            };
            tmr.Start();
        }

        /// <summary>
        /// Hides the category collection
        /// </summary>
        public new void Hide()
        {
            Hide(false);
        }

        /// <summary>
        /// Flips to the previous category collection (hides the category collection), with an animation
        /// </summary>
        /// <param name="dispose">True if the category collection should be disposed after hiding it</param>
        public void Hide(bool dispose = false)
        {
            // animation
            var tmr = new System.Timers.Timer
            {
                Interval = 1,
                SynchronizingObject = this
            };
            tmr.Elapsed += delegate
            {
                if (Location.X >= Width)
                {
                    tmr.Stop();
                    base.Hide();
                    if (dispose)
                    {
                        base.Dispose();
                    }
                    return;
                }
                Location = new System.Drawing.Point(Location.X + 10, Location.Y);
            };
            tmr.Start();
        }
    }
}
