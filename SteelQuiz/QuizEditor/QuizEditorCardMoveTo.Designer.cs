namespace SteelQuiz.QuizEditor
{
    partial class QuizEditorCardMoveTo
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_currentIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_newIndex = new System.Windows.Forms.NumericUpDown();
            this.btn_move = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_newIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current index:";
            // 
            // lbl_currentIndex
            // 
            this.lbl_currentIndex.AutoSize = true;
            this.lbl_currentIndex.Location = new System.Drawing.Point(107, 9);
            this.lbl_currentIndex.Name = "lbl_currentIndex";
            this.lbl_currentIndex.Size = new System.Drawing.Size(20, 17);
            this.lbl_currentIndex.TabIndex = 1;
            this.lbl_currentIndex.Text = "-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "New index:";
            // 
            // nud_newIndex
            // 
            this.nud_newIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.nud_newIndex.ForeColor = System.Drawing.Color.White;
            this.nud_newIndex.Location = new System.Drawing.Point(110, 33);
            this.nud_newIndex.Name = "nud_newIndex";
            this.nud_newIndex.Size = new System.Drawing.Size(194, 25);
            this.nud_newIndex.TabIndex = 3;
            // 
            // btn_move
            // 
            this.btn_move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_move.FlatAppearance.BorderSize = 0;
            this.btn_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_move.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_move.Location = new System.Drawing.Point(196, 72);
            this.btn_move.Name = "btn_move";
            this.btn_move.Size = new System.Drawing.Size(108, 30);
            this.btn_move.TabIndex = 4;
            this.btn_move.Text = "Move";
            this.btn_move.UseVisualStyleBackColor = false;
            this.btn_move.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(12, 72);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // QuizEditorCardMoveTo
            // 
            this.AcceptButton = this.btn_move;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(316, 114);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_move);
            this.Controls.Add(this.nud_newIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_currentIndex);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuizEditorCardMoveTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move Card";
            ((System.ComponentModel.ISupportInitialize)(this.nud_newIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_currentIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_newIndex;
        private System.Windows.Forms.Button btn_move;
        private System.Windows.Forms.Button btn_cancel;
    }
}