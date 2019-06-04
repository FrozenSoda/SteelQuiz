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
    partial class QuizProgressConflict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizProgressConflict));
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_keepTarget = new System.Windows.Forms.RadioButton();
            this.rdo_overwriteTarget = new System.Windows.Forms.RadioButton();
            this.btn_continue = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.rdo_mergePrioTarget = new System.Windows.Forms.RadioButton();
            this.rdo_mergePrioCurrent = new System.Windows.Forms.RadioButton();
            this.btn_help = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "A quiz progress data file already exists in the selected folder. What do you want" +
    " to do?";
            // 
            // rdo_keepTarget
            // 
            this.rdo_keepTarget.AutoSize = true;
            this.rdo_keepTarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_keepTarget.Location = new System.Drawing.Point(342, 81);
            this.rdo_keepTarget.Name = "rdo_keepTarget";
            this.rdo_keepTarget.Size = new System.Drawing.Size(327, 46);
            this.rdo_keepTarget.TabIndex = 1;
            this.rdo_keepTarget.Text = "The quiz progress file in the selected folder.\r\nRemove the currently used progres" +
    "s file.";
            this.rdo_keepTarget.UseVisualStyleBackColor = true;
            // 
            // rdo_overwriteTarget
            // 
            this.rdo_overwriteTarget.AutoSize = true;
            this.rdo_overwriteTarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_overwriteTarget.Location = new System.Drawing.Point(342, 133);
            this.rdo_overwriteTarget.Name = "rdo_overwriteTarget";
            this.rdo_overwriteTarget.Size = new System.Drawing.Size(325, 46);
            this.rdo_overwriteTarget.TabIndex = 2;
            this.rdo_overwriteTarget.Text = "The quiz progress file currently being used.\r\nOverwrite the file in the selected " +
    "folder.";
            this.rdo_overwriteTarget.UseVisualStyleBackColor = true;
            // 
            // btn_continue
            // 
            this.btn_continue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_continue.FlatAppearance.BorderSize = 0;
            this.btn_continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_continue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continue.Location = new System.Drawing.Point(489, 249);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(180, 38);
            this.btn_continue.TabIndex = 3;
            this.btn_continue.Text = "Continue";
            this.btn_continue.UseVisualStyleBackColor = false;
            this.btn_continue.Click += new System.EventHandler(this.Btn_continue_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(12, 249);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(119, 38);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // rdo_mergePrioTarget
            // 
            this.rdo_mergePrioTarget.Checked = true;
            this.rdo_mergePrioTarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_mergePrioTarget.Location = new System.Drawing.Point(12, 81);
            this.rdo_mergePrioTarget.Name = "rdo_mergePrioTarget";
            this.rdo_mergePrioTarget.Size = new System.Drawing.Size(327, 68);
            this.rdo_mergePrioTarget.TabIndex = 6;
            this.rdo_mergePrioTarget.Text = "Merge the files.\r\nPrioritize data from the file in the selected folder (recommend" +
    "ed)";
            this.rdo_mergePrioTarget.UseVisualStyleBackColor = true;
            // 
            // rdo_mergePrioCurrent
            // 
            this.rdo_mergePrioCurrent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_mergePrioCurrent.Location = new System.Drawing.Point(12, 155);
            this.rdo_mergePrioCurrent.Name = "rdo_mergePrioCurrent";
            this.rdo_mergePrioCurrent.Size = new System.Drawing.Size(327, 67);
            this.rdo_mergePrioCurrent.TabIndex = 7;
            this.rdo_mergePrioCurrent.Text = "Merge the files.\r\nPrioritize data from the file in the current folder.";
            this.rdo_mergePrioCurrent.UseVisualStyleBackColor = true;
            // 
            // btn_help
            // 
            this.btn_help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_help.FlatAppearance.BorderSize = 0;
            this.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_help.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_help.Location = new System.Drawing.Point(137, 249);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(136, 38);
            this.btn_help.TabIndex = 8;
            this.btn_help.Text = "Help, I don\'t know";
            this.btn_help.UseVisualStyleBackColor = false;
            // 
            // QuizProgressConflict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(681, 299);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.rdo_mergePrioCurrent);
            this.Controls.Add(this.rdo_mergePrioTarget);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_continue);
            this.Controls.Add(this.rdo_overwriteTarget);
            this.Controls.Add(this.rdo_keepTarget);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QuizProgressConflict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Progress Data Conflict | SteelQuiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo_keepTarget;
        private System.Windows.Forms.RadioButton rdo_overwriteTarget;
        private System.Windows.Forms.Button btn_continue;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.RadioButton rdo_mergePrioTarget;
        private System.Windows.Forms.RadioButton rdo_mergePrioCurrent;
        private System.Windows.Forms.Button btn_help;
    }
}