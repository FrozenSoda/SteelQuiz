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

namespace SteelQuiz
{
    partial class PrefCategoryItem
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
            this.lbl_text = new System.Windows.Forms.Label();
            this.lbl_selectedIndicator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbl_text.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.White;
            this.lbl_text.Location = new System.Drawing.Point(8, 0);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(122, 29);
            this.lbl_text.TabIndex = 3;
            this.lbl_text.Text = "CATEGORY";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_text.Click += new System.EventHandler(this.Lbl_text_Click);
            this.lbl_text.MouseEnter += new System.EventHandler(this.Lbl_text_MouseEnter);
            this.lbl_text.MouseLeave += new System.EventHandler(this.Lbl_text_MouseLeave);
            // 
            // lbl_selectedIndicator
            // 
            this.lbl_selectedIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbl_selectedIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_selectedIndicator.Location = new System.Drawing.Point(0, 0);
            this.lbl_selectedIndicator.Name = "lbl_selectedIndicator";
            this.lbl_selectedIndicator.Size = new System.Drawing.Size(8, 29);
            this.lbl_selectedIndicator.TabIndex = 2;
            this.lbl_selectedIndicator.Click += new System.EventHandler(this.Lbl_selectedIndicator_Click);
            this.lbl_selectedIndicator.MouseEnter += new System.EventHandler(this.Lbl_selectedIndicator_MouseEnter);
            this.lbl_selectedIndicator.MouseLeave += new System.EventHandler(this.Lbl_selectedIndicator_MouseLeave);
            // 
            // PrefCategoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.lbl_selectedIndicator);
            this.Name = "PrefCategoryItem";
            this.Size = new System.Drawing.Size(130, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label lbl_selectedIndicator;
    }
}
