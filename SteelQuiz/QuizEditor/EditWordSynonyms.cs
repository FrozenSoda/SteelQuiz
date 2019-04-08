/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
        public List<string> Synonyms { get; set; }
        public int Language { get; set; }

        private new QuizEditorWordPair Parent { get; set; }
        private QuizEditor QEOwner => Parent.QEOwner;

        private bool changedTextBox = false; // since listbox select switch
        private object[] initialListBoxCollection;
        private bool closeWarning = true;

        public EditWordSynonyms(QuizEditorWordPair parent, string word, List<string> currentSynonyms, int language)
        {
            InitializeComponent();
            Parent = parent;
            Language = language;
            lbl_synForWord.Text = $"Synonyms for word: {word}";

            if (currentSynonyms != null)
            {
                foreach (var synonym in currentSynonyms)
                {
                    lst_synonyms.Items.Add(synonym);
                }
            }

            initialListBoxCollection = new object[lst_synonyms.Items.Count];
            lst_synonyms.Items.CopyTo(initialListBoxCollection, 0);
        }

        private bool ListBoxChanged()
        {
            object[] currentListBoxCollection = new object[lst_synonyms.Items.Count];
            lst_synonyms.Items.CopyTo(currentListBoxCollection, 0);

            return !currentListBoxCollection.SequenceEqual(initialListBoxCollection);
        }

        public void ApplyChanges()
        {
            Synonyms = lst_synonyms.Items.OfType<string>().ToList();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (txt_wordAdd.Text != "")
            {
                var msg = MessageBox.Show("Warning! The textbox contains text not added to the list. Add it to the list and exit?", "SteelQuiz",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    AddSynonym();
                }
                else if (msg == DialogResult.Cancel)
                {
                    return;
                }
            }

            ApplyChanges();
            closeWarning = false;
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (!ListBoxChanged() || MessageBox.Show("Are you sure you want to cancel? The changes will not be applied", "SteelQuiz", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                closeWarning = false;
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddSynonym();
        }

        private void AddSynonym()
        {
            if (lst_synonyms.Items.Contains(txt_wordAdd.Text))
            {
                MessageBox.Show("Duplicates are not allowed", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_wordAdd.Text.StartsWith(" ") || txt_wordAdd.Text.EndsWith(" "))
            {
                var msg = MessageBox.Show("The text contains whitespace in the beginning/end. Remove this whitespace (trim the text)?"
                    + "\r\n\r\nThis is strongly recommended if you did not intend this",
                    "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    txt_wordAdd.Text = txt_wordAdd.Text.Trim();
                }
                else if (msg == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (txt_wordAdd.Text.Contains("  "))
            {
                var msg = MessageBox.Show("The text contains double-/multispaces. Replace the double-/multispaces with single spaces?" +
                    "\r\n\r\nThis is strongly recommended if you did not intend this", "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    while (txt_wordAdd.Text.Contains("  "))
                    {
                        txt_wordAdd.Text = txt_wordAdd.Text.Replace("  ", " ");
                    }
                }
                else if (msg == DialogResult.Cancel)
                {
                    return;
                }
            }

            lst_synonyms.Items.Add(txt_wordAdd.Text);

            QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { lst_synonyms.RemoveItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, txt_wordAdd.Text) },
                new Func<object>[] { lst_synonyms.AddItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, txt_wordAdd.Text) },
                new OwnerControlData(this, this.Parent, Language)));

            txt_wordAdd.Text = "";
            changedTextBox = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (lst_synonyms.Items.Contains(txt_wordAdd.Text))
            {
                MessageBox.Show("Duplicates are not allowed", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_wordAdd.Text.StartsWith(" ") || txt_wordAdd.Text.EndsWith(" "))
            {
                var msg = MessageBox.Show("The text contains whitespace in the beginning/end. Remove this whitespace (trim the text)?"
                    + "\r\n\r\nThis is strongly recommended if you did not intend this",
                    "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    txt_wordAdd.Text = txt_wordAdd.Text.Trim();
                }
                else if (msg == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (txt_wordAdd.Text.Contains("  "))
            {
                var msg = MessageBox.Show("The text contains double-/multispaces. Replace the double-/multispaces with single spaces?" +
                    "\r\n\r\nThis is strongly recommended if you did not intend this", "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    while (txt_wordAdd.Text.Contains("  "))
                    {
                        txt_wordAdd.Text = txt_wordAdd.Text.Replace("  ", " ");
                    }
                }
                else if (msg == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (lst_synonyms.SelectedItems.Count == 0)
            {
                return;
            }

            if (lst_synonyms.SelectedItems.Count > 1)
            {
                MessageBox.Show("Only one item can be updated as duplicates are not allowed", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                undoes.Add(lst_synonyms.ChangeItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, old, _new));
                redoes.Add(lst_synonyms.ChangeItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, _new, old));
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), new OwnerControlData(this, this.Parent, Language)));

            txt_wordAdd.Text = "";
            changedTextBox = false;
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

                undoes.Add(lst_synonyms.AddItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, item));
                redoes.Add(lst_synonyms.RemoveItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, item));
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), new OwnerControlData(this, this.Parent, Language)));
        }

        private void lst_synonyms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!changedTextBox || txt_wordAdd.Text.Length == 0))
            {
                if (lst_synonyms.SelectedItems.Count == 1)
                {
                    // only update textbox if only one item is selected, and the textbox hasn't been changed since last selection
                    txt_wordAdd.Text = (string)lst_synonyms.Items[lst_synonyms.SelectedIndex];
                }
                else if (lst_synonyms.SelectedItems.Count == 0)
                {
                    // clear textbox if no items are left in the list, and the textbox hasn't been changed since last selection
                    txt_wordAdd.Text = "";
                }
            }

            if (lst_synonyms.SelectedItems.Count > 0)
            {
                btn_update.Enabled = true;
                btn_remove.Enabled = true;
            }
            else
            {
                btn_update.Enabled = false;
                btn_remove.Enabled = false;
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
                if (pop.OwnerControlData.Control != this)
                {
                    // do not allow undoing stuff outside this window
                    return;
                }

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
                if (pop.OwnerControlData.Control != this)
                {
                    // do not allow redoing stuff outside this window
                    return;
                }

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

        private void EditWordSynonyms_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeWarning || !ListBoxChanged())
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel? The changes will not be applied", "SteelQuiz", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}