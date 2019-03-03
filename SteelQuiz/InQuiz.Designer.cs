namespace SteelQuiz
{
    partial class InQuiz
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
            this.lbl_word1 = new System.Windows.Forms.Label();
            this.lbl_word2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_word1
            // 
            this.lbl_word1.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word1.Location = new System.Drawing.Point(12, 9);
            this.lbl_word1.Name = "lbl_word1";
            this.lbl_word1.Size = new System.Drawing.Size(331, 429);
            this.lbl_word1.TabIndex = 0;
            this.lbl_word1.Text = "lbl_word1";
            this.lbl_word1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_word2
            // 
            this.lbl_word2.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_word2.Location = new System.Drawing.Point(392, 12);
            this.lbl_word2.Name = "lbl_word2";
            this.lbl_word2.Size = new System.Drawing.Size(396, 429);
            this.lbl_word2.TabIndex = 1;
            this.lbl_word2.Text = "Enter your answer...";
            this.lbl_word2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_word2);
            this.Controls.Add(this.lbl_word1);
            this.KeyPreview = true;
            this.Name = "InQuiz";
            this.Text = "InQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InQuiz_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InQuiz_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_word1;
        private System.Windows.Forms.Label lbl_word2;
    }
}