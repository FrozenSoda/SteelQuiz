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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizEditor.UndoRedo;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizEditorWord : UserControl
    {
        public int Language { get; set; }
        public string Word => txt_word.Text;
        public List<string> Synonyms { get; set; } = null;
        public EditWordSynonyms EditWordSynonyms { get; set; } = null;

        public bool ignore_txt_word_change = false;
        public bool ignore_chk_ignoreCapitalization_change = false;
        public bool ignore_chk_ignoreExcl_change = false;

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

        public void InitEditWordSynonyms()
        {
            if (EditWordSynonyms == null)
            {
                EditWordSynonyms = new EditWordSynonyms(this, txt_word.Text, Synonyms);
            }
        }

        public void DisposeEditWordSynonyms()
        {
            if (EditWordSynonyms != null)
            {
                EditWordSynonyms.Dispose();
                EditWordSynonyms = null;
            }
        }

        private void btn_editSynonyms_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms();
            if (EditWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                Synonyms = EditWordSynonyms.Synonyms;
            }
            DisposeEditWordSynonyms();
        }

        private string txt_word_text_old = "";

        private void txt_word_TextChanged(object sender, EventArgs e)
        {
            if (ignore_txt_word_change)
            {
                txt_word_text_old = txt_word.Text;
                ignore_txt_word_change = false;
                return;
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { txt_word.ChangeText(txt_word_text_old, () => { ignore_txt_word_change = true; }) },
                new Func<object>[] { txt_word.ChangeText(txt_word.Text, () => { ignore_txt_word_change = true; }) },
                new OwnerControlData(this, this.Parent)));

            txt_word_text_old = txt_word.Text;
        }

        private void chk_ignoreCapitalization_CheckedChanged(object sender, EventArgs e)
        {
            if (ignore_chk_ignoreCapitalization_change)
            {
                ignore_chk_ignoreCapitalization_change = false;
                return;
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { chk_ignoreCapitalization.SetChecked(!chk_ignoreCapitalization.Checked, () => { ignore_chk_ignoreCapitalization_change = true; }) },
                new Func<object>[] { chk_ignoreCapitalization.SetChecked(chk_ignoreCapitalization.Checked, () => { ignore_chk_ignoreCapitalization_change = true; }) },
                new OwnerControlData(this, this.Parent)
                ));
        }

        private void chk_ignoreExcl_CheckedChanged(object sender, EventArgs e)
        {
            if (ignore_chk_ignoreExcl_change)
            {
                ignore_chk_ignoreExcl_change = false;
                return;
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { chk_ignoreExcl.SetChecked(!chk_ignoreExcl.Checked, () => { ignore_chk_ignoreExcl_change = true; }) },
                new Func<object>[] { chk_ignoreExcl.SetChecked(chk_ignoreExcl.Checked, () => { ignore_chk_ignoreExcl_change = true; }) },
                new OwnerControlData(this, this.Parent)
                ));
        }
    }
}
