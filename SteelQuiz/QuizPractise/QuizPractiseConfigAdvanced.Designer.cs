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

namespace SteelQuiz.QuizPractise
{
    partial class QuizPractiseConfigAdvanced
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizPractiseConfigAdvanced));
            this.panel1 = new System.Windows.Forms.Panel();
            this.nud_intelligentLearningAttempsCount = new System.Windows.Forms.NumericUpDown();
            this.rdo_lastNattemptsIntelligentLearning = new System.Windows.Forms.RadioButton();
            this.rdo_allAttemptsIntelligentLearning = new System.Windows.Forms.RadioButton();
            this.rdo_last3attemptsIntelligentLearning = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_minAnsTriesSkip = new System.Windows.Forms.NumericUpDown();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_intelligentLearningAttempsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_minAnsTriesSkip)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nud_intelligentLearningAttempsCount);
            this.panel1.Controls.Add(this.rdo_lastNattemptsIntelligentLearning);
            this.panel1.Controls.Add(this.rdo_allAttemptsIntelligentLearning);
            this.panel1.Controls.Add(this.rdo_last3attemptsIntelligentLearning);
            this.panel1.Location = new System.Drawing.Point(12, 12);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Minimum number of answer tries per card to consider skipping:";
            // 
            // nud_minAnsTriesSkip
            // 
            this.nud_minAnsTriesSkip.Location = new System.Drawing.Point(373, 106);
            this.nud_minAnsTriesSkip.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_minAnsTriesSkip.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_minAnsTriesSkip.Name = "nud_minAnsTriesSkip";
            this.nud_minAnsTriesSkip.Size = new System.Drawing.Size(68, 22);
            this.nud_minAnsTriesSkip.TabIndex = 19;
            this.nud_minAnsTriesSkip.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Gray;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(264, 279);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(251, 23);
            this.btn_close.TabIndex = 23;
            this.btn_close.TabStop = false;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // QuizPractiseConfigAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(527, 314);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.nud_minAnsTriesSkip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizPractiseConfigAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Practise Config Advanced";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_intelligentLearningAttempsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_minAnsTriesSkip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo_allAttemptsIntelligentLearning;
        private System.Windows.Forms.RadioButton rdo_last3attemptsIntelligentLearning;
        private System.Windows.Forms.RadioButton rdo_lastNattemptsIntelligentLearning;
        private System.Windows.Forms.NumericUpDown nud_intelligentLearningAttempsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_minAnsTriesSkip;
        private System.Windows.Forms.Button btn_close;
    }
}