namespace SteelQuiz.Preferences
{
    partial class CategoriesSync
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
            this.pcat_progSync = new SteelQuiz.PrefCategoryItem();
            this.pcat_quizFolders = new SteelQuiz.PrefCategoryItem();
            this.SuspendLayout();
            // 
            // pcat_progSync
            // 
            this.pcat_progSync.Location = new System.Drawing.Point(0, 83);
            this.pcat_progSync.Name = "pcat_progSync";
            this.pcat_progSync.PrefText = "Progress Sync";
            this.pcat_progSync.Selectable = true;
            this.pcat_progSync.Selected = false;
            this.pcat_progSync.Size = new System.Drawing.Size(130, 29);
            this.pcat_progSync.TabIndex = 1;
            // 
            // pcat_quizFolders
            // 
            this.pcat_quizFolders.Location = new System.Drawing.Point(0, 48);
            this.pcat_quizFolders.Name = "pcat_quizFolders";
            this.pcat_quizFolders.PrefText = "Quiz Folders";
            this.pcat_quizFolders.Selectable = true;
            this.pcat_quizFolders.Selected = true;
            this.pcat_quizFolders.Size = new System.Drawing.Size(130, 29);
            this.pcat_quizFolders.TabIndex = 0;
            this.pcat_quizFolders.OnPrefSelected += new System.EventHandler(this.Pcat_quizFolders_OnPrefSelected);
            // 
            // CategoriesSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pcat_progSync);
            this.Controls.Add(this.pcat_quizFolders);
            this.IsSubCategory = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CategoriesSync";
            this.Size = new System.Drawing.Size(130, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private PrefCategoryItem pcat_quizFolders;
        private PrefCategoryItem pcat_progSync;
    }
}
