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
using SteelQuiz.Extensions;
using SteelQuiz.QuizEditor.UndoRedo;

namespace SteelQuiz.QuizEditor
{
    public partial class EditCardSynonyms : AutoThemeableUndoRedoForm, IUndoRedo
    {
        public int Language { get; set; }
        public List<string> Synonyms
        {
            get
            {
                return Language == 1 ? Parent.FrontSynonyms : Parent.BackSynonyms;
            }

            set
            {
                if (Language == 1)
                {
                    Parent.FrontSynonyms = value;
                }
                else
                {
                    Parent.BackSynonyms = value;
                }
            }
        }

        private new QuizEditorCard Parent { get; set; }
        private QuizEditor QuizEditor => Parent.QuizEditor;

        private bool changedTextBox = false; // since listbox select switch
        private object[] initialListBoxCollection;
        private bool closeWarning = true;

        public EditCardSynonyms(QuizEditorCard parent, string cardText, int language)
        {
            InitializeComponent();
            Parent = parent;
            Language = language;
            lbl_synForPhrase.Text = $"Synonyms for: {cardText}";

            if (Synonyms != null)
            {
                foreach (var synonym in Synonyms)
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

        public bool ApplyChanges(bool ask = false)
        {
            if (ask)
            {
                var msg = MessageBox.Show("Apply changes to synonyms?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                {
                    return false;
                }
            }

            if (txt_synonymAdd.Text != "" && !lst_synonyms.Items.Contains(txt_synonymAdd.Text))
            {
                var msg = MessageBox.Show("Warning! The textbox contains text not added to the list. Add it to the list before applying?", "SteelQuiz",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (msg == DialogResult.Yes)
                {
                    if (!AddSynonym())
                    {
                        return false;
                    }
                }
                else if (msg == DialogResult.Cancel)
                {
                    return false;
                }
            }

            var oldSynonyms = Synonyms.Clone().ToList();
            var newSynonyms = lst_synonyms.Items.OfType<string>().ToList();

            QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Action[] { () => { Synonyms = oldSynonyms; } },
                new Action[] { () => { Synonyms = newSynonyms; } },
                "Change Synonyms",
                new OwnerControlData(this, QuizEditor)));
            QuizEditor.ChangedSinceLastSave = true;
            QuizEditor.UpdateUndoRedoTooltips();

            Synonyms = newSynonyms;

            // update last saved state
            initialListBoxCollection = new object[lst_synonyms.Items.Count];
            lst_synonyms.Items.CopyTo(initialListBoxCollection, 0);

            return true;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (!ApplyChanges())
            {
                return;
            }
            closeWarning = false;
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (((txt_synonymAdd.Text == "" || lst_synonyms.Items.Contains(txt_synonymAdd.Text)) && !ListBoxChanged())
                || MessageBox.Show("Are you sure you want to cancel? The changes will not be applied", "SteelQuiz", MessageBoxButtons.YesNo,
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

        private bool SynonymChk()
        {
            if (txt_synonymAdd.Text == "")
            {
                MessageBox.Show("Synonym cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (lst_synonyms.Items.Contains(txt_synonymAdd.Text))
            {
                MessageBox.Show("Duplicates are not allowed", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Language == 1)
            {
                if (txt_synonymAdd.Text == Parent.Front)
                {
                    MessageBox.Show("You can't add a synonym equal to the word you are adding synonyms for", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (Language == 2)
            {
                if (txt_synonymAdd.Text == Parent.Back)
                {
                    MessageBox.Show("You can't add a synonym equal to the word you are adding synonyms for", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool AddSynonym()
        {
            if (!SynonymChk())
            {
                return false;
            }

            if (txt_synonymAdd.Text.StartsWith(" ") || txt_synonymAdd.Text.EndsWith(" "))
            {
                var msg = MessageBox.Show("The text contains whitespace in the beginning/end. Remove this whitespace (trim the text)?"
                    + "\r\n\r\nThis is strongly recommended if you did not intend this",
                    "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    txt_synonymAdd.Text = txt_synonymAdd.Text.Trim();
                }
                else if (msg == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (txt_synonymAdd.Text.Contains("  "))
            {
                var msg = MessageBox.Show("The text contains double-/multispaces. Replace the double-/multispaces with single spaces?" +
                    "\r\n\r\nThis is strongly recommended if you did not intend this", "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    while (txt_synonymAdd.Text.Contains("  "))
                    {
                        txt_synonymAdd.Text = txt_synonymAdd.Text.Replace("  ", " ");
                    }
                }
                else if (msg == DialogResult.Cancel)
                {
                    return false;
                }
            }

            lst_synonyms.Items.Add(txt_synonymAdd.Text);

            UndoStack.Push(new UndoRedoFuncPair(
                new Action[] { lst_synonyms.RemoveItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, txt_synonymAdd.Text) },
                new Action[] { lst_synonyms.AddItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, txt_synonymAdd.Text) },
                "Add synonym(s)",
                new OwnerControlData(this, this.Parent, Language)));
            UpdateUndoRedoTooltips();
            ChangedSinceLastSave = true;

            txt_synonymAdd.Text = "";
            changedTextBox = false;

            return true;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!SynonymChk())
            {
                return;
            }

            if (txt_synonymAdd.Text.StartsWith(" ") || txt_synonymAdd.Text.EndsWith(" "))
            {
                var msg = MessageBox.Show("The text contains whitespace in the beginning/end. Remove this whitespace (trim the text)?"
                    + "\r\n\r\nThis is strongly recommended if you did not intend this",
                    "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    txt_synonymAdd.Text = txt_synonymAdd.Text.Trim();
                }
                else if (msg == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (txt_synonymAdd.Text.Contains("  "))
            {
                var msg = MessageBox.Show("The text contains double-/multispaces. Replace the double-/multispaces with single spaces?" +
                    "\r\n\r\nThis is strongly recommended if you did not intend this", "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes)
                {
                    while (txt_synonymAdd.Text.Contains("  "))
                    {
                        txt_synonymAdd.Text = txt_synonymAdd.Text.Replace("  ", " ");
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
                var _new = txt_synonymAdd.Text;

                lst_synonyms.Items[lst_synonyms.Items.IndexOf(item)] = _new;

                undoes.Add(lst_synonyms.ChangeItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, old, _new));
                redoes.Add(lst_synonyms.ChangeItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, _new, old));
            }

            UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), "Update synonym(s)", new OwnerControlData(this, this.Parent, Language)));
            UpdateUndoRedoTooltips();
            ChangedSinceLastSave = true;

            txt_synonymAdd.Text = "";
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

                undoes.Add(lst_synonyms.AddItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, item));
                redoes.Add(lst_synonyms.RemoveItem(() => { return this.Parent.EditWordSynonyms; }, lst_synonyms.Name, item));
            }

            UndoStack.Push(new UndoRedoFuncPair(undoes.ToArray(), redoes.ToArray(), "Remove synonym(s)", new OwnerControlData(this, this.Parent, Language)));
            UpdateUndoRedoTooltips();
            ChangedSinceLastSave = true;
        }

        private void lst_synonyms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((!changedTextBox || txt_synonymAdd.Text.Length == 0))
            {
                if (lst_synonyms.SelectedItems.Count == 1)
                {
                    // only update textbox if only one item is selected, and the textbox hasn't been changed since last selection
                    txt_synonymAdd.Text = (string)lst_synonyms.Items[lst_synonyms.SelectedIndex];
                }
                else if (lst_synonyms.SelectedItems.Count == 0)
                {
                    // clear textbox if no items are left in the list, and the textbox hasn't been changed since last selection
                    txt_synonymAdd.Text = "";
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
                txt_synonymAdd.Text = (string)lst_synonyms.Items[lst_synonyms.SelectedIndex];
                changedTextBox = false;
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
            if (!closeWarning || (!ListBoxChanged() && (txt_synonymAdd.Text == "" || lst_synonyms.Items.Contains(txt_synonymAdd.Text))))
            {
                //RemoveUndoRedoStuff();
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel? The changes will not be applied", "SteelQuiz", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //RemoveUndoRedoStuff();
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void txt_wordAdd_TextChanged(object sender, EventArgs e)
        {
            var duplicate = lst_synonyms.Items.Contains(txt_synonymAdd.Text);
            btn_add.Enabled = txt_synonymAdd.Text.Length > 0 && !duplicate;
        }

        public override void UpdateUndoRedoTooltips()
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