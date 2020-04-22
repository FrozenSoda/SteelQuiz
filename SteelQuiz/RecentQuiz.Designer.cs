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
    partial class RecentQuiz
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dasdToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetProgressDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_folder = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.ContextMenuStrip = this.contextMenuStrip1;
            this.lbl_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(0, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(170, 49);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "p308";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_name.Click += new System.EventHandler(this.Lbl_name_Click);
            this.lbl_name.MouseEnter += new System.EventHandler(this.Everything_MouseEnter);
            this.lbl_name.MouseLeave += new System.EventHandler(this.Everything_MouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportQuizToolStripMenuItem,
            this.dasdToolStripMenuItem,
            this.removeFromListToolStripMenuItem,
            this.resetProgressDataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 76);
            // 
            // exportQuizToolStripMenuItem
            // 
            this.exportQuizToolStripMenuItem.Name = "exportQuizToolStripMenuItem";
            this.exportQuizToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exportQuizToolStripMenuItem.Text = "Export Quiz";
            this.exportQuizToolStripMenuItem.Click += new System.EventHandler(this.exportQuizToolStripMenuItem_Click);
            // 
            // dasdToolStripMenuItem
            // 
            this.dasdToolStripMenuItem.Name = "dasdToolStripMenuItem";
            this.dasdToolStripMenuItem.Size = new System.Drawing.Size(174, 6);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removeFromListToolStripMenuItem.Text = "Remove from List";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromListToolStripMenuItem_Click);
            // 
            // resetProgressDataToolStripMenuItem
            // 
            this.resetProgressDataToolStripMenuItem.Name = "resetProgressDataToolStripMenuItem";
            this.resetProgressDataToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.resetProgressDataToolStripMenuItem.Text = "Reset Progress Data";
            this.resetProgressDataToolStripMenuItem.Click += new System.EventHandler(this.ResetProgressDataToolStripMenuItem_Click);
            // 
            // lbl_folder
            // 
            this.lbl_folder.ContextMenuStrip = this.contextMenuStrip1;
            this.lbl_folder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_folder.Location = new System.Drawing.Point(0, 35);
            this.lbl_folder.Name = "lbl_folder";
            this.lbl_folder.Size = new System.Drawing.Size(170, 24);
            this.lbl_folder.TabIndex = 1;
            this.lbl_folder.Text = "Spanish";
            this.lbl_folder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_folder.Click += new System.EventHandler(this.Lbl_name_Click);
            this.lbl_folder.MouseEnter += new System.EventHandler(this.Everything_MouseEnter);
            this.lbl_folder.MouseLeave += new System.EventHandler(this.Everything_MouseLeave);
            // 
            // RecentQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbl_folder);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "RecentQuiz";
            this.Size = new System.Drawing.Size(170, 59);
            this.MouseEnter += new System.EventHandler(this.Everything_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Everything_MouseLeave);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetProgressDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportQuizToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator dasdToolStripMenuItem;
        private System.Windows.Forms.Label lbl_folder;
    }
}
