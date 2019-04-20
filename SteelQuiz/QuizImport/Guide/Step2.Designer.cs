namespace SteelQuiz.QuizImport.Guide
{
    partial class Step2
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
            this.txt_lang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_words = new System.Windows.Forms.ListBox();
            this.lbl_question = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_lang
            // 
            this.txt_lang.Location = new System.Drawing.Point(145, 334);
            this.txt_lang.Name = "txt_lang";
            this.txt_lang.Size = new System.Drawing.Size(618, 20);
            this.txt_lang.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Language (in English):";
            // 
            // lst_words
            // 
            this.lst_words.FormattingEnabled = true;
            this.lst_words.Location = new System.Drawing.Point(2, 55);
            this.lst_words.Name = "lst_words";
            this.lst_words.Size = new System.Drawing.Size(761, 277);
            this.lst_words.TabIndex = 6;
            this.lst_words.TabStop = false;
            // 
            // lbl_question
            // 
            this.lbl_question.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.Location = new System.Drawing.Point(3, 9);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(775, 43);
            this.lbl_question.TabIndex = 4;
            this.lbl_question.Text = "Which language are the following words written in?";
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_lang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_words);
            this.Controls.Add(this.lbl_question);
            this.Name = "Step2";
            this.Size = new System.Drawing.Size(766, 364);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_lang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_words;
        private System.Windows.Forms.Label lbl_question;
    }
}
