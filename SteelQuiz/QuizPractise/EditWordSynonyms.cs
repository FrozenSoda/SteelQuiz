/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
using SteelQuiz.QuizData;
using SteelQuiz.QuizEditor.UndoRedo;

namespace SteelQuiz.QuizPractise
{
    public partial class EditWordSynonyms : AutoThemeableForm, IUndoRedo
    {
        public List<string> Synonyms { get; set; }
        public int Language { get; set; }

        private Stack<UndoRedoFuncPair> UndoStack { get; set; } = new Stack<UndoRedoFuncPair>();
        private Stack<UndoRedoFuncPair> RedoStack { get; set; } = new Stack<UndoRedoFuncPair>();

        private bool changedTextBox = false; // since listbox select switch
        private object[] initialListBoxCollection;
        private bool closeWarning = true;

        public EditWordSynonyms(Card wordPair, int language)
        {
            InitializeComponent();
            Language = language;
            if (Language == 1)
            {
                lbl_synForWord.Text = $"Synonyms for word: {wordPair.Front}";
            }
            else
            {
                lbl_synForWord.Text = $"Synonyms for word: {wordPair.Back}";
            }

            var currentSynonyms = language == 1 ? wordPair.FrontSynonyms : wordPair.BackSynonyms;
            if (currentSynonyms != null)
            {
                foreach (var synonym in currentSynonyms)
                {
                    lst_synonyms.Items.Add(synonym);
                }
            }

            initialListBoxCollection = new object[lst_synonyms.Items.Count];
            lst_synonyms.Items.CopyTo(initialListBoxCollection, 0);

            SetTheme();
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

            UndoStack.Push(new UndoRedoFuncPair(
                new Action[] { lst_synonyms.RemoveItem(txt_wordAdd.Text) },
                new Action[] { lst_synonyms.AddItem(txt_wordAdd.Text) },
                "Add synonym(s)",
                new OwnerControlData(this, this.Parent, Language)));
            UpdateUndoRedoTooltips();

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

            var undoes = new List<Action>();
            var redoes = new List<Action>();

            foreach (var item in toUpdate)
            {
                var old = lst_synonyms.Items[lst_synonyms.Items.IndexOf(item)];
                var _new = txt_wordAdd.Text;

                lst_synonyms.Items[lst_synonyms.Items.IndexOf(item)] = _new;

                undoes.Add(lst_synonyms.ChangeItem(old, _new));
                redoes.Add(lst_synonyms.ChangeItem(_new, old));
            }

            UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), "Update synonym(s)", new OwnerControlData(this, this.Parent, Language)));
            UpdateUndoRedoTooltips();

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

            var undoes = new List<Action>();
            var redoes = new List<Action>();

            foreach (var item in toRemove)
            {
                lst_synonyms.Items.Remove(item);

                undoes.Add(lst_synonyms.AddItem(item));
                redoes.Add(lst_synonyms.RemoveItem(item));
            }

            UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), "Remove synonym(s)", new OwnerControlData(this, this.Parent, Language)));
            UpdateUndoRedoTooltips();
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
            if (UndoStack.Count > 0)
            {
                var pop = UndoStack.Pop();
                if (pop.OwnerControlData.Control != this)
                {
                    // do not allow undoing stuff outside this window
                    return;
                }

                foreach (var undo in pop.UndoActions)
                {
                    undo();
                }
                RedoStack.Push(pop);
                UpdateUndoRedoTooltips();
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                var pop = RedoStack.Pop();
                if (pop.OwnerControlData.Control != this)
                {
                    // do not allow redoing stuff outside this window
                    return;
                }

                foreach (var redo in pop.RedoActions)
                {
                    redo();
                }
                UndoStack.Push(pop);
                UpdateUndoRedoTooltips();
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
            if (!closeWarning || (!ListBoxChanged() && (txt_wordAdd.Text == "" || lst_synonyms.Items.Contains(txt_wordAdd.Text))))
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

        private void txt_wordAdd_TextChanged(object sender, EventArgs e)
        {
            var duplicate = lst_synonyms.Items.Contains(txt_wordAdd.Text);
            btn_add.Enabled = txt_wordAdd.Text.Length > 0 && !duplicate;
        }

        public void UpdateUndoRedoTooltips()
        {
            if (UndoStack.Count > 0)
            {
                undoToolStripMenuItem.Text = $"Undo {UndoStack.Peek().Description}";
            }
            else
            {
                undoToolStripMenuItem.Text = "Undo";
            }

            if (RedoStack.Count > 0)
            {
                redoToolStripMenuItem.Text = $"Redo {RedoStack.Peek().Description}";
            }
            else
            {
                redoToolStripMenuItem.Text = "Redo";
            }
        }


        private void EditWordSynonyms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        e.Handled = true;
                        Undo();
                        break;

                    case Keys.Y:
                        e.Handled = true;
                        Redo();
                        break;
                }
            }
        }

        private void EditWordSynonyms_SizeChanged(object sender, EventArgs e)
        {
            lst_synonyms.Size = new Size(this.Size.Width - 43, this.Size.Height - 173);
        }
    }
}