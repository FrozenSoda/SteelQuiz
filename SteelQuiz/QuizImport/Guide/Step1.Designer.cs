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
            this.flp_siteRdo.Controls.Add(this.rdo_studentlitteratur);
            this.flp_siteRdo.Location = new System.Drawing.Point(8, 69);
            this.flp_siteRdo.Name = "flp_siteRdo";
            this.flp_siteRdo.Size = new System.Drawing.Size(755, 62);
            this.flp_siteRdo.TabIndex = 7;
            this.flp_siteRdo.TabStop = true;
            // 
            // rdo_studentlitteratur
            // 
            this.rdo_studentlitteratur.AutoSize = true;
            this.rdo_studentlitteratur.Checked = true;
            this.rdo_studentlitteratur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_studentlitteratur.ForeColor = System.Drawing.Color.White;
            this.rdo_studentlitteratur.Location = new System.Drawing.Point(3, 3);
            this.rdo_studentlitteratur.Name = "rdo_studentlitteratur";
            this.rdo_studentlitteratur.Size = new System.Drawing.Size(142, 24);
            this.rdo_studentlitteratur.TabIndex = 0;
            this.rdo_studentlitteratur.TabStop = true;
            this.rdo_studentlitteratur.Text = "Studentlitteratur";
            this.rdo_studentlitteratur.UseVisualStyleBackColor = true;
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.Controls.Add(this.flp_siteRdo);
            this.Controls.Add(this.lbl_question);
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
    }
}
