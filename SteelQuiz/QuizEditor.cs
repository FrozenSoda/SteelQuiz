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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class QuizEditor : Form
    {
        private List<QuizEditorWord> quizEditorWords_lang1 = new List<QuizEditorWord>();
        private List<QuizEditorWord> quizEditorWords_lang2 = new List<QuizEditorWord>();

        public QuizEditor()
        {
            InitializeComponent();
            this.Location = new Point(Program.frmWelcome.Location.X + (Program.frmWelcome.Size.Width / 2) - (this.Size.Width / 2),
                              Program.frmWelcome.Location.Y + (Program.frmWelcome.Size.Height / 2) - (this.Size.Height / 2)
                            );
            AddWordPair(20);
        }

        private void AddWordPair(int count = 1)
        {
            for (int i = 0; i < count; ++i)
            {
                var w1 = new QuizEditorWord();
                quizEditorWords_lang1.Add(w1);
                flp_words1.Controls.Add(w1);

                var w2 = new QuizEditorWord();
                quizEditorWords_lang2.Add(w2);
                flp_words2.Controls.Add(w2);
            }
        }
    }
}
