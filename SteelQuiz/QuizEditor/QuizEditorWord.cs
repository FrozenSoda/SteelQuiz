using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class QuizEditorWord : UserControl
    {
        public string[] Synonyms { get; set; } = null;

        public QuizEditorWord(bool showTranslationRulesOptions)
        {
            InitializeComponent();
            if (showTranslationRulesOptions)
            {
                pnl_translationRules.Visible = true;
            }
        }

        private void btn_editSynonyms_Click(object sender, EventArgs e)
        {
            var editSynonyms = new EditWordSynonyms(txt_word.Text, Synonyms);
            if (editSynonyms.ShowDialog() == DialogResult.OK)
            {
                Synonyms = editSynonyms.Synonyms;
            }
        }
    }
}
