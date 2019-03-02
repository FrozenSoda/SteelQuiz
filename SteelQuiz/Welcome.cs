using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frmInQuiz = new InQuiz();
            frmInQuiz.Show();
        }

        private void btn_importQuizFromSite_Click(object sender, EventArgs e)
        {
            var import = new ImportQuizFromSite();
            if (import.ShowDialog() == DialogResult.OK)
            {
                var inQuiz = new InQuiz();
                inQuiz.Show();
                Hide();
            }
        }
    }
}
