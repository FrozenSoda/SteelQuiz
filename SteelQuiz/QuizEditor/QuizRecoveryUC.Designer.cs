namespace SteelQuiz.QuizEditor
{
    partial class QuizRecoveryUC
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
            this.lbl_recoveryPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_recoveryPath
            // 
            this.lbl_recoveryPath.AutoSize = true;
            this.lbl_recoveryPath.Location = new System.Drawing.Point(14, 10);
            this.lbl_recoveryPath.Name = "lbl_recoveryPath";
            this.lbl_recoveryPath.Size = new System.Drawing.Size(80, 13);
            this.lbl_recoveryPath.TabIndex = 0;
            this.lbl_recoveryPath.Text = "Recovery path:";
            // 
            // QuizRecoveryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_recoveryPath);
            this.Name = "QuizRecoveryUC";
            this.Size = new System.Drawing.Size(548, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_recoveryPath;
    }
}
