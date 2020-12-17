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
            this.lbl_expl2 = new System.Windows.Forms.Label();
            this.lbl_expl1 = new System.Windows.Forms.Label();
            this.rdo_multipleDefinitionsAsSynonyms = new System.Windows.Forms.RadioButton();
            this.rdo_multipleDefinitionsAsSeparateCards = new System.Windows.Forms.RadioButton();
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
            this.lbl_question.Text = "How should SteelQuiz import terms that have multiple definitions?";
            // 
            // pnl_multiTranslationOptions
            // 
            this.pnl_multiTranslationOptions.Controls.Add(this.lbl_expl2);
            this.pnl_multiTranslationOptions.Controls.Add(this.lbl_expl1);
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_multipleDefinitionsAsSynonyms);
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_multipleDefinitionsAsSeparateCards);
            this.pnl_multiTranslationOptions.Location = new System.Drawing.Point(8, 59);
            this.pnl_multiTranslationOptions.Name = "pnl_multiTranslationOptions";
            this.pnl_multiTranslationOptions.Size = new System.Drawing.Size(760, 161);
            this.pnl_multiTranslationOptions.TabIndex = 21;
            // 
            // lbl_expl2
            // 
            this.lbl_expl2.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_expl2.Location = new System.Drawing.Point(20, 98);
            this.lbl_expl2.Name = "lbl_expl2";
            this.lbl_expl2.Size = new System.Drawing.Size(735, 51);
            this.lbl_expl2.TabIndex = 6;
            this.lbl_expl2.Text = "With this selected, any definition of the term will be accepted when you are prom" +
    "pted to enter it. You will not necessarily learn all of the definitions of the t" +
    "erms.";
            // 
            // lbl_expl1
            // 
            this.lbl_expl1.AutoSize = true;
            this.lbl_expl1.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_expl1.Location = new System.Drawing.Point(20, 23);
            this.lbl_expl1.Name = "lbl_expl1";
            this.lbl_expl1.Size = new System.Drawing.Size(483, 13);
            this.lbl_expl1.TabIndex = 5;
            this.lbl_expl1.Text = "With this selected, SteelQuiz will make sure that you learn all of the definition" +
    "s, of the terms.";
            // 
            // rdo_multipleDefinitionsAsSynonyms
            // 
            this.rdo_multipleDefinitionsAsSynonyms.AutoSize = true;
            this.rdo_multipleDefinitionsAsSynonyms.ForeColor = System.Drawing.Color.White;
            this.rdo_multipleDefinitionsAsSynonyms.Location = new System.Drawing.Point(3, 78);
            this.rdo_multipleDefinitionsAsSynonyms.Name = "rdo_multipleDefinitionsAsSynonyms";
            this.rdo_multipleDefinitionsAsSynonyms.Size = new System.Drawing.Size(412, 17);
            this.rdo_multipleDefinitionsAsSynonyms.TabIndex = 4;
            this.rdo_multipleDefinitionsAsSynonyms.Text = "Add multiple definitions/translations of a term as synonyms in a single card";
            this.rdo_multipleDefinitionsAsSynonyms.UseVisualStyleBackColor = true;
            this.rdo_multipleDefinitionsAsSynonyms.CheckedChanged += new System.EventHandler(this.Rdo_addMultipleTranslationsAsSynonyms_CheckedChanged);
            // 
            // rdo_multipleDefinitionsAsSeparateCards
            // 
            this.rdo_multipleDefinitionsAsSeparateCards.AutoSize = true;
            this.rdo_multipleDefinitionsAsSeparateCards.Checked = true;
            this.rdo_multipleDefinitionsAsSeparateCards.ForeColor = System.Drawing.Color.White;
            this.rdo_multipleDefinitionsAsSeparateCards.Location = new System.Drawing.Point(3, 3);
            this.rdo_multipleDefinitionsAsSeparateCards.Name = "rdo_multipleDefinitionsAsSeparateCards";
            this.rdo_multipleDefinitionsAsSeparateCards.Size = new System.Drawing.Size(445, 17);
            this.rdo_multipleDefinitionsAsSeparateCards.TabIndex = 3;
            this.rdo_multipleDefinitionsAsSeparateCards.TabStop = true;
            this.rdo_multipleDefinitionsAsSeparateCards.Text = "Add terms with multiple definitions/translations as separate cards (recommended)";
            this.rdo_multipleDefinitionsAsSeparateCards.UseVisualStyleBackColor = true;
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.pnl_multiTranslationOptions);
            this.Controls.Add(this.lbl_question);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Step2";
            this.Size = new System.Drawing.Size(766, 364);
            this.pnl_multiTranslationOptions.ResumeLayout(false);
            this.pnl_multiTranslationOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.Panel pnl_multiTranslationOptions;
        internal System.Windows.Forms.RadioButton rdo_multipleDefinitionsAsSynonyms;
        internal System.Windows.Forms.RadioButton rdo_multipleDefinitionsAsSeparateCards;
        private System.Windows.Forms.Label lbl_expl2;
        private System.Windows.Forms.Label lbl_expl1;
    }
}
