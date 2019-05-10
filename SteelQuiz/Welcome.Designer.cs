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

namespace SteelQuiz
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_createQuiz = new System.Windows.Forms.Button();
            this.btn_loadQuiz = new System.Windows.Forms.Button();
            this.btn_importQuizFromSite = new System.Windows.Forms.Button();
            this.ofd_loadQuiz = new System.Windows.Forms.OpenFileDialog();
            this.lbl_copyright = new System.Windows.Forms.Label();
            this.btn_continueLast = new System.Windows.Forms.Button();
            this.tmr_chkUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_welcome.Location = new System.Drawing.Point(12, 9);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(776, 43);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Welcome! What do you want to do?";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_createQuiz
            // 
            this.btn_createQuiz.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_createQuiz.FlatAppearance.BorderSize = 0;
            this.btn_createQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_createQuiz.Location = new System.Drawing.Point(13, 84);
            this.btn_createQuiz.Name = "btn_createQuiz";
            this.btn_createQuiz.Size = new System.Drawing.Size(237, 57);
            this.btn_createQuiz.TabIndex = 1;
            this.btn_createQuiz.Text = "Create / edit quiz";
            this.btn_createQuiz.UseVisualStyleBackColor = false;
            this.btn_createQuiz.Click += new System.EventHandler(this.btn_createQuiz_Click);
            // 
            // btn_loadQuiz
            // 
            this.btn_loadQuiz.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_loadQuiz.FlatAppearance.BorderSize = 0;
            this.btn_loadQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loadQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_loadQuiz.Location = new System.Drawing.Point(282, 84);
            this.btn_loadQuiz.Name = "btn_loadQuiz";
            this.btn_loadQuiz.Size = new System.Drawing.Size(237, 57);
            this.btn_loadQuiz.TabIndex = 2;
            this.btn_loadQuiz.Text = "Load quiz from file";
            this.btn_loadQuiz.UseVisualStyleBackColor = false;
            this.btn_loadQuiz.Click += new System.EventHandler(this.btn_loadQuiz_Click);
            // 
            // btn_importQuizFromSite
            // 
            this.btn_importQuizFromSite.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_importQuizFromSite.FlatAppearance.BorderSize = 0;
            this.btn_importQuizFromSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_importQuizFromSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_importQuizFromSite.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_importQuizFromSite.Location = new System.Drawing.Point(551, 84);
            this.btn_importQuizFromSite.Name = "btn_importQuizFromSite";
            this.btn_importQuizFromSite.Size = new System.Drawing.Size(237, 57);
            this.btn_importQuizFromSite.TabIndex = 3;
            this.btn_importQuizFromSite.Text = "Import quiz from another source";
            this.btn_importQuizFromSite.UseVisualStyleBackColor = false;
            this.btn_importQuizFromSite.Click += new System.EventHandler(this.btn_importQuizFromSite_Click);
            // 
            // ofd_loadQuiz
            // 
            this.ofd_loadQuiz.Filter = "SteelQuiz Quizzes|*.steelquiz";
            this.ofd_loadQuiz.Title = "Select a quiz to load";
            // 
            // lbl_copyright
            // 
            this.lbl_copyright.AutoSize = true;
            this.lbl_copyright.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_copyright.Location = new System.Drawing.Point(12, 428);
            this.lbl_copyright.Name = "lbl_copyright";
            this.lbl_copyright.Size = new System.Drawing.Size(243, 13);
            this.lbl_copyright.TabIndex = 4;
            this.lbl_copyright.Text = "Copyright (C) 2019 Steel9Apps - All rights reserved";
            // 
            // btn_continueLast
            // 
            this.btn_continueLast.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_continueLast.Enabled = false;
            this.btn_continueLast.FlatAppearance.BorderSize = 0;
            this.btn_continueLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_continueLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continueLast.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_continueLast.Location = new System.Drawing.Point(146, 147);
            this.btn_continueLast.Name = "btn_continueLast";
            this.btn_continueLast.Size = new System.Drawing.Size(508, 57);
            this.btn_continueLast.TabIndex = 5;
            this.btn_continueLast.Text = "Continue practising last quiz";
            this.btn_continueLast.UseVisualStyleBackColor = false;
            this.btn_continueLast.Click += new System.EventHandler(this.btn_continueLast_Click);
            // 
            // tmr_chkUpdate
            // 
            this.tmr_chkUpdate.Enabled = true;
            this.tmr_chkUpdate.Interval = 120000;
            this.tmr_chkUpdate.Tick += new System.EventHandler(this.Tmr_chkUpdate_Tick);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_continueLast);
            this.Controls.Add(this.lbl_copyright);
            this.Controls.Add(this.btn_importQuizFromSite);
            this.Controls.Add(this.btn_loadQuiz);
            this.Controls.Add(this.btn_createQuiz);
            this.Controls.Add(this.lbl_welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btn_createQuiz;
        private System.Windows.Forms.Button btn_loadQuiz;
        private System.Windows.Forms.Button btn_importQuizFromSite;
        private System.Windows.Forms.OpenFileDialog ofd_loadQuiz;
        private System.Windows.Forms.Label lbl_copyright;
        private System.Windows.Forms.Button btn_continueLast;
        private System.Windows.Forms.Timer tmr_chkUpdate;
    }
}

