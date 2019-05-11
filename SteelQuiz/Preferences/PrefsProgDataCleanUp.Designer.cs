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

namespace SteelQuiz.Preferences
{
    partial class PrefsProgDataCleanUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrefsProgDataCleanUp));
            this.btn_cleanUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.lbl_analysisResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cleanUp
            // 
            this.btn_cleanUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_cleanUp.FlatAppearance.BorderSize = 0;
            this.btn_cleanUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cleanUp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cleanUp.ForeColor = System.Drawing.Color.White;
            this.btn_cleanUp.Location = new System.Drawing.Point(329, 347);
            this.btn_cleanUp.Name = "btn_cleanUp";
            this.btn_cleanUp.Size = new System.Drawing.Size(124, 40);
            this.btn_cleanUp.TabIndex = 1;
            this.btn_cleanUp.Text = "Clean up";
            this.btn_cleanUp.UseVisualStyleBackColor = false;
            this.btn_cleanUp.Click += new System.EventHandler(this.Btn_cleanUp_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 188);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(652, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "――――――――――――――――――――――――――――――――――――――――――――――――――――――――――";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_analyze
            // 
            this.btn_analyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_analyze.FlatAppearance.BorderSize = 0;
            this.btn_analyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_analyze.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_analyze.ForeColor = System.Drawing.Color.White;
            this.btn_analyze.Location = new System.Drawing.Point(199, 347);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(124, 40);
            this.btn_analyze.TabIndex = 4;
            this.btn_analyze.Text = "Analyze";
            this.btn_analyze.UseVisualStyleBackColor = false;
            this.btn_analyze.Click += new System.EventHandler(this.Btn_analyze_Click);
            // 
            // lbl_analysisResult
            // 
            this.lbl_analysisResult.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_analysisResult.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_analysisResult.Location = new System.Drawing.Point(3, 282);
            this.lbl_analysisResult.Name = "lbl_analysisResult";
            this.lbl_analysisResult.Size = new System.Drawing.Size(646, 32);
            this.lbl_analysisResult.TabIndex = 5;
            this.lbl_analysisResult.Text = "Analysis result: Progress data for 0 quizzes can be removed";
            this.lbl_analysisResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_analysisResult.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(646, 68);
            this.label4.TabIndex = 6;
            this.label4.Text = "Warning! Quizzes removed from the quiz folder, will have its progress data remove" +
    "d.\r\nPressing \"Cancel\" will NOT undo the clean up after it is finished.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PrefsProgDataCleanUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_analysisResult);
            this.Controls.Add(this.btn_analyze);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cleanUp);
            this.Name = "PrefsProgDataCleanUp";
            this.Size = new System.Drawing.Size(652, 409);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_cleanUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.Label lbl_analysisResult;
        private System.Windows.Forms.Label label4;
    }
}
