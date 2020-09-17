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

namespace SteelQuiz.Preferences
{
    partial class PrefsAbout
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
            this.pnl_updates = new System.Windows.Forms.Panel();
            this.btn_chkUpdates = new System.Windows.Forms.Button();
            this.lbl_versionType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_installedVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llb_gitHub = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_updates.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_updates
            // 
            this.pnl_updates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_updates.Controls.Add(this.btn_chkUpdates);
            this.pnl_updates.Controls.Add(this.lbl_versionType);
            this.pnl_updates.Controls.Add(this.label5);
            this.pnl_updates.Controls.Add(this.lbl_installedVersion);
            this.pnl_updates.Controls.Add(this.label2);
            this.pnl_updates.Controls.Add(this.label3);
            this.pnl_updates.Location = new System.Drawing.Point(14, 172);
            this.pnl_updates.Name = "pnl_updates";
            this.pnl_updates.Size = new System.Drawing.Size(635, 138);
            this.pnl_updates.TabIndex = 4;
            // 
            // btn_chkUpdates
            // 
            this.btn_chkUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_chkUpdates.FlatAppearance.BorderSize = 0;
            this.btn_chkUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chkUpdates.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chkUpdates.ForeColor = System.Drawing.Color.White;
            this.btn_chkUpdates.Location = new System.Drawing.Point(19, 101);
            this.btn_chkUpdates.Name = "btn_chkUpdates";
            this.btn_chkUpdates.Size = new System.Drawing.Size(116, 24);
            this.btn_chkUpdates.TabIndex = 9;
            this.btn_chkUpdates.Text = "Check for Updates";
            this.btn_chkUpdates.UseVisualStyleBackColor = false;
            this.btn_chkUpdates.Click += new System.EventHandler(this.btn_chkUpdates_Click);
            // 
            // lbl_versionType
            // 
            this.lbl_versionType.AutoSize = true;
            this.lbl_versionType.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_versionType.Location = new System.Drawing.Point(141, 69);
            this.lbl_versionType.Name = "lbl_versionType";
            this.lbl_versionType.Size = new System.Drawing.Size(75, 20);
            this.lbl_versionType.TabIndex = 8;
            this.lbl_versionType.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Version Type:";
            // 
            // lbl_installedVersion
            // 
            this.lbl_installedVersion.AutoSize = true;
            this.lbl_installedVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_installedVersion.Location = new System.Drawing.Point(141, 40);
            this.lbl_installedVersion.Name = "lbl_installedVersion";
            this.lbl_installedVersion.Size = new System.Drawing.Size(53, 20);
            this.lbl_installedVersion.TabIndex = 6;
            this.lbl_installedVersion.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Installed Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Updates";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.llb_gitHub);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 138);
            this.panel1.TabIndex = 3;
            // 
            // llb_gitHub
            // 
            this.llb_gitHub.AutoSize = true;
            this.llb_gitHub.LinkColor = System.Drawing.Color.Aqua;
            this.llb_gitHub.Location = new System.Drawing.Point(16, 109);
            this.llb_gitHub.Name = "llb_gitHub";
            this.llb_gitHub.Size = new System.Drawing.Size(44, 13);
            this.llb_gitHub.TabIndex = 2;
            this.llb_gitHub.TabStop = true;
            this.llb_gitHub.Text = "GitHub";
            this.llb_gitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_gitHub_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "A quiz program designed to make learning easier.\r\n\r\nCopyright (C) 2020 Steel9Apps" +
    "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "SteelQuiz";
            // 
            // PrefsAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_updates);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "PrefsAbout";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_updates.ResumeLayout(false);
            this.pnl_updates.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_updates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_installedVersion;
        private System.Windows.Forms.Label lbl_versionType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_chkUpdates;
        private System.Windows.Forms.LinkLabel llb_gitHub;
    }
}
