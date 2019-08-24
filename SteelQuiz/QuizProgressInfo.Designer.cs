namespace SteelQuiz
{
    partial class QuizProgressInfo
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
            this.btn_practiseQuiz = new System.Windows.Forms.Button();
            this.btn_editQuiz = new System.Windows.Forms.Button();
            this.btn_deleteQuiz = new System.Windows.Forms.Button();
            this.lbl_quizNameHere = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_practiseQuiz
            // 
            this.btn_practiseQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_practiseQuiz.FlatAppearance.BorderSize = 0;
            this.btn_practiseQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_practiseQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_practiseQuiz.Location = new System.Drawing.Point(398, 306);
            this.btn_practiseQuiz.Name = "btn_practiseQuiz";
            this.btn_practiseQuiz.Size = new System.Drawing.Size(185, 45);
            this.btn_practiseQuiz.TabIndex = 0;
            this.btn_practiseQuiz.Text = "Practise Quiz";
            this.btn_practiseQuiz.UseVisualStyleBackColor = false;
            // 
            // btn_editQuiz
            // 
            this.btn_editQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_editQuiz.FlatAppearance.BorderSize = 0;
            this.btn_editQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editQuiz.Location = new System.Drawing.Point(207, 306);
            this.btn_editQuiz.Name = "btn_editQuiz";
            this.btn_editQuiz.Size = new System.Drawing.Size(185, 45);
            this.btn_editQuiz.TabIndex = 1;
            this.btn_editQuiz.Text = "Edit Quiz";
            this.btn_editQuiz.UseVisualStyleBackColor = false;
            // 
            // btn_deleteQuiz
            // 
            this.btn_deleteQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_deleteQuiz.FlatAppearance.BorderSize = 0;
            this.btn_deleteQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteQuiz.ForeColor = System.Drawing.Color.LightCoral;
            this.btn_deleteQuiz.Location = new System.Drawing.Point(3, 306);
            this.btn_deleteQuiz.Name = "btn_deleteQuiz";
            this.btn_deleteQuiz.Size = new System.Drawing.Size(185, 45);
            this.btn_deleteQuiz.TabIndex = 2;
            this.btn_deleteQuiz.Text = "Delete Quiz";
            this.btn_deleteQuiz.UseVisualStyleBackColor = false;
            // 
            // lbl_quizNameHere
            // 
            this.lbl_quizNameHere.AutoSize = true;
            this.lbl_quizNameHere.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quizNameHere.Location = new System.Drawing.Point(3, 19);
            this.lbl_quizNameHere.Name = "lbl_quizNameHere";
            this.lbl_quizNameHere.Size = new System.Drawing.Size(154, 25);
            this.lbl_quizNameHere.TabIndex = 3;
            this.lbl_quizNameHere.Text = "Quiz Name Here";
            // 
            // QuizProgressInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.lbl_quizNameHere);
            this.Controls.Add(this.btn_deleteQuiz);
            this.Controls.Add(this.btn_editQuiz);
            this.Controls.Add(this.btn_practiseQuiz);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QuizProgressInfo";
            this.Size = new System.Drawing.Size(586, 354);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_practiseQuiz;
        private System.Windows.Forms.Button btn_editQuiz;
        private System.Windows.Forms.Button btn_deleteQuiz;
        private System.Windows.Forms.Label lbl_quizNameHere;
    }
}
