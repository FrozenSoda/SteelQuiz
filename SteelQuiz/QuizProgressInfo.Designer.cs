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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizProgressInfo));
            this.btn_practiseQuiz = new System.Windows.Forms.Button();
            this.btn_editQuiz = new System.Windows.Forms.Button();
            this.lbl_quizNameHere = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flp_words = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_learningProgress_bar = new System.Windows.Forms.Label();
            this.lbl_learningProgress_desc = new System.Windows.Forms.Label();
            this.lbl_learningProgress = new System.Windows.Forms.Label();
            this.btn_more = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_order = new System.Windows.Forms.ComboBox();
            this.cmb_orderAscendingDescending = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_termsCount = new System.Windows.Forms.Label();
            this.btn_practiseWriting = new System.Windows.Forms.Button();
            this.btn_practiseFlashcards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_practiseQuiz
            // 
            this.btn_practiseQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_practiseQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_practiseQuiz.FlatAppearance.BorderSize = 0;
            this.btn_practiseQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_practiseQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_practiseQuiz.Location = new System.Drawing.Point(572, 527);
            this.btn_practiseQuiz.Name = "btn_practiseQuiz";
            this.btn_practiseQuiz.Size = new System.Drawing.Size(158, 45);
            this.btn_practiseQuiz.TabIndex = 0;
            this.btn_practiseQuiz.Text = "Practise Quiz";
            this.btn_practiseQuiz.UseVisualStyleBackColor = false;
            this.btn_practiseQuiz.Click += new System.EventHandler(this.Btn_practiseQuiz_Click);
            // 
            // btn_editQuiz
            // 
            this.btn_editQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_editQuiz.FlatAppearance.BorderSize = 0;
            this.btn_editQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editQuiz.Location = new System.Drawing.Point(408, 527);
            this.btn_editQuiz.Name = "btn_editQuiz";
            this.btn_editQuiz.Size = new System.Drawing.Size(158, 45);
            this.btn_editQuiz.TabIndex = 1;
            this.btn_editQuiz.Text = "Edit Quiz";
            this.btn_editQuiz.UseVisualStyleBackColor = false;
            this.btn_editQuiz.Click += new System.EventHandler(this.Btn_editQuiz_Click);
            // 
            // lbl_quizNameHere
            // 
            this.lbl_quizNameHere.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quizNameHere.Location = new System.Drawing.Point(3, 22);
            this.lbl_quizNameHere.Name = "lbl_quizNameHere";
            this.lbl_quizNameHere.Size = new System.Drawing.Size(580, 38);
            this.lbl_quizNameHere.TabIndex = 3;
            this.lbl_quizNameHere.Text = "Quiz Name Here";
            // 
            // flp_words
            // 
            this.flp_words.AutoScroll = true;
            this.flp_words.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_words.Location = new System.Drawing.Point(9, 106);
            this.flp_words.MinimumSize = new System.Drawing.Size(574, 269);
            this.flp_words.Name = "flp_words";
            this.flp_words.Size = new System.Drawing.Size(718, 415);
            this.flp_words.TabIndex = 7;
            this.flp_words.WrapContents = false;
            // 
            // lbl_learningProgress_bar
            // 
            this.lbl_learningProgress_bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_learningProgress_bar.ForeColor = System.Drawing.Color.Lime;
            this.lbl_learningProgress_bar.Location = new System.Drawing.Point(0, 0);
            this.lbl_learningProgress_bar.Name = "lbl_learningProgress_bar";
            this.lbl_learningProgress_bar.Size = new System.Drawing.Size(586, 13);
            this.lbl_learningProgress_bar.TabIndex = 8;
            this.lbl_learningProgress_bar.Text = resources.GetString("lbl_learningProgress_bar.Text");
            this.lbl_learningProgress_bar.SizeChanged += new System.EventHandler(this.Lbl_learningProgress_bar_SizeChanged);
            // 
            // lbl_learningProgress_desc
            // 
            this.lbl_learningProgress_desc.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_learningProgress_desc.Location = new System.Drawing.Point(6, 65);
            this.lbl_learningProgress_desc.Name = "lbl_learningProgress_desc";
            this.lbl_learningProgress_desc.Size = new System.Drawing.Size(128, 38);
            this.lbl_learningProgress_desc.TabIndex = 9;
            this.lbl_learningProgress_desc.Text = "Learning Progress:";
            this.lbl_learningProgress_desc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_learningProgress
            // 
            this.lbl_learningProgress.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_learningProgress.Location = new System.Drawing.Point(140, 65);
            this.lbl_learningProgress.Name = "lbl_learningProgress";
            this.lbl_learningProgress.Size = new System.Drawing.Size(88, 38);
            this.lbl_learningProgress.TabIndex = 10;
            this.lbl_learningProgress.Text = "100 %";
            this.lbl_learningProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_more
            // 
            this.btn_more.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_more.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_more.FlatAppearance.BorderSize = 0;
            this.btn_more.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_more.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_more.Location = new System.Drawing.Point(9, 527);
            this.btn_more.Name = "btn_more";
            this.btn_more.Size = new System.Drawing.Size(33, 45);
            this.btn_more.TabIndex = 11;
            this.btn_more.Text = "...";
            this.btn_more.UseCompatibleTextRendering = true;
            this.btn_more.UseVisualStyleBackColor = false;
            this.btn_more.Click += new System.EventHandler(this.Btn_more_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Order by:";
            // 
            // cmb_order
            // 
            this.cmb_order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_order.FormattingEnabled = true;
            this.cmb_order.Items.AddRange(new object[] {
            "Success Rate",
            "Quiz Order",
            "Alphabetical Term 1",
            "Alphabetical Term 2"});
            this.cmb_order.Location = new System.Drawing.Point(603, 52);
            this.cmb_order.Name = "cmb_order";
            this.cmb_order.Size = new System.Drawing.Size(124, 21);
            this.cmb_order.TabIndex = 13;
            this.cmb_order.SelectedIndexChanged += new System.EventHandler(this.Cmb_order_SelectedIndexChanged);
            // 
            // cmb_orderAscendingDescending
            // 
            this.cmb_orderAscendingDescending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_orderAscendingDescending.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_orderAscendingDescending.FormattingEnabled = true;
            this.cmb_orderAscendingDescending.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cmb_orderAscendingDescending.Location = new System.Drawing.Point(603, 79);
            this.cmb_orderAscendingDescending.Name = "cmb_orderAscendingDescending";
            this.cmb_orderAscendingDescending.Size = new System.Drawing.Size(124, 21);
            this.cmb_orderAscendingDescending.TabIndex = 14;
            this.cmb_orderAscendingDescending.SelectedIndexChanged += new System.EventHandler(this.Cmb_order_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 38);
            this.label2.TabIndex = 15;
            this.label2.Text = "Number of Terms:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_termsCount
            // 
            this.lbl_termsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_termsCount.Location = new System.Drawing.Point(377, 65);
            this.lbl_termsCount.Name = "lbl_termsCount";
            this.lbl_termsCount.Size = new System.Drawing.Size(88, 38);
            this.lbl_termsCount.TabIndex = 16;
            this.lbl_termsCount.Text = "0";
            this.lbl_termsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_practiseWriting
            // 
            this.btn_practiseWriting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_practiseWriting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_practiseWriting.FlatAppearance.BorderSize = 0;
            this.btn_practiseWriting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_practiseWriting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_practiseWriting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_practiseWriting.Location = new System.Drawing.Point(572, 453);
            this.btn_practiseWriting.Name = "btn_practiseWriting";
            this.btn_practiseWriting.Size = new System.Drawing.Size(158, 31);
            this.btn_practiseWriting.TabIndex = 12;
            this.btn_practiseWriting.Text = "Writing";
            this.btn_practiseWriting.UseVisualStyleBackColor = false;
            this.btn_practiseWriting.Visible = false;
            this.btn_practiseWriting.Click += new System.EventHandler(this.btn_practiseWriting_Click);
            // 
            // btn_practiseFlashcards
            // 
            this.btn_practiseFlashcards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_practiseFlashcards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_practiseFlashcards.FlatAppearance.BorderSize = 0;
            this.btn_practiseFlashcards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_practiseFlashcards.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_practiseFlashcards.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_practiseFlashcards.Location = new System.Drawing.Point(572, 490);
            this.btn_practiseFlashcards.Name = "btn_practiseFlashcards";
            this.btn_practiseFlashcards.Size = new System.Drawing.Size(158, 31);
            this.btn_practiseFlashcards.TabIndex = 17;
            this.btn_practiseFlashcards.Text = "Flashcards";
            this.btn_practiseFlashcards.UseVisualStyleBackColor = false;
            this.btn_practiseFlashcards.Visible = false;
            this.btn_practiseFlashcards.Click += new System.EventHandler(this.btn_practiseFlashcards_Click);
            // 
            // QuizProgressInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.btn_practiseQuiz);
            this.Controls.Add(this.btn_practiseFlashcards);
            this.Controls.Add(this.btn_practiseWriting);
            this.Controls.Add(this.lbl_termsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_orderAscendingDescending);
            this.Controls.Add(this.cmb_order);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_more);
            this.Controls.Add(this.lbl_learningProgress);
            this.Controls.Add(this.lbl_learningProgress_desc);
            this.Controls.Add(this.lbl_learningProgress_bar);
            this.Controls.Add(this.flp_words);
            this.Controls.Add(this.lbl_quizNameHere);
            this.Controls.Add(this.btn_editQuiz);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizProgressInfo";
            this.Size = new System.Drawing.Size(730, 572);
            this.SizeChanged += new System.EventHandler(this.QuizProgressInfo_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_practiseQuiz;
        private System.Windows.Forms.Button btn_editQuiz;
        private System.Windows.Forms.Label lbl_quizNameHere;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flp_words;
        private System.Windows.Forms.Label lbl_learningProgress_bar;
        private System.Windows.Forms.Label lbl_learningProgress_desc;
        private System.Windows.Forms.Label lbl_learningProgress;
        private System.Windows.Forms.Button btn_more;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_order;
        private System.Windows.Forms.ComboBox cmb_orderAscendingDescending;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_termsCount;
        private System.Windows.Forms.Button btn_practiseWriting;
        private System.Windows.Forms.Button btn_practiseFlashcards;
    }
}
