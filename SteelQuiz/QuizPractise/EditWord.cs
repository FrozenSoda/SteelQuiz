using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizPractise
{
    public partial class EditWord : Form
    {
        public string Word { get; set; }

        public EditWord(string word)
        {
            InitializeComponent();
            label1.Text = $"Enter new value for word '{word}':";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_word.Text == "")
            {
                MessageBox.Show("Word cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Word = txt_word.Text;
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
