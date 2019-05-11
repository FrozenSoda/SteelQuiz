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
    partial class QuizImportGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizImportGuide));
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_prevCancel = new System.Windows.Forms.Button();
            this.pnl_steps = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_next.FlatAppearance.BorderSize = 0;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Location = new System.Drawing.Point(549, 392);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(239, 46);
            this.btn_next.TabIndex = 1;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_prevCancel
            // 
            this.btn_prevCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_prevCancel.FlatAppearance.BorderSize = 0;
            this.btn_prevCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prevCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prevCancel.ForeColor = System.Drawing.Color.White;
            this.btn_prevCancel.Location = new System.Drawing.Point(12, 392);
            this.btn_prevCancel.Name = "btn_prevCancel";
            this.btn_prevCancel.Size = new System.Drawing.Size(162, 46);
            this.btn_prevCancel.TabIndex = 6;
            this.btn_prevCancel.Text = "Cancel";
            this.btn_prevCancel.UseVisualStyleBackColor = false;
            this.btn_prevCancel.Click += new System.EventHandler(this.btn_prevCancel_Click);
            // 
            // pnl_steps
            // 
            this.pnl_steps.Location = new System.Drawing.Point(12, 12);
            this.pnl_steps.Name = "pnl_steps";
            this.pnl_steps.Size = new System.Drawing.Size(776, 374);
            this.pnl_steps.TabIndex = 0;
            this.pnl_steps.TabStop = true;
            // 
            // QuizImportGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_steps);
            this.Controls.Add(this.btn_prevCancel);
            this.Controls.Add(this.btn_next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QuizImportGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Importer | SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizImportGuide_FormClosing);
            this.Shown += new System.EventHandler(this.QuizImportGuide_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_prevCancel;
        private System.Windows.Forms.Panel pnl_steps;
    }
}