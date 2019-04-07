using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizEditor.UndoRedo;

namespace SteelQuiz.QuizEditor
{
    public partial class EditWordSynonyms : Form, IUndoRedo
    {
        public string[] Synonyms { get; set; }
        private new QuizEditorWord Parent { get; set; }

        private bool changedTextBox = false; // since listbox select switch

        public EditWordSynonyms(QuizEditorWord parent, string word, string[] currentSynonyms)
        {
            InitializeComponent();
            Parent = parent;
            lbl_synForWord.Text = $"Synonyms for word: {word}";

            if (currentSynonyms != null)
            {
                foreach (var synonym in currentSynonyms)
                {
                    lst_synonyms.Items.Add(synonym);
                }
            }
        }

        public void ApplyChanges()
        {
            Synonyms = lst_synonyms.Items.OfType<string>().ToArray();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
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

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { lst_synonyms.RemoveItemChild(this.Parent, lst_synonyms.Name, txt_wordAdd.Text) },
                new Func<object>[] { lst_synonyms.AddItemChild(this.Parent, lst_synonyms.Name, txt_wordAdd.Text) },
                new OwnerControlData(this, this.Parent)));
            
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

                undoes.Add(lst_synonyms.ChangeItemChild(this.Parent, lst_synonyms.Name, old, _new));
                redoes.Add(lst_synonyms.ChangeItemChild(this.Parent, lst_synonyms.Name, _new, old));
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), new OwnerControlData(this, this.Parent)));

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

                undoes.Add(lst_synonyms.AddItemChild(this.Parent, lst_synonyms.Name, item));
                redoes.Add(lst_synonyms.RemoveItemChild(this.Parent, lst_synonyms.Name, item));
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), new OwnerControlData(this, this.Parent)));
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

        public void Undo()
        {
            if (Program.frmQuizEditor.UndoStack.Count > 0)
            {
                var pop = Program.frmQuizEditor.UndoStack.Pop();
                foreach (var undo in pop.UndoActions)
                {
                    undo();
                }
                Program.frmQuizEditor.RedoStack.Push(pop);
            }
        }

        public void Redo()
        {
            if (Program.frmQuizEditor.RedoStack.Count > 0)
            {
                var pop = Program.frmQuizEditor.RedoStack.Pop();
                foreach (var redo in pop.RedoActions)
                {
                    redo();
                }
                Program.frmQuizEditor.UndoStack.Push(pop);
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