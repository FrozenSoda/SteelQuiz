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
    partial class PrefsQuizFolders
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
            this.pnl_quizFolders = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dflp_quizFolders = new SteelQuiz.Controls.DraggableFlowLayoutPanel();
            this.pnl_quizFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_quizFolders
            // 
            this.pnl_quizFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnl_quizFolders.Controls.Add(this.dflp_quizFolders);
            this.pnl_quizFolders.Controls.Add(this.btn_add);
            this.pnl_quizFolders.Controls.Add(this.label4);
            this.pnl_quizFolders.Location = new System.Drawing.Point(14, 14);
            this.pnl_quizFolders.Name = "pnl_quizFolders";
            this.pnl_quizFolders.Size = new System.Drawing.Size(635, 433);
            this.pnl_quizFolders.TabIndex = 3;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(470, 11);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(124, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quiz Folders";
            // 
            // dflp_quizFolders
            // 
            this.dflp_quizFolders.Location = new System.Drawing.Point(15, 40);
            this.dflp_quizFolders.Name = "dflp_quizFolders";
            this.dflp_quizFolders.Size = new System.Drawing.Size(617, 393);
            this.dflp_quizFolders.TabIndex = 3;
            // 
            // PrefsQuizFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_quizFolders);
            this.Name = "PrefsQuizFolders";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_quizFolders.ResumeLayout(false);
            this.pnl_quizFolders.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_quizFolders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_add;
        private Controls.DraggableFlowLayoutPanel dflp_quizFolders;
    }
}
