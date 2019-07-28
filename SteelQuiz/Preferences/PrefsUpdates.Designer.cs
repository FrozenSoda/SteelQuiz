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
            this.pnl_autoUpdate = new System.Windows.Forms.Panel();
            this.rdo_notifyUpdate = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_autoUpdate = new System.Windows.Forms.RadioButton();
            this.pnl_updateDialog = new System.Windows.Forms.Panel();
            this.nud_buttonEnableDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_updateChannel = new System.Windows.Forms.Panel();
            this.rdo_chDev = new System.Windows.Forms.RadioButton();
            this.rdo_chStable = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rdo_doNotUpdate = new System.Windows.Forms.RadioButton();
            this.pnl_autoUpdate.SuspendLayout();
            this.pnl_updateDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_buttonEnableDelay)).BeginInit();
            this.pnl_updateChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_autoUpdate
            // 
            this.pnl_autoUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_autoUpdate.Controls.Add(this.rdo_doNotUpdate);
            this.pnl_autoUpdate.Controls.Add(this.rdo_notifyUpdate);
            this.pnl_autoUpdate.Controls.Add(this.label1);
            this.pnl_autoUpdate.Controls.Add(this.rdo_autoUpdate);
            this.pnl_autoUpdate.Location = new System.Drawing.Point(14, 14);
            this.pnl_autoUpdate.Name = "pnl_autoUpdate";
            this.pnl_autoUpdate.Size = new System.Drawing.Size(635, 155);
            this.pnl_autoUpdate.TabIndex = 2;
            // 
            // rdo_notifyUpdate
            // 
            this.rdo_notifyUpdate.AutoSize = true;
            this.rdo_notifyUpdate.Checked = true;
            this.rdo_notifyUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_notifyUpdate.ForeColor = System.Drawing.Color.White;
            this.rdo_notifyUpdate.Location = new System.Drawing.Point(15, 70);
            this.rdo_notifyUpdate.Name = "rdo_notifyUpdate";
            this.rdo_notifyUpdate.Size = new System.Drawing.Size(528, 24);
            this.rdo_notifyUpdate.TabIndex = 1;
            this.rdo_notifyUpdate.Text = "Check for updates, but let me choose whether to download and install them";
            this.rdo_notifyUpdate.UseVisualStyleBackColor = true;
            this.rdo_notifyUpdate.CheckedChanged += new System.EventHandler(this.Rdo_notifyUpdate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Automatic Updates";
            // 
            // rdo_autoUpdate
            // 
            this.rdo_autoUpdate.AutoSize = true;
            this.rdo_autoUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_autoUpdate.ForeColor = System.Drawing.Color.White;
            this.rdo_autoUpdate.Location = new System.Drawing.Point(15, 40);
            this.rdo_autoUpdate.Name = "rdo_autoUpdate";
            this.rdo_autoUpdate.Size = new System.Drawing.Size(319, 24);
            this.rdo_autoUpdate.TabIndex = 0;
            this.rdo_autoUpdate.Text = "Automatically download and install updates";
            this.rdo_autoUpdate.UseVisualStyleBackColor = true;
            this.rdo_autoUpdate.CheckedChanged += new System.EventHandler(this.Rdo_autoUpdate_CheckedChanged);
            // 
            // pnl_updateDialog
            // 
            this.pnl_updateDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_updateDialog.Controls.Add(this.nud_buttonEnableDelay);
            this.pnl_updateDialog.Controls.Add(this.label3);
            this.pnl_updateDialog.Controls.Add(this.label2);
            this.pnl_updateDialog.Location = new System.Drawing.Point(14, 175);
            this.pnl_updateDialog.Name = "pnl_updateDialog";
            this.pnl_updateDialog.Size = new System.Drawing.Size(635, 94);
            this.pnl_updateDialog.TabIndex = 3;
            // 
            // nud_buttonEnableDelay
            // 
            this.nud_buttonEnableDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud_buttonEnableDelay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_buttonEnableDelay.Location = new System.Drawing.Point(186, 33);
            this.nud_buttonEnableDelay.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_buttonEnableDelay.Name = "nud_buttonEnableDelay";
            this.nud_buttonEnableDelay.Size = new System.Drawing.Size(120, 23);
            this.nud_buttonEnableDelay.TabIndex = 2;
            this.nud_buttonEnableDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nud_buttonEnableDelay.ValueChanged += new System.EventHandler(this.Nud_buttonEnableDelay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Button enable delay (s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Update Dialog";
            // 
            // pnl_updateChannel
            // 
            this.pnl_updateChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_updateChannel.Controls.Add(this.rdo_chDev);
            this.pnl_updateChannel.Controls.Add(this.rdo_chStable);
            this.pnl_updateChannel.Controls.Add(this.label5);
            this.pnl_updateChannel.Location = new System.Drawing.Point(14, 275);
            this.pnl_updateChannel.Name = "pnl_updateChannel";
            this.pnl_updateChannel.Size = new System.Drawing.Size(635, 130);
            this.pnl_updateChannel.TabIndex = 4;
            // 
            // rdo_chDev
            // 
            this.rdo_chDev.AutoSize = true;
            this.rdo_chDev.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_chDev.ForeColor = System.Drawing.Color.White;
            this.rdo_chDev.Location = new System.Drawing.Point(15, 70);
            this.rdo_chDev.Name = "rdo_chDev";
            this.rdo_chDev.Size = new System.Drawing.Size(117, 24);
            this.rdo_chDev.TabIndex = 3;
            this.rdo_chDev.Text = "Development";
            this.rdo_chDev.UseVisualStyleBackColor = true;
            this.rdo_chDev.CheckedChanged += new System.EventHandler(this.Rdo_chDev_CheckedChanged);
            // 
            // rdo_chStable
            // 
            this.rdo_chStable.AutoSize = true;
            this.rdo_chStable.Checked = true;
            this.rdo_chStable.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_chStable.ForeColor = System.Drawing.Color.White;
            this.rdo_chStable.Location = new System.Drawing.Point(15, 40);
            this.rdo_chStable.Name = "rdo_chStable";
            this.rdo_chStable.Size = new System.Drawing.Size(180, 24);
            this.rdo_chStable.TabIndex = 2;
            this.rdo_chStable.TabStop = true;
            this.rdo_chStable.Text = "Stable (recommended)";
            this.rdo_chStable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Update Channel";
            // 
            // rdo_doNotUpdate
            // 
            this.rdo_doNotUpdate.AutoSize = true;
            this.rdo_doNotUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_doNotUpdate.ForeColor = System.Drawing.Color.White;
            this.rdo_doNotUpdate.Location = new System.Drawing.Point(15, 100);
            this.rdo_doNotUpdate.Name = "rdo_doNotUpdate";
            this.rdo_doNotUpdate.Size = new System.Drawing.Size(432, 24);
            this.rdo_doNotUpdate.TabIndex = 2;
            this.rdo_doNotUpdate.Text = "Do not check for updates automatically (NOT recommended)";
            this.rdo_doNotUpdate.UseVisualStyleBackColor = true;
            this.rdo_doNotUpdate.CheckedChanged += new System.EventHandler(this.Rdo_doNotUpdate_CheckedChanged);
            // 
            // PrefsUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_updateChannel);
            this.Controls.Add(this.pnl_updateDialog);
            this.Controls.Add(this.pnl_autoUpdate);
            this.Name = "PrefsUpdates";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_autoUpdate.ResumeLayout(false);
            this.pnl_autoUpdate.PerformLayout();
            this.pnl_updateDialog.ResumeLayout(false);
            this.pnl_updateDialog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_buttonEnableDelay)).EndInit();
            this.pnl_updateChannel.ResumeLayout(false);
            this.pnl_updateChannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_autoUpdate;
        internal System.Windows.Forms.RadioButton rdo_notifyUpdate;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RadioButton rdo_autoUpdate;
        private System.Windows.Forms.Panel pnl_updateDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_buttonEnableDelay;
        private System.Windows.Forms.Panel pnl_updateChannel;
        internal System.Windows.Forms.RadioButton rdo_chDev;
        internal System.Windows.Forms.RadioButton rdo_chStable;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.RadioButton rdo_doNotUpdate;
    }
}
