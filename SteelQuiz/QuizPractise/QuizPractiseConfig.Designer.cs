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
    partial class QuizPractiseConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizPractiseConfig));
            this.btn_dontAgree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_langAns = new System.Windows.Forms.ComboBox();
            this.btn_switchTestMode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nud_intelligentLearningAttempsCount = new System.Windows.Forms.NumericUpDown();
            this.rdo_lastNattemptsIntelligentLearning = new System.Windows.Forms.RadioButton();
            this.rdo_allAttemptsIntelligentLearning = new System.Windows.Forms.RadioButton();
            this.rdo_last3attemptsIntelligentLearning = new System.Windows.Forms.RadioButton();
            this.chk_randomOrderQuestions = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_intelligentLearningAttempsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dontAgree
            // 
            this.btn_dontAgree.BackColor = System.Drawing.Color.Gray;
            this.btn_dontAgree.FlatAppearance.BorderSize = 0;
            this.btn_dontAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dontAgree.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dontAgree.ForeColor = System.Drawing.Color.White;
            this.btn_dontAgree.Location = new System.Drawing.Point(12, 279);
            this.btn_dontAgree.Name = "btn_dontAgree";
            this.btn_dontAgree.Size = new System.Drawing.Size(503, 23);
            this.btn_dontAgree.TabIndex = 12;
            this.btn_dontAgree.TabStop = false;
            this.btn_dontAgree.Text = "Fix Quiz Errors";
            this.btn_dontAgree.UseVisualStyleBackColor = false;
            this.btn_dontAgree.Click += new System.EventHandler(this.Btn_dontAgree_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Language to answer in:";
            // 
            // cmb_langAns
            // 
            this.cmb_langAns.FormattingEnabled = true;
            this.cmb_langAns.Location = new System.Drawing.Point(143, 6);
            this.cmb_langAns.Name = "cmb_langAns";
            this.cmb_langAns.Size = new System.Drawing.Size(372, 21);
            this.cmb_langAns.TabIndex = 14;
            // 
            // btn_switchTestMode
            // 
            this.btn_switchTestMode.BackColor = System.Drawing.Color.Gray;
            this.btn_switchTestMode.FlatAppearance.BorderSize = 0;
            this.btn_switchTestMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_switchTestMode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_switchTestMode.ForeColor = System.Drawing.Color.White;
            this.btn_switchTestMode.Location = new System.Drawing.Point(12, 250);
            this.btn_switchTestMode.Name = "btn_switchTestMode";
            this.btn_switchTestMode.Size = new System.Drawing.Size(503, 23);
            this.btn_switchTestMode.TabIndex = 15;
            this.btn_switchTestMode.TabStop = false;
            this.btn_switchTestMode.Text = "Disable Intelligent Learning - Do Full Test";
            this.btn_switchTestMode.UseVisualStyleBackColor = false;
            this.btn_switchTestMode.Click += new System.EventHandler(this.Btn_switchTestMode_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nud_intelligentLearningAttempsCount);
            this.panel1.Controls.Add(this.rdo_lastNattemptsIntelligentLearning);
            this.panel1.Controls.Add(this.rdo_allAttemptsIntelligentLearning);
            this.panel1.Controls.Add(this.rdo_last3attemptsIntelligentLearning);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 81);
            this.panel1.TabIndex = 16;
            // 
            // nud_intelligentLearningAttempsCount
            // 
            this.nud_intelligentLearningAttempsCount.Location = new System.Drawing.Point(417, 49);
            this.nud_intelligentLearningAttempsCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_intelligentLearningAttempsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_intelligentLearningAttempsCount.Name = "nud_intelligentLearningAttempsCount";
            this.nud_intelligentLearningAttempsCount.Size = new System.Drawing.Size(68, 22);
            this.nud_intelligentLearningAttempsCount.TabIndex = 3;
            this.nud_intelligentLearningAttempsCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // rdo_lastNattemptsIntelligentLearning
            // 
            this.rdo_lastNattemptsIntelligentLearning.AutoSize = true;
            this.rdo_lastNattemptsIntelligentLearning.Location = new System.Drawing.Point(0, 49);
            this.rdo_lastNattemptsIntelligentLearning.Name = "rdo_lastNattemptsIntelligentLearning";
            this.rdo_lastNattemptsIntelligentLearning.Size = new System.Drawing.Size(414, 17);
            this.rdo_lastNattemptsIntelligentLearning.TabIndex = 2;
            this.rdo_lastNattemptsIntelligentLearning.Text = "Use only last n attempts as basis for Intelligent Learning question selection:";
            this.rdo_lastNattemptsIntelligentLearning.UseVisualStyleBackColor = true;
            // 
            // rdo_allAttemptsIntelligentLearning
            // 
            this.rdo_allAttemptsIntelligentLearning.AutoSize = true;
            this.rdo_allAttemptsIntelligentLearning.Location = new System.Drawing.Point(0, 26);
            this.rdo_allAttemptsIntelligentLearning.Name = "rdo_allAttemptsIntelligentLearning";
            this.rdo_allAttemptsIntelligentLearning.Size = new System.Drawing.Size(425, 17);
            this.rdo_allAttemptsIntelligentLearning.TabIndex = 1;
            this.rdo_allAttemptsIntelligentLearning.Text = "Use all attempts ever made as basis for Intelligent Learning question selection";
            this.rdo_allAttemptsIntelligentLearning.UseVisualStyleBackColor = true;
            // 
            // rdo_last3attemptsIntelligentLearning
            // 
            this.rdo_last3attemptsIntelligentLearning.AutoSize = true;
            this.rdo_last3attemptsIntelligentLearning.Checked = true;
            this.rdo_last3attemptsIntelligentLearning.Location = new System.Drawing.Point(0, 3);
            this.rdo_last3attemptsIntelligentLearning.Name = "rdo_last3attemptsIntelligentLearning";
            this.rdo_last3attemptsIntelligentLearning.Size = new System.Drawing.Size(492, 17);
            this.rdo_last3attemptsIntelligentLearning.TabIndex = 0;
            this.rdo_last3attemptsIntelligentLearning.TabStop = true;
            this.rdo_last3attemptsIntelligentLearning.Text = "Use only last 3 attempts as basis for Intelligent Learning question selection (re" +
    "commended)";
            this.rdo_last3attemptsIntelligentLearning.UseVisualStyleBackColor = true;
            // 
            // chk_randomOrderQuestions
            // 
            this.chk_randomOrderQuestions.AutoSize = true;
            this.chk_randomOrderQuestions.Checked = true;
            this.chk_randomOrderQuestions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_randomOrderQuestions.Location = new System.Drawing.Point(12, 138);
            this.chk_randomOrderQuestions.Name = "chk_randomOrderQuestions";
            this.chk_randomOrderQuestions.Size = new System.Drawing.Size(185, 17);
            this.chk_randomOrderQuestions.TabIndex = 17;
            this.chk_randomOrderQuestions.Text = "Ask questions in random order";
            this.chk_randomOrderQuestions.UseVisualStyleBackColor = true;
            // 
            // QuizPractiseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(527, 314);
            this.Controls.Add(this.chk_randomOrderQuestions);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_switchTestMode);
            this.Controls.Add(this.cmb_langAns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dontAgree);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizPractiseConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Practise Config";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_intelligentLearningAttempsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_dontAgree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_langAns;
        private System.Windows.Forms.Button btn_switchTestMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo_allAttemptsIntelligentLearning;
        private System.Windows.Forms.RadioButton rdo_last3attemptsIntelligentLearning;
        private System.Windows.Forms.RadioButton rdo_lastNattemptsIntelligentLearning;
        private System.Windows.Forms.NumericUpDown nud_intelligentLearningAttempsCount;
        private System.Windows.Forms.CheckBox chk_randomOrderQuestions;
    }
}