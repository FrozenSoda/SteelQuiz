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
    partial class CorrectAnswer
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
            this.lbl_certainty = new System.Windows.Forms.Label();
            this.lbl_cardQuestionSideType = new System.Windows.Forms.Label();
            this.lbl_cardSideToAsk = new System.Windows.Forms.Label();
            this.lbl_cardSideToAnswer = new System.Windows.Forms.Label();
            this.lbl_cardAnswerSideType = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_certainty
            // 
            this.lbl_certainty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_certainty.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lbl_certainty.Location = new System.Drawing.Point(4, 18);
            this.lbl_certainty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_certainty.Name = "lbl_certainty";
            this.lbl_certainty.Size = new System.Drawing.Size(317, 32);
            this.lbl_certainty.TabIndex = 0;
            this.lbl_certainty.Text = "Correct!";
            this.lbl_certainty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_cardQuestionSideType
            // 
            this.lbl_cardQuestionSideType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardQuestionSideType.Location = new System.Drawing.Point(4, 74);
            this.lbl_cardQuestionSideType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardQuestionSideType.Name = "lbl_cardQuestionSideType";
            this.lbl_cardQuestionSideType.Size = new System.Drawing.Size(317, 32);
            this.lbl_cardQuestionSideType.TabIndex = 1;
            this.lbl_cardQuestionSideType.Text = "English:";
            this.lbl_cardQuestionSideType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_cardSideToAsk
            // 
            this.lbl_cardSideToAsk.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardSideToAsk.Location = new System.Drawing.Point(4, 106);
            this.lbl_cardSideToAsk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardSideToAsk.Name = "lbl_cardSideToAsk";
            this.lbl_cardSideToAsk.Size = new System.Drawing.Size(317, 76);
            this.lbl_cardSideToAsk.TabIndex = 2;
            this.lbl_cardSideToAsk.Text = "To eat";
            this.lbl_cardSideToAsk.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_cardSideToAnswer
            // 
            this.lbl_cardSideToAnswer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardSideToAnswer.Location = new System.Drawing.Point(4, 214);
            this.lbl_cardSideToAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardSideToAnswer.Name = "lbl_cardSideToAnswer";
            this.lbl_cardSideToAnswer.Size = new System.Drawing.Size(317, 76);
            this.lbl_cardSideToAnswer.TabIndex = 4;
            this.lbl_cardSideToAnswer.Text = "Comer";
            this.lbl_cardSideToAnswer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_cardAnswerSideType
            // 
            this.lbl_cardAnswerSideType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardAnswerSideType.Location = new System.Drawing.Point(4, 182);
            this.lbl_cardAnswerSideType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardAnswerSideType.Name = "lbl_cardAnswerSideType";
            this.lbl_cardAnswerSideType.Size = new System.Drawing.Size(317, 32);
            this.lbl_cardAnswerSideType.TabIndex = 3;
            this.lbl_cardAnswerSideType.Text = "Spanish:";
            this.lbl_cardAnswerSideType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_instruction
            // 
            this.lbl_instruction.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instruction.Location = new System.Drawing.Point(4, 290);
            this.lbl_instruction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(317, 32);
            this.lbl_instruction.TabIndex = 6;
            this.lbl_instruction.Text = "Press ENTER to continue";
            this.lbl_instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CorrectAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.lbl_instruction);
            this.Controls.Add(this.lbl_cardSideToAnswer);
            this.Controls.Add(this.lbl_cardAnswerSideType);
            this.Controls.Add(this.lbl_cardSideToAsk);
            this.Controls.Add(this.lbl_cardQuestionSideType);
            this.Controls.Add(this.lbl_certainty);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CorrectAnswer";
            this.Size = new System.Drawing.Size(325, 345);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_certainty;
        private System.Windows.Forms.Label lbl_cardQuestionSideType;
        private System.Windows.Forms.Label lbl_cardSideToAsk;
        private System.Windows.Forms.Label lbl_cardSideToAnswer;
        private System.Windows.Forms.Label lbl_cardAnswerSideType;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_instruction;
    }
}
