using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizEditorCardMoveTo : Form
    {
        public int NewIndex => (int)nud_newIndex.Value;

        public QuizEditorCardMoveTo(int currentIndex, int maxIndex)
        {
            InitializeComponent();

            lbl_currentIndex.Text = currentIndex.ToString();
            nud_newIndex.Minimum = 0;
            nud_newIndex.Maximum = maxIndex;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_move_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
