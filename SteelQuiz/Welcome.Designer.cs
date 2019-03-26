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
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_createQuiz = new System.Windows.Forms.Button();
            this.btn_loadQuiz = new System.Windows.Forms.Button();
            this.btn_importQuizFromSite = new System.Windows.Forms.Button();
            this.ofd_loadQuiz = new System.Windows.Forms.OpenFileDialog();
            this.lbl_copyright = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.Location = new System.Drawing.Point(12, 9);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(776, 43);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Welcome! What do you want to do?";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_createQuiz
            // 
            this.btn_createQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createQuiz.Location = new System.Drawing.Point(12, 79);
            this.btn_createQuiz.Name = "btn_createQuiz";
            this.btn_createQuiz.Size = new System.Drawing.Size(237, 57);
            this.btn_createQuiz.TabIndex = 1;
            this.btn_createQuiz.Text = "Create quiz";
            this.btn_createQuiz.UseVisualStyleBackColor = true;
            // 
            // btn_loadQuiz
            // 
            this.btn_loadQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loadQuiz.Location = new System.Drawing.Point(280, 79);
            this.btn_loadQuiz.Name = "btn_loadQuiz";
            this.btn_loadQuiz.Size = new System.Drawing.Size(237, 57);
            this.btn_loadQuiz.TabIndex = 2;
            this.btn_loadQuiz.Text = "Load quiz from file";
            this.btn_loadQuiz.UseVisualStyleBackColor = true;
            this.btn_loadQuiz.Click += new System.EventHandler(this.btn_loadQuiz_Click);
            // 
            // btn_importQuizFromSite
            // 
            this.btn_importQuizFromSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_importQuizFromSite.Location = new System.Drawing.Point(551, 79);
            this.btn_importQuizFromSite.Name = "btn_importQuizFromSite";
            this.btn_importQuizFromSite.Size = new System.Drawing.Size(237, 57);
            this.btn_importQuizFromSite.TabIndex = 3;
            this.btn_importQuizFromSite.Text = "Import quiz from another site";
            this.btn_importQuizFromSite.UseVisualStyleBackColor = true;
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
            this.lbl_copyright.Location = new System.Drawing.Point(12, 428);
            this.lbl_copyright.Name = "lbl_copyright";
            this.lbl_copyright.Size = new System.Drawing.Size(351, 13);
            this.lbl_copyright.TabIndex = 4;
            this.lbl_copyright.Text = "Experimental software | Copyright (C) 2019 steel9apps - All rights reserved";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_copyright);
            this.Controls.Add(this.btn_importQuizFromSite);
            this.Controls.Add(this.btn_loadQuiz);
            this.Controls.Add(this.btn_createQuiz);
            this.Controls.Add(this.lbl_welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.Text = "SteelQuiz | Experimental alpha";
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
    }
}

