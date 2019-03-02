﻿namespace SteelQuiz
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
            this.button4 = new System.Windows.Forms.Button();
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(713, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "inQuiz";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_importQuizFromSite);
            this.Controls.Add(this.btn_loadQuiz);
            this.Controls.Add(this.btn_createQuiz);
            this.Controls.Add(this.lbl_welcome);
            this.Name = "Welcome";
            this.Text = "SteelQuiz";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btn_createQuiz;
        private System.Windows.Forms.Button btn_loadQuiz;
        private System.Windows.Forms.Button btn_importQuizFromSite;
        private System.Windows.Forms.Button button4;
    }
}

