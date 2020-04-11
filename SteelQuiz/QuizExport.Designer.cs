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

namespace SteelQuiz
{
    partial class QuizExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizExport));
            this.rtf_text = new System.Windows.Forms.RichTextBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_chBetweenLines = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_chBetweenWords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtf_text
            // 
            this.rtf_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtf_text.Location = new System.Drawing.Point(12, 12);
            this.rtf_text.Name = "rtf_text";
            this.rtf_text.ReadOnly = true;
            this.rtf_text.Size = new System.Drawing.Size(776, 373);
            this.rtf_text.TabIndex = 0;
            this.rtf_text.Text = "";
            // 
            // btn_copy
            // 
            this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_copy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_copy.FlatAppearance.BorderSize = 0;
            this.btn_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_copy.ForeColor = System.Drawing.Color.White;
            this.btn_copy.Location = new System.Drawing.Point(602, 391);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(186, 47);
            this.btn_copy.TabIndex = 1;
            this.btn_copy.Text = "Copy Text to Clipboard";
            this.btn_copy.UseVisualStyleBackColor = false;
            this.btn_copy.Click += new System.EventHandler(this.Btn_copy_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(12, 391);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(158, 47);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // txt_chBetweenLines
            // 
            this.txt_chBetweenLines.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_chBetweenLines.Location = new System.Drawing.Point(414, 416);
            this.txt_chBetweenLines.Name = "txt_chBetweenLines";
            this.txt_chBetweenLines.Size = new System.Drawing.Size(113, 22);
            this.txt_chBetweenLines.TabIndex = 25;
            this.txt_chBetweenLines.Text = "\\n";
            this.txt_chBetweenLines.TextChanged += new System.EventHandler(this.Txt_chBetweenLines_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Character(s) between each line:\r\n";
            // 
            // txt_chBetweenWords
            // 
            this.txt_chBetweenWords.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txt_chBetweenWords.Location = new System.Drawing.Point(414, 391);
            this.txt_chBetweenWords.Name = "txt_chBetweenWords";
            this.txt_chBetweenWords.Size = new System.Drawing.Size(113, 22);
            this.txt_chBetweenWords.TabIndex = 23;
            this.txt_chBetweenWords.Text = " - ";
            this.txt_chBetweenWords.TextChanged += new System.EventHandler(this.Txt_chBetweenWords_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Character(s) between words:";
            // 
            // QuizExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_chBetweenLines);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_chBetweenWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.rtf_text);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuizExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Quiz - SteelQuiz";
            this.SizeChanged += new System.EventHandler(this.QuizExport_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtf_text;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_close;
        internal System.Windows.Forms.TextBox txt_chBetweenLines;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txt_chBetweenWords;
        private System.Windows.Forms.Label label1;
    }
}