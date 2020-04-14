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

using SteelQuiz.QuizData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizPractise
{
    public partial class FixQuizErrors : AutoThemeableForm
    {
        public Card WordPair { get; set; }
        private new InQuiz Parent { get; set; }

        public FixQuizErrors(InQuiz parent, Card wordPair)
        {
            InitializeComponent();
            WordPair = wordPair;
            Parent = parent;

            UpdateWordLabels();

            SetTheme();
        }

        private void UpdateWordLabels()
        {
            lbl_word1.Text = $"Word 1:    {WordPair.Front}";
            lbl_word2.Text = $"Word 2:    {WordPair.Back}";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_editWord1_Click(object sender, EventArgs e)
        {
            var editWord = new EditWord(WordPair.Front);
            if (editWord.ShowDialog() == DialogResult.OK)
            {
                WordPair.Front = editWord.Word;
                QuizCore.SaveQuiz();
                UpdateWordLabels();
            }
        }

        private void btn_editWord2_Click(object sender, EventArgs e)
        {
            var editWord = new EditWord(WordPair.Back);
            if (editWord.ShowDialog() == DialogResult.OK)
            {
                WordPair.Back = editWord.Word;
                QuizCore.SaveQuiz();
                UpdateWordLabels();
            }
        }

        private void btn_editFrontSynonyms_Click(object sender, EventArgs e)
        {
            var editWordSynonyms = new EditWordSynonyms(WordPair, 1);
            if (editWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                WordPair.FrontSynonyms = editWordSynonyms.Synonyms;
                QuizCore.SaveQuiz();
            }
        }

        private void btn_editBackSynonyms_Click(object sender, EventArgs e)
        {
            var editWordSynonyms = new EditWordSynonyms(WordPair, 2);
            if (editWordSynonyms.ShowDialog() == DialogResult.OK)
            {
                WordPair.BackSynonyms = editWordSynonyms.Synonyms;
                QuizCore.SaveQuiz();
            }
        }

        private void DontAgreeMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btn_editInEditor_Click(object sender, EventArgs e)
        {
            Parent.ExitAppOnClose = false;
            Program.frmWelcome.Show();
            Program.frmWelcome.OpenQuizEditor(QuizCore.Quiz, QuizCore.QuizPath);
            DialogResult = DialogResult.Abort;
        }
    }
}
