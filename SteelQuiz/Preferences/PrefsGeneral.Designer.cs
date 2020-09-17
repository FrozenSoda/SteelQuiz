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
    partial class PrefsGeneral
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
            this.pnl_name = new System.Windows.Forms.Panel();
            this.chk_displayNameInWelcomeMessages = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_win10themeSync = new System.Windows.Forms.CheckBox();
            this.rdo_themeDark = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rdo_themeLight = new System.Windows.Forms.RadioButton();
            this.pnl_name.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_name
            // 
            this.pnl_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_name.Controls.Add(this.chk_displayNameInWelcomeMessages);
            this.pnl_name.Controls.Add(this.label3);
            this.pnl_name.Controls.Add(this.txt_name);
            this.pnl_name.Controls.Add(this.label2);
            this.pnl_name.Location = new System.Drawing.Point(14, 172);
            this.pnl_name.Name = "pnl_name";
            this.pnl_name.Size = new System.Drawing.Size(635, 130);
            this.pnl_name.TabIndex = 4;
            // 
            // chk_displayNameInWelcomeMessages
            // 
            this.chk_displayNameInWelcomeMessages.AutoSize = true;
            this.chk_displayNameInWelcomeMessages.Checked = true;
            this.chk_displayNameInWelcomeMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_displayNameInWelcomeMessages.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_displayNameInWelcomeMessages.Location = new System.Drawing.Point(19, 81);
            this.chk_displayNameInWelcomeMessages.Name = "chk_displayNameInWelcomeMessages";
            this.chk_displayNameInWelcomeMessages.Size = new System.Drawing.Size(266, 24);
            this.chk_displayNameInWelcomeMessages.TabIndex = 5;
            this.chk_displayNameInWelcomeMessages.Text = "Display name in welcome messages";
            this.chk_displayNameInWelcomeMessages.UseVisualStyleBackColor = true;
            this.chk_displayNameInWelcomeMessages.CheckedChanged += new System.EventHandler(this.chk_displayNameInWelcomeMessages_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Personal";
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(135, 40);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(497, 23);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextChanged += new System.EventHandler(this.Txt_name_TextChanged);
            this.txt_name.Leave += new System.EventHandler(this.Txt_name_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Your full name:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.chk_win10themeSync);
            this.panel1.Controls.Add(this.rdo_themeDark);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rdo_themeLight);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 138);
            this.panel1.TabIndex = 3;
            // 
            // chk_win10themeSync
            // 
            this.chk_win10themeSync.AutoSize = true;
            this.chk_win10themeSync.Checked = true;
            this.chk_win10themeSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_win10themeSync.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_win10themeSync.ForeColor = System.Drawing.Color.White;
            this.chk_win10themeSync.Location = new System.Drawing.Point(15, 111);
            this.chk_win10themeSync.Name = "chk_win10themeSync";
            this.chk_win10themeSync.Size = new System.Drawing.Size(221, 24);
            this.chk_win10themeSync.TabIndex = 2;
            this.chk_win10themeSync.Text = "Sync with Windows 10 theme";
            this.chk_win10themeSync.UseVisualStyleBackColor = true;
            this.chk_win10themeSync.CheckedChanged += new System.EventHandler(this.Chk_win10themeSync_CheckedChanged);
            // 
            // rdo_themeDark
            // 
            this.rdo_themeDark.AutoSize = true;
            this.rdo_themeDark.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_themeDark.ForeColor = System.Drawing.Color.White;
            this.rdo_themeDark.Location = new System.Drawing.Point(15, 70);
            this.rdo_themeDark.Name = "rdo_themeDark";
            this.rdo_themeDark.Size = new System.Drawing.Size(58, 24);
            this.rdo_themeDark.TabIndex = 1;
            this.rdo_themeDark.Text = "Dark";
            this.rdo_themeDark.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Theme";
            // 
            // rdo_themeLight
            // 
            this.rdo_themeLight.AutoSize = true;
            this.rdo_themeLight.Checked = true;
            this.rdo_themeLight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_themeLight.ForeColor = System.Drawing.Color.White;
            this.rdo_themeLight.Location = new System.Drawing.Point(15, 40);
            this.rdo_themeLight.Name = "rdo_themeLight";
            this.rdo_themeLight.Size = new System.Drawing.Size(60, 24);
            this.rdo_themeLight.TabIndex = 0;
            this.rdo_themeLight.TabStop = true;
            this.rdo_themeLight.Text = "Light";
            this.rdo_themeLight.UseVisualStyleBackColor = true;
            this.rdo_themeLight.CheckedChanged += new System.EventHandler(this.Rdo_themeLight_CheckedChanged);
            // 
            // PrefsGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_name);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "PrefsGeneral";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_name.ResumeLayout(false);
            this.pnl_name.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.RadioButton rdo_themeDark;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.RadioButton rdo_themeLight;
        private System.Windows.Forms.CheckBox chk_win10themeSync;
        private System.Windows.Forms.CheckBox chk_displayNameInWelcomeMessages;
    }
}
