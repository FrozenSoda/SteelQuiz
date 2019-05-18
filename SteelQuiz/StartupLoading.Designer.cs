﻿namespace SteelQuiz
{
    partial class StartupLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupLoading));
            this.lbl_msg = new System.Windows.Forms.Label();
            this.lbl_dot1 = new System.Windows.Forms.Label();
            this.lbl_dot2 = new System.Windows.Forms.Label();
            this.lbl_dot3 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_msg
            // 
            this.lbl_msg.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msg.ForeColor = System.Drawing.Color.White;
            this.lbl_msg.Location = new System.Drawing.Point(12, 38);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(427, 61);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "Just a moment...";
            this.lbl_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dot1
            // 
            this.lbl_dot1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dot1.ForeColor = System.Drawing.Color.White;
            this.lbl_dot1.Location = new System.Drawing.Point(195, 90);
            this.lbl_dot1.Name = "lbl_dot1";
            this.lbl_dot1.Size = new System.Drawing.Size(16, 30);
            this.lbl_dot1.TabIndex = 1;
            this.lbl_dot1.Text = ".";
            this.lbl_dot1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dot2
            // 
            this.lbl_dot2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dot2.ForeColor = System.Drawing.Color.White;
            this.lbl_dot2.Location = new System.Drawing.Point(217, 90);
            this.lbl_dot2.Name = "lbl_dot2";
            this.lbl_dot2.Size = new System.Drawing.Size(16, 30);
            this.lbl_dot2.TabIndex = 2;
            this.lbl_dot2.Text = ".";
            this.lbl_dot2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dot3
            // 
            this.lbl_dot3.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dot3.ForeColor = System.Drawing.Color.White;
            this.lbl_dot3.Location = new System.Drawing.Point(239, 90);
            this.lbl_dot3.Name = "lbl_dot3";
            this.lbl_dot3.Size = new System.Drawing.Size(16, 30);
            this.lbl_dot3.TabIndex = 3;
            this.lbl_dot3.Text = ".";
            this.lbl_dot3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(427, 29);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "SteelQuiz";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartupLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(451, 182);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_dot3);
            this.Controls.Add(this.lbl_dot2);
            this.Controls.Add(this.lbl_dot1);
            this.Controls.Add(this.lbl_msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartupLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartupLoading";
            this.Shown += new System.EventHandler(this.StartupLoading_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_msg;
        private System.Windows.Forms.Label lbl_dot1;
        private System.Windows.Forms.Label lbl_dot2;
        private System.Windows.Forms.Label lbl_dot3;
        private System.Windows.Forms.Label lbl_title;
    }
}