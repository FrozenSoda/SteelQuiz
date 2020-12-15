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
    partial class Step5
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
            this.txt_lang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_terms = new System.Windows.Forms.ListBox();
            this.lbl_question = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_lang
            // 
            this.txt_lang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_lang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lang.Location = new System.Drawing.Point(158, 334);
            this.txt_lang.Name = "txt_lang";
            this.txt_lang.Size = new System.Drawing.Size(605, 22);
            this.txt_lang.TabIndex = 0;
            this.txt_lang.TextChanged += new System.EventHandler(this.Txt_lang_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Language/type (in English):";
            // 
            // lst_terms
            // 
            this.lst_terms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_terms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_terms.ForeColor = System.Drawing.Color.White;
            this.lst_terms.FormattingEnabled = true;
            this.lst_terms.Location = new System.Drawing.Point(2, 55);
            this.lst_terms.Name = "lst_terms";
            this.lst_terms.Size = new System.Drawing.Size(761, 236);
            this.lst_terms.TabIndex = 6;
            this.lst_terms.TabStop = false;
            // 
            // lbl_question
            // 
            this.lbl_question.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.ForeColor = System.Drawing.Color.White;
            this.lbl_question.Location = new System.Drawing.Point(3, 13);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(760, 43);
            this.lbl_question.TabIndex = 4;
            this.lbl_question.Text = "Which language/type best describes these terms?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(5, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Examples:   Norwegian; Answer; Name; Mass; Rectangular form; ...";
            // 
            // Step5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_lang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_terms);
            this.Controls.Add(this.lbl_question);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Step5";
            this.Size = new System.Drawing.Size(766, 364);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox txt_lang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_terms;
        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.Label label2;
    }
}
