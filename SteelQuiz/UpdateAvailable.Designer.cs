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
    partial class UpdateAvailable
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAvailable));
            this.lbl_top = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_notNow = new System.Windows.Forms.Button();
            this.rtf_releaseNotes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_installedVer = new System.Windows.Forms.Label();
            this.tmr_btnEnable = new System.Windows.Forms.Timer(this.components);
            this.chk_autoUpdateInFuture = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_top
            // 
            this.lbl_top.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_top.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_top.Location = new System.Drawing.Point(12, 9);
            this.lbl_top.Name = "lbl_top";
            this.lbl_top.Size = new System.Drawing.Size(776, 43);
            this.lbl_top.TabIndex = 1;
            this.lbl_top.Text = "A new version of SteelQuiz is available (v0.0.0)";
            this.lbl_top.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "It is recommended that you update, to get the latest features, bug fixes and impr" +
    "ovements";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_update.Enabled = false;
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(481, 392);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(307, 46);
            this.btn_update.TabIndex = 0;
            this.btn_update.Text = "(3s) Update now (recommended)";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // btn_notNow
            // 
            this.btn_notNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_notNow.Enabled = false;
            this.btn_notNow.FlatAppearance.BorderSize = 0;
            this.btn_notNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_notNow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_notNow.ForeColor = System.Drawing.Color.White;
            this.btn_notNow.Location = new System.Drawing.Point(12, 392);
            this.btn_notNow.Name = "btn_notNow";
            this.btn_notNow.Size = new System.Drawing.Size(140, 46);
            this.btn_notNow.TabIndex = 2;
            this.btn_notNow.Text = "(3s) Not now";
            this.btn_notNow.UseVisualStyleBackColor = false;
            this.btn_notNow.Click += new System.EventHandler(this.Btn_notNow_Click);
            // 
            // rtf_releaseNotes
            // 
            this.rtf_releaseNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.rtf_releaseNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtf_releaseNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtf_releaseNotes.ForeColor = System.Drawing.Color.White;
            this.rtf_releaseNotes.Location = new System.Drawing.Point(12, 140);
            this.rtf_releaseNotes.Name = "rtf_releaseNotes";
            this.rtf_releaseNotes.ReadOnly = true;
            this.rtf_releaseNotes.Size = new System.Drawing.Size(776, 246);
            this.rtf_releaseNotes.TabIndex = 1;
            this.rtf_releaseNotes.Text = "Please wait...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(776, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Release notes:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_installedVer
            // 
            this.lbl_installedVer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_installedVer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_installedVer.Location = new System.Drawing.Point(8, 85);
            this.lbl_installedVer.Name = "lbl_installedVer";
            this.lbl_installedVer.Size = new System.Drawing.Size(776, 27);
            this.lbl_installedVer.TabIndex = 7;
            this.lbl_installedVer.Text = "Installed version: v0.0.0";
            this.lbl_installedVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_btnEnable
            // 
            this.tmr_btnEnable.Enabled = true;
            this.tmr_btnEnable.Interval = 1000;
            this.tmr_btnEnable.Tick += new System.EventHandler(this.Tmr_btnEnable_Tick);
            // 
            // chk_autoUpdateInFuture
            // 
            this.chk_autoUpdateInFuture.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_autoUpdateInFuture.ForeColor = System.Drawing.Color.White;
            this.chk_autoUpdateInFuture.Location = new System.Drawing.Point(219, 392);
            this.chk_autoUpdateInFuture.Name = "chk_autoUpdateInFuture";
            this.chk_autoUpdateInFuture.Size = new System.Drawing.Size(256, 46);
            this.chk_autoUpdateInFuture.TabIndex = 8;
            this.chk_autoUpdateInFuture.Text = "In the future, update automatically";
            this.chk_autoUpdateInFuture.UseVisualStyleBackColor = true;
            this.chk_autoUpdateInFuture.CheckedChanged += new System.EventHandler(this.Chk_autoUpdateInFuture_CheckedChanged);
            // 
            // UpdateAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chk_autoUpdateInFuture);
            this.Controls.Add(this.lbl_installedVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtf_releaseNotes);
            this.Controls.Add(this.btn_notNow);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateAvailable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Software Update Available - SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateAvailable_FormClosing);
            this.Shown += new System.EventHandler(this.UpdateAvailable_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_notNow;
        private System.Windows.Forms.RichTextBox rtf_releaseNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_installedVer;
        private System.Windows.Forms.Timer tmr_btnEnable;
        private System.Windows.Forms.CheckBox chk_autoUpdateInFuture;
    }
}