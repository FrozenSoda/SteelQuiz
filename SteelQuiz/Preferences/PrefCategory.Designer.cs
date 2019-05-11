namespace SteelQuiz
{
    partial class PrefCategory
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
            this.lbl_text = new System.Windows.Forms.Label();
            this.lbl_selectedIndicator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbl_text.ForeColor = System.Drawing.Color.White;
            this.lbl_text.Location = new System.Drawing.Point(8, 0);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(122, 29);
            this.lbl_text.TabIndex = 3;
            this.lbl_text.Text = "User Interface";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_selectedIndicator
            // 
            this.lbl_selectedIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbl_selectedIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_selectedIndicator.Location = new System.Drawing.Point(0, 0);
            this.lbl_selectedIndicator.Name = "lbl_selectedIndicator";
            this.lbl_selectedIndicator.Size = new System.Drawing.Size(8, 29);
            this.lbl_selectedIndicator.TabIndex = 2;
            // 
            // PrefCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.lbl_selectedIndicator);
            this.Name = "PrefCategory";
            this.Size = new System.Drawing.Size(130, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label lbl_selectedIndicator;
    }
}
