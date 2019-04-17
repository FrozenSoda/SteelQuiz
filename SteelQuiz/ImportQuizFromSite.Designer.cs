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

namespace SteelQuiz
{
    partial class ImportQuizFromSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportQuizFromSite));
            this.flp_siteRdo = new System.Windows.Forms.FlowLayoutPanel();
            this.rdo_studentlitteratur = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_lang1 = new System.Windows.Forms.TextBox();
            this.txt_lang2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_quizName = new System.Windows.Forms.TextBox();
            this.btn_urlHowToFind = new System.Windows.Forms.Button();
            this.lbl_studentl_supportedExercises = new System.Windows.Forms.Label();
            this.pnl_multiTranslationOptions = new System.Windows.Forms.Panel();
            this.rdo_addMultipleTranslationsAsSynonyms = new System.Windows.Forms.RadioButton();
            this.rdo_multipleTranslationsAsDifferentWordPairs = new System.Windows.Forms.RadioButton();
            this.flp_siteRdo.SuspendLayout();
            this.pnl_multiTranslationOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_siteRdo
            // 
            this.flp_siteRdo.Controls.Add(this.rdo_studentlitteratur);
            this.flp_siteRdo.Location = new System.Drawing.Point(12, 12);
            this.flp_siteRdo.Name = "flp_siteRdo";
            this.flp_siteRdo.Size = new System.Drawing.Size(776, 27);
            this.flp_siteRdo.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(50, 55);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(657, 20);
            this.txt_url.TabIndex = 1;
            // 
            // btn_import
            // 
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Location = new System.Drawing.Point(549, 392);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(239, 46);
            this.btn_import.TabIndex = 5;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(12, 392);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(162, 46);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Language 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Language 2:";
            // 
            // txt_lang1
            // 
            this.txt_lang1.Location = new System.Drawing.Point(85, 87);
            this.txt_lang1.Name = "txt_lang1";
            this.txt_lang1.Size = new System.Drawing.Size(703, 20);
            this.txt_lang1.TabIndex = 2;
            // 
            // txt_lang2
            // 
            this.txt_lang2.Location = new System.Drawing.Point(85, 115);
            this.txt_lang2.Name = "txt_lang2";
            this.txt_lang2.Size = new System.Drawing.Size(703, 20);
            this.txt_lang2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quiz name:";
            // 
            // txt_quizName
            // 
            this.txt_quizName.Location = new System.Drawing.Point(78, 164);
            this.txt_quizName.Name = "txt_quizName";
            this.txt_quizName.Size = new System.Drawing.Size(710, 20);
            this.txt_quizName.TabIndex = 4;
            // 
            // btn_urlHowToFind
            // 
            this.btn_urlHowToFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_urlHowToFind.Location = new System.Drawing.Point(713, 53);
            this.btn_urlHowToFind.Name = "btn_urlHowToFind";
            this.btn_urlHowToFind.Size = new System.Drawing.Size(75, 23);
            this.btn_urlHowToFind.TabIndex = 8;
            this.btn_urlHowToFind.Text = "How to find";
            this.btn_urlHowToFind.UseVisualStyleBackColor = true;
            this.btn_urlHowToFind.Click += new System.EventHandler(this.btn_urlHowToFind_Click);
            // 
            // lbl_studentl_supportedExercises
            // 
            this.lbl_studentl_supportedExercises.AutoSize = true;
            this.lbl_studentl_supportedExercises.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_studentl_supportedExercises.Location = new System.Drawing.Point(9, 294);
            this.lbl_studentl_supportedExercises.Name = "lbl_studentl_supportedExercises";
            this.lbl_studentl_supportedExercises.Size = new System.Drawing.Size(446, 80);
            this.lbl_studentl_supportedExercises.TabIndex = 9;
            this.lbl_studentl_supportedExercises.Text = "Supported exercises:\r\n- Spelling\r\n- Vocabulary bank\r\n\r\nTrying to import an unsupp" +
    "orted exercise type will probably cause an error";
            // 
            // pnl_multiTranslationOptions
            // 
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_addMultipleTranslationsAsSynonyms);
            this.pnl_multiTranslationOptions.Controls.Add(this.rdo_multipleTranslationsAsDifferentWordPairs);
            this.pnl_multiTranslationOptions.Location = new System.Drawing.Point(15, 209);
            this.pnl_multiTranslationOptions.Name = "pnl_multiTranslationOptions";
            this.pnl_multiTranslationOptions.Size = new System.Drawing.Size(773, 55);
            this.pnl_multiTranslationOptions.TabIndex = 10;
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
            // ImportQuizFromSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_multiTranslationOptions);
            this.Controls.Add(this.lbl_studentl_supportedExercises);
            this.Controls.Add(this.btn_urlHowToFind);
            this.Controls.Add(this.txt_quizName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_lang2);
            this.Controls.Add(this.txt_lang1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flp_siteRdo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportQuizFromSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Importer | SteelQuiz";
            this.flp_siteRdo.ResumeLayout(false);
            this.flp_siteRdo.PerformLayout();
            this.pnl_multiTranslationOptions.ResumeLayout(false);
            this.pnl_multiTranslationOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_siteRdo;
        private System.Windows.Forms.RadioButton rdo_studentlitteratur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_lang1;
        private System.Windows.Forms.TextBox txt_lang2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_quizName;
        private System.Windows.Forms.Button btn_urlHowToFind;
        private System.Windows.Forms.Label lbl_studentl_supportedExercises;
        private System.Windows.Forms.Panel pnl_multiTranslationOptions;
        private System.Windows.Forms.RadioButton rdo_addMultipleTranslationsAsSynonyms;
        private System.Windows.Forms.RadioButton rdo_multipleTranslationsAsDifferentWordPairs;
    }
}