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
    partial class Step0
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
            this.pnl_multiTranslationOptions = new System.Windows.Forms.Panel();
            this.rdo_addMultipleTranslationsAsSynonyms = new System.Windows.Forms.RadioButton();
            this.rdo_multipleTranslationsAsDifferentWordPairs = new System.Windows.Forms.RadioButton();
            this.lbl_studentl_supportedExercises = new System.Windows.Forms.Label();
            this.btn_urlHowToFind = new System.Windows.Forms.Button();
            this.txt_quizName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flp_siteRdo = new System.Windows.Forms.FlowLayoutPanel();
            this.rdo_studentlitteratur = new System.Windows.Forms.RadioButton();
            this.pnl_multiTranslationOptions.SuspendLayout();
            this.flp_siteRdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_multiTranslationOptions
            // 
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_addMultipleTranslationsAsSynonyms);
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_multipleTranslationsAsDifferentWordPairs);
            this.pnl_multiTranslationOptions.Location = new System.Drawing.Point(3, 99);
            this.pnl_multiTranslationOptions.Name = "pnl_multiTranslationOptions";
            this.pnl_multiTranslationOptions.Size = new System.Drawing.Size(760, 55);
            this.pnl_multiTranslationOptions.TabIndex = 18;
            // 
            // rdo_addMultipleTranslationsAsSynonyms
            // 
            this.rdo_addMultipleTranslationsAsSynonyms.AutoSize = true;
            this.rdo_addMultipleTranslationsAsSynonyms.Location = new System.Drawing.Point(3, 26);
            this.rdo_addMultipleTranslationsAsSynonyms.Name = "rdo_addMultipleTranslationsAsSynonyms";
            this.rdo_addMultipleTranslationsAsSynonyms.Size = new System.Drawing.Size(344, 17);
            this.rdo_addMultipleTranslationsAsSynonyms.TabIndex = 1;
            this.rdo_addMultipleTranslationsAsSynonyms.Text = "Add multiple translations of a word as synonyms in a single word pair";
            this.rdo_addMultipleTranslationsAsSynonyms.UseVisualStyleBackColor = true;
            this.rdo_addMultipleTranslationsAsSynonyms.CheckedChanged += new System.EventHandler(this.Rdo_addMultipleTranslationsAsSynonyms_CheckedChanged);
            // 
            // rdo_multipleTranslationsAsDifferentWordPairs
            // 
            this.rdo_multipleTranslationsAsDifferentWordPairs.AutoSize = true;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Checked = true;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Location = new System.Drawing.Point(3, 3);
            this.rdo_multipleTranslationsAsDifferentWordPairs.Name = "rdo_multipleTranslationsAsDifferentWordPairs";
            this.rdo_multipleTranslationsAsDifferentWordPairs.Size = new System.Drawing.Size(376, 17);
            this.rdo_multipleTranslationsAsDifferentWordPairs.TabIndex = 0;
            this.rdo_multipleTranslationsAsDifferentWordPairs.TabStop = true;
            this.rdo_multipleTranslationsAsDifferentWordPairs.Text = "Add words with multiple translations as separate word pairs (recommended)";
            this.rdo_multipleTranslationsAsDifferentWordPairs.UseVisualStyleBackColor = true;
            // 
            // lbl_studentl_supportedExercises
            // 
            this.lbl_studentl_supportedExercises.AutoSize = true;
            this.lbl_studentl_supportedExercises.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studentl_supportedExercises.Location = new System.Drawing.Point(3, 177);
            this.lbl_studentl_supportedExercises.Name = "lbl_studentl_supportedExercises";
            this.lbl_studentl_supportedExercises.Size = new System.Drawing.Size(446, 80);
            this.lbl_studentl_supportedExercises.TabIndex = 17;
            this.lbl_studentl_supportedExercises.Text = "Supported exercises:\r\n- Spelling\r\n- Vocabulary bank\r\n\r\nTrying to import an unsupp" +
    "orted exercise type will probably cause an error";
            // 
            // btn_urlHowToFind
            // 
            this.btn_urlHowToFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_urlHowToFind.Location = new System.Drawing.Point(688, 44);
            this.btn_urlHowToFind.Name = "btn_urlHowToFind";
            this.btn_urlHowToFind.Size = new System.Drawing.Size(75, 23);
            this.btn_urlHowToFind.TabIndex = 16;
            this.btn_urlHowToFind.Text = "How to find";
            this.btn_urlHowToFind.UseVisualStyleBackColor = true;
            this.btn_urlHowToFind.Click += new System.EventHandler(this.btn_urlHowToFind_Click);
            // 
            // txt_quizName
            // 
            this.txt_quizName.Location = new System.Drawing.Point(69, 73);
            this.txt_quizName.Name = "txt_quizName";
            this.txt_quizName.Size = new System.Drawing.Size(694, 20);
            this.txt_quizName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Quiz name:";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(41, 46);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(641, 20);
            this.txt_url.TabIndex = 12;
            this.txt_url.DoubleClick += new System.EventHandler(this.Txt_url_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "URL:";
            // 
            // flp_siteRdo
            // 
            this.flp_siteRdo.Controls.Add(this.rdo_studentlitteratur);
            this.flp_siteRdo.Location = new System.Drawing.Point(3, 3);
            this.flp_siteRdo.Name = "flp_siteRdo";
            this.flp_siteRdo.Size = new System.Drawing.Size(760, 27);
            this.flp_siteRdo.TabIndex = 11;
            // 
            // rdo_studentlitteratur
            // 
            this.rdo_studentlitteratur.AutoSize = true;
            this.rdo_studentlitteratur.Checked = true;
            this.rdo_studentlitteratur.Location = new System.Drawing.Point(3, 3);
            this.rdo_studentlitteratur.Name = "rdo_studentlitteratur";
            this.rdo_studentlitteratur.Size = new System.Drawing.Size(99, 17);
            this.rdo_studentlitteratur.TabIndex = 0;
            this.rdo_studentlitteratur.TabStop = true;
            this.rdo_studentlitteratur.Text = "Studentlitteratur";
            this.rdo_studentlitteratur.UseVisualStyleBackColor = true;
            // 
            // Step0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_multiTranslationOptions);
            this.Controls.Add(this.lbl_studentl_supportedExercises);
            this.Controls.Add(this.btn_urlHowToFind);
            this.Controls.Add(this.txt_quizName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flp_siteRdo);
            this.Name = "Step0";
            this.Size = new System.Drawing.Size(766, 364);
            this.pnl_multiTranslationOptions.ResumeLayout(false);
            this.pnl_multiTranslationOptions.PerformLayout();
            this.flp_siteRdo.ResumeLayout(false);
            this.flp_siteRdo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_multiTranslationOptions;
        internal System.Windows.Forms.RadioButton rdo_addMultipleTranslationsAsSynonyms;
        internal System.Windows.Forms.RadioButton rdo_multipleTranslationsAsDifferentWordPairs;
        private System.Windows.Forms.Label lbl_studentl_supportedExercises;
        private System.Windows.Forms.Button btn_urlHowToFind;
        internal System.Windows.Forms.TextBox txt_quizName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flp_siteRdo;
        internal System.Windows.Forms.RadioButton rdo_studentlitteratur;
    }
}
