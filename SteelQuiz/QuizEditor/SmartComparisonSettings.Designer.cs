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
    partial class SmartComparisonSettings
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
            this.chk_ignoreCapitalizationFirstChar = new System.Windows.Forms.CheckBox();
            this.chk_ignoreOpeningWhitespace = new System.Windows.Forms.CheckBox();
            this.chk_ignoreEndingWhitespace = new System.Windows.Forms.CheckBox();
            this.chk_ignoreDotsInEnd = new System.Windows.Forms.CheckBox();
            this.chk_treatTextInParenthesisAsSynonym = new System.Windows.Forms.CheckBox();
            this.chk_treatWordsBetweenSlashAsSynonyms = new System.Windows.Forms.CheckBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chk_ignoreCapitalizationFirstChar
            // 
            this.chk_ignoreCapitalizationFirstChar.AutoCheck = false;
            this.chk_ignoreCapitalizationFirstChar.AutoSize = true;
            this.chk_ignoreCapitalizationFirstChar.Checked = true;
            this.chk_ignoreCapitalizationFirstChar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ignoreCapitalizationFirstChar.Location = new System.Drawing.Point(12, 12);
            this.chk_ignoreCapitalizationFirstChar.Name = "chk_ignoreCapitalizationFirstChar";
            this.chk_ignoreCapitalizationFirstChar.Size = new System.Drawing.Size(223, 17);
            this.chk_ignoreCapitalizationFirstChar.TabIndex = 0;
            this.chk_ignoreCapitalizationFirstChar.Text = "Ignore capitalization for first character";
            this.chk_ignoreCapitalizationFirstChar.ThreeState = true;
            this.chk_ignoreCapitalizationFirstChar.UseVisualStyleBackColor = true;
            this.chk_ignoreCapitalizationFirstChar.Click += new System.EventHandler(this.Chk_Click);
            // 
            // chk_ignoreOpeningWhitespace
            // 
            this.chk_ignoreOpeningWhitespace.AutoCheck = false;
            this.chk_ignoreOpeningWhitespace.AutoSize = true;
            this.chk_ignoreOpeningWhitespace.Checked = true;
            this.chk_ignoreOpeningWhitespace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ignoreOpeningWhitespace.Location = new System.Drawing.Point(12, 35);
            this.chk_ignoreOpeningWhitespace.Name = "chk_ignoreOpeningWhitespace";
            this.chk_ignoreOpeningWhitespace.Size = new System.Drawing.Size(168, 17);
            this.chk_ignoreOpeningWhitespace.TabIndex = 1;
            this.chk_ignoreOpeningWhitespace.Text = "Ignore opening whitespace";
            this.chk_ignoreOpeningWhitespace.ThreeState = true;
            this.chk_ignoreOpeningWhitespace.UseVisualStyleBackColor = true;
            this.chk_ignoreOpeningWhitespace.Click += new System.EventHandler(this.Chk_Click);
            // 
            // chk_ignoreEndingWhitespace
            // 
            this.chk_ignoreEndingWhitespace.AutoCheck = false;
            this.chk_ignoreEndingWhitespace.AutoSize = true;
            this.chk_ignoreEndingWhitespace.Checked = true;
            this.chk_ignoreEndingWhitespace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ignoreEndingWhitespace.Location = new System.Drawing.Point(12, 58);
            this.chk_ignoreEndingWhitespace.Name = "chk_ignoreEndingWhitespace";
            this.chk_ignoreEndingWhitespace.Size = new System.Drawing.Size(161, 17);
            this.chk_ignoreEndingWhitespace.TabIndex = 2;
            this.chk_ignoreEndingWhitespace.Text = "Ignore ending whitespace";
            this.chk_ignoreEndingWhitespace.ThreeState = true;
            this.chk_ignoreEndingWhitespace.UseVisualStyleBackColor = true;
            this.chk_ignoreEndingWhitespace.Click += new System.EventHandler(this.Chk_Click);
            // 
            // chk_ignoreDotsInEnd
            // 
            this.chk_ignoreDotsInEnd.AutoCheck = false;
            this.chk_ignoreDotsInEnd.AutoSize = true;
            this.chk_ignoreDotsInEnd.Checked = true;
            this.chk_ignoreDotsInEnd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ignoreDotsInEnd.Location = new System.Drawing.Point(12, 81);
            this.chk_ignoreDotsInEnd.Name = "chk_ignoreDotsInEnd";
            this.chk_ignoreDotsInEnd.Size = new System.Drawing.Size(122, 17);
            this.chk_ignoreDotsInEnd.TabIndex = 3;
            this.chk_ignoreDotsInEnd.Text = "Ignore dots in end";
            this.chk_ignoreDotsInEnd.ThreeState = true;
            this.chk_ignoreDotsInEnd.UseVisualStyleBackColor = true;
            this.chk_ignoreDotsInEnd.Click += new System.EventHandler(this.Chk_Click);
            // 
            // chk_treatTextInParenthesisAsSynonym
            // 
            this.chk_treatTextInParenthesisAsSynonym.AutoCheck = false;
            this.chk_treatTextInParenthesisAsSynonym.AutoSize = true;
            this.chk_treatTextInParenthesisAsSynonym.Checked = true;
            this.chk_treatTextInParenthesisAsSynonym.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_treatTextInParenthesisAsSynonym.Location = new System.Drawing.Point(12, 104);
            this.chk_treatTextInParenthesisAsSynonym.Name = "chk_treatTextInParenthesisAsSynonym";
            this.chk_treatTextInParenthesisAsSynonym.Size = new System.Drawing.Size(265, 17);
            this.chk_treatTextInParenthesisAsSynonym.TabIndex = 4;
            this.chk_treatTextInParenthesisAsSynonym.Text = "Treat text in parenthesis as synonym / optional";
            this.chk_treatTextInParenthesisAsSynonym.ThreeState = true;
            this.chk_treatTextInParenthesisAsSynonym.UseVisualStyleBackColor = true;
            this.chk_treatTextInParenthesisAsSynonym.Click += new System.EventHandler(this.Chk_Click);
            // 
            // chk_treatWordsBetweenSlashAsSynonyms
            // 
            this.chk_treatWordsBetweenSlashAsSynonyms.AutoCheck = false;
            this.chk_treatWordsBetweenSlashAsSynonyms.AutoSize = true;
            this.chk_treatWordsBetweenSlashAsSynonyms.Checked = true;
            this.chk_treatWordsBetweenSlashAsSynonyms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_treatWordsBetweenSlashAsSynonyms.Location = new System.Drawing.Point(12, 127);
            this.chk_treatWordsBetweenSlashAsSynonyms.Name = "chk_treatWordsBetweenSlashAsSynonyms";
            this.chk_treatWordsBetweenSlashAsSynonyms.Size = new System.Drawing.Size(230, 17);
            this.chk_treatWordsBetweenSlashAsSynonyms.TabIndex = 5;
            this.chk_treatWordsBetweenSlashAsSynonyms.Text = "Treat words between slash as synonyms";
            this.chk_treatWordsBetweenSlashAsSynonyms.ThreeState = true;
            this.chk_treatWordsBetweenSlashAsSynonyms.UseVisualStyleBackColor = true;
            this.chk_treatWordsBetweenSlashAsSynonyms.Click += new System.EventHandler(this.Chk_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_apply.FlatAppearance.BorderSize = 0;
            this.btn_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_apply.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_apply.ForeColor = System.Drawing.Color.White;
            this.btn_apply.Location = new System.Drawing.Point(219, 166);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(139, 25);
            this.btn_apply.TabIndex = 7;
            this.btn_apply.TabStop = false;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.Btn_apply_Click);
            // 
            // SmartComparisonSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(370, 203);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.chk_treatWordsBetweenSlashAsSynonyms);
            this.Controls.Add(this.chk_treatTextInParenthesisAsSynonym);
            this.Controls.Add(this.chk_ignoreDotsInEnd);
            this.Controls.Add(this.chk_ignoreEndingWhitespace);
            this.Controls.Add(this.chk_ignoreOpeningWhitespace);
            this.Controls.Add(this.chk_ignoreCapitalizationFirstChar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SmartComparisonSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Comparison Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_ignoreCapitalizationFirstChar;
        private System.Windows.Forms.CheckBox chk_ignoreOpeningWhitespace;
        private System.Windows.Forms.CheckBox chk_ignoreEndingWhitespace;
        private System.Windows.Forms.CheckBox chk_ignoreDotsInEnd;
        private System.Windows.Forms.CheckBox chk_treatTextInParenthesisAsSynonym;
        private System.Windows.Forms.CheckBox chk_treatWordsBetweenSlashAsSynonyms;
        private System.Windows.Forms.Button btn_apply;
    }
}