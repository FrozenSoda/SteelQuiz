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

namespace SteelQuiz.QuizImport
{
    public partial class QuizLanguageSelector : Form
    {
        public string Language1 { get; set; } = "";
        public string Language2 { get; set; } = "";

        private int _langStep = 0;
        private int LangStep
        {
            get
            {
                return _langStep;
            }

            set
            {
                _langStep = value;
                SwitchLanguage();
            }
        }

        private IEnumerable<WordPair> WordPairs { get; set; }

        public QuizLanguageSelector(IEnumerable<WordPair> wordPairs)
        {
            InitializeComponent();
            WordPairs = wordPairs;
            ++LangStep;
        }

        public void SwitchLanguage()
        {
            lst_words.Items.Clear();
            txt_lang.Clear();
            txt_lang.ClearUndo();
            if (LangStep == 1)
            {
                btn_nextOK.Text = "Next";
                btn_backCancel.Text = "Cancel import";
                txt_lang.Text = Language1;
                foreach (var wordPair in WordPairs)
                {
                    lst_words.Items.Add(wordPair.Word1);
                }
            }
            else if (LangStep == 2)
            {
                btn_nextOK.Text = "Finish";
                btn_backCancel.Text = "Previous";
                txt_lang.Text = Language2;
                foreach (var wordPair in WordPairs)
                {
                    lst_words.Items.Add(wordPair.Word2);
                }
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            if (LangStep == 1)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (LangStep == 2)
            {
                --LangStep;
            }
        }

        private void Btn_nextOK_Click(object sender, EventArgs e)
        {
            if (LangStep == 1)
            {
                Language1 = txt_lang.Text;
                ++LangStep;
            }
            else if (LangStep == 2)
            {
                Language2 = txt_lang.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void QuizLanguageSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            var msg = MessageBox.Show("Are you sure you want to cancel the import?", "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
