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
            this.pcat_maintenance = new SteelQuiz.PrefCategoryItem();
            this.pcat_general = new SteelQuiz.PrefCategoryItem();
            this.pcat_quizEditor = new SteelQuiz.PrefCategoryItem();
            this.pcat_updates = new SteelQuiz.PrefCategoryItem();
            this.pcat_sync = new SteelQuiz.PrefCategoryItem();
            this.pcat_advanced = new SteelQuiz.PrefCategoryItem();
            this.SuspendLayout();
            // 
            // pcat_maintenance
            // 
            this.pcat_maintenance.Location = new System.Drawing.Point(0, 153);
            this.pcat_maintenance.Name = "pcat_maintenance";
            this.pcat_maintenance.PrefText = "Maintenance >";
            this.pcat_maintenance.Selectable = false;
            this.pcat_maintenance.Selected = false;
            this.pcat_maintenance.Size = new System.Drawing.Size(130, 29);
            this.pcat_maintenance.TabIndex = 13;
            this.pcat_maintenance.OnPrefSelected += new System.EventHandler(this.Prefs_maintenance_OnPrefSelected);
            // 
            // pcat_general
            // 
            this.pcat_general.Location = new System.Drawing.Point(0, 13);
            this.pcat_general.Name = "pcat_general";
            this.pcat_general.PrefText = "General";
            this.pcat_general.Selectable = true;
            this.pcat_general.Selected = true;
            this.pcat_general.Size = new System.Drawing.Size(130, 29);
            this.pcat_general.TabIndex = 12;
            this.pcat_general.OnPrefSelected += new System.EventHandler(this.Prefs_general_OnPrefSelected);
            // 
            // pcat_quizEditor
            // 
            this.pcat_quizEditor.Location = new System.Drawing.Point(0, 83);
            this.pcat_quizEditor.Name = "pcat_quizEditor";
            this.pcat_quizEditor.PrefText = "Quiz Editor";
            this.pcat_quizEditor.Selectable = true;
            this.pcat_quizEditor.Selected = false;
            this.pcat_quizEditor.Size = new System.Drawing.Size(130, 29);
            this.pcat_quizEditor.TabIndex = 14;
            this.pcat_quizEditor.OnPrefSelected += new System.EventHandler(this.Pcat_quizEditor_OnPrefSelected);
            // 
            // pcat_updates
            // 
            this.pcat_updates.Location = new System.Drawing.Point(0, 48);
            this.pcat_updates.Name = "pcat_updates";
            this.pcat_updates.PrefText = "Updates";
            this.pcat_updates.Selectable = true;
            this.pcat_updates.Selected = false;
            this.pcat_updates.Size = new System.Drawing.Size(130, 29);
            this.pcat_updates.TabIndex = 15;
            this.pcat_updates.OnPrefSelected += new System.EventHandler(this.Pcat_updates_OnPrefSelected);
            // 
            // pcat_sync
            // 
            this.pcat_sync.Location = new System.Drawing.Point(0, 118);
            this.pcat_sync.Name = "pcat_sync";
            this.pcat_sync.PrefText = "Sync >";
            this.pcat_sync.Selectable = false;
            this.pcat_sync.Selected = false;
            this.pcat_sync.Size = new System.Drawing.Size(130, 29);
            this.pcat_sync.TabIndex = 16;
            this.pcat_sync.OnPrefSelected += new System.EventHandler(this.Pcat_sync_OnPrefSelected);
            // 
            // pcat_advanced
            // 
            this.pcat_advanced.Location = new System.Drawing.Point(0, 188);
            this.pcat_advanced.Name = "pcat_advanced";
            this.pcat_advanced.PrefText = "Advanced";
            this.pcat_advanced.Selectable = true;
            this.pcat_advanced.Selected = false;
            this.pcat_advanced.Size = new System.Drawing.Size(130, 29);
            this.pcat_advanced.TabIndex = 17;
            // 
            // CategoriesRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.pcat_advanced);
            this.Controls.Add(this.pcat_sync);
            this.Controls.Add(this.pcat_updates);
            this.Controls.Add(this.pcat_quizEditor);
            this.Controls.Add(this.pcat_maintenance);
            this.Controls.Add(this.pcat_general);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CategoriesRoot";
            this.Size = new System.Drawing.Size(130, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private PrefCategoryItem pcat_maintenance;
        private PrefCategoryItem pcat_general;
        private PrefCategoryItem pcat_quizEditor;
        private PrefCategoryItem pcat_updates;
        private PrefCategoryItem pcat_sync;
        private PrefCategoryItem pcat_advanced;
    }
}
