namespace SteelQuiz.QuizImport.Guide
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
            this.btn_select = new System.Windows.Forms.Button();
            this.fbd_path = new System.Windows.Forms.FolderBrowserDialog();
            this.lbl_folderPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_select
            // 
            this.btn_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_select.FlatAppearance.BorderSize = 0;
            this.btn_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_select.ForeColor = System.Drawing.Color.White;
            this.btn_select.Location = new System.Drawing.Point(453, 71);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(124, 23);
            this.btn_select.TabIndex = 4;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = false;
            // 
            // fbd_path
            // 
            this.fbd_path.Description = "Select a folder to add as a quiz folder. The folder should ONLY contain quizzes";
            // 
            // lbl_folderPath
            // 
            this.lbl_folderPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_folderPath.Location = new System.Drawing.Point(4, 4);
            this.lbl_folderPath.Name = "lbl_folderPath";
            this.lbl_folderPath.Size = new System.Drawing.Size(573, 49);
            this.lbl_folderPath.TabIndex = 5;
            this.lbl_folderPath.Text = "C:\\Users\\user\\AppData\\Roaming\\SteelQuiz\\Quizzes";
            this.lbl_folderPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuizFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.lbl_folderPath);
            this.Controls.Add(this.btn_select);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizFolder";
            this.Size = new System.Drawing.Size(580, 111);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.FolderBrowserDialog fbd_path;
        private System.Windows.Forms.Label lbl_folderPath;
    }
}
