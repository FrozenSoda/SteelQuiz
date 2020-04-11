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
    partial class PrefsTroubleshooting
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
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.pnl_update = new System.Windows.Forms.Panel();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbl_update = new System.Windows.Forms.Label();
            this.pnl_resetProgData = new System.Windows.Forms.Panel();
            this.btn_resetProgData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_resetAppConfig = new System.Windows.Forms.Panel();
            this.btn_resetAppConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.flp_solutions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_update.SuspendLayout();
            this.pnl_resetProgData.SuspendLayout();
            this.pnl_resetAppConfig.SuspendLayout();
            this.flp_solutions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_welcome.Location = new System.Drawing.Point(3, 0);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(646, 43);
            this.lbl_welcome.TabIndex = 1;
            this.lbl_welcome.Text = "Do you experience problems? Try any of these solutions";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_update
            // 
            this.pnl_update.Controls.Add(this.btn_update);
            this.pnl_update.Controls.Add(this.lbl_update);
            this.pnl_update.Location = new System.Drawing.Point(3, 3);
            this.pnl_update.Name = "pnl_update";
            this.pnl_update.Size = new System.Drawing.Size(652, 90);
            this.pnl_update.TabIndex = 3;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_update.Enabled = false;
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(261, 31);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(124, 40);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "Please wait...";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // lbl_update
            // 
            this.lbl_update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_update.ForeColor = System.Drawing.Color.White;
            this.lbl_update.Location = new System.Drawing.Point(-1, 0);
            this.lbl_update.Name = "lbl_update";
            this.lbl_update.Size = new System.Drawing.Size(645, 28);
            this.lbl_update.TabIndex = 0;
            this.lbl_update.Text = "Update SteelQuiz";
            this.lbl_update.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnl_resetProgData
            // 
            this.pnl_resetProgData.Controls.Add(this.btn_resetProgData);
            this.pnl_resetProgData.Controls.Add(this.label2);
            this.pnl_resetProgData.Location = new System.Drawing.Point(3, 99);
            this.pnl_resetProgData.Name = "pnl_resetProgData";
            this.pnl_resetProgData.Size = new System.Drawing.Size(652, 90);
            this.pnl_resetProgData.TabIndex = 4;
            // 
            // btn_resetProgData
            // 
            this.btn_resetProgData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_resetProgData.FlatAppearance.BorderSize = 0;
            this.btn_resetProgData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetProgData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resetProgData.ForeColor = System.Drawing.Color.White;
            this.btn_resetProgData.Location = new System.Drawing.Point(261, 31);
            this.btn_resetProgData.Name = "btn_resetProgData";
            this.btn_resetProgData.Size = new System.Drawing.Size(124, 40);
            this.btn_resetProgData.TabIndex = 5;
            this.btn_resetProgData.Text = "Continue";
            this.btn_resetProgData.UseVisualStyleBackColor = false;
            this.btn_resetProgData.Click += new System.EventHandler(this.Btn_resetProgData_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(645, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reset quiz progress data";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnl_resetAppConfig
            // 
            this.pnl_resetAppConfig.Controls.Add(this.btn_resetAppConfig);
            this.pnl_resetAppConfig.Controls.Add(this.label3);
            this.pnl_resetAppConfig.Location = new System.Drawing.Point(3, 195);
            this.pnl_resetAppConfig.Name = "pnl_resetAppConfig";
            this.pnl_resetAppConfig.Size = new System.Drawing.Size(652, 90);
            this.pnl_resetAppConfig.TabIndex = 5;
            // 
            // btn_resetAppConfig
            // 
            this.btn_resetAppConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_resetAppConfig.FlatAppearance.BorderSize = 0;
            this.btn_resetAppConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetAppConfig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resetAppConfig.ForeColor = System.Drawing.Color.White;
            this.btn_resetAppConfig.Location = new System.Drawing.Point(261, 31);
            this.btn_resetAppConfig.Name = "btn_resetAppConfig";
            this.btn_resetAppConfig.Size = new System.Drawing.Size(124, 40);
            this.btn_resetAppConfig.TabIndex = 5;
            this.btn_resetAppConfig.Text = "Continue";
            this.btn_resetAppConfig.UseVisualStyleBackColor = false;
            this.btn_resetAppConfig.Click += new System.EventHandler(this.Btn_resetAppConfig_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(645, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reset application configuration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flp_solutions
            // 
            this.flp_solutions.Controls.Add(this.pnl_update);
            this.flp_solutions.Controls.Add(this.pnl_resetProgData);
            this.flp_solutions.Controls.Add(this.pnl_resetAppConfig);
            this.flp_solutions.Location = new System.Drawing.Point(0, 72);
            this.flp_solutions.Name = "flp_solutions";
            this.flp_solutions.Size = new System.Drawing.Size(652, 378);
            this.flp_solutions.TabIndex = 6;
            // 
            // PrefsTroubleshooting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.flp_solutions);
            this.Controls.Add(this.lbl_welcome);
            this.Name = "PrefsTroubleshooting";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_update.ResumeLayout(false);
            this.pnl_resetProgData.ResumeLayout(false);
            this.pnl_resetAppConfig.ResumeLayout(false);
            this.flp_solutions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Panel pnl_update;
        private System.Windows.Forms.Label lbl_update;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Panel pnl_resetProgData;
        private System.Windows.Forms.Button btn_resetProgData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_resetAppConfig;
        private System.Windows.Forms.Button btn_resetAppConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flp_solutions;
    }
}
