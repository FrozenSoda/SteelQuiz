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
    partial class PrefsUpdates
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
            this.pnl_rdoTheme = new System.Windows.Forms.Panel();
            this.rdo_notifyUpdate = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_autoUpdate = new System.Windows.Forms.RadioButton();
            this.pnl_rdoTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_rdoTheme
            // 
            this.pnl_rdoTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_rdoTheme.Controls.Add(this.rdo_notifyUpdate);
            this.pnl_rdoTheme.Controls.Add(this.label1);
            this.pnl_rdoTheme.Controls.Add(this.rdo_autoUpdate);
            this.pnl_rdoTheme.Location = new System.Drawing.Point(14, 14);
            this.pnl_rdoTheme.Name = "pnl_rdoTheme";
            this.pnl_rdoTheme.Size = new System.Drawing.Size(635, 130);
            this.pnl_rdoTheme.TabIndex = 2;
            // 
            // rdo_notifyUpdate
            // 
            this.rdo_notifyUpdate.AutoSize = true;
            this.rdo_notifyUpdate.Checked = true;
            this.rdo_notifyUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_notifyUpdate.ForeColor = System.Drawing.Color.White;
            this.rdo_notifyUpdate.Location = new System.Drawing.Point(15, 70);
            this.rdo_notifyUpdate.Name = "rdo_notifyUpdate";
            this.rdo_notifyUpdate.Size = new System.Drawing.Size(476, 24);
            this.rdo_notifyUpdate.TabIndex = 1;
            this.rdo_notifyUpdate.TabStop = true;
            this.rdo_notifyUpdate.Text = "Automatically check for updates, and notify if an update is available";
            this.rdo_notifyUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Automatic updates";
            // 
            // rdo_autoUpdate
            // 
            this.rdo_autoUpdate.AutoSize = true;
            this.rdo_autoUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_autoUpdate.ForeColor = System.Drawing.Color.White;
            this.rdo_autoUpdate.Location = new System.Drawing.Point(15, 40);
            this.rdo_autoUpdate.Name = "rdo_autoUpdate";
            this.rdo_autoUpdate.Size = new System.Drawing.Size(493, 24);
            this.rdo_autoUpdate.TabIndex = 0;
            this.rdo_autoUpdate.Text = "Automatically download and install updates when launching SteelQuiz";
            this.rdo_autoUpdate.UseVisualStyleBackColor = true;
            this.rdo_autoUpdate.CheckedChanged += new System.EventHandler(this.Rdo_autoUpdate_CheckedChanged);
            // 
            // PrefsUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_rdoTheme);
            this.Name = "PrefsUpdates";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_rdoTheme.ResumeLayout(false);
            this.pnl_rdoTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_rdoTheme;
        internal System.Windows.Forms.RadioButton rdo_notifyUpdate;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RadioButton rdo_autoUpdate;
    }
}
