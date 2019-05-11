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

namespace SteelQuiz.Preferences
{
    partial class CategoriesRoot
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prefs_maintenance = new SteelQuiz.PrefCategory();
            this.prefs_general = new SteelQuiz.PrefCategory();
            this.SuspendLayout();
            // 
            // prefs_maintenance
            // 
            this.prefs_maintenance.Location = new System.Drawing.Point(0, 48);
            this.prefs_maintenance.Name = "prefs_maintenance";
            this.prefs_maintenance.PrefText = "Maintenance >";
            this.prefs_maintenance.Selectable = false;
            this.prefs_maintenance.Selected = false;
            this.prefs_maintenance.Size = new System.Drawing.Size(130, 29);
            this.prefs_maintenance.TabIndex = 13;
            this.prefs_maintenance.OnPrefSelected += new System.EventHandler(this.Prefs_maintenance_OnPrefSelected);
            // 
            // prefs_general
            // 
            this.prefs_general.Location = new System.Drawing.Point(0, 13);
            this.prefs_general.Name = "prefs_general";
            this.prefs_general.PrefText = "General";
            this.prefs_general.Selectable = true;
            this.prefs_general.Selected = true;
            this.prefs_general.Size = new System.Drawing.Size(130, 29);
            this.prefs_general.TabIndex = 12;
            this.prefs_general.OnPrefSelected += new System.EventHandler(this.Prefs_general_OnPrefSelected);
            // 
            // CategoriesRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.prefs_maintenance);
            this.Controls.Add(this.prefs_general);
            this.Name = "CategoriesRoot";
            this.Size = new System.Drawing.Size(130, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private PrefCategory prefs_maintenance;
        private PrefCategory prefs_general;
    }
}
