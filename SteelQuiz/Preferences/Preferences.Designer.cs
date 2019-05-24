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
    partial class Preferences
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.pnl_prefCategories = new System.Windows.Forms.Panel();
            this.pnl_prefs = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_prefCategories
            // 
            this.pnl_prefCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnl_prefCategories.Location = new System.Drawing.Point(0, 0);
            this.pnl_prefCategories.Name = "pnl_prefCategories";
            this.pnl_prefCategories.Size = new System.Drawing.Size(130, 450);
            this.pnl_prefCategories.TabIndex = 11;
            // 
            // pnl_prefs
            // 
            this.pnl_prefs.AutoScroll = true;
            this.pnl_prefs.Location = new System.Drawing.Point(136, 0);
            this.pnl_prefs.Name = "pnl_prefs";
            this.pnl_prefs.Size = new System.Drawing.Size(652, 450);
            this.pnl_prefs.TabIndex = 12;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_prefs);
            this.Controls.Add(this.pnl_prefCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences - SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preferences_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_prefCategories;
        private System.Windows.Forms.Panel pnl_prefs;
    }
}