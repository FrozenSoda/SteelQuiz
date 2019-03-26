namespace SteelQuiz
{
    partial class TermsOfUse
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermsOfUse));
            this.lbl_notice = new System.Windows.Forms.Label();
            this.rtb_license = new System.Windows.Forms.RichTextBox();
            this.btn_agree = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.timer_agree_unlock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_notice
            // 
            this.lbl_notice.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notice.Location = new System.Drawing.Point(12, 9);
            this.lbl_notice.Name = "lbl_notice";
            this.lbl_notice.Size = new System.Drawing.Size(776, 57);
            this.lbl_notice.TabIndex = 0;
            this.lbl_notice.Text = "Welcome! To use this software, you must agree to the terms of use";
            this.lbl_notice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtb_license
            // 
            this.rtb_license.Location = new System.Drawing.Point(16, 69);
            this.rtb_license.Name = "rtb_license";
            this.rtb_license.ReadOnly = true;
            this.rtb_license.Size = new System.Drawing.Size(772, 340);
            this.rtb_license.TabIndex = 1;
            this.rtb_license.Text = resources.GetString("rtb_license.Text");
            // 
            // btn_agree
            // 
            this.btn_agree.Enabled = false;
            this.btn_agree.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agree.Location = new System.Drawing.Point(647, 415);
            this.btn_agree.Name = "btn_agree";
            this.btn_agree.Size = new System.Drawing.Size(141, 23);
            this.btn_agree.TabIndex = 2;
            this.btn_agree.Text = "I agree";
            this.btn_agree.UseVisualStyleBackColor = true;
            this.btn_agree.Click += new System.EventHandler(this.btn_agree_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(16, 415);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // timer_agree_unlock
            // 
            this.timer_agree_unlock.Enabled = true;
            this.timer_agree_unlock.Interval = 1000;
            this.timer_agree_unlock.Tick += new System.EventHandler(this.timer_agree_unlock_Tick);
            // 
            // TermsOfUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_agree);
            this.Controls.Add(this.rtb_license);
            this.Controls.Add(this.lbl_notice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TermsOfUse";
            this.Text = "SteelQuiz | Experimental alpha";
            this.Load += new System.EventHandler(this.TermsOfUse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_notice;
        private System.Windows.Forms.RichTextBox rtb_license;
        private System.Windows.Forms.Button btn_agree;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Timer timer_agree_unlock;
    }
}