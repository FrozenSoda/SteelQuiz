namespace SteelQuiz.Preferences
{
    partial class CategoriesRoot
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
            this.prefs_updates = new SteelQuiz.PrefCategory();
            this.prefs_UI = new SteelQuiz.PrefCategory();
            this.SuspendLayout();
            // 
            // prefs_updates
            // 
            this.prefs_updates.Location = new System.Drawing.Point(0, 38);
            this.prefs_updates.Name = "prefs_updates";
            this.prefs_updates.PrefText = "Maintenance";
            this.prefs_updates.Selected = false;
            this.prefs_updates.Size = new System.Drawing.Size(130, 29);
            this.prefs_updates.TabIndex = 13;
            this.prefs_updates.OnPrefSelected += new System.EventHandler(this.Prefs_updates_OnPrefSelected);
            // 
            // prefs_UI
            // 
            this.prefs_UI.Location = new System.Drawing.Point(0, 3);
            this.prefs_UI.Name = "prefs_UI";
            this.prefs_UI.PrefText = "General";
            this.prefs_UI.Selected = true;
            this.prefs_UI.Size = new System.Drawing.Size(130, 29);
            this.prefs_UI.TabIndex = 12;
            this.prefs_UI.OnPrefSelected += new System.EventHandler(this.Prefs_UI_OnPrefSelected);
            // 
            // CategoriesRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.prefs_updates);
            this.Controls.Add(this.prefs_UI);
            this.Name = "CategoriesRoot";
            this.Size = new System.Drawing.Size(130, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private PrefCategory prefs_updates;
        private PrefCategory prefs_UI;
    }
}
