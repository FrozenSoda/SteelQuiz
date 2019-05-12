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

namespace SteelQuiz.QuizEditor
{
    partial class SaveDontSave
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
            this.lbl_msg = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.pic_icon = new System.Windows.Forms.PictureBox();
            this.btn_doNotSave = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.chk_doNotSave = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_msg
            // 
            this.lbl_msg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msg.ForeColor = System.Drawing.Color.White;
            this.lbl_msg.Location = new System.Drawing.Point(78, 12);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(309, 36);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "The project contains unsaved changes. Save before quitting?";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(12, 87);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(115, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // pic_icon
            // 
            this.pic_icon.Location = new System.Drawing.Point(12, 12);
            this.pic_icon.Name = "pic_icon";
            this.pic_icon.Size = new System.Drawing.Size(60, 60);
            this.pic_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_icon.TabIndex = 2;
            this.pic_icon.TabStop = false;
            // 
            // btn_doNotSave
            // 
            this.btn_doNotSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_doNotSave.Enabled = false;
            this.btn_doNotSave.FlatAppearance.BorderSize = 0;
            this.btn_doNotSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doNotSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_doNotSave.ForeColor = System.Drawing.Color.White;
            this.btn_doNotSave.Location = new System.Drawing.Point(133, 87);
            this.btn_doNotSave.Name = "btn_doNotSave";
            this.btn_doNotSave.Size = new System.Drawing.Size(115, 23);
            this.btn_doNotSave.TabIndex = 3;
            this.btn_doNotSave.Text = "Do not save";
            this.btn_doNotSave.UseVisualStyleBackColor = false;
            this.btn_doNotSave.Click += new System.EventHandler(this.Btn_doNotSave_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(272, 87);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(115, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // chk_doNotSave
            // 
            this.chk_doNotSave.AutoSize = true;
            this.chk_doNotSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_doNotSave.ForeColor = System.Drawing.Color.White;
            this.chk_doNotSave.Location = new System.Drawing.Point(81, 55);
            this.chk_doNotSave.Name = "chk_doNotSave";
            this.chk_doNotSave.Size = new System.Drawing.Size(156, 17);
            this.chk_doNotSave.TabIndex = 2;
            this.chk_doNotSave.Text = "Do not save confirmation";
            this.chk_doNotSave.UseVisualStyleBackColor = true;
            this.chk_doNotSave.CheckedChanged += new System.EventHandler(this.Chk_doNotSave_CheckedChanged);
            // 
            // SaveDontSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(395, 118);
            this.ControlBox = false;
            this.Controls.Add(this.chk_doNotSave);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_doNotSave);
            this.Controls.Add(this.pic_icon);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SaveDontSave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Save before exiting? - SteelQuiz";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_msg;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.PictureBox pic_icon;
        private System.Windows.Forms.Button btn_doNotSave;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.CheckBox chk_doNotSave;
    }
}