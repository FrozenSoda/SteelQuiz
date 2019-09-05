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
    partial class ProbablyCorrectAnswer
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_questionLang = new System.Windows.Forms.Label();
            this.lbl_questionWord = new System.Windows.Forms.Label();
            this.lbl_correctAnswer = new System.Windows.Forms.Label();
            this.lbl_answerLang = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Probably correct!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_questionLang
            // 
            this.lbl_questionLang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_questionLang.Location = new System.Drawing.Point(4, 74);
            this.lbl_questionLang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_questionLang.Name = "lbl_questionLang";
            this.lbl_questionLang.Size = new System.Drawing.Size(317, 32);
            this.lbl_questionLang.TabIndex = 1;
            this.lbl_questionLang.Text = "English word:";
            this.lbl_questionLang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_questionWord
            // 
            this.lbl_questionWord.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_questionWord.Location = new System.Drawing.Point(4, 106);
            this.lbl_questionWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_questionWord.Name = "lbl_questionWord";
            this.lbl_questionWord.Size = new System.Drawing.Size(317, 76);
            this.lbl_questionWord.TabIndex = 2;
            this.lbl_questionWord.Text = "To eat";
            this.lbl_questionWord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_correctAnswer
            // 
            this.lbl_correctAnswer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_correctAnswer.Location = new System.Drawing.Point(4, 214);
            this.lbl_correctAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_correctAnswer.Name = "lbl_correctAnswer";
            this.lbl_correctAnswer.Size = new System.Drawing.Size(317, 76);
            this.lbl_correctAnswer.TabIndex = 4;
            this.lbl_correctAnswer.Text = "Comer";
            this.lbl_correctAnswer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_answerLang
            // 
            this.lbl_answerLang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_answerLang.Location = new System.Drawing.Point(4, 182);
            this.lbl_answerLang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_answerLang.Name = "lbl_answerLang";
            this.lbl_answerLang.Size = new System.Drawing.Size(317, 32);
            this.lbl_answerLang.TabIndex = 3;
            this.lbl_answerLang.Text = "Spanish word:";
            this.lbl_answerLang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProbablyCorrectAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.lbl_correctAnswer);
            this.Controls.Add(this.lbl_answerLang);
            this.Controls.Add(this.lbl_questionWord);
            this.Controls.Add(this.lbl_questionLang);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProbablyCorrectAnswer";
            this.Size = new System.Drawing.Size(325, 345);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_questionLang;
        private System.Windows.Forms.Label lbl_questionWord;
        private System.Windows.Forms.Label lbl_correctAnswer;
        private System.Windows.Forms.Label lbl_answerLang;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
