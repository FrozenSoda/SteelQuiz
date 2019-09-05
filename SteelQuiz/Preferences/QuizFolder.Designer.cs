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
    partial class QuizFolder
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
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.fbd_path = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_drag = new System.Windows.Forms.Panel();
            this.btn_moveAllQuizzesHere = new System.Windows.Forms.Button();
            this.btn_browsePath = new System.Windows.Forms.Button();
            this.pnl_drag.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_path
            // 
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.ForeColor = System.Drawing.Color.White;
            this.txt_path.Location = new System.Drawing.Point(3, 12);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(503, 22);
            this.txt_path.TabIndex = 0;
            this.txt_path.Leave += new System.EventHandler(this.Txt_path_Leave);
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.ForeColor = System.Drawing.Color.White;
            this.btn_del.Location = new System.Drawing.Point(323, 39);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(124, 33);
            this.btn_del.TabIndex = 3;
            this.btn_del.Text = "Remove from list";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.Btn_del_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_browse.FlatAppearance.BorderSize = 0;
            this.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browse.ForeColor = System.Drawing.Color.White;
            this.btn_browse.Location = new System.Drawing.Point(453, 39);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(124, 33);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.Btn_browse_Click);
            // 
            // fbd_path
            // 
            this.fbd_path.Description = "Select a folder to add as a quiz folder";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 10);
            this.label1.TabIndex = 5;
            this.label1.Text = "⎯⎯⎯⎯";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 10);
            this.label2.TabIndex = 6;
            this.label2.Text = "⎯⎯⎯⎯";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 10);
            this.label3.TabIndex = 7;
            this.label3.Text = "⎯⎯⎯⎯";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // pnl_drag
            // 
            this.pnl_drag.Controls.Add(this.label1);
            this.pnl_drag.Controls.Add(this.label3);
            this.pnl_drag.Controls.Add(this.label2);
            this.pnl_drag.Location = new System.Drawing.Point(0, 40);
            this.pnl_drag.Name = "pnl_drag";
            this.pnl_drag.Size = new System.Drawing.Size(50, 35);
            this.pnl_drag.TabIndex = 8;
            this.pnl_drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseDown);
            this.pnl_drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseMove);
            this.pnl_drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_drag_MouseUp);
            // 
            // btn_moveAllQuizzesHere
            // 
            this.btn_moveAllQuizzesHere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_moveAllQuizzesHere.FlatAppearance.BorderSize = 0;
            this.btn_moveAllQuizzesHere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_moveAllQuizzesHere.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_moveAllQuizzesHere.ForeColor = System.Drawing.Color.White;
            this.btn_moveAllQuizzesHere.Location = new System.Drawing.Point(180, 39);
            this.btn_moveAllQuizzesHere.Name = "btn_moveAllQuizzesHere";
            this.btn_moveAllQuizzesHere.Size = new System.Drawing.Size(137, 33);
            this.btn_moveAllQuizzesHere.TabIndex = 9;
            this.btn_moveAllQuizzesHere.Text = "Move all quizzes here";
            this.btn_moveAllQuizzesHere.UseVisualStyleBackColor = false;
            this.btn_moveAllQuizzesHere.Click += new System.EventHandler(this.Btn_moveAllQuizzesHere_Click);
            // 
            // btn_browsePath
            // 
            this.btn_browsePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_browsePath.FlatAppearance.BorderSize = 0;
            this.btn_browsePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browsePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browsePath.ForeColor = System.Drawing.Color.White;
            this.btn_browsePath.Location = new System.Drawing.Point(512, 12);
            this.btn_browsePath.Name = "btn_browsePath";
            this.btn_browsePath.Size = new System.Drawing.Size(65, 22);
            this.btn_browsePath.TabIndex = 10;
            this.btn_browsePath.Text = "...";
            this.btn_browsePath.UseVisualStyleBackColor = false;
            this.btn_browsePath.Click += new System.EventHandler(this.Btn_browsePath_Click);
            // 
            // QuizFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.btn_browsePath);
            this.Controls.Add(this.btn_moveAllQuizzesHere);
            this.Controls.Add(this.pnl_drag);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.txt_path);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizFolder";
            this.Size = new System.Drawing.Size(580, 75);
            this.pnl_drag.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.FolderBrowserDialog fbd_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_drag;
        private System.Windows.Forms.Button btn_moveAllQuizzesHere;
        private System.Windows.Forms.Button btn_browsePath;
    }
}
