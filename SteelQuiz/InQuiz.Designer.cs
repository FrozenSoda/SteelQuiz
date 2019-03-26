/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  steel9apps

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
    partial class InQuiz
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
            this.lbl_word1 = new System.Windows.Forms.Label();
            this.lbl_word2 = new System.Windows.Forms.Label();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.btn_switchTestMode = new System.Windows.Forms.Button();
            this.lbl_AI = new System.Windows.Forms.Label();
            this.lbl_lang1 = new System.Windows.Forms.Label();
            this.lbl_lang2 = new System.Windows.Forms.Label();
            this.btn_w1_synonyms = new System.Windows.Forms.Button();
            this.pnl_word1 = new System.Windows.Forms.Panel();
            this.pnl_word2 = new System.Windows.Forms.Panel();
            this.pnl_word1.SuspendLayout();
            this.pnl_word2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_word1
            // 
            this.lbl_word1.AutoSize = true;
            this.lbl_word1.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word1.Location = new System.Drawing.Point(0, 0);
            this.lbl_word1.MaximumSize = new System.Drawing.Size(325, 0);
            this.lbl_word1.MinimumSize = new System.Drawing.Size(325, 345);
            this.lbl_word1.Name = "lbl_word1";
            this.lbl_word1.Size = new System.Drawing.Size(325, 345);
            this.lbl_word1.TabIndex = 0;
            this.lbl_word1.Text = "lbl_word1";
            this.lbl_word1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_word1.Click += new System.EventHandler(this.lbl_word1_Click);
            // 
            // lbl_word2
            // 
            this.lbl_word2.AutoSize = true;
            this.lbl_word2.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word2.Location = new System.Drawing.Point(0, 0);
            this.lbl_word2.MaximumSize = new System.Drawing.Size(387, 0);
            this.lbl_word2.MinimumSize = new System.Drawing.Size(387, 345);
            this.lbl_word2.Name = "lbl_word2";
            this.lbl_word2.Size = new System.Drawing.Size(387, 345);
            this.lbl_word2.TabIndex = 1;
            this.lbl_word2.Text = "Enter your answer...";
            this.lbl_word2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_word2.Click += new System.EventHandler(this.lbl_word2_Click);
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(12, 428);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(100, 13);
            this.lbl_progress.TabIndex = 2;
            this.lbl_progress.Text = "Progress this round:";
            // 
            // btn_switchTestMode
            // 
            this.btn_switchTestMode.Location = new System.Drawing.Point(580, 415);
            this.btn_switchTestMode.Name = "btn_switchTestMode";
            this.btn_switchTestMode.Size = new System.Drawing.Size(208, 23);
            this.btn_switchTestMode.TabIndex = 3;
            this.btn_switchTestMode.TabStop = false;
            this.btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
            this.btn_switchTestMode.UseVisualStyleBackColor = true;
            this.btn_switchTestMode.Click += new System.EventHandler(this.btn_switchTestMode_Click);
            // 
            // lbl_AI
            // 
            this.lbl_AI.AutoSize = true;
            this.lbl_AI.Location = new System.Drawing.Point(276, 428);
            this.lbl_AI.Name = "lbl_AI";
            this.lbl_AI.Size = new System.Drawing.Size(205, 13);
            this.lbl_AI.TabIndex = 4;
            this.lbl_AI.Text = "Intelligent learning: STATUS_UNKNOWN";
            // 
            // lbl_lang1
            // 
            this.lbl_lang1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lang1.Location = new System.Drawing.Point(12, 9);
            this.lbl_lang1.Name = "lbl_lang1";
            this.lbl_lang1.Size = new System.Drawing.Size(331, 23);
            this.lbl_lang1.TabIndex = 5;
            this.lbl_lang1.Text = "lbl_lang1";
            this.lbl_lang1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_lang2
            // 
            this.lbl_lang2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lang2.Location = new System.Drawing.Point(398, 12);
            this.lbl_lang2.Name = "lbl_lang2";
            this.lbl_lang2.Size = new System.Drawing.Size(390, 23);
            this.lbl_lang2.TabIndex = 6;
            this.lbl_lang2.Text = "lbl_lang2";
            this.lbl_lang2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_w1_synonyms
            // 
            this.btn_w1_synonyms.Enabled = false;
            this.btn_w1_synonyms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_w1_synonyms.Location = new System.Drawing.Point(140, 35);
            this.btn_w1_synonyms.Name = "btn_w1_synonyms";
            this.btn_w1_synonyms.Size = new System.Drawing.Size(75, 23);
            this.btn_w1_synonyms.TabIndex = 7;
            this.btn_w1_synonyms.TabStop = false;
            this.btn_w1_synonyms.Text = "Synonyms";
            this.btn_w1_synonyms.UseVisualStyleBackColor = true;
            this.btn_w1_synonyms.Click += new System.EventHandler(this.btn_w1_synonyms_Click);
            // 
            // pnl_word1
            // 
            this.pnl_word1.AutoScroll = true;
            this.pnl_word1.Controls.Add(this.lbl_word1);
            this.pnl_word1.Location = new System.Drawing.Point(18, 61);
            this.pnl_word1.Name = "pnl_word1";
            this.pnl_word1.Size = new System.Drawing.Size(325, 345);
            this.pnl_word1.TabIndex = 8;
            // 
            // pnl_word2
            // 
            this.pnl_word2.AutoScroll = true;
            this.pnl_word2.Controls.Add(this.lbl_word2);
            this.pnl_word2.Location = new System.Drawing.Point(401, 61);
            this.pnl_word2.Name = "pnl_word2";
            this.pnl_word2.Size = new System.Drawing.Size(387, 345);
            this.pnl_word2.TabIndex = 9;
            // 
            // InQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_word2);
            this.Controls.Add(this.pnl_word1);
            this.Controls.Add(this.btn_w1_synonyms);
            this.Controls.Add(this.lbl_lang2);
            this.Controls.Add(this.lbl_lang1);
            this.Controls.Add(this.lbl_AI);
            this.Controls.Add(this.btn_switchTestMode);
            this.Controls.Add(this.lbl_progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "InQuiz";
            this.Text = "SteelQuiz | Experimental alpha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InQuiz_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InQuiz_KeyPress);
            this.pnl_word1.ResumeLayout(false);
            this.pnl_word1.PerformLayout();
            this.pnl_word2.ResumeLayout(false);
            this.pnl_word2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_word1;
        private System.Windows.Forms.Label lbl_word2;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Button btn_switchTestMode;
        private System.Windows.Forms.Label lbl_AI;
        private System.Windows.Forms.Label lbl_lang1;
        private System.Windows.Forms.Label lbl_lang2;
        private System.Windows.Forms.Button btn_w1_synonyms;
        private System.Windows.Forms.Panel pnl_word1;
        private System.Windows.Forms.Panel pnl_word2;
    }
}