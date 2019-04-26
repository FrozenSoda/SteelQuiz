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

namespace SteelQuiz.QuizEditor
{
    partial class EditorNotification
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
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_timeStamp = new System.Windows.Forms.Label();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.tmr_timeStamp = new System.Windows.Forms.Timer(this.components);
            this.tmr_autoDestruction = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_close.Location = new System.Drawing.Point(249, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(23, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // lbl_timeStamp
            // 
            this.lbl_timeStamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_timeStamp.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeStamp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_timeStamp.Location = new System.Drawing.Point(7, 65);
            this.lbl_timeStamp.Name = "lbl_timeStamp";
            this.lbl_timeStamp.Size = new System.Drawing.Size(236, 22);
            this.lbl_timeStamp.TabIndex = 4;
            this.lbl_timeStamp.Text = "Just now";
            this.lbl_timeStamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_msg
            // 
            this.lbl_msg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_msg.Location = new System.Drawing.Point(6, 13);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(234, 52);
            this.lbl_msg.TabIndex = 3;
            this.lbl_msg.Text = "Message here";
            // 
            // tmr_timeStamp
            // 
            this.tmr_timeStamp.Enabled = true;
            this.tmr_timeStamp.Interval = 15000;
            this.tmr_timeStamp.Tick += new System.EventHandler(this.Tmr_timeStamp_Tick);
            // 
            // tmr_autoDestruction
            // 
            this.tmr_autoDestruction.Tick += new System.EventHandler(this.Tmr_autoDestruction_Tick);
            // 
            // EditorNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_timeStamp);
            this.Controls.Add(this.lbl_msg);
            this.Name = "EditorNotification";
            this.Size = new System.Drawing.Size(275, 98);
            this.SizeChanged += new System.EventHandler(this.EditorNotification_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_timeStamp;
        private System.Windows.Forms.Label lbl_msg;
        private System.Windows.Forms.Timer tmr_timeStamp;
        private System.Windows.Forms.Timer tmr_autoDestruction;
    }
}
