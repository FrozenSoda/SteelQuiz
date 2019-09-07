﻿/*
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
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizPractise;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizEditorWordPair : AutoThemeableUserControl
    {
        public int Number { get; set; } // number in flowlayoutpanel, the first one has number 0 for instance
        public string Word1 => txt_word1.Text;
        public string Word2 => txt_word2.Text;

        public List<string> Synonyms1 { get; set; } = null;
        public List<string> Synonyms2 { get; set; } = null;

        private StringComp.Rules __comparisonRules = StringComp.SMART_RULES;
        public StringComp.Rules ComparisonRules
        {
            get
            {
                return __comparisonRules;
            }

            set
            {
                __comparisonRules = value;

                if (value.HasFlag(StringComp.SMART_RULES))
                {
                    chk_smartComp.CheckState = CheckState.Checked;
                }
                else if (value == StringComp.Rules.None)
                {
                    chk_smartComp.CheckState = CheckState.Unchecked;
                }
                else
                {
                    chk_smartComp.CheckState = CheckState.Indeterminate;
                }

#warning push to undo/redo stack
                QEOwner.ChangedSinceLastSave = true;
            }
        }

        public EditWordSynonyms EditWordSynonyms { get; set; } = null;

        public QuizEditor QEOwner { get; set; }

        public bool ignore_txt_word_change = false;
        public bool ignore_chk_smartComp_change = false;

        public QuizEditorWordPair(QuizEditor owner, int number)
        {
            InitializeComponent();
            QEOwner = owner;
            Number = number;
            RemoveSynonymsEqualToWords();

            SetTheme();
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            base.SetTheme(theme);

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                btn_smartCompSettings.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("gear_1077563_black_with_bigger_border_512x512");
            }
            else
            {
                btn_smartCompSettings.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("gear_1077563_black_with_bigger_border_512x512");
            }
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
                EditWordSynonyms.DialogResult = DialogResult.Cancel;
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
                QEOwner.ChkFixWordsCount();
            }
            DisposeEditWordSynonyms();
        }

        private void btn_editSynonyms_w2_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms(2);
            if (EditWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                Synonyms2 = EditWordSynonyms.Synonyms;
                QEOwner.ChkFixWordsCount();
            }
            DisposeEditWordSynonyms();
        }

        private string txt_word1_text_old = "";

        private void txt_word1_TextChanged(object sender, EventArgs e)
        {
            QEOwner.ChkFixWordsCount();

            if (ignore_txt_word_change)
            {
                txt_word1_text_old = txt_word1.Text;
                ignore_txt_word_change = false;
                return;
            }

            if (QEOwner.UpdateUndoRedoStacks)
            {
                QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                    new Func<object>[] { txt_word1.ChangeText(txt_word1_text_old, () => { ignore_txt_word_change = true; }) },
                    new Func<object>[] { txt_word1.ChangeText(txt_word1.Text, () => { ignore_txt_word_change = true; }) },
                    "Change word",
                    new OwnerControlData(this, this.Parent)));
                QEOwner.UpdateUndoRedoTooltips();
            }
            QEOwner.ChangedSinceLastSave = true;

            txt_word1_text_old = txt_word1.Text;
        }

        private string txt_word2_text_old = "";

        private void txt_word2_TextChanged(object sender, EventArgs e)
        {
            QEOwner.ChkFixWordsCount();

            if (ignore_txt_word_change)
            {
                txt_word2_text_old = txt_word2.Text;
                ignore_txt_word_change = false;
                return;
            }

            if (QEOwner.UpdateUndoRedoStacks)
            {
                QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                new Func<object>[] { txt_word2.ChangeText(txt_word2_text_old, () => { ignore_txt_word_change = true; }) },
                new Func<object>[] { txt_word2.ChangeText(txt_word2.Text, () => { ignore_txt_word_change = true; }) },
                "Change word",
                new OwnerControlData(this, this.Parent)));
                QEOwner.UpdateUndoRedoTooltips();
            }
            QEOwner.ChangedSinceLastSave = true;

            txt_word2_text_old = txt_word2.Text;
        }

        private void chk_ignoreExcl_CheckedChanged(object sender, EventArgs e)
        {
            if (ignore_chk_smartComp_change)
            {
                ignore_chk_smartComp_change = false;
                return;
            }

            if (QEOwner.UpdateUndoRedoStacks)
            {
                QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                    new Func<object>[] { chk_smartComp.SetChecked(!chk_smartComp.Checked, () => { ignore_chk_smartComp_change = true; }) },
                    new Func<object>[] { chk_smartComp.SetChecked(chk_smartComp.Checked, () => { ignore_chk_smartComp_change = true; }) },
                    "Checkbox switch",
                    new OwnerControlData(this, this.Parent)
                    ));
                QEOwner.UpdateUndoRedoTooltips();
            }
            QEOwner.ChangedSinceLastSave = true;
        }

        private void txt_word_Click(object sender, EventArgs e)
        {
            QEOwner.ChkFixWordsCount();
        }

        private void txt_word1_Enter(object sender, EventArgs e)
        {
            QEOwner.ChkFixWordsCount();
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (QEOwner.UpdateUndoRedoStacks)
            {
                QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                    new Func<object>[] { QEOwner.AddWordPair(this, QEOwner.flp_words.Controls.GetChildIndex(this)) },
                    new Func<object>[] { QEOwner.RemoveWordPair(this) },
                    "Remove word pair",
                    new OwnerControlData(this, this.Parent)
                    ));
            }
            QEOwner.UpdateUndoRedoTooltips();
            QEOwner.flp_words.Controls.Remove(this);
            QEOwner.ChkFixWordsCount();
            QEOwner.ChangedSinceLastSave = true;
        }

        public void RemoveSynonymsEqualToWords(int word = -1)
        {
            // check if synonyms contains word entered

            if ((word == -1 || word == 1) && Synonyms1 != null && Synonyms1.Contains(Word1))
            {
                QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                    new Func<object>[] { Synonyms1.AddItem(Word1) },
                    new Func<object>[] { Synonyms1.RemoveItem(Word1) },
                    "Auto-remove synonym",
                    new OwnerControlData(this, this.Parent)
                    ));
                QEOwner.UpdateUndoRedoTooltips();
                Synonyms1.Remove(Word1);
                /*
#warning dont use messageboxes
                var msg = MessageBox.Show($"A synonym to {Word1} has been removed, that was equal to the word", "SteelQuiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    */
                QEOwner.ShowNotification($"A synonym to '{Word1}' has been removed, due to it being equal to the word itself", 0);
            }

            if ((word == -1 || word == 2) && Synonyms2 != null && Synonyms2.Contains(Word2))
            {
                QEOwner.UndoStack.Push(new UndoRedoFuncPair(
                    new Func<object>[] { Synonyms2.AddItem(Word2) },
                    new Func<object>[] { Synonyms2.RemoveItem(Word2) },
                    "Auto-remove synonym",
                    new OwnerControlData(this, this.Parent)
                    ));
                QEOwner.UpdateUndoRedoTooltips();
                Synonyms2.Remove(Word2);
                /*
                var msg = MessageBox.Show($"A synonym to word {Word2} has been removed, that was equal to the word", "SteelQuiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    */
                QEOwner.ShowNotification($"A synonym to '{Word2}' has been removed, due to it being equal to the word itself", 0);
            }
        }

        private void Txt_word1_Leave(object sender, EventArgs e)
        {
            RemoveSynonymsEqualToWords(1);
        }

        private void Txt_word2_Leave(object sender, EventArgs e)
        {
            RemoveSynonymsEqualToWords(2);
        }

        private void Btn_smartCompSettings_Click(object sender, EventArgs e)
        {
            var smartCompSettings = new SmartComparisonSettings(ComparisonRules);
            var result = smartCompSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                ComparisonRules = smartCompSettings.Rules;
            }
        }
    }
}
