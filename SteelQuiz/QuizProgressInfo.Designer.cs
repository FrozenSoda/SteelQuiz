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
    partial class QuizProgressInfo
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
            this.btn_practiseQuiz = new System.Windows.Forms.Button();
            this.btn_editQuiz = new System.Windows.Forms.Button();
            this.btn_deleteQuiz = new System.Windows.Forms.Button();
            this.lbl_quizNameHere = new System.Windows.Forms.Label();
            this.cpb_learningProgress = new CircularProgressBar.CircularProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flp_words = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_practiseQuiz
            // 
            this.btn_practiseQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_practiseQuiz.FlatAppearance.BorderSize = 0;
            this.btn_practiseQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_practiseQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_practiseQuiz.Location = new System.Drawing.Point(428, 381);
            this.btn_practiseQuiz.Name = "btn_practiseQuiz";
            this.btn_practiseQuiz.Size = new System.Drawing.Size(158, 45);
            this.btn_practiseQuiz.TabIndex = 0;
            this.btn_practiseQuiz.Text = "Practise Quiz";
            this.btn_practiseQuiz.UseVisualStyleBackColor = false;
            this.btn_practiseQuiz.Click += new System.EventHandler(this.Btn_practiseQuiz_Click);
            // 
            // btn_editQuiz
            // 
            this.btn_editQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_editQuiz.FlatAppearance.BorderSize = 0;
            this.btn_editQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editQuiz.Location = new System.Drawing.Point(264, 381);
            this.btn_editQuiz.Name = "btn_editQuiz";
            this.btn_editQuiz.Size = new System.Drawing.Size(158, 45);
            this.btn_editQuiz.TabIndex = 1;
            this.btn_editQuiz.Text = "Edit Quiz";
            this.btn_editQuiz.UseVisualStyleBackColor = false;
            // 
            // btn_deleteQuiz
            // 
            this.btn_deleteQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_deleteQuiz.FlatAppearance.BorderSize = 0;
            this.btn_deleteQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteQuiz.ForeColor = System.Drawing.Color.LightCoral;
            this.btn_deleteQuiz.Location = new System.Drawing.Point(42, 381);
            this.btn_deleteQuiz.Name = "btn_deleteQuiz";
            this.btn_deleteQuiz.Size = new System.Drawing.Size(158, 45);
            this.btn_deleteQuiz.TabIndex = 2;
            this.btn_deleteQuiz.Text = "Delete Quiz";
            this.btn_deleteQuiz.UseVisualStyleBackColor = false;
            // 
            // lbl_quizNameHere
            // 
            this.lbl_quizNameHere.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quizNameHere.Location = new System.Drawing.Point(3, 0);
            this.lbl_quizNameHere.Name = "lbl_quizNameHere";
            this.lbl_quizNameHere.Size = new System.Drawing.Size(580, 68);
            this.lbl_quizNameHere.TabIndex = 3;
            this.lbl_quizNameHere.Text = "Quiz Name Here";
            // 
            // cpb_learningProgress
            // 
            this.cpb_learningProgress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpb_learningProgress.AnimationSpeed = 500;
            this.cpb_learningProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cpb_learningProgress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpb_learningProgress.ForeColor = System.Drawing.Color.White;
            this.cpb_learningProgress.InnerColor = System.Drawing.Color.Transparent;
            this.cpb_learningProgress.InnerMargin = -1;
            this.cpb_learningProgress.InnerWidth = -1;
            this.cpb_learningProgress.Location = new System.Drawing.Point(483, 10);
            this.cpb_learningProgress.MarqueeAnimationSpeed = 2000;
            this.cpb_learningProgress.Name = "cpb_learningProgress";
            this.cpb_learningProgress.OuterColor = System.Drawing.Color.DimGray;
            this.cpb_learningProgress.OuterMargin = -25;
            this.cpb_learningProgress.OuterWidth = 24;
            this.cpb_learningProgress.ProgressColor = System.Drawing.Color.Magenta;
            this.cpb_learningProgress.ProgressWidth = 10;
            this.cpb_learningProgress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpb_learningProgress.Size = new System.Drawing.Size(90, 90);
            this.cpb_learningProgress.StartAngle = 270;
            this.cpb_learningProgress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpb_learningProgress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpb_learningProgress.SubscriptText = "";
            this.cpb_learningProgress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpb_learningProgress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpb_learningProgress.SuperscriptText = "";
            this.cpb_learningProgress.TabIndex = 6;
            this.cpb_learningProgress.Text = "0 %";
            this.cpb_learningProgress.TextMargin = new System.Windows.Forms.Padding(0);
            this.toolTip1.SetToolTip(this.cpb_learningProgress, "Learning Progress");
            this.cpb_learningProgress.Value = 68;
            // 
            // flp_words
            // 
            this.flp_words.AutoScroll = true;
            this.flp_words.Location = new System.Drawing.Point(9, 106);
            this.flp_words.Name = "flp_words";
            this.flp_words.Size = new System.Drawing.Size(574, 269);
            this.flp_words.TabIndex = 7;
            // 
            // QuizProgressInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.flp_words);
            this.Controls.Add(this.cpb_learningProgress);
            this.Controls.Add(this.lbl_quizNameHere);
            this.Controls.Add(this.btn_deleteQuiz);
            this.Controls.Add(this.btn_editQuiz);
            this.Controls.Add(this.btn_practiseQuiz);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizProgressInfo";
            this.Size = new System.Drawing.Size(586, 426);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_practiseQuiz;
        private System.Windows.Forms.Button btn_editQuiz;
        private System.Windows.Forms.Button btn_deleteQuiz;
        private System.Windows.Forms.Label lbl_quizNameHere;
        private CircularProgressBar.CircularProgressBar cpb_learningProgress;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flp_words;
    }
}
