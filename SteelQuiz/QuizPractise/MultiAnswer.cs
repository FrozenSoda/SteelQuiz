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
using SteelQuiz.Extensions;

namespace SteelQuiz.QuizPractise
{
    public partial class MultiAnswer : AutoThemeableUserControl
    {
        public int AnswersProvided
        {
            get
            {
                return flp_answers.Controls.OfType<Label>().Count();
            }
        }

        public Label CurrentLabel
        {
            get
            {
                return flp_answers.Controls.OfType<Label>().Last();
            }
        }

        public MultiAnswer()
        {
            InitializeComponent();
            SetTheme();
            AlignFlpAnswers();
        }

        private void AlignFlpAnswers()
        {
            int x = 3;

            int yMin = 34;
            int y = Size.Height / 2 - flp_answers.Controls.OfType<Label>().Sum(n => (n.Size.Height + flp_answers.Padding.Top) / 2);

            y = Math.Max(yMin, y);

            flp_answers.Location = new Point(x, y);
        }

        private void Flp_answers_ControlAdded(object sender, ControlEventArgs e)
        {
            AlignFlpAnswers();
        }
    }
}
