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

namespace SteelQuiz.QuizImport.Guide
{
    partial class Step1
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
            this.flp_siteRdo = new System.Windows.Forms.FlowLayoutPanel();
            this.rdo_plainTextImport = new System.Windows.Forms.RadioButton();
            this.rdo_studentlitteratur = new System.Windows.Forms.RadioButton();
            this.flp_siteRdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_question
            // 
            this.lbl_question.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.ForeColor = System.Drawing.Color.White;
            this.lbl_question.Location = new System.Drawing.Point(3, 13);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(760, 43);
            this.lbl_question.TabIndex = 6;
            this.lbl_question.Text = "Select the source from which you are going to import the quiz";
            // 
            // flp_siteRdo
            // 
            this.flp_siteRdo.Controls.Add(this.rdo_plainTextImport);
            this.flp_siteRdo.Controls.Add(this.rdo_studentlitteratur);
            this.flp_siteRdo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_siteRdo.Location = new System.Drawing.Point(8, 59);
            this.flp_siteRdo.Name = "flp_siteRdo";
            this.flp_siteRdo.Size = new System.Drawing.Size(755, 248);
            this.flp_siteRdo.TabIndex = 7;
            this.flp_siteRdo.TabStop = true;
            // 
            // rdo_plainTextImport
            // 
            this.rdo_plainTextImport.AutoSize = true;
            this.rdo_plainTextImport.Checked = true;
            this.rdo_plainTextImport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_plainTextImport.ForeColor = System.Drawing.Color.White;
            this.rdo_plainTextImport.Location = new System.Drawing.Point(3, 3);
            this.rdo_plainTextImport.Name = "rdo_plainTextImport";
            this.rdo_plainTextImport.Size = new System.Drawing.Size(78, 21);
            this.rdo_plainTextImport.TabIndex = 1;
            this.rdo_plainTextImport.TabStop = true;
            this.rdo_plainTextImport.Text = "Plain text";
            this.rdo_plainTextImport.UseVisualStyleBackColor = true;
            // 
            // rdo_studentlitteratur
            // 
            this.rdo_studentlitteratur.AutoSize = true;
            this.rdo_studentlitteratur.Enabled = false;
            this.rdo_studentlitteratur.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_studentlitteratur.ForeColor = System.Drawing.Color.White;
            this.rdo_studentlitteratur.Location = new System.Drawing.Point(3, 30);
            this.rdo_studentlitteratur.Name = "rdo_studentlitteratur";
            this.rdo_studentlitteratur.Size = new System.Drawing.Size(119, 21);
            this.rdo_studentlitteratur.TabIndex = 0;
            this.rdo_studentlitteratur.Text = "Studentlitteratur";
            this.rdo_studentlitteratur.UseVisualStyleBackColor = true;
            this.rdo_studentlitteratur.Visible = false;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.flp_siteRdo);
            this.Controls.Add(this.lbl_question);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Step1";
            this.Size = new System.Drawing.Size(766, 364);
            this.flp_siteRdo.ResumeLayout(false);
            this.flp_siteRdo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.FlowLayoutPanel flp_siteRdo;
        internal System.Windows.Forms.RadioButton rdo_studentlitteratur;
        internal System.Windows.Forms.RadioButton rdo_plainTextImport;
    }
}
