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
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizImport.Guide
{
    public partial class Step5 : UserControl
    {
        public string Language1 => txt_lang.Text;

        public Step5(IEnumerable<WordPair> wordPairs)
        {
            InitializeComponent();
            foreach (var wordPair in wordPairs)
            {
                lst_words.Items.Add(wordPair.Word1);
            }
        }

        private void Txt_lang_TextChanged(object sender, EventArgs e)
        {
            if (txt_lang.Text.Length < 1)
            {
                return;
            }

            // force first character to be uppercase
            if (char.IsLower(txt_lang.Text.First()))
            {
                var initialSelection = txt_lang.SelectionStart;

                //make it uppercase
                txt_lang.Text = txt_lang.Text.First().ToString().ToUpper() + txt_lang.Text.Substring(1);
                txt_lang.SelectionStart = initialSelection;
            }
        }
    }
}
