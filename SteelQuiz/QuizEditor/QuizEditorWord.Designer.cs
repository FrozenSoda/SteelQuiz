namespace SteelQuiz
{
    partial class QuizEditorWord
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
            this.pnl_translationRules = new System.Windows.Forms.Panel();
            this.chk_ignoreExcl = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_ignoreCapitalization = new System.Windows.Forms.CheckBox();
            this.txt_word = new System.Windows.Forms.TextBox();
            this.btn_editSynonyms = new System.Windows.Forms.Button();
            this.pnl_translationRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_translationRules
            // 
            this.pnl_translationRules.Controls.Add(this.chk_ignoreExcl);
            this.pnl_translationRules.Controls.Add(this.label4);
            this.pnl_translationRules.Controls.Add(this.chk_ignoreCapitalization);
            this.pnl_translationRules.Location = new System.Drawing.Point(3, 29);
            this.pnl_translationRules.Name = "pnl_translationRules";
            this.pnl_translationRules.Size = new System.Drawing.Size(279, 65);
            this.pnl_translationRules.TabIndex = 2;
            this.pnl_translationRules.Visible = false;
            // 
            // chk_ignoreExcl
            // 
            this.chk_ignoreExcl.AutoSize = true;
            this.chk_ignoreExcl.Location = new System.Drawing.Point(129, 22);
            this.chk_ignoreExcl.Name = "chk_ignoreExcl";
            this.chk_ignoreExcl.Size = new System.Drawing.Size(146, 17);
            this.chk_ignoreExcl.TabIndex = 2;
            this.chk_ignoreExcl.TabStop = false;
            this.chk_ignoreExcl.Text = "Ignore exclamation marks";
            this.chk_ignoreExcl.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Translation rules";
            // 
            // chk_ignoreCapitalization
            // 
            this.chk_ignoreCapitalization.AutoSize = true;
            this.chk_ignoreCapitalization.Location = new System.Drawing.Point(3, 22);
            this.chk_ignoreCapitalization.Name = "chk_ignoreCapitalization";
            this.chk_ignoreCapitalization.Size = new System.Drawing.Size(120, 17);
            this.chk_ignoreCapitalization.TabIndex = 0;
            this.chk_ignoreCapitalization.TabStop = false;
            this.chk_ignoreCapitalization.Text = "Ignore capitalization";
            this.chk_ignoreCapitalization.UseVisualStyleBackColor = true;
            // 
            // txt_word
            // 
            this.txt_word.Location = new System.Drawing.Point(3, 3);
            this.txt_word.Name = "txt_word";
            this.txt_word.Size = new System.Drawing.Size(359, 20);
            this.txt_word.TabIndex = 0;
            this.txt_word.TextChanged += new System.EventHandler(this.txt_word_TextChanged);
            // 
            // btn_editSynonyms
            // 
            this.btn_editSynonyms.Location = new System.Drawing.Point(287, 29);
            this.btn_editSynonyms.Name = "btn_editSynonyms";
            this.btn_editSynonyms.Size = new System.Drawing.Size(75, 39);
            this.btn_editSynonyms.TabIndex = 4;
            this.btn_editSynonyms.TabStop = false;
            this.btn_editSynonyms.Text = "Edit synonyms";
            this.btn_editSynonyms.UseVisualStyleBackColor = true;
            this.btn_editSynonyms.Click += new System.EventHandler(this.btn_editSynonyms_Click);
            // 
            // QuizEditorWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_editSynonyms);
            this.Controls.Add(this.txt_word);
            this.Controls.Add(this.pnl_translationRules);
            this.Name = "QuizEditorWord";
            this.Size = new System.Drawing.Size(365, 97);
            this.pnl_translationRules.ResumeLayout(false);
            this.pnl_translationRules.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_translationRules;
        internal System.Windows.Forms.CheckBox chk_ignoreExcl;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox chk_ignoreCapitalization;
        internal System.Windows.Forms.TextBox txt_word;
        private System.Windows.Forms.Button btn_editSynonyms;
    }
}
