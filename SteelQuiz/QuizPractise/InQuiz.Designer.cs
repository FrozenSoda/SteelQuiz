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

namespace SteelQuiz.QuizPractise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InQuiz));
            this.lbl_word1 = new System.Windows.Forms.Label();
            this.lbl_word2 = new System.Windows.Forms.Label();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.lbl_intelligentLearning = new System.Windows.Forms.Label();
            this.lbl_lang1 = new System.Windows.Forms.Label();
            this.lbl_lang2 = new System.Windows.Forms.Label();
            this.btn_w1_synonyms = new System.Windows.Forms.Button();
            this.pnl_knewAnswer = new System.Windows.Forms.Panel();
            this.btn_knewAnswerNO = new System.Windows.Forms.Button();
            this.btn_knewAnswerYES = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_cfg = new System.Windows.Forms.Button();
            this.tlp_qAns = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_knewAnswer.SuspendLayout();
            this.tlp_qAns.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_word1
            // 
            this.lbl_word1.AutoSize = true;
            this.lbl_word1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_word1.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word1.ForeColor = System.Drawing.Color.White;
            this.lbl_word1.Location = new System.Drawing.Point(3, 60);
            this.lbl_word1.MinimumSize = new System.Drawing.Size(325, 345);
            this.lbl_word1.Name = "lbl_word1";
            this.lbl_word1.Size = new System.Drawing.Size(435, 387);
            this.lbl_word1.TabIndex = 0;
            this.lbl_word1.Text = "lbl_word1";
            this.lbl_word1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_word1.Click += new System.EventHandler(this.lbl_word1_Click);
            // 
            // lbl_word2
            // 
            this.lbl_word2.AutoSize = true;
            this.lbl_word2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_word2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word2.ForeColor = System.Drawing.Color.White;
            this.lbl_word2.Location = new System.Drawing.Point(444, 60);
            this.lbl_word2.MinimumSize = new System.Drawing.Size(387, 345);
            this.lbl_word2.Name = "lbl_word2";
            this.lbl_word2.Size = new System.Drawing.Size(436, 387);
            this.lbl_word2.TabIndex = 1;
            this.lbl_word2.Text = "Enter your answer...";
            this.lbl_word2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_word2.UseMnemonic = false;
            this.lbl_word2.Click += new System.EventHandler(this.lbl_word2_Click);
            // 
            // lbl_progress
            // 
            this.lbl_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_progress.Location = new System.Drawing.Point(12, 528);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(111, 13);
            this.lbl_progress.TabIndex = 2;
            this.lbl_progress.Text = "Progress this round:";
            // 
            // lbl_intelligentLearning
            // 
            this.lbl_intelligentLearning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_intelligentLearning.AutoSize = true;
            this.lbl_intelligentLearning.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_intelligentLearning.Location = new System.Drawing.Point(657, 528);
            this.lbl_intelligentLearning.Name = "lbl_intelligentLearning";
            this.lbl_intelligentLearning.Size = new System.Drawing.Size(214, 13);
            this.lbl_intelligentLearning.TabIndex = 4;
            this.lbl_intelligentLearning.Text = "Intelligent Learning: STATUS_UNKNOWN";
            // 
            // lbl_lang1
            // 
            this.lbl_lang1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_lang1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lang1.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_lang1.Location = new System.Drawing.Point(0, 0);
            this.lbl_lang1.Name = "lbl_lang1";
            this.lbl_lang1.Size = new System.Drawing.Size(435, 23);
            this.lbl_lang1.TabIndex = 5;
            this.lbl_lang1.Text = "lbl_lang1";
            this.lbl_lang1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_lang2
            // 
            this.lbl_lang2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_lang2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lang2.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_lang2.Location = new System.Drawing.Point(0, 0);
            this.lbl_lang2.Name = "lbl_lang2";
            this.lbl_lang2.Size = new System.Drawing.Size(436, 23);
            this.lbl_lang2.TabIndex = 6;
            this.lbl_lang2.Text = "lbl_lang2";
            this.lbl_lang2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_w1_synonyms
            // 
            this.btn_w1_synonyms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_w1_synonyms.BackColor = System.Drawing.Color.Gray;
            this.btn_w1_synonyms.Enabled = false;
            this.btn_w1_synonyms.FlatAppearance.BorderSize = 0;
            this.btn_w1_synonyms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_w1_synonyms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_w1_synonyms.ForeColor = System.Drawing.Color.White;
            this.btn_w1_synonyms.Location = new System.Drawing.Point(184, 28);
            this.btn_w1_synonyms.Name = "btn_w1_synonyms";
            this.btn_w1_synonyms.Size = new System.Drawing.Size(75, 23);
            this.btn_w1_synonyms.TabIndex = 7;
            this.btn_w1_synonyms.TabStop = false;
            this.btn_w1_synonyms.Text = "Synonyms";
            this.btn_w1_synonyms.UseVisualStyleBackColor = false;
            this.btn_w1_synonyms.Click += new System.EventHandler(this.btn_w1_synonyms_Click);
            // 
            // pnl_knewAnswer
            // 
            this.pnl_knewAnswer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_knewAnswer.Controls.Add(this.btn_knewAnswerNO);
            this.pnl_knewAnswer.Controls.Add(this.btn_knewAnswerYES);
            this.pnl_knewAnswer.Controls.Add(this.label1);
            this.pnl_knewAnswer.Location = new System.Drawing.Point(460, 462);
            this.pnl_knewAnswer.Name = "pnl_knewAnswer";
            this.pnl_knewAnswer.Size = new System.Drawing.Size(381, 50);
            this.pnl_knewAnswer.TabIndex = 1;
            this.pnl_knewAnswer.Visible = false;
            // 
            // btn_knewAnswerNO
            // 
            this.btn_knewAnswerNO.BackColor = System.Drawing.Color.Maroon;
            this.btn_knewAnswerNO.FlatAppearance.BorderSize = 0;
            this.btn_knewAnswerNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_knewAnswerNO.Location = new System.Drawing.Point(112, 24);
            this.btn_knewAnswerNO.Name = "btn_knewAnswerNO";
            this.btn_knewAnswerNO.Size = new System.Drawing.Size(75, 23);
            this.btn_knewAnswerNO.TabIndex = 2;
            this.btn_knewAnswerNO.Text = "No";
            this.btn_knewAnswerNO.UseVisualStyleBackColor = false;
            this.btn_knewAnswerNO.Click += new System.EventHandler(this.btn_knewAnswerNO_Click);
            // 
            // btn_knewAnswerYES
            // 
            this.btn_knewAnswerYES.BackColor = System.Drawing.Color.Green;
            this.btn_knewAnswerYES.FlatAppearance.BorderSize = 0;
            this.btn_knewAnswerYES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_knewAnswerYES.Location = new System.Drawing.Point(193, 24);
            this.btn_knewAnswerYES.Name = "btn_knewAnswerYES";
            this.btn_knewAnswerYES.Size = new System.Drawing.Size(75, 23);
            this.btn_knewAnswerYES.TabIndex = 1;
            this.btn_knewAnswerYES.Text = "Yes";
            this.btn_knewAnswerYES.UseVisualStyleBackColor = false;
            this.btn_knewAnswerYES.Click += new System.EventHandler(this.btn_knewAnswerYES_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Did you know the answer?";
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.Gray;
            this.btn_home.FlatAppearance.BorderSize = 0;
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.ForeColor = System.Drawing.Color.White;
            this.btn_home.Location = new System.Drawing.Point(3, 28);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(68, 23);
            this.btn_home.TabIndex = 10;
            this.btn_home.TabStop = false;
            this.btn_home.Text = "←";
            this.btn_home.UseVisualStyleBackColor = false;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_cfg
            // 
            this.btn_cfg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cfg.BackColor = System.Drawing.Color.Gray;
            this.btn_cfg.BackgroundImage = global::SteelQuiz.Properties.Resources.gear_1077563_white_with_bigger_border_512x512;
            this.btn_cfg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_cfg.FlatAppearance.BorderSize = 0;
            this.btn_cfg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cfg.Location = new System.Drawing.Point(877, 519);
            this.btn_cfg.Name = "btn_cfg";
            this.btn_cfg.Size = new System.Drawing.Size(30, 30);
            this.btn_cfg.TabIndex = 12;
            this.btn_cfg.TabStop = false;
            this.btn_cfg.UseVisualStyleBackColor = false;
            this.btn_cfg.Click += new System.EventHandler(this.Btn_cfg_Click);
            // 
            // tlp_qAns
            // 
            this.tlp_qAns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp_qAns.ColumnCount = 2;
            this.tlp_qAns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_qAns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_qAns.Controls.Add(this.panel2, 1, 0);
            this.tlp_qAns.Controls.Add(this.panel1, 0, 0);
            this.tlp_qAns.Controls.Add(this.lbl_word2, 1, 1);
            this.tlp_qAns.Controls.Add(this.lbl_word1, 0, 1);
            this.tlp_qAns.Location = new System.Drawing.Point(12, 12);
            this.tlp_qAns.Name = "tlp_qAns";
            this.tlp_qAns.RowCount = 2;
            this.tlp_qAns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_qAns.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_qAns.Size = new System.Drawing.Size(883, 447);
            this.tlp_qAns.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_lang2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(444, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 54);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_home);
            this.panel1.Controls.Add(this.btn_w1_synonyms);
            this.panel1.Controls.Add(this.lbl_lang1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 54);
            this.panel1.TabIndex = 15;
            // 
            // InQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(907, 550);
            this.Controls.Add(this.tlp_qAns);
            this.Controls.Add(this.pnl_knewAnswer);
            this.Controls.Add(this.btn_cfg);
            this.Controls.Add(this.lbl_intelligentLearning);
            this.Controls.Add(this.lbl_progress);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "InQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InQuiz_FormClosing);
            this.SizeChanged += new System.EventHandler(this.InQuiz_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InQuiz_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InQuiz_KeyPress);
            this.pnl_knewAnswer.ResumeLayout(false);
            this.pnl_knewAnswer.PerformLayout();
            this.tlp_qAns.ResumeLayout(false);
            this.tlp_qAns.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_word1;
        private System.Windows.Forms.Label lbl_word2;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Label lbl_intelligentLearning;
        private System.Windows.Forms.Label lbl_lang1;
        private System.Windows.Forms.Label lbl_lang2;
        private System.Windows.Forms.Button btn_w1_synonyms;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Button btn_cfg;
        private System.Windows.Forms.Panel pnl_knewAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_knewAnswerYES;
        private System.Windows.Forms.Button btn_knewAnswerNO;
        private System.Windows.Forms.TableLayoutPanel tlp_qAns;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}