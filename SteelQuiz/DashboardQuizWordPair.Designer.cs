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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardQuizWordPair));
            this.lbl_word1 = new System.Windows.Forms.Label();
            this.lbl_word2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_learningProgress_bar = new System.Windows.Forms.Label();
            this.lbl_learningProgress = new System.Windows.Forms.Label();
            this.lbl_learningProgress_desc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_word1
            // 
            this.lbl_word1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word1.Location = new System.Drawing.Point(4, 22);
            this.lbl_word1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_word1.Name = "lbl_word1";
            this.lbl_word1.Size = new System.Drawing.Size(250, 38);
            this.lbl_word1.TabIndex = 0;
            this.lbl_word1.Text = "¿Cómo te llamas?";
            // 
            // lbl_word2
            // 
            this.lbl_word2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_word2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word2.Location = new System.Drawing.Point(286, 22);
            this.lbl_word2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_word2.Name = "lbl_word2";
            this.lbl_word2.Size = new System.Drawing.Size(250, 38);
            this.lbl_word2.TabIndex = 1;
            this.lbl_word2.Text = "What\'s your name?";
            this.lbl_word2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_learningProgress_bar
            // 
            this.lbl_learningProgress_bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_learningProgress_bar.ForeColor = System.Drawing.Color.Lime;
            this.lbl_learningProgress_bar.Location = new System.Drawing.Point(0, 0);
            this.lbl_learningProgress_bar.Name = "lbl_learningProgress_bar";
            this.lbl_learningProgress_bar.Size = new System.Drawing.Size(540, 13);
            this.lbl_learningProgress_bar.TabIndex = 9;
            this.lbl_learningProgress_bar.Text = resources.GetString("lbl_learningProgress_bar.Text");
            this.lbl_learningProgress_bar.SizeChanged += new System.EventHandler(this.Lbl_learningProgress_bar_SizeChanged);
            // 
            // lbl_learningProgress
            // 
            this.lbl_learningProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_learningProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_learningProgress.Location = new System.Drawing.Point(483, 60);
            this.lbl_learningProgress.Name = "lbl_learningProgress";
            this.lbl_learningProgress.Size = new System.Drawing.Size(53, 38);
            this.lbl_learningProgress.TabIndex = 12;
            this.lbl_learningProgress.Text = "100 %";
            this.lbl_learningProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_learningProgress_desc
            // 
            this.lbl_learningProgress_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_learningProgress_desc.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_learningProgress_desc.Location = new System.Drawing.Point(382, 60);
            this.lbl_learningProgress_desc.Name = "lbl_learningProgress_desc";
            this.lbl_learningProgress_desc.Size = new System.Drawing.Size(95, 38);
            this.lbl_learningProgress_desc.TabIndex = 11;
            this.lbl_learningProgress_desc.Text = "Success rate:";
            this.lbl_learningProgress_desc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DashboardQuizWordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.lbl_learningProgress);
            this.Controls.Add(this.lbl_learningProgress_desc);
            this.Controls.Add(this.lbl_learningProgress_bar);
            this.Controls.Add(this.lbl_word2);
            this.Controls.Add(this.lbl_word1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DashboardQuizWordPair";
            this.Size = new System.Drawing.Size(540, 100);
            this.SizeChanged += new System.EventHandler(this.DashboardQuizWordPair_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_word1;
        private System.Windows.Forms.Label lbl_word2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_learningProgress_bar;
        private System.Windows.Forms.Label lbl_learningProgress;
        private System.Windows.Forms.Label lbl_learningProgress_desc;
    }
}
