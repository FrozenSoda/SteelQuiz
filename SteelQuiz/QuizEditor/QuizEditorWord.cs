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
        public int Number { get; set; } // number in flowlayoutpanel, the first one has number 0 for instance
        public string Word1 => txt_word1.Text;
        public string Word2 => txt_word2.Text;

        public List<string> Synonyms1 { get; set; } = null;
        public List<string> Synonyms2 { get; set; } = null;
        public EditWordSynonyms EditWordSynonyms { get; set; } = null;

        public bool ignore_txt_word_change = false;
        public bool ignore_chk_ignoreCapitalization_change = false;
        public bool ignore_chk_ignoreExcl_change = false;

        public QuizEditorWord(int number)
        {
            InitializeComponent();
            Number = number;
        }

        public void InitEditWordSynonyms(int language)
        {
            if (EditWordSynonyms == null)
            {
                EditWordSynonyms = new EditWordSynonyms(this, language == 1 ? txt_word1.Text : txt_word2.Text, language == 1 ? Synonyms1 : Synonyms2, language);
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

        private void btn_editSynonyms_w1_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms(1);
            if (EditWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                Synonyms1 = EditWordSynonyms.Synonyms;
            }
            DisposeEditWordSynonyms();
        }

        private void btn_editSynonyms_w2_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms(2);
            if (EditWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                Synonyms2 = EditWordSynonyms.Synonyms;
            }
            DisposeEditWordSynonyms();
        }

        private string txt_word1_text_old = "";

        private void txt_word1_TextChanged(object sender, EventArgs e)
        {
            if (ignore_txt_word_change)
            {
                txt_word1_text_old = txt_word1.Text;
                ignore_txt_word_change = false;
                return;
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { txt_word1.ChangeText(txt_word1_text_old, () => { ignore_txt_word_change = true; }) },
                new Func<object>[] { txt_word1.ChangeText(txt_word1.Text, () => { ignore_txt_word_change = true; }) },
                new OwnerControlData(this, this.Parent)));

            txt_word1_text_old = txt_word1.Text;
        }

        private string txt_word2_text_old = "";

        private void txt_word2_TextChanged(object sender, EventArgs e)
        {
            if (ignore_txt_word_change)
            {
                txt_word2_text_old = txt_word2.Text;
                ignore_txt_word_change = false;
                return;
            }

            Program.frmQuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { txt_word2.ChangeText(txt_word2_text_old, () => { ignore_txt_word_change = true; }) },
                new Func<object>[] { txt_word2.ChangeText(txt_word2.Text, () => { ignore_txt_word_change = true; }) },
                new OwnerControlData(this, this.Parent)));

            txt_word2_text_old = txt_word2.Text;
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

        private void txt_word_Click(object sender, EventArgs e)
        {
            if (Number >= Program.frmQuizEditor.flp_controls_count - 1)
            {
                Program.frmQuizEditor.AddWordPair(1);
            }
        }
    }
}
