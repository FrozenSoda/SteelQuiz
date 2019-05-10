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

namespace SteelQuiz.QuizImport.Guide
{
    partial class Step2
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
            this.pnl_multiTranslationOptions = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_addMultipleTranslationsAsSynonyms = new System.Windows.Forms.RadioButton();
            this.rdo_multipleTranslationsAsDifferentWordPairs = new System.Windows.Forms.RadioButton();
            this.pnl_multiTranslationOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_question
            // 
            this.lbl_question.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.ForeColor = System.Drawing.Color.White;
            this.lbl_question.Location = new System.Drawing.Point(3, 13);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(760, 43);
            this.lbl_question.TabIndex = 20;
            this.lbl_question.Text = "How should SteelQuiz import words that have multiple definitions?";
            // 
            // pnl_multiTranslationOptions
            // 
            this.pnl_multiTranslationOptions.Controls.Add(this.label2);
            this.pnl_multiTranslationOptions.Controls.Add(this.label1);
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_addMultipleTranslationsAsSynonyms);
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_multipleTranslationsAsDifferentWordPairs);
            this.pnl_multiTranslationOptions.Location = new System.Drawing.Point(8, 59);
            this.pnl_multiTranslationOptions.Name = "pnl_multiTranslationOptions";
            this.pnl_multiTranslationOptions.Size = new System.Drawing.Size(760, 161);
            this.pnl_multiTranslationOptions.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(20, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(735, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "With this selected, any definition of the word will be accepted when you are prom" +
    "pted to enter it. You will not necessarily learn all of the definitions of the w" +
    "ords.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "With this selected, SteelQuiz will make sure that you learn all of the definition" +
    "s, of the words.";
            // 
            // rdo_addMultipleTranslationsAsSynonyms
            // 
            this.rdo_addMultipleTranslationsAsSynonyms.AutoSize = true;
            this.rdo_addMultipleTranslationsAsSynonyms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_addMultipleTranslationsAsSynonyms.ForeColor = System.Drawing.Color.White;
            this.rdo_addMultipleTranslationsAsSynonyms.Location = new System.Drawing.Point(3, 78);
            this.rdo_addMultipleTranslationsAsSynonyms.Name = "rdo_addMultipleTranslationsAsSynonyms";
            this.rdo_addMultipleTranslationsAsSynonyms.Size = new System.Drawing.Size(495, 20);
            this.rdo_addMultipleTranslationsAsSynonyms.TabIndex = 4;
            this.rdo_addMultipleTranslationsAsSynonyms.Text = "Add multiple definitions/translations of a word as synonyms in a single word pair" +
    "";
            this.rdo_addMultipleTranslationsAsSynonyms.UseVisualStyleBackColor = true;
            this.rdo_addMultipleTranslationsAsSynonyms.CheckedChanged += new System.EventHandler(this.Rdo_addMultipleTranslationsAsSynonyms_CheckedChanged);
            // 
            // rdo_multipleTranslationsAsDifferentWordPairs
            // 
            this.rdo_multipleTranslationsAsDifferentWordPairs.AutoSize = true;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Checked = true;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_multipleTranslationsAsDifferentWordPairs.ForeColor = System.Drawing.Color.White;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Location = new System.Drawing.Point(3, 3);
            this.rdo_multipleTranslationsAsDifferentWordPairs.Name = "rdo_multipleTranslationsAsDifferentWordPairs";
            this.rdo_multipleTranslationsAsDifferentWordPairs.Size = new System.Drawing.Size(538, 20);
            this.rdo_multipleTranslationsAsDifferentWordPairs.TabIndex = 3;
            this.rdo_multipleTranslationsAsDifferentWordPairs.TabStop = true;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Text = "Add words with multiple definitions/translations as separate word pairs (recommen" +
    "ded)";
            this.rdo_multipleTranslationsAsDifferentWordPairs.UseVisualStyleBackColor = true;
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.pnl_multiTranslationOptions);
            this.Controls.Add(this.lbl_question);
            this.Name = "Step2";
            this.Size = new System.Drawing.Size(766, 364);
            this.pnl_multiTranslationOptions.ResumeLayout(false);
            this.pnl_multiTranslationOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.Panel pnl_multiTranslationOptions;
        internal System.Windows.Forms.RadioButton rdo_addMultipleTranslationsAsSynonyms;
        internal System.Windows.Forms.RadioButton rdo_multipleTranslationsAsDifferentWordPairs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
