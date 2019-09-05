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

namespace SteelQuiz.QuizPractise
{
    public partial class WrongAnswer : AutoThemeableUserControl
    {
        public WrongAnswer(string questionWord, string questionLang, string correctAnswer, string answerLang)
        {
            InitializeComponent();
            SetTheme();

            lbl_questionLang.Text = $"{questionLang} word:";
            lbl_questionWord.Text = questionWord;
            toolTip1.SetToolTip(lbl_questionWord, questionWord);

            AutoShrinkFont(lbl_questionWord, 8);

            lbl_answerLang.Text = $"Correct {answerLang} word:";
            lbl_correctAnswer.Text = correctAnswer;
            toolTip1.SetToolTip(lbl_correctAnswer, correctAnswer);

            AutoShrinkFont(lbl_correctAnswer, 8);

            lbl_instruction.Text = $"Type the {answerLang} word";
        }

        private void AutoShrinkFont(Label lbl, int minimumSize)
        {
            // Method doesn't work without autosize
            bool disableAutoSize = false;
            if (!lbl.AutoSize)
            {
                lbl.AutoSize = true;
                disableAutoSize = true;
            }

            while (lbl.Width < TextRenderer.MeasureText(lbl.Text,
                new Font(lbl.Font.FontFamily, lbl.Font.Size, lbl.Font.Style)).Width && lbl.Font.Size > minimumSize)
            {
                lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size - 0.5f, lbl.Font.Style);
            }

            // Restore autosize to previous value
            if (disableAutoSize)
            {
                lbl.AutoSize = false;
            }
        }
    }
}
