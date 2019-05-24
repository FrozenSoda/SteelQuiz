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
            this.SuspendLayout();
            // 
            // txt_path
            // 
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.ForeColor = System.Drawing.Color.White;
            this.txt_path.Location = new System.Drawing.Point(3, 12);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(574, 22);
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
            this.btn_del.Size = new System.Drawing.Size(124, 23);
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
            this.btn_browse.Size = new System.Drawing.Size(124, 23);
            this.btn_browse.TabIndex = 4;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = false;
            this.btn_browse.Click += new System.EventHandler(this.Btn_browse_Click);
            // 
            // fbd_path
            // 
            this.fbd_path.Description = "Select a folder to add as a quiz folder. The folder should ONLY contain quizzes";
            // 
            // QuizFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.txt_path);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizFolder";
            this.Size = new System.Drawing.Size(580, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.FolderBrowserDialog fbd_path;
    }
}
