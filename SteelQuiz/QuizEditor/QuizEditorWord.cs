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
        public string[] Synonyms { get; set; } = null;

        private Stack<UndoRedoFuncPair> undoStack = new Stack<UndoRedoFuncPair>();
        private Stack<UndoRedoFuncPair> redoStack = new Stack<UndoRedoFuncPair>();

        public QuizEditorWord(bool showTranslationRulesOptions, ref Stack<UndoRedoFuncPair> _undoStack, ref Stack<UndoRedoFuncPair> _redoStack)
        {
            InitializeComponent();
            if (showTranslationRulesOptions)
            {
                pnl_translationRules.Visible = true;
            }
            undoStack = _undoStack;
            redoStack = _redoStack;
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
            undoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { txt_word.ChangeText(txt_word_text_old) },
                new Func<object>[] { txt_word.ChangeText(txt_word.Text) },
                this));

            txt_word_text_old = txt_word.Text;
        }
    }
}
