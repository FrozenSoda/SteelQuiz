using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.UndoRedo;

namespace SteelQuiz
{
    public partial class EditWordSynonyms : Form
    {
        public string[] Synonyms { get; set; }

        private Stack<UndoRedoFuncPair> undoStack = new Stack<UndoRedoFuncPair>();
        private Stack<UndoRedoFuncPair> redoStack = new Stack<UndoRedoFuncPair>();

        private bool changedTextBox = false; // since listbox select switch

        public EditWordSynonyms(string word, string[] currentSynonyms)
        {
            InitializeComponent();
            lbl_synForWord.Text = $"Synonyms for word: {word}";

            if (currentSynonyms != null)
            {
                foreach (var synonym in currentSynonyms)
                {
                    lst_synonyms.Items.Add(synonym);
                }
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            Synonyms = lst_synonyms.Items.OfType<string>().ToArray();
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel? The changes will not be applied", "SteelQuiz", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            lst_synonyms.Items.Add(txt_wordAdd.Text);

            undoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { lst_synonyms.RemoveItem(txt_wordAdd.Text) },
                new Func<object>[] { lst_synonyms.AddItem(txt_wordAdd.Text) }));

            txt_wordAdd.Text = "";
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var toUpdate = new List<object>();

            for (int i = 0; i < lst_synonyms.SelectedItems.Count; ++i)
            {
                toUpdate.Add(lst_synonyms.SelectedItems[i]);
            }

            var undoes = new List<Func<object>>();
            var redoes = new List<Func<object>>();

            foreach (var item in toUpdate)
            {
                var old = lst_synonyms.Items[lst_synonyms.Items.IndexOf(item)];
                var _new = txt_wordAdd.Text;

                lst_synonyms.Items[lst_synonyms.Items.IndexOf(item)] = _new;

                undoes.Add(lst_synonyms.ChangeItem(old, _new));
                redoes.Add(lst_synonyms.ChangeItem(_new, old));
            }

            undoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray()));

            txt_wordAdd.Text = "";
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            var toRemove = new List<object>();

            for (int i = 0; i < lst_synonyms.SelectedItems.Count; ++i)
            {
                toRemove.Add(lst_synonyms.SelectedItems[i]);
            }

            var undoes = new List<Func<object>>();
            var redoes = new List<Func<object>>();

            foreach (var item in toRemove)
            {
                lst_synonyms.Items.Remove(item);

                undoes.Add(lst_synonyms.AddItem(item));
                redoes.Add(lst_synonyms.RemoveItem(item));
            }

            undoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray()));
        }

        private void lst_synonyms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!changedTextBox || txt_wordAdd.Text.Length == 0) && lst_synonyms.SelectedItems.Count == 1)
            {
                // only update textbox if only one item is selected, and the textbox hasn't been changed since last selection
                txt_wordAdd.Text = (string)lst_synonyms.Items[lst_synonyms.SelectedIndex];
            }
        }

        private void txt_wordAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            changedTextBox = true;
        }

        private void lst_synonyms_DoubleClick(object sender, EventArgs e)
        {
            if (lst_synonyms.SelectedItems.Count == 1)
            {
                // only update textbox if only one item is selected
                txt_wordAdd.Text = (string)lst_synonyms.Items[lst_synonyms.SelectedIndex];
                changedTextBox = false;
            }
        }

        private void Undo()
        {
            if (undoStack.Count > 0)
            {
                var pop = undoStack.Pop();
                foreach (var undo in pop.UndoActions)
                {
                    undo();
                }
                redoStack.Push(pop);
            }
        }

        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                var pop = redoStack.Pop();
                foreach (var redo in pop.RedoActions)
                {
                    redo();
                }
                undoStack.Push(pop);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }
    }
}