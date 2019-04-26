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
    partial class QuizRecoveryUC
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
            this.lbl_recoveryPath = new System.Windows.Forms.Label();
            this.lbl_quizPath = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_recoveryPath
            // 
            this.lbl_recoveryPath.AutoSize = true;
            this.lbl_recoveryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recoveryPath.Location = new System.Drawing.Point(12, 11);
            this.lbl_recoveryPath.Name = "lbl_recoveryPath";
            this.lbl_recoveryPath.Size = new System.Drawing.Size(99, 16);
            this.lbl_recoveryPath.TabIndex = 0;
            this.lbl_recoveryPath.Text = "Recovery path:";
            // 
            // lbl_quizPath
            // 
            this.lbl_quizPath.AutoSize = true;
            this.lbl_quizPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quizPath.Location = new System.Drawing.Point(12, 37);
            this.lbl_quizPath.Name = "lbl_quizPath";
            this.lbl_quizPath.Size = new System.Drawing.Size(66, 16);
            this.lbl_quizPath.TabIndex = 1;
            this.lbl_quizPath.Text = "Quiz path:";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(12, 63);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(159, 16);
            this.lbl_date.TabIndex = 2;
            this.lbl_date.Text = "Auto-recovery-save date:";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(572, 93);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(148, 23);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(433, 93);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(133, 23);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // QuizRecoveryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_quizPath);
            this.Controls.Add(this.lbl_recoveryPath);
            this.Name = "QuizRecoveryUC";
            this.Size = new System.Drawing.Size(737, 126);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_recoveryPath;
        private System.Windows.Forms.Label lbl_quizPath;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_delete;
    }
}
