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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class QuizExport : AutoThemeableForm
    {
        private Quiz Quiz { get; set; }

        public QuizExport(Quiz quiz)
        {
            InitializeComponent();
            SetTheme();

            Quiz = quiz;

            GenerateText();
        }

        private void GenerateText()
        {
            rtf_text.Text = "";
            foreach (var wp in Quiz.Cards)
            {
                rtf_text.Text += wp.Front;
                foreach (var synonym in wp.FrontSynonyms)
                {
                    rtf_text.Text += $" / {synonym}";
                }

                rtf_text.Text += Regex.Unescape(txt_chBetweenWords.Text);

                rtf_text.Text += wp.Back;
                foreach (var synonym in wp.BackSynonyms)
                {
                    rtf_text.Text += $" / {synonym}";
                }

                rtf_text.Text += Regex.Unescape(txt_chBetweenLines.Text);
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtf_text.Text);
        }

        private void Txt_chBetweenWords_TextChanged(object sender, EventArgs e)
        {
            GenerateText();
        }

        private void Txt_chBetweenLines_TextChanged(object sender, EventArgs e)
        {
            GenerateText();
        }

        private void QuizExport_SizeChanged(object sender, EventArgs e)
        {
            rtf_text.Size = new Size(Size.Width - 40, Size.Height - 116);
        }
    }
}
