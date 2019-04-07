using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.UndoRedo;

namespace SteelQuiz
{
    public partial class QuizEditorWord : UserControl
    {
        public int Language { get; set; }
        public string Word => txt_word.Text;
        public string[] Synonyms { get; set; } = null;
        public EditWordSynonyms editWordSynonyms = null;

        public QuizEditorWord(bool showTranslationRulesOptions)
        {
            InitializeComponent();
            if (showTranslationRulesOptions)
            {
                pnl_translationRules.Visible = true;
                Language = 1;
            }
            else
            {
                Language = 2;
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

        private string txt_word_text_old = "";

        private void txt_word_TextChanged(object sender, EventArgs e)
        {
            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { txt_word.ChangeText(txt_word_text_old) },
                new Func<object>[] { txt_word.ChangeText(txt_word.Text) },
                this));

            txt_word_text_old = txt_word.Text;
        }
    }
}
