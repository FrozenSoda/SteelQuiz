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
    partial class CategoriesSync
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
            this.pcat_progSync = new SteelQuiz.PrefCategoryItem();
            this.SuspendLayout();
            // 
            // pcat_progSync
            // 
            this.pcat_progSync.Location = new System.Drawing.Point(0, 48);
            this.pcat_progSync.Name = "pcat_progSync";
            this.pcat_progSync.PrefText = "Progress Sync";
            this.pcat_progSync.Selectable = true;
            this.pcat_progSync.Selected = true;
            this.pcat_progSync.Size = new System.Drawing.Size(130, 29);
            this.pcat_progSync.TabIndex = 1;
            this.pcat_progSync.OnPrefSelected += new System.EventHandler(this.Pcat_progSync_OnPrefSelected);
            this.pcat_progSync.OnPrefDeselected += new System.EventHandler<SteelQuiz.Util.ReturnArgs>(this.Pcat_progSync_OnPrefDeselected);
            // 
            // CategoriesSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pcat_progSync);
            this.IsSubCategory = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CategoriesSync";
            this.Size = new System.Drawing.Size(130, 409);
            this.ResumeLayout(false);

        }

        #endregion
        private PrefCategoryItem pcat_progSync;
    }
}
