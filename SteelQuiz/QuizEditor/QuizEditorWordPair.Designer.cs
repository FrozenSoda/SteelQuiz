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

namespace SteelQuiz.QuizEditor
{
    partial class QuizEditorCard
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
            this.pnl_translationRules = new System.Windows.Forms.Panel();
            this.btn_smartCompSettings = new System.Windows.Forms.Button();
            this.lbl_ansCompRules = new System.Windows.Forms.Label();
            this.chk_smartComp = new System.Windows.Forms.CheckBox();
            this.txt_front = new System.Windows.Forms.TextBox();
            this.btn_editSynonymsFront = new System.Windows.Forms.Button();
            this.txt_back = new System.Windows.Forms.TextBox();
            this.btn_editSynonymsBack = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_translationRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_translationRules
            // 
            this.pnl_translationRules.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl_translationRules.Controls.Add(this.btn_smartCompSettings);
            this.pnl_translationRules.Controls.Add(this.lbl_ansCompRules);
            this.pnl_translationRules.Controls.Add(this.chk_smartComp);
            this.pnl_translationRules.Location = new System.Drawing.Point(217, 29);
            this.pnl_translationRules.Name = "pnl_translationRules";
            this.pnl_translationRules.Size = new System.Drawing.Size(299, 65);
            this.pnl_translationRules.TabIndex = 2;
            // 
            // btn_smartCompSettings
            // 
            this.btn_smartCompSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_smartCompSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_smartCompSettings.FlatAppearance.BorderSize = 0;
            this.btn_smartCompSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_smartCompSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_smartCompSettings.ForeColor = System.Drawing.Color.White;
            this.btn_smartCompSettings.Location = new System.Drawing.Point(214, 19);
            this.btn_smartCompSettings.Name = "btn_smartCompSettings";
            this.btn_smartCompSettings.Size = new System.Drawing.Size(20, 20);
            this.btn_smartCompSettings.TabIndex = 8;
            this.btn_smartCompSettings.TabStop = false;
            this.btn_smartCompSettings.UseVisualStyleBackColor = false;
            this.btn_smartCompSettings.Click += new System.EventHandler(this.Btn_smartCompSettings_Click);
            // 
            // lbl_ansCompRules
            // 
            this.lbl_ansCompRules.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ansCompRules.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_ansCompRules.Location = new System.Drawing.Point(3, 0);
            this.lbl_ansCompRules.Name = "lbl_ansCompRules";
            this.lbl_ansCompRules.Size = new System.Drawing.Size(282, 13);
            this.lbl_ansCompRules.TabIndex = 1;
            this.lbl_ansCompRules.Text = "Answer Comparison Rules";
            this.lbl_ansCompRules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_smartComp
            // 
            this.chk_smartComp.AutoCheck = false;
            this.chk_smartComp.AutoSize = true;
            this.chk_smartComp.Checked = true;
            this.chk_smartComp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_smartComp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_smartComp.ForeColor = System.Drawing.Color.LightGray;
            this.chk_smartComp.Location = new System.Drawing.Point(88, 22);
            this.chk_smartComp.Name = "chk_smartComp";
            this.chk_smartComp.Size = new System.Drawing.Size(120, 17);
            this.chk_smartComp.TabIndex = 0;
            this.chk_smartComp.TabStop = false;
            this.chk_smartComp.Text = "Smart Comparison";
            this.chk_smartComp.ThreeState = true;
            this.chk_smartComp.UseVisualStyleBackColor = true;
            this.chk_smartComp.CheckStateChanged += new System.EventHandler(this.Chk_smartComp_CheckStateChanged);
            this.chk_smartComp.Click += new System.EventHandler(this.Chk_smartComp_Click);
            // 
            // txt_front
            // 
            this.txt_front.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txt_front.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_front.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_front.ForeColor = System.Drawing.Color.White;
            this.txt_front.Location = new System.Drawing.Point(25, 3);
            this.txt_front.Name = "txt_front";
            this.txt_front.Size = new System.Drawing.Size(335, 22);
            this.txt_front.TabIndex = 0;
            this.txt_front.Click += new System.EventHandler(this.txt_word_Click);
            this.txt_front.TextChanged += new System.EventHandler(this.txt_word1_TextChanged);
            this.txt_front.Enter += new System.EventHandler(this.txt_word1_Enter);
            this.txt_front.Leave += new System.EventHandler(this.Txt_word1_Leave);
            // 
            // btn_editSynonymsFront
            // 
            this.btn_editSynonymsFront.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_editSynonymsFront.FlatAppearance.BorderSize = 0;
            this.btn_editSynonymsFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editSynonymsFront.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editSynonymsFront.ForeColor = System.Drawing.Color.White;
            this.btn_editSynonymsFront.Location = new System.Drawing.Point(25, 29);
            this.btn_editSynonymsFront.Name = "btn_editSynonymsFront";
            this.btn_editSynonymsFront.Size = new System.Drawing.Size(70, 39);
            this.btn_editSynonymsFront.TabIndex = 4;
            this.btn_editSynonymsFront.TabStop = false;
            this.btn_editSynonymsFront.Text = "Edit Synonyms";
            this.btn_editSynonymsFront.UseVisualStyleBackColor = false;
            this.btn_editSynonymsFront.Click += new System.EventHandler(this.btn_editSynonyms_w1_Click);
            // 
            // txt_back
            // 
            this.txt_back.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txt_back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_back.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_back.ForeColor = System.Drawing.Color.White;
            this.txt_back.Location = new System.Drawing.Point(390, 3);
            this.txt_back.Name = "txt_back";
            this.txt_back.Size = new System.Drawing.Size(335, 22);
            this.txt_back.TabIndex = 5;
            this.txt_back.Click += new System.EventHandler(this.txt_word_Click);
            this.txt_back.TextChanged += new System.EventHandler(this.txt_word2_TextChanged);
            this.txt_back.Enter += new System.EventHandler(this.txt_word1_Enter);
            this.txt_back.Leave += new System.EventHandler(this.Txt_word2_Leave);
            // 
            // btn_editSynonymsBack
            // 
            this.btn_editSynonymsBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editSynonymsBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_editSynonymsBack.FlatAppearance.BorderSize = 0;
            this.btn_editSynonymsBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editSynonymsBack.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editSynonymsBack.ForeColor = System.Drawing.Color.White;
            this.btn_editSynonymsBack.Location = new System.Drawing.Point(655, 29);
            this.btn_editSynonymsBack.Name = "btn_editSynonymsBack";
            this.btn_editSynonymsBack.Size = new System.Drawing.Size(70, 39);
            this.btn_editSynonymsBack.TabIndex = 6;
            this.btn_editSynonymsBack.TabStop = false;
            this.btn_editSynonymsBack.Text = "Edit Synonyms";
            this.btn_editSynonymsBack.UseVisualStyleBackColor = false;
            this.btn_editSynonymsBack.Click += new System.EventHandler(this.btn_editSynonyms_w2_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(574, 29);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 39);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.TabStop = false;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "1:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(368, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "2:";
            // 
            // QuizEditorCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_editSynonymsBack);
            this.Controls.Add(this.txt_back);
            this.Controls.Add(this.btn_editSynonymsFront);
            this.Controls.Add(this.txt_front);
            this.Controls.Add(this.pnl_translationRules);
            this.Name = "QuizEditorCard";
            this.Size = new System.Drawing.Size(730, 97);
            this.SizeChanged += new System.EventHandler(this.QuizEditorWordPair_SizeChanged);
            this.pnl_translationRules.ResumeLayout(false);
            this.pnl_translationRules.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_translationRules;
        private System.Windows.Forms.Label lbl_ansCompRules;
        internal System.Windows.Forms.CheckBox chk_smartComp;
        internal System.Windows.Forms.TextBox txt_front;
        private System.Windows.Forms.Button btn_editSynonymsFront;
        internal System.Windows.Forms.TextBox txt_back;
        private System.Windows.Forms.Button btn_editSynonymsBack;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_smartCompSettings;
    }
}
