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

namespace SteelQuiz
{
    partial class DashboardQuizWordPair
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
            this.lbl_word1 = new System.Windows.Forms.Label();
            this.lbl_word2 = new System.Windows.Forms.Label();
            this.cpb_learningProgress = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // lbl_word1
            // 
            this.lbl_word1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word1.Location = new System.Drawing.Point(4, 9);
            this.lbl_word1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_word1.Name = "lbl_word1";
            this.lbl_word1.Size = new System.Drawing.Size(250, 38);
            this.lbl_word1.TabIndex = 0;
            this.lbl_word1.Text = "¿Cómo te llamas?";
            // 
            // lbl_word2
            // 
            this.lbl_word2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word2.Location = new System.Drawing.Point(286, 9);
            this.lbl_word2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_word2.Name = "lbl_word2";
            this.lbl_word2.Size = new System.Drawing.Size(250, 38);
            this.lbl_word2.TabIndex = 1;
            this.lbl_word2.Text = "What\'s your name?";
            this.lbl_word2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cpb_learningProgress
            // 
            this.cpb_learningProgress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpb_learningProgress.AnimationSpeed = 500;
            this.cpb_learningProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cpb_learningProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpb_learningProgress.ForeColor = System.Drawing.Color.White;
            this.cpb_learningProgress.InnerColor = System.Drawing.Color.Transparent;
            this.cpb_learningProgress.InnerMargin = 2;
            this.cpb_learningProgress.InnerWidth = -1;
            this.cpb_learningProgress.Location = new System.Drawing.Point(487, 47);
            this.cpb_learningProgress.MarqueeAnimationSpeed = 2000;
            this.cpb_learningProgress.Name = "cpb_learningProgress";
            this.cpb_learningProgress.OuterColor = System.Drawing.Color.White;
            this.cpb_learningProgress.OuterMargin = -25;
            this.cpb_learningProgress.OuterWidth = 24;
            this.cpb_learningProgress.ProgressColor = System.Drawing.Color.Magenta;
            this.cpb_learningProgress.ProgressWidth = 5;
            this.cpb_learningProgress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpb_learningProgress.Size = new System.Drawing.Size(50, 50);
            this.cpb_learningProgress.StartAngle = 270;
            this.cpb_learningProgress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpb_learningProgress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpb_learningProgress.SubscriptText = "";
            this.cpb_learningProgress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpb_learningProgress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpb_learningProgress.SuperscriptText = "";
            this.cpb_learningProgress.TabIndex = 7;
            this.cpb_learningProgress.Text = "0 %";
            this.cpb_learningProgress.TextMargin = new System.Windows.Forms.Padding(0);
            this.cpb_learningProgress.Value = 68;
            // 
            // DashboardQuizWordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.cpb_learningProgress);
            this.Controls.Add(this.lbl_word2);
            this.Controls.Add(this.lbl_word1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DashboardQuizWordPair";
            this.Size = new System.Drawing.Size(540, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_word1;
        private System.Windows.Forms.Label lbl_word2;
        private CircularProgressBar.CircularProgressBar cpb_learningProgress;
    }
}
