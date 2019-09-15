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

namespace SteelQuiz.QuizEditor
{
    partial class QuizEditorWordPair
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
            this.txt_word1 = new System.Windows.Forms.TextBox();
            this.btn_editSynonyms_w1 = new System.Windows.Forms.Button();
            this.txt_word2 = new System.Windows.Forms.TextBox();
            this.btn_editSynonyms_w2 = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_drag = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_translationRules.SuspendLayout();
            this.pnl_drag.SuspendLayout();
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
            // txt_word1
            // 
            this.txt_word1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txt_word1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_word1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_word1.ForeColor = System.Drawing.Color.White;
            this.txt_word1.Location = new System.Drawing.Point(25, 3);
            this.txt_word1.Name = "txt_word1";
            this.txt_word1.Size = new System.Drawing.Size(335, 22);
            this.txt_word1.TabIndex = 0;
            this.txt_word1.Click += new System.EventHandler(this.txt_word_Click);
            this.txt_word1.TextChanged += new System.EventHandler(this.txt_word1_TextChanged);
            this.txt_word1.Enter += new System.EventHandler(this.txt_word1_Enter);
            this.txt_word1.Leave += new System.EventHandler(this.Txt_word1_Leave);
            // 
            // btn_editSynonyms_w1
            // 
            this.btn_editSynonyms_w1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_editSynonyms_w1.FlatAppearance.BorderSize = 0;
            this.btn_editSynonyms_w1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editSynonyms_w1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editSynonyms_w1.ForeColor = System.Drawing.Color.White;
            this.btn_editSynonyms_w1.Location = new System.Drawing.Point(25, 29);
            this.btn_editSynonyms_w1.Name = "btn_editSynonyms_w1";
            this.btn_editSynonyms_w1.Size = new System.Drawing.Size(110, 27);
            this.btn_editSynonyms_w1.TabIndex = 4;
            this.btn_editSynonyms_w1.TabStop = false;
            this.btn_editSynonyms_w1.Text = "Edit synonyms";
            this.btn_editSynonyms_w1.UseVisualStyleBackColor = false;
            this.btn_editSynonyms_w1.Click += new System.EventHandler(this.btn_editSynonyms_w1_Click);
            // 
            // txt_word2
            // 
            this.txt_word2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_word2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txt_word2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_word2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_word2.ForeColor = System.Drawing.Color.White;
            this.txt_word2.Location = new System.Drawing.Point(390, 3);
            this.txt_word2.Name = "txt_word2";
            this.txt_word2.Size = new System.Drawing.Size(335, 22);
            this.txt_word2.TabIndex = 5;
            this.txt_word2.Click += new System.EventHandler(this.txt_word_Click);
            this.txt_word2.TextChanged += new System.EventHandler(this.txt_word2_TextChanged);
            this.txt_word2.Enter += new System.EventHandler(this.txt_word1_Enter);
            this.txt_word2.Leave += new System.EventHandler(this.Txt_word2_Leave);
            // 
            // btn_editSynonyms_w2
            // 
            this.btn_editSynonyms_w2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editSynonyms_w2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_editSynonyms_w2.FlatAppearance.BorderSize = 0;
            this.btn_editSynonyms_w2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editSynonyms_w2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editSynonyms_w2.ForeColor = System.Drawing.Color.White;
            this.btn_editSynonyms_w2.Location = new System.Drawing.Point(617, 31);
            this.btn_editSynonyms_w2.Name = "btn_editSynonyms_w2";
            this.btn_editSynonyms_w2.Size = new System.Drawing.Size(110, 27);
            this.btn_editSynonyms_w2.TabIndex = 6;
            this.btn_editSynonyms_w2.TabStop = false;
            this.btn_editSynonyms_w2.Text = "Edit synonyms";
            this.btn_editSynonyms_w2.UseVisualStyleBackColor = false;
            this.btn_editSynonyms_w2.Click += new System.EventHandler(this.btn_editSynonyms_w2_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(522, 31);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(89, 27);
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
            // pnl_drag
            // 
            this.pnl_drag.Controls.Add(this.label3);
            this.pnl_drag.Controls.Add(this.label4);
            this.pnl_drag.Controls.Add(this.label5);
            this.pnl_drag.Location = new System.Drawing.Point(25, 62);
            this.pnl_drag.Name = "pnl_drag";
            this.pnl_drag.Size = new System.Drawing.Size(68, 35);
            this.pnl_drag.TabIndex = 10;
            this.pnl_drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.pnl_drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.pnl_drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 10);
            this.label3.TabIndex = 5;
            this.label3.Text = "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯" +
    "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 10);
            this.label4.TabIndex = 7;
            this.label4.Text = "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯" +
    "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.label4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 10);
            this.label5.TabIndex = 6;
            this.label5.Text = "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯" +
    "⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // QuizEditorWordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_drag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_editSynonyms_w2);
            this.Controls.Add(this.txt_word2);
            this.Controls.Add(this.btn_editSynonyms_w1);
            this.Controls.Add(this.txt_word1);
            this.Controls.Add(this.pnl_translationRules);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizEditorWordPair";
            this.Size = new System.Drawing.Size(730, 97);
            this.SizeChanged += new System.EventHandler(this.QuizEditorWordPair_SizeChanged);
            this.pnl_translationRules.ResumeLayout(false);
            this.pnl_translationRules.PerformLayout();
            this.pnl_drag.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_translationRules;
        private System.Windows.Forms.Label lbl_ansCompRules;
        internal System.Windows.Forms.CheckBox chk_smartComp;
        internal System.Windows.Forms.TextBox txt_word1;
        private System.Windows.Forms.Button btn_editSynonyms_w1;
        internal System.Windows.Forms.TextBox txt_word2;
        private System.Windows.Forms.Button btn_editSynonyms_w2;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_smartCompSettings;
        private System.Windows.Forms.Panel pnl_drag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
