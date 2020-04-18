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

namespace SteelQuiz.QuizPractise
{
    partial class RoundCompleted
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
            this.components = new System.ComponentModel.Container();
            this.lbl_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_cardsShown = new System.Windows.Forms.Label();
            this.lbl_successRate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lbl_title.Location = new System.Drawing.Point(4, 18);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(317, 32);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Round Completed!";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_title.Click += new System.EventHandler(this.RoundCompleted_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cards Shown:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.RoundCompleted_Click);
            // 
            // lbl_cardsShown
            // 
            this.lbl_cardsShown.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardsShown.Location = new System.Drawing.Point(4, 106);
            this.lbl_cardsShown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardsShown.Name = "lbl_cardsShown";
            this.lbl_cardsShown.Size = new System.Drawing.Size(317, 76);
            this.lbl_cardsShown.TabIndex = 2;
            this.lbl_cardsShown.Text = "0";
            this.lbl_cardsShown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_cardsShown.Click += new System.EventHandler(this.RoundCompleted_Click);
            // 
            // lbl_successRate
            // 
            this.lbl_successRate.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_successRate.Location = new System.Drawing.Point(4, 214);
            this.lbl_successRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_successRate.Name = "lbl_successRate";
            this.lbl_successRate.Size = new System.Drawing.Size(317, 76);
            this.lbl_successRate.TabIndex = 4;
            this.lbl_successRate.Text = "0 %";
            this.lbl_successRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_successRate.Click += new System.EventHandler(this.RoundCompleted_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Correct Answer Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.RoundCompleted_Click);
            // 
            // lbl_instruction
            // 
            this.lbl_instruction.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instruction.Location = new System.Drawing.Point(4, 290);
            this.lbl_instruction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(317, 32);
            this.lbl_instruction.TabIndex = 6;
            this.lbl_instruction.Text = "Press ENTER to continue";
            this.lbl_instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_instruction.Click += new System.EventHandler(this.RoundCompleted_Click);
            // 
            // RoundCompleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.lbl_instruction);
            this.Controls.Add(this.lbl_successRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_cardsShown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_title);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RoundCompleted";
            this.Size = new System.Drawing.Size(325, 345);
            this.Click += new System.EventHandler(this.RoundCompleted_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_cardsShown;
        private System.Windows.Forms.Label lbl_successRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_instruction;
    }
}
