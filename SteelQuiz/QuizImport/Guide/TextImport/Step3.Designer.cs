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

namespace SteelQuiz.QuizImport.Guide.TextImport
{
    partial class Step3
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
            this.lbl_question = new System.Windows.Forms.Label();
            this.rtf_text = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_chBetweenWords = new System.Windows.Forms.TextBox();
            this.txt_chBetweenLines = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_question
            // 
            this.lbl_question.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.ForeColor = System.Drawing.Color.White;
            this.lbl_question.Location = new System.Drawing.Point(3, 13);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(760, 43);
            this.lbl_question.TabIndex = 16;
            this.lbl_question.Text = "Paste the text containing the quiz\r\n";
            // 
            // rtf_text
            // 
            this.rtf_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtf_text.Location = new System.Drawing.Point(8, 59);
            this.rtf_text.Name = "rtf_text";
            this.rtf_text.Size = new System.Drawing.Size(755, 266);
            this.rtf_text.TabIndex = 17;
            this.rtf_text.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Character(s) between terms:";
            // 
            // txt_chBetweenWords
            // 
            this.txt_chBetweenWords.Location = new System.Drawing.Point(164, 337);
            this.txt_chBetweenWords.Name = "txt_chBetweenWords";
            this.txt_chBetweenWords.Size = new System.Drawing.Size(113, 22);
            this.txt_chBetweenWords.TabIndex = 19;
            this.txt_chBetweenWords.Text = " - ";
            // 
            // txt_chBetweenLines
            // 
            this.txt_chBetweenLines.Location = new System.Drawing.Point(490, 337);
            this.txt_chBetweenLines.Name = "txt_chBetweenLines";
            this.txt_chBetweenLines.Size = new System.Drawing.Size(113, 22);
            this.txt_chBetweenLines.TabIndex = 21;
            this.txt_chBetweenLines.Text = "\\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Character(s) between each line:\r\n";
            // 
            // Step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.txt_chBetweenLines);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_chBetweenWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtf_text);
            this.Controls.Add(this.lbl_question);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Step3";
            this.Size = new System.Drawing.Size(766, 364);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.RichTextBox rtf_text;
        internal System.Windows.Forms.TextBox txt_chBetweenWords;
        internal System.Windows.Forms.TextBox txt_chBetweenLines;
    }
}
