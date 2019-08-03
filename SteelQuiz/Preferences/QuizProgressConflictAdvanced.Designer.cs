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
    partial class QuizProgressConflictAdvanced
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
            this.rdo_mergePrioCurrent = new System.Windows.Forms.RadioButton();
            this.rdo_mergePrioTarget = new System.Windows.Forms.RadioButton();
            this.rdo_overwriteTarget = new System.Windows.Forms.RadioButton();
            this.rdo_keepTarget = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdo_mergePrioCurrent
            // 
            this.rdo_mergePrioCurrent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_mergePrioCurrent.Location = new System.Drawing.Point(3, 77);
            this.rdo_mergePrioCurrent.Name = "rdo_mergePrioCurrent";
            this.rdo_mergePrioCurrent.Size = new System.Drawing.Size(327, 67);
            this.rdo_mergePrioCurrent.TabIndex = 11;
            this.rdo_mergePrioCurrent.Text = "Merge the files.\r\nPrioritize data from the file in the current folder.";
            this.rdo_mergePrioCurrent.UseVisualStyleBackColor = true;
            // 
            // rdo_mergePrioTarget
            // 
            this.rdo_mergePrioTarget.Checked = true;
            this.rdo_mergePrioTarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_mergePrioTarget.Location = new System.Drawing.Point(3, 3);
            this.rdo_mergePrioTarget.Name = "rdo_mergePrioTarget";
            this.rdo_mergePrioTarget.Size = new System.Drawing.Size(327, 68);
            this.rdo_mergePrioTarget.TabIndex = 10;
            this.rdo_mergePrioTarget.TabStop = true;
            this.rdo_mergePrioTarget.Text = "Merge the files.\r\nPrioritize data from the file in the selected folder (recommend" +
    "ed)";
            this.rdo_mergePrioTarget.UseVisualStyleBackColor = true;
            // 
            // rdo_overwriteTarget
            // 
            this.rdo_overwriteTarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_overwriteTarget.Location = new System.Drawing.Point(333, 77);
            this.rdo_overwriteTarget.Name = "rdo_overwriteTarget";
            this.rdo_overwriteTarget.Size = new System.Drawing.Size(321, 67);
            this.rdo_overwriteTarget.TabIndex = 9;
            this.rdo_overwriteTarget.Text = "Keep && use the quiz progress file currently being used.\r\nOverwrite the file in t" +
    "he selected folder.";
            this.rdo_overwriteTarget.UseVisualStyleBackColor = true;
            // 
            // rdo_keepTarget
            // 
            this.rdo_keepTarget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_keepTarget.Location = new System.Drawing.Point(333, 3);
            this.rdo_keepTarget.Name = "rdo_keepTarget";
            this.rdo_keepTarget.Size = new System.Drawing.Size(321, 68);
            this.rdo_keepTarget.TabIndex = 8;
            this.rdo_keepTarget.Text = "Keep && use the quiz progress file in the selected folder.\r\nRemove the currently " +
    "used progress file.";
            this.rdo_keepTarget.UseVisualStyleBackColor = true;
            // 
            // QuizProgressConflictAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.rdo_mergePrioCurrent);
            this.Controls.Add(this.rdo_mergePrioTarget);
            this.Controls.Add(this.rdo_overwriteTarget);
            this.Controls.Add(this.rdo_keepTarget);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizProgressConflictAdvanced";
            this.Size = new System.Drawing.Size(657, 208);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton rdo_mergePrioCurrent;
        internal System.Windows.Forms.RadioButton rdo_mergePrioTarget;
        internal System.Windows.Forms.RadioButton rdo_overwriteTarget;
        internal System.Windows.Forms.RadioButton rdo_keepTarget;
    }
}
