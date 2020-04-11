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

        public List<string> Synonyms1 { get; set; } = new List<string>();
        public List<string> Synonyms2 { get; set; } = new List<string>();

        public Pointer<StringComp.Rules> ComparisonRules { get; set; } = new Pointer<StringComp.Rules>(StringComp.SMART_RULES);

        public EditWordSynonyms EditWordSynonyms { get; set; } = null;

        public QuizEditor QuizEditor { get; set; }

        public bool ignore_txt_word_change = false;
        public bool ignore_chk_smartComp_change = false;

        public QuizEditorWordPair(QuizEditor owner, int number)
        {
            InitializeComponent();
            QuizEditor = owner;
            Number = number;
            RemoveSynonymsEqualToWords();

            ComparisonRules.BeforeDataChanged += (sender, e) =>
            {
                if (QuizEditor.UpdateUndoRedoStacks)
                {
                    QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                        new Action[] { ComparisonRules.SetSemiSilentUR(ComparisonRules.Data) },
                        new Action[] { ComparisonRules.SetSemiSilentUR(e) },
                        "Change comparison rules",
                        new OwnerControlData(this, this.Parent)
                        ));
                    QuizEditor.UpdateUndoRedoTooltips();
                }

                QuizEditor.ChangedSinceLastSave = true;
            };

            ComparisonRules.AfterDataChanged += (sender, e) =>
            {
                chk_smartComp.CheckStateChanged -= Chk_smartComp_CheckStateChanged;
                if (ComparisonRules.Data.HasFlag(StringComp.SMART_RULES))
                {
                    chk_smartComp.CheckState = CheckState.Checked;
                }
                else if (ComparisonRules.Data == StringComp.Rules.None)
                {
                    chk_smartComp.CheckState = CheckState.Unchecked;
                }
                else
                {
                    chk_smartComp.CheckState = CheckState.Indeterminate;
                }
                chk_smartComp.CheckStateChanged += Chk_smartComp_CheckStateChanged;
                QuizEditor.SetGlobalSmartComparisonState();
            };

            SetTheme();
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null)
            {
                theme = new GeneralTheme();
            }

            base.SetTheme(theme);

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                btn_smartCompSettings.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("gear_1077563_white_with_bigger_border_512x512");
            }
            else
            {
                btn_smartCompSettings.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("gear_1077563_black_with_bigger_border_512x512");
            }

            lbl_ansCompRules.ForeColor = theme.GetBackgroundLabelForeColor();
            chk_smartComp.ForeColor = theme.GetBackgroundLabelForeColor();
        }

        public void InitEditWordSynonyms(int language)
        {
            if (EditWordSynonyms == null)
            {
                EditWordSynonyms = new EditWordSynonyms(this, language == 1 ? txt_word1.Text : txt_word2.Text, language);
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
                QuizEditor.ChkFixWordsCount();
            }
            DisposeEditWordSynonyms();
        }

        private void btn_editSynonyms_w2_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms(2);
            if (EditWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                Synonyms2 = EditWordSynonyms.Synonyms;
                QuizEditor.ChkFixWordsCount();
            }
            DisposeEditWordSynonyms();
        }

        private string txt_word1_text_old = "";

        private void txt_word1_TextChanged(object sender, EventArgs e)
        {
            QuizEditor.ChkFixWordsCount();

            if (ignore_txt_word_change)
            {
                txt_word1_text_old = txt_word1.Text;
                ignore_txt_word_change = false;
                return;
            }

            if (QuizEditor.UpdateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                    new Action[] { txt_word1.ChangeText(txt_word1_text_old, () => { ignore_txt_word_change = true; }) },
                    new Action[] { txt_word1.ChangeText(txt_word1.Text, () => { ignore_txt_word_change = true; }) },
                    "Change word",
                    new OwnerControlData(this, this.Parent)));
                QuizEditor.UpdateUndoRedoTooltips();
            }
            QuizEditor.ChangedSinceLastSave = true;

            txt_word1_text_old = txt_word1.Text;
        }

        private string txt_word2_text_old = "";

        private void txt_word2_TextChanged(object sender, EventArgs e)
        {
            QuizEditor.ChkFixWordsCount();

            if (ignore_txt_word_change)
            {
                txt_word2_text_old = txt_word2.Text;
                ignore_txt_word_change = false;
                return;
            }

            if (QuizEditor.UpdateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                new Action[] { txt_word2.ChangeText(txt_word2_text_old, () => { ignore_txt_word_change = true; }) },
                new Action[] { txt_word2.ChangeText(txt_word2.Text, () => { ignore_txt_word_change = true; }) },
                "Change word",
                new OwnerControlData(this, this.Parent)));
                QuizEditor.UpdateUndoRedoTooltips();
            }
            QuizEditor.ChangedSinceLastSave = true;

            txt_word2_text_old = txt_word2.Text;
        }

        private void txt_word_Click(object sender, EventArgs e)
        {
            QuizEditor.ChkFixWordsCount();
        }

        private void txt_word1_Enter(object sender, EventArgs e)
        {
            QuizEditor.ChkFixWordsCount();
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (QuizEditor.UpdateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                    new Action[] { QuizEditor.AddWordPair(this, QuizEditor.flp_words.Controls.GetChildIndex(this)) },
                    new Action[] { QuizEditor.RemoveWordPair(this) },
                    "Remove word pair",
                    new OwnerControlData(this, this.Parent)
                    ));
            }
            QuizEditor.UpdateUndoRedoTooltips();
            QuizEditor.flp_words.Controls.Remove(this);
            QuizEditor.ChkFixWordsCount();
            QuizEditor.ChangedSinceLastSave = true;
        }

        public void RemoveSynonymsEqualToWords(int word = -1)
        {
            // check if synonyms contains word entered

            if ((word == -1 || word == 1) && Synonyms1 != null && Synonyms1.Contains(Word1))
            {
                QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                    new Action[] { Synonyms1.AddItem(Word1) },
                    new Action[] { Synonyms1.RemoveItem(Word1) },
                    "Auto-remove synonym",
                    new OwnerControlData(this, this.Parent)
                    ));
                QuizEditor.UpdateUndoRedoTooltips();
                Synonyms1.Remove(Word1);
                /*
#warning dont use messageboxes
                var msg = MessageBox.Show($"A synonym to {Word1} has been removed, that was equal to the word", "SteelQuiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    */
                QuizEditor.ShowNotification($"A synonym to '{Word1}' has been removed, due to it being equal to the word itself", 0);
            }

            if ((word == -1 || word == 2) && Synonyms2 != null && Synonyms2.Contains(Word2))
            {
                QuizEditor.UndoStack.Push(new UndoRedoFuncPair(
                    new Action[] { Synonyms2.AddItem(Word2) },
                    new Action[] { Synonyms2.RemoveItem(Word2) },
                    "Auto-remove synonym",
                    new OwnerControlData(this, this.Parent)
                    ));
                QuizEditor.UpdateUndoRedoTooltips();
                Synonyms2.Remove(Word2);
                /*
                var msg = MessageBox.Show($"A synonym to word {Word2} has been removed, that was equal to the word", "SteelQuiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    */
                QuizEditor.ShowNotification($"A synonym to '{Word2}' has been removed, due to it being equal to the word itself", 0);
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
            var smartCompSettings = new SmartComparisonSettings(ComparisonRules.Data);
            var result = smartCompSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                ComparisonRules.Data = smartCompSettings.Rules;
            }
        }

        private void Chk_smartComp_Click(object sender, EventArgs e)
        {
            if (chk_smartComp.CheckState == CheckState.Checked)
            {
                chk_smartComp.CheckState = CheckState.Unchecked;
            }
            else if (chk_smartComp.CheckState == CheckState.Unchecked)
            {
                chk_smartComp.CheckState = CheckState.Checked;
            }
            else if (chk_smartComp.CheckState == CheckState.Indeterminate)
            {
                chk_smartComp.CheckState = CheckState.Checked;
            }
        }

        private void Chk_smartComp_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignore_chk_smartComp_change)
            {
                ignore_chk_smartComp_change = false;
                return;
            }

            if (chk_smartComp.CheckState == CheckState.Checked)
            {
                ComparisonRules.Data = StringComp.SMART_RULES;
            }
            else if (chk_smartComp.CheckState == CheckState.Unchecked)
            {
                ComparisonRules.Data = StringComp.Rules.None;
            }

            QuizEditor.ChangedSinceLastSave = true;
        }

        private void QuizEditorWordPair_SizeChanged(object sender, EventArgs e)
        {
            int width = (int)Math.Floor(Size.Width / 2d - 30);

            txt_word1.Size = new Size(width, txt_word1.Size.Height);
            txt_word2.Size = new Size(width, txt_word2.Size.Height);
        }
    }
}
