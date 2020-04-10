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
    partial class PrefsStorage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrefsStorage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_resetToDefaultsProgressData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_browseQuizProgPath = new System.Windows.Forms.Button();
            this.txt_quizProgPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fbd_quizProgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_resetToDefaultsQuizSavePath = new System.Windows.Forms.Button();
            this.btn_browseDefaultQuizSavePath = new System.Windows.Forms.Button();
            this.txt_defaultQuizSaveFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fbd_defaultQuizSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.btn_resetToDefaultsProgressData);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_browseQuizProgPath);
            this.panel1.Controls.Add(this.txt_quizProgPath);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 158);
            this.panel1.TabIndex = 4;
            // 
            // btn_resetToDefaultsProgressData
            // 
            this.btn_resetToDefaultsProgressData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_resetToDefaultsProgressData.FlatAppearance.BorderSize = 0;
            this.btn_resetToDefaultsProgressData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetToDefaultsProgressData.Location = new System.Drawing.Point(505, 132);
            this.btn_resetToDefaultsProgressData.Name = "btn_resetToDefaultsProgressData";
            this.btn_resetToDefaultsProgressData.Size = new System.Drawing.Size(127, 23);
            this.btn_resetToDefaultsProgressData.TabIndex = 5;
            this.btn_resetToDefaultsProgressData.Text = "Reset to defaults";
            this.btn_resetToDefaultsProgressData.UseVisualStyleBackColor = false;
            this.btn_resetToDefaultsProgressData.Click += new System.EventHandler(this.Btn_resetToDefaults_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(617, 51);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btn_browseQuizProgPath
            // 
            this.btn_browseQuizProgPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_browseQuizProgPath.FlatAppearance.BorderSize = 0;
            this.btn_browseQuizProgPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browseQuizProgPath.Location = new System.Drawing.Point(557, 40);
            this.btn_browseQuizProgPath.Name = "btn_browseQuizProgPath";
            this.btn_browseQuizProgPath.Size = new System.Drawing.Size(75, 23);
            this.btn_browseQuizProgPath.TabIndex = 3;
            this.btn_browseQuizProgPath.Text = "...";
            this.btn_browseQuizProgPath.UseVisualStyleBackColor = false;
            this.btn_browseQuizProgPath.Click += new System.EventHandler(this.Btn_browseQuizProgPath_Click);
            // 
            // txt_quizProgPath
            // 
            this.txt_quizProgPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_quizProgPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quizProgPath.Location = new System.Drawing.Point(15, 40);
            this.txt_quizProgPath.Name = "txt_quizProgPath";
            this.txt_quizProgPath.Size = new System.Drawing.Size(536, 23);
            this.txt_quizProgPath.TabIndex = 2;
            this.txt_quizProgPath.Leave += new System.EventHandler(this.Txt_quizProgPath_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quiz Progress Data Folder Path";
            // 
            // fbd_quizProgFolder
            // 
            this.fbd_quizProgFolder.Description = "Select the folder where SteelQuiz should store your quiz progress";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.btn_resetToDefaultsQuizSavePath);
            this.panel2.Controls.Add(this.btn_browseDefaultQuizSavePath);
            this.panel2.Controls.Add(this.txt_defaultQuizSaveFolder);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(14, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 101);
            this.panel2.TabIndex = 5;
            // 
            // btn_resetToDefaultsQuizSavePath
            // 
            this.btn_resetToDefaultsQuizSavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_resetToDefaultsQuizSavePath.FlatAppearance.BorderSize = 0;
            this.btn_resetToDefaultsQuizSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetToDefaultsQuizSavePath.Location = new System.Drawing.Point(505, 69);
            this.btn_resetToDefaultsQuizSavePath.Name = "btn_resetToDefaultsQuizSavePath";
            this.btn_resetToDefaultsQuizSavePath.Size = new System.Drawing.Size(127, 23);
            this.btn_resetToDefaultsQuizSavePath.TabIndex = 5;
            this.btn_resetToDefaultsQuizSavePath.Text = "Reset to defaults";
            this.btn_resetToDefaultsQuizSavePath.UseVisualStyleBackColor = false;
            this.btn_resetToDefaultsQuizSavePath.Click += new System.EventHandler(this.btn_resetToDefaultsQuizSavePath_Click);
            // 
            // btn_browseDefaultQuizSavePath
            // 
            this.btn_browseDefaultQuizSavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_browseDefaultQuizSavePath.FlatAppearance.BorderSize = 0;
            this.btn_browseDefaultQuizSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browseDefaultQuizSavePath.Location = new System.Drawing.Point(557, 40);
            this.btn_browseDefaultQuizSavePath.Name = "btn_browseDefaultQuizSavePath";
            this.btn_browseDefaultQuizSavePath.Size = new System.Drawing.Size(75, 23);
            this.btn_browseDefaultQuizSavePath.TabIndex = 3;
            this.btn_browseDefaultQuizSavePath.Text = "...";
            this.btn_browseDefaultQuizSavePath.UseVisualStyleBackColor = false;
            this.btn_browseDefaultQuizSavePath.Click += new System.EventHandler(this.btn_browseDefaultQuizSavePath_Click);
            // 
            // txt_defaultQuizSaveFolder
            // 
            this.txt_defaultQuizSaveFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_defaultQuizSaveFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_defaultQuizSaveFolder.Location = new System.Drawing.Point(15, 40);
            this.txt_defaultQuizSaveFolder.Name = "txt_defaultQuizSaveFolder";
            this.txt_defaultQuizSaveFolder.Size = new System.Drawing.Size(536, 23);
            this.txt_defaultQuizSaveFolder.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Default Quiz Save Folder Path";
            // 
            // fbd_defaultQuizSaveFolder
            // 
            this.fbd_defaultQuizSaveFolder.Description = "Select the folder that should be the default folder for saving quizzes in";
            // 
            // PrefsStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "PrefsStorage";
            this.Size = new System.Drawing.Size(652, 450);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_quizProgPath;
        private System.Windows.Forms.Button btn_browseQuizProgPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd_quizProgFolder;
        private System.Windows.Forms.Button btn_resetToDefaultsProgressData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_resetToDefaultsQuizSavePath;
        private System.Windows.Forms.Button btn_browseDefaultQuizSavePath;
        private System.Windows.Forms.TextBox txt_defaultQuizSaveFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fbd_defaultQuizSaveFolder;
    }
}
