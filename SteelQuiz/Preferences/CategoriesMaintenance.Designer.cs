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
    partial class CategoriesMaintenance
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
            this.prefs_troubleshooting = new SteelQuiz.PrefCategory();
            this.prefs_cleanUp = new SteelQuiz.PrefCategory();
            this.SuspendLayout();
            // 
            // prefs_troubleshooting
            // 
            this.prefs_troubleshooting.Location = new System.Drawing.Point(0, 83);
            this.prefs_troubleshooting.Name = "prefs_troubleshooting";
            this.prefs_troubleshooting.PrefText = "Troubleshooting";
            this.prefs_troubleshooting.Selectable = true;
            this.prefs_troubleshooting.Selected = false;
            this.prefs_troubleshooting.Size = new System.Drawing.Size(130, 29);
            this.prefs_troubleshooting.TabIndex = 13;
            // 
            // prefs_cleanUp
            // 
            this.prefs_cleanUp.Location = new System.Drawing.Point(0, 48);
            this.prefs_cleanUp.Name = "prefs_cleanUp";
            this.prefs_cleanUp.PrefText = "Clean Up";
            this.prefs_cleanUp.Selectable = true;
            this.prefs_cleanUp.Selected = true;
            this.prefs_cleanUp.Size = new System.Drawing.Size(130, 29);
            this.prefs_cleanUp.TabIndex = 12;
            this.prefs_cleanUp.OnPrefSelected += new System.EventHandler(this.Prefs_cleanUp_OnPrefSelected);
            // 
            // CategoriesMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.prefs_troubleshooting);
            this.Controls.Add(this.prefs_cleanUp);
            this.IsSubCategory = true;
            this.Name = "CategoriesMaintenance";
            this.Size = new System.Drawing.Size(130, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private PrefCategory prefs_troubleshooting;
        private PrefCategory prefs_cleanUp;
    }
}
