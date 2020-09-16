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
    partial class RenameQuiz
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
            this.txt_newName = new System.Windows.Forms.TextBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_newName
            // 
            this.txt_newName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txt_newName.Location = new System.Drawing.Point(12, 12);
            this.txt_newName.Name = "txt_newName";
            this.txt_newName.Size = new System.Drawing.Size(275, 22);
            this.txt_newName.TabIndex = 0;
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_apply.FlatAppearance.BorderSize = 0;
            this.btn_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_apply.Location = new System.Drawing.Point(293, 12);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 1;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // RenameQuiz
            // 
            this.AcceptButton = this.btn_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(380, 45);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.txt_newName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RenameQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename Quiz - SteelQuiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_newName;
        private System.Windows.Forms.Button btn_apply;
    }
}