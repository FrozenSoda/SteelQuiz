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

namespace SteelQuiz
{
    partial class DashboardQuizCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardQuizCard));
            this.lbl_cardFront = new System.Windows.Forms.Label();
            this.lbl_cardBack = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_learningProgress_bar = new System.Windows.Forms.Label();
            this.lbl_learningProgress = new System.Windows.Forms.Label();
            this.lbl_learningProgress_desc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_cardFront
            // 
            this.lbl_cardFront.AutoSize = true;
            this.lbl_cardFront.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardFront.Location = new System.Drawing.Point(4, 22);
            this.lbl_cardFront.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardFront.MaximumSize = new System.Drawing.Size(250, 0);
            this.lbl_cardFront.MinimumSize = new System.Drawing.Size(250, 38);
            this.lbl_cardFront.Name = "lbl_cardFront";
            this.lbl_cardFront.Size = new System.Drawing.Size(250, 38);
            this.lbl_cardFront.TabIndex = 0;
            this.lbl_cardFront.Text = "¿Cómo te llamas?";
            this.lbl_cardFront.SizeChanged += new System.EventHandler(this.Lbl_card_SizeChanged);
            // 
            // lbl_cardBack
            // 
            this.lbl_cardBack.AutoSize = true;
            this.lbl_cardBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cardBack.Location = new System.Drawing.Point(286, 22);
            this.lbl_cardBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cardBack.MaximumSize = new System.Drawing.Size(250, 0);
            this.lbl_cardBack.MinimumSize = new System.Drawing.Size(250, 38);
            this.lbl_cardBack.Name = "lbl_cardBack";
            this.lbl_cardBack.Size = new System.Drawing.Size(250, 38);
            this.lbl_cardBack.TabIndex = 1;
            this.lbl_cardBack.Text = "What\'s your name?";
            this.lbl_cardBack.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_cardBack.SizeChanged += new System.EventHandler(this.Lbl_card_SizeChanged);
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
            this.lbl_learningProgress_desc.Location = new System.Drawing.Point(399, 60);
            this.lbl_learningProgress_desc.Name = "lbl_learningProgress_desc";
            this.lbl_learningProgress_desc.Size = new System.Drawing.Size(78, 38);
            this.lbl_learningProgress_desc.TabIndex = 11;
            this.lbl_learningProgress_desc.Text = "Success rate:";
            this.lbl_learningProgress_desc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DashboardQuizCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.lbl_learningProgress);
            this.Controls.Add(this.lbl_learningProgress_desc);
            this.Controls.Add(this.lbl_learningProgress_bar);
            this.Controls.Add(this.lbl_cardBack);
            this.Controls.Add(this.lbl_cardFront);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DashboardQuizCard";
            this.Size = new System.Drawing.Size(540, 100);
            this.SizeChanged += new System.EventHandler(this.DashboardQuizCard_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_cardFront;
        private System.Windows.Forms.Label lbl_cardBack;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_learningProgress_bar;
        private System.Windows.Forms.Label lbl_learningProgress;
        private System.Windows.Forms.Label lbl_learningProgress_desc;
    }
}
