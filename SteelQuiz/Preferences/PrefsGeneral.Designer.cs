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
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_rdoTheme = new System.Windows.Forms.Panel();
            this.rdo_themeDark = new System.Windows.Forms.RadioButton();
            this.rdo_themeLight = new System.Windows.Forms.RadioButton();
            this.pnl_name = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rdo_dontShowNameOnWelcome = new System.Windows.Forms.RadioButton();
            this.rdo_showNameOnWelcome = new System.Windows.Forms.RadioButton();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_rdoTheme.SuspendLayout();
            this.pnl_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Theme:";
            // 
            // pnl_rdoTheme
            // 
            this.pnl_rdoTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_rdoTheme.Controls.Add(this.rdo_themeDark);
            this.pnl_rdoTheme.Controls.Add(this.label1);
            this.pnl_rdoTheme.Controls.Add(this.rdo_themeLight);
            this.pnl_rdoTheme.Location = new System.Drawing.Point(14, 14);
            this.pnl_rdoTheme.Name = "pnl_rdoTheme";
            this.pnl_rdoTheme.Size = new System.Drawing.Size(635, 130);
            this.pnl_rdoTheme.TabIndex = 1;
            // 
            // rdo_themeDark
            // 
            this.rdo_themeDark.AutoSize = true;
            this.rdo_themeDark.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_themeDark.ForeColor = System.Drawing.Color.White;
            this.rdo_themeDark.Location = new System.Drawing.Point(15, 69);
            this.rdo_themeDark.Name = "rdo_themeDark";
            this.rdo_themeDark.Size = new System.Drawing.Size(58, 24);
            this.rdo_themeDark.TabIndex = 1;
            this.rdo_themeDark.Text = "Dark";
            this.rdo_themeDark.UseVisualStyleBackColor = true;
            // 
            // rdo_themeLight
            // 
            this.rdo_themeLight.AutoSize = true;
            this.rdo_themeLight.Checked = true;
            this.rdo_themeLight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_themeLight.ForeColor = System.Drawing.Color.White;
            this.rdo_themeLight.Location = new System.Drawing.Point(15, 39);
            this.rdo_themeLight.Name = "rdo_themeLight";
            this.rdo_themeLight.Size = new System.Drawing.Size(60, 24);
            this.rdo_themeLight.TabIndex = 0;
            this.rdo_themeLight.TabStop = true;
            this.rdo_themeLight.Text = "Light";
            this.rdo_themeLight.UseVisualStyleBackColor = true;
            this.rdo_themeLight.CheckedChanged += new System.EventHandler(this.Rdo_themeLight_CheckedChanged);
            // 
            // pnl_name
            // 
            this.pnl_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_name.Controls.Add(this.label3);
            this.pnl_name.Controls.Add(this.rdo_dontShowNameOnWelcome);
            this.pnl_name.Controls.Add(this.rdo_showNameOnWelcome);
            this.pnl_name.Controls.Add(this.txt_name);
            this.pnl_name.Controls.Add(this.label2);
            this.pnl_name.Location = new System.Drawing.Point(14, 150);
            this.pnl_name.Name = "pnl_name";
            this.pnl_name.Size = new System.Drawing.Size(635, 130);
            this.pnl_name.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Personal:";
            // 
            // rdo_dontShowNameOnWelcome
            // 
            this.rdo_dontShowNameOnWelcome.AutoSize = true;
            this.rdo_dontShowNameOnWelcome.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_dontShowNameOnWelcome.ForeColor = System.Drawing.Color.White;
            this.rdo_dontShowNameOnWelcome.Location = new System.Drawing.Point(15, 103);
            this.rdo_dontShowNameOnWelcome.Name = "rdo_dontShowNameOnWelcome";
            this.rdo_dontShowNameOnWelcome.Size = new System.Drawing.Size(283, 24);
            this.rdo_dontShowNameOnWelcome.TabIndex = 3;
            this.rdo_dontShowNameOnWelcome.Text = "Do not show name on welcome screen";
            this.rdo_dontShowNameOnWelcome.UseVisualStyleBackColor = true;
            // 
            // rdo_showNameOnWelcome
            // 
            this.rdo_showNameOnWelcome.AutoSize = true;
            this.rdo_showNameOnWelcome.Checked = true;
            this.rdo_showNameOnWelcome.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_showNameOnWelcome.ForeColor = System.Drawing.Color.White;
            this.rdo_showNameOnWelcome.Location = new System.Drawing.Point(15, 73);
            this.rdo_showNameOnWelcome.Name = "rdo_showNameOnWelcome";
            this.rdo_showNameOnWelcome.Size = new System.Drawing.Size(235, 24);
            this.rdo_showNameOnWelcome.TabIndex = 2;
            this.rdo_showNameOnWelcome.TabStop = true;
            this.rdo_showNameOnWelcome.Text = "Show name on welcome screen";
            this.rdo_showNameOnWelcome.UseVisualStyleBackColor = true;
            this.rdo_showNameOnWelcome.CheckedChanged += new System.EventHandler(this.Rdo_showNameOnWelcome_CheckedChanged);
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(129, 34);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(503, 23);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextChanged += new System.EventHandler(this.Txt_name_TextChanged);
            this.txt_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_name_KeyPress);
            this.txt_name.Leave += new System.EventHandler(this.Txt_name_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Your full name:";
            // 
            // PrefsGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_name);
            this.Controls.Add(this.pnl_rdoTheme);
            this.Name = "PrefsGeneral";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_rdoTheme.ResumeLayout(false);
            this.pnl_rdoTheme.PerformLayout();
            this.pnl_name.ResumeLayout(false);
            this.pnl_name.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_rdoTheme;
        internal System.Windows.Forms.RadioButton rdo_themeLight;
        internal System.Windows.Forms.RadioButton rdo_themeDark;
        private System.Windows.Forms.Panel pnl_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.RadioButton rdo_showNameOnWelcome;
        private System.Windows.Forms.RadioButton rdo_dontShowNameOnWelcome;
        private System.Windows.Forms.Label label3;
    }
}
