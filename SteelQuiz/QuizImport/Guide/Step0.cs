using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizImport.Guide
{
    public partial class Step0 : UserControl, IStep
    {
        private const int STEP_NUMBER = 0;

        public Step0()
        {
            InitializeComponent();
        }

        public int GetStepNumber()
        {
            return STEP_NUMBER;
        }

        private void btn_urlHowToFind_Click(object sender, EventArgs e)
        {
            if (rdo_studentlitteratur.Checked)
            {
                MessageBox.Show("1. Start the exercise.\r\n2. Open developer tools in your browser (Ctrl+Shift+I in Chrome).\r\n" +
                    "3. Go to the Network tab.\r\n4. Write one word in the exercise and press ENTER.\r\n5. Double click the entry which appeared in the Network tab." +
                    "\r\n6. Copy the URL of the opened tab and paste it in the URL field in SteelQuiz.", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Rdo_addMultipleTranslationsAsSynonyms_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_addMultipleTranslationsAsSynonyms.Checked)
            {
                var msg = MessageBox.Show("Warning! If this option is selected, you will not necessarily learn all the synonyms of the words (which are added" +
                    " to the quiz). Continue?",
                    "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                {
                    rdo_addMultipleTranslationsAsSynonyms.Checked = false;
                    rdo_multipleTranslationsAsDifferentWordPairs.Checked = true;
                }
            }
        }

        private void Txt_url_DoubleClick(object sender, EventArgs e)
        {
            txt_url.Text = "";
        }
    }
}
