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

namespace SteelQuiz.QuizPractise
{
    public partial class EditWord : Form
    {
        public string Word { get; set; }

        public EditWord(string word)
        {
            InitializeComponent();
            label1.Text = $"Enter new value for word '{word}':";
            toolTip1.SetToolTip(label1, $"Word: '{word}'");
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_word.Text == "")
            {
                MessageBox.Show("Word cannot be empty", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Word = txt_word.Text;
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
