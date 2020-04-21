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

namespace SteelQuiz.QuizEditor
{
    partial class QuizEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizEditor));
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_lang1 = new System.Windows.Forms.ComboBox();
            this.cmb_lang2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flp_cards = new System.Windows.Forms.FlowLayoutPanel();
            this.mns_top = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableSmartComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySmartComparisonSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sorryThereIsNoneYetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd_quiz = new System.Windows.Forms.SaveFileDialog();
            this.ofd_quiz = new System.Windows.Forms.OpenFileDialog();
            this.tmr_autoRecoverySave = new System.Windows.Forms.Timer(this.components);
            this.pnl_msg = new System.Windows.Forms.Panel();
            this.mns_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Card Front Type:";
            // 
            // cmb_lang1
            // 
            this.cmb_lang1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmb_lang1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_lang1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_lang1.ForeColor = System.Drawing.Color.White;
            this.cmb_lang1.FormattingEnabled = true;
            this.cmb_lang1.Location = new System.Drawing.Point(109, 30);
            this.cmb_lang1.Name = "cmb_lang1";
            this.cmb_lang1.Size = new System.Drawing.Size(267, 21);
            this.cmb_lang1.TabIndex = 1;
            this.cmb_lang1.TextUpdate += new System.EventHandler(this.Cmb_lang1_TextUpdate);
            // 
            // cmb_lang2
            // 
            this.cmb_lang2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_lang2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.cmb_lang2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_lang2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_lang2.ForeColor = System.Drawing.Color.White;
            this.cmb_lang2.FormattingEnabled = true;
            this.cmb_lang2.Location = new System.Drawing.Point(489, 30);
            this.cmb_lang2.Name = "cmb_lang2";
            this.cmb_lang2.Size = new System.Drawing.Size(272, 21);
            this.cmb_lang2.TabIndex = 2;
            this.cmb_lang2.TextUpdate += new System.EventHandler(this.Cmb_lang2_TextUpdate);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(397, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Card Back Type:";
            // 
            // flp_cards
            // 
            this.flp_cards.AutoScroll = true;
            this.flp_cards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.flp_cards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_cards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_cards.Location = new System.Drawing.Point(12, 73);
            this.flp_cards.Name = "flp_cards";
            this.flp_cards.Size = new System.Drawing.Size(791, 372);
            this.flp_cards.TabIndex = 3;
            this.flp_cards.WrapContents = false;
            // 
            // mns_top
            // 
            this.mns_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.mns_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.globalToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mns_top.Location = new System.Drawing.Point(0, 0);
            this.mns_top.Name = "mns_top";
            this.mns_top.Size = new System.Drawing.Size(815, 24);
            this.mns_top.TabIndex = 10;
            this.mns_top.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeMenuToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+N";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+O";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+S";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeMenuToolStripMenuItem
            // 
            this.closeMenuToolStripMenuItem.Name = "closeMenuToolStripMenuItem";
            this.closeMenuToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.closeMenuToolStripMenuItem.Text = "Close";
            this.closeMenuToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+Z";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+Y";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // globalToolStripMenuItem
            // 
            this.globalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableSmartComparisonToolStripMenuItem,
            this.modifySmartComparisonSettingsToolStripMenuItem});
            this.globalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.globalToolStripMenuItem.Name = "globalToolStripMenuItem";
            this.globalToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.globalToolStripMenuItem.Text = "Global";
            // 
            // enableSmartComparisonToolStripMenuItem
            // 
            this.enableSmartComparisonToolStripMenuItem.Checked = true;
            this.enableSmartComparisonToolStripMenuItem.CheckOnClick = true;
            this.enableSmartComparisonToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableSmartComparisonToolStripMenuItem.Name = "enableSmartComparisonToolStripMenuItem";
            this.enableSmartComparisonToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.enableSmartComparisonToolStripMenuItem.Text = "Enable Smart Comparison";
            this.enableSmartComparisonToolStripMenuItem.Click += new System.EventHandler(this.EnableSmartComparisonToolStripMenuItem_Click);
            // 
            // modifySmartComparisonSettingsToolStripMenuItem
            // 
            this.modifySmartComparisonSettingsToolStripMenuItem.Name = "modifySmartComparisonSettingsToolStripMenuItem";
            this.modifySmartComparisonSettingsToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.modifySmartComparisonSettingsToolStripMenuItem.Text = "Modify Smart Comparison Settings";
            this.modifySmartComparisonSettingsToolStripMenuItem.Click += new System.EventHandler(this.ModifySmartComparisonSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sorryThereIsNoneYetToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // sorryThereIsNoneYetToolStripMenuItem
            // 
            this.sorryThereIsNoneYetToolStripMenuItem.Name = "sorryThereIsNoneYetToolStripMenuItem";
            this.sorryThereIsNoneYetToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.sorryThereIsNoneYetToolStripMenuItem.Text = "Sorry, there is none yet";
            // 
            // sfd_quiz
            // 
            this.sfd_quiz.Filter = "SteelQuiz Quizzes | *.steelquiz";
            this.sfd_quiz.Title = "Save quiz";
            // 
            // ofd_quiz
            // 
            this.ofd_quiz.Filter = "SteelQuiz Quizzes | *.steelquiz";
            this.ofd_quiz.Title = "Select a quiz to edit";
            // 
            // tmr_autoRecoverySave
            // 
            this.tmr_autoRecoverySave.Enabled = true;
            this.tmr_autoRecoverySave.Interval = 30000;
            this.tmr_autoRecoverySave.Tick += new System.EventHandler(this.tmr_autoRecoverySave_Tick);
            // 
            // pnl_msg
            // 
            this.pnl_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_msg.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnl_msg.Location = new System.Drawing.Point(526, 345);
            this.pnl_msg.Name = "pnl_msg";
            this.pnl_msg.Size = new System.Drawing.Size(277, 100);
            this.pnl_msg.TabIndex = 0;
            this.pnl_msg.Visible = false;
            this.pnl_msg.SizeChanged += new System.EventHandler(this.Pnl_msg_SizeChanged);
            // 
            // QuizEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(815, 457);
            this.Controls.Add(this.pnl_msg);
            this.Controls.Add(this.flp_cards);
            this.Controls.Add(this.cmb_lang2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_lang1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mns_top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mns_top;
            this.MinimumSize = new System.Drawing.Size(831, 496);
            this.Name = "QuizEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Untitled - SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizEditor_FormClosing);
            this.SizeChanged += new System.EventHandler(this.QuizEditor_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuizEditor_KeyDown);
            this.mns_top.ResumeLayout(false);
            this.mns_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_lang1;
        private System.Windows.Forms.ComboBox cmb_lang2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.FlowLayoutPanel flp_cards;
        private System.Windows.Forms.MenuStrip mns_top;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd_quiz;
        private System.Windows.Forms.OpenFileDialog ofd_quiz;
        private System.Windows.Forms.Timer tmr_autoRecoverySave;
        private System.Windows.Forms.ToolStripMenuItem sorryThereIsNoneYetToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_msg;
        private System.Windows.Forms.ToolStripMenuItem globalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableSmartComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySmartComparisonSettingsToolStripMenuItem;
    }
}