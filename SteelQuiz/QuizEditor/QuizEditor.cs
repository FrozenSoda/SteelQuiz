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
using SteelQuiz.QuizData;

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
                var w1 = new QuizEditorWord(true);
                quizEditorWords_lang1.Add(w1);
                flp_words.Controls.Add(w1);

                var w2 = new QuizEditorWord(false);
                quizEditorWords_lang2.Add(w2);
                flp_words.Controls.Add(w2);
            }
        }

        private Quiz ConstructQuiz()
        {
            // add synonyms

            throw new NotImplementedException();

            var quiz = new Quiz(cmb_lang1.Text, cmb_lang2.Text, MetaData.QUIZ_FILE_FORMAT_VERSION);

            QuizEditorWord w1 = null;
            foreach (var word in flp_words.Controls.OfType<QuizEditorWord>())
            {
                if (w1 == null)
                {
                    w1 = word;
                }
                else
                {
                    StringComp.Rules translationRules = StringComp.Rules.None;
                    if (w1.chk_ignoreCapitalization.Checked)
                    {
                        translationRules |= StringComp.Rules.IgnoreCapitalization;
                    }
                    if (w1.chk_ignoreExcl.Checked)
                    {
                        translationRules |= StringComp.Rules.IgnoreExclamation;
                    }
                    var wordPair = new WordPair(w1.txt_word.Text, word.txt_word.Text, translationRules);
                    w1 = null;
                }
            }
        }

        private void QuizEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmWelcome.Show();
        }
    }
}
