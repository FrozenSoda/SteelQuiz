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
            this.btn_advanced = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_randomOrderQuestions = new System.Windows.Forms.CheckBox();
            this.rdo_answerFront = new System.Windows.Forms.RadioButton();
            this.rdo_answerBack = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_intelligentLearning = new System.Windows.Forms.CheckBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_advanced
            // 
            this.btn_advanced.BackColor = System.Drawing.Color.Gray;
            this.btn_advanced.FlatAppearance.BorderSize = 0;
            this.btn_advanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_advanced.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_advanced.ForeColor = System.Drawing.Color.White;
            this.btn_advanced.Location = new System.Drawing.Point(12, 279);
            this.btn_advanced.Name = "btn_advanced";
            this.btn_advanced.Size = new System.Drawing.Size(146, 23);
            this.btn_advanced.TabIndex = 12;
            this.btn_advanced.TabStop = false;
            this.btn_advanced.Text = "Advanced Options";
            this.btn_advanced.UseVisualStyleBackColor = false;
            this.btn_advanced.Click += new System.EventHandler(this.Btn_advanced_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Card Answer Side:";
            // 
            // chk_randomOrderQuestions
            // 
            this.chk_randomOrderQuestions.AutoSize = true;
            this.chk_randomOrderQuestions.Checked = true;
            this.chk_randomOrderQuestions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_randomOrderQuestions.Location = new System.Drawing.Point(12, 116);
            this.chk_randomOrderQuestions.Name = "chk_randomOrderQuestions";
            this.chk_randomOrderQuestions.Size = new System.Drawing.Size(143, 17);
            this.chk_randomOrderQuestions.TabIndex = 17;
            this.chk_randomOrderQuestions.Text = "Randomize Card Order";
            this.chk_randomOrderQuestions.UseVisualStyleBackColor = true;
            // 
            // rdo_answerFront
            // 
            this.rdo_answerFront.AutoSize = true;
            this.rdo_answerFront.Checked = true;
            this.rdo_answerFront.Location = new System.Drawing.Point(23, 26);
            this.rdo_answerFront.Name = "rdo_answerFront";
            this.rdo_answerFront.Size = new System.Drawing.Size(53, 17);
            this.rdo_answerFront.TabIndex = 18;
            this.rdo_answerFront.TabStop = true;
            this.rdo_answerFront.Text = "Front";
            this.rdo_answerFront.UseVisualStyleBackColor = true;
            // 
            // rdo_answerBack
            // 
            this.rdo_answerBack.AutoSize = true;
            this.rdo_answerBack.Location = new System.Drawing.Point(23, 49);
            this.rdo_answerBack.Name = "rdo_answerBack";
            this.rdo_answerBack.Size = new System.Drawing.Size(48, 17);
            this.rdo_answerBack.TabIndex = 19;
            this.rdo_answerBack.Text = "Back";
            this.rdo_answerBack.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdo_answerBack);
            this.panel1.Controls.Add(this.rdo_answerFront);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 83);
            this.panel1.TabIndex = 20;
            // 
            // chk_intelligentLearning
            // 
            this.chk_intelligentLearning.AutoSize = true;
            this.chk_intelligentLearning.Checked = true;
            this.chk_intelligentLearning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_intelligentLearning.Location = new System.Drawing.Point(12, 139);
            this.chk_intelligentLearning.Name = "chk_intelligentLearning";
            this.chk_intelligentLearning.Size = new System.Drawing.Size(165, 17);
            this.chk_intelligentLearning.TabIndex = 21;
            this.chk_intelligentLearning.Text = "Enable Intelligent Learning";
            this.chk_intelligentLearning.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Gray;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(164, 279);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(251, 23);
            this.btn_close.TabIndex = 22;
            this.btn_close.TabStop = false;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // QuizPractiseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(427, 314);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.chk_intelligentLearning);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chk_randomOrderQuestions);
            this.Controls.Add(this.btn_advanced);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizPractiseConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Practise Config";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_advanced;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_randomOrderQuestions;
        private System.Windows.Forms.RadioButton rdo_answerFront;
        private System.Windows.Forms.RadioButton rdo_answerBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chk_intelligentLearning;
        private System.Windows.Forms.Button btn_close;
    }
}