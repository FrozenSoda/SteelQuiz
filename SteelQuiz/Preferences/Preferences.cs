using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Preferences
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void Apply()
        {
            throw new NotImplementedException();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            Apply();
            DialogResult = DialogResult.OK;
        }

        private void Prefs_UI_OnPrefSelected(object sender, EventArgs e)
        {

        }
    }
}
