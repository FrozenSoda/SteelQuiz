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
    partial class FixQuizErrors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixQuizErrors));
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_editWord1 = new System.Windows.Forms.Button();
            this.btn_editWord1synonyms = new System.Windows.Forms.Button();
            this.btn_editWord2synonyms = new System.Windows.Forms.Button();
            this.btn_editWord2 = new System.Windows.Forms.Button();
            this.lbl_word1 = new System.Windows.Forms.Label();
            this.lbl_word2 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_editInEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_welcome.Location = new System.Drawing.Point(12, 9);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(776, 43);
            this.lbl_welcome.TabIndex = 1;
            this.lbl_welcome.Text = "What is wrong?";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_editWord1
            // 
            this.btn_editWord1.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_editWord1.FlatAppearance.BorderSize = 0;
            this.btn_editWord1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editWord1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editWord1.ForeColor = System.Drawing.Color.White;
            this.btn_editWord1.Location = new System.Drawing.Point(282, 154);
            this.btn_editWord1.Name = "btn_editWord1";
            this.btn_editWord1.Size = new System.Drawing.Size(237, 34);
            this.btn_editWord1.TabIndex = 2;
            this.btn_editWord1.Text = "Word 1 is incorrect";
            this.btn_editWord1.UseVisualStyleBackColor = false;
            this.btn_editWord1.Click += new System.EventHandler(this.btn_editWord1_Click);
            // 
            // btn_editWord1synonyms
            // 
            this.btn_editWord1synonyms.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_editWord1synonyms.FlatAppearance.BorderSize = 0;
            this.btn_editWord1synonyms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editWord1synonyms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editWord1synonyms.ForeColor = System.Drawing.Color.White;
            this.btn_editWord1synonyms.Location = new System.Drawing.Point(282, 194);
            this.btn_editWord1synonyms.Name = "btn_editWord1synonyms";
            this.btn_editWord1synonyms.Size = new System.Drawing.Size(237, 34);
            this.btn_editWord1synonyms.TabIndex = 3;
            this.btn_editWord1synonyms.Text = "I want to edit the synonyms for word 1";
            this.btn_editWord1synonyms.UseVisualStyleBackColor = false;
            this.btn_editWord1synonyms.Click += new System.EventHandler(this.btn_editWord1synonyms_Click);
            // 
            // btn_editWord2synonyms
            // 
            this.btn_editWord2synonyms.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_editWord2synonyms.FlatAppearance.BorderSize = 0;
            this.btn_editWord2synonyms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editWord2synonyms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editWord2synonyms.ForeColor = System.Drawing.Color.White;
            this.btn_editWord2synonyms.Location = new System.Drawing.Point(282, 274);
            this.btn_editWord2synonyms.Name = "btn_editWord2synonyms";
            this.btn_editWord2synonyms.Size = new System.Drawing.Size(237, 34);
            this.btn_editWord2synonyms.TabIndex = 4;
            this.btn_editWord2synonyms.Text = "I want to edit the synonyms for word 2";
            this.btn_editWord2synonyms.UseVisualStyleBackColor = false;
            this.btn_editWord2synonyms.Click += new System.EventHandler(this.btn_editWord2synonyms_Click);
            // 
            // btn_editWord2
            // 
            this.btn_editWord2.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_editWord2.FlatAppearance.BorderSize = 0;
            this.btn_editWord2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editWord2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editWord2.ForeColor = System.Drawing.Color.White;
            this.btn_editWord2.Location = new System.Drawing.Point(282, 234);
            this.btn_editWord2.Name = "btn_editWord2";
            this.btn_editWord2.Size = new System.Drawing.Size(237, 34);
            this.btn_editWord2.TabIndex = 5;
            this.btn_editWord2.Text = "Word 2 is incorrect";
            this.btn_editWord2.UseVisualStyleBackColor = false;
            this.btn_editWord2.Click += new System.EventHandler(this.btn_editWord2_Click);
            // 
            // lbl_word1
            // 
            this.lbl_word1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word1.ForeColor = System.Drawing.Color.White;
            this.lbl_word1.Location = new System.Drawing.Point(12, 52);
            this.lbl_word1.Name = "lbl_word1";
            this.lbl_word1.Size = new System.Drawing.Size(776, 43);
            this.lbl_word1.TabIndex = 6;
            this.lbl_word1.Text = "Word 1:";
            this.lbl_word1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_word2
            // 
            this.lbl_word2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word2.ForeColor = System.Drawing.Color.White;
            this.lbl_word2.Location = new System.Drawing.Point(12, 95);
            this.lbl_word2.Name = "lbl_word2";
            this.lbl_word2.Size = new System.Drawing.Size(776, 43);
            this.lbl_word2.TabIndex = 7;
            this.lbl_word2.Text = "Word 2:";
            this.lbl_word2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(282, 393);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(237, 45);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_editInEditor
            // 
            this.btn_editInEditor.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_editInEditor.FlatAppearance.BorderSize = 0;
            this.btn_editInEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editInEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editInEditor.ForeColor = System.Drawing.Color.White;
            this.btn_editInEditor.Location = new System.Drawing.Point(282, 324);
            this.btn_editInEditor.Name = "btn_editInEditor";
            this.btn_editInEditor.Size = new System.Drawing.Size(237, 44);
            this.btn_editInEditor.TabIndex = 9;
            this.btn_editInEditor.Text = "Too much, edit the entire quiz in the editor";
            this.btn_editInEditor.UseVisualStyleBackColor = false;
            this.btn_editInEditor.Click += new System.EventHandler(this.btn_editInEditor_Click);
            // 
            // FixQuizErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_editInEditor);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_word2);
            this.Controls.Add(this.lbl_word1);
            this.Controls.Add(this.btn_editWord2);
            this.Controls.Add(this.btn_editWord2synonyms);
            this.Controls.Add(this.btn_editWord1synonyms);
            this.Controls.Add(this.btn_editWord1);
            this.Controls.Add(this.lbl_welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FixQuizErrors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fix quiz errors | SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DontAgreeMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btn_editWord1;
        private System.Windows.Forms.Button btn_editWord1synonyms;
        private System.Windows.Forms.Button btn_editWord2synonyms;
        private System.Windows.Forms.Button btn_editWord2;
        private System.Windows.Forms.Label lbl_word1;
        private System.Windows.Forms.Label lbl_word2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_editInEditor;
    }
}