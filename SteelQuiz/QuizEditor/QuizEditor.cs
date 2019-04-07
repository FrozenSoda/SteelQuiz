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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SteelQuiz.QuizData;
using SteelQuiz.QuizEditor.UndoRedo;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizEditor : Form, IUndoRedo
    {
        private string QuizPath { get; set; } = null;

        //private List<QuizEditorWord> quizEditorWords_lang1 = new List<QuizEditorWord>();
        //private List<QuizEditorWord> quizEditorWords_lang2 = new List<QuizEditorWord>();

        public Stack<UndoRedoFuncPair> UndoStack { get; set; } = new Stack<UndoRedoFuncPair>();
        public Stack<UndoRedoFuncPair> RedoStack { get; set; } = new Stack<UndoRedoFuncPair>();

        public QuizEditor()
        {
            InitializeComponent();
            this.Location = new Point(Program.frmWelcome.Location.X + (Program.frmWelcome.Size.Width / 2) - (this.Size.Width / 2),
                              Program.frmWelcome.Location.Y + (Program.frmWelcome.Size.Height / 2) - (this.Size.Height / 2)
                            );
            AddWordPair(2);
        }

        private void AddWordPair(int count = 1)
        {
            for (int i = 0; i < count; ++i)
            {
                var w1 = new QuizEditorWord(true);
                //quizEditorWords_lang1.Add(w1);
                flp_words.Controls.Add(w1);

                var w2 = new QuizEditorWord(false);
                //quizEditorWords_lang2.Add(w2);
                flp_words.Controls.Add(w2);
            }
        }

        private void SetWordPairs(int count)
        {
            flp_words.Controls.Clear();

            for (int i = 0; i < count; ++i)
            {
                var w1 = new QuizEditorWord(true);
                //quizEditorWords_lang1.Add(w1);
                flp_words.Controls.Add(w1);

                var w2 = new QuizEditorWord(false);
                //quizEditorWords_lang2.Add(w2);
                flp_words.Controls.Add(w2);
            }
        }

        private Quiz ConstructQuiz()
        {
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
                    var w2 = word;

                    StringComp.Rules translationRules = StringComp.Rules.None;
                    if (w1.chk_ignoreCapitalization.Checked)
                    {
                        translationRules |= StringComp.Rules.IgnoreCapitalization;
                    }
                    if (w1.chk_ignoreExcl.Checked)
                    {
                        translationRules |= StringComp.Rules.IgnoreExclamation;
                    }

                    var wordPair = new WordPair(w1.txt_word.Text, w2.txt_word.Text, translationRules, w1.Synonyms, w2.Synonyms);
                    quiz.WordPairs.Add(wordPair);
                    
                    w1 = null;
                }
            }

            return quiz;
        }

        private void LoadQuiz()
        {
            var ofd = ofd_quiz.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                QuizPath = ofd_quiz.FileName;
            }
            else
            {
                return;
            }

            Quiz quiz;

            using (var reader = new StreamReader(QuizPath))
            {
                quiz = JsonConvert.DeserializeObject<Quiz>(reader.ReadToEnd());
            }

            SetWordPairs(quiz.WordPairs.Count + 2);

            int i = 0;
            int j = 0;

            for (; i < quiz.WordPairs.Count && j < quiz.WordPairs.Count; ++i, j += 2)
            {
                var ctrl1 = flp_words.Controls.OfType<QuizEditorWord>().ElementAt(j);
                var ctrl2 = flp_words.Controls.OfType<QuizEditorWord>().ElementAt(j + 1);
                var wp = quiz.WordPairs[i];

                ctrl1.txt_word.Text = wp.Word1;
                ctrl1.Synonyms = wp.Word1Synonyms;
                ctrl2.txt_word.Text = wp.Word2;
                ctrl2.Synonyms = wp.Word2Synonyms;
            }
        }

        private void QuizEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmWelcome.Show();
        }

        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                var peek = UndoStack.Peek();
                if (peek.OwnerControlData.Control == this || this.Controls.Contains(peek.OwnerControlData.Parent))
                {
                    var pop = UndoStack.Pop();
                    foreach (var undo in pop.UndoActions)
                    {
                        undo();
                    }
                    RedoStack.Push(pop);
                }
                else if (peek.OwnerControlData.Control is EditWordSynonyms)
                {
                    foreach (var qwrd in flp_words.Controls.OfType<QuizEditorWord>())
                    {
                        if (peek.OwnerControlData.Parent == qwrd)
                        {
                            qwrd.InitEditWordSynonyms();
                            qwrd.EditWordSynonyms.Undo();
                            qwrd.EditWordSynonyms.ApplyChanges();
                            qwrd.Synonyms = qwrd.EditWordSynonyms.Synonyms;
                            qwrd.DisposeEditWordSynonyms();
                            break;
                        }
                    }
                }
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                var peek = RedoStack.Peek();
                if (peek.OwnerControlData.Control == this || this.Controls.Contains(peek.OwnerControlData.Parent))
                {
                    var pop = RedoStack.Pop();
                    foreach (var redo in pop.RedoActions)
                    {
                        redo();
                    }
                    UndoStack.Push(pop);
                }
                else if (peek.OwnerControlData.Control is EditWordSynonyms)
                {
                    foreach (var qwrd in flp_words.Controls.OfType<QuizEditorWord>())
                    {
                        if (peek.OwnerControlData.Parent == qwrd)
                        {
                            qwrd.InitEditWordSynonyms();
                            qwrd.EditWordSynonyms.Redo();
                            qwrd.EditWordSynonyms.ApplyChanges();
                            qwrd.Synonyms = qwrd.EditWordSynonyms.Synonyms;
                            qwrd.DisposeEditWordSynonyms();
                            break;
                        }
                    }
                }
            }
        }

        private void SaveQuiz(bool saveAs = false)
        {
            if (QuizPath == null || saveAs)
            {
                sfd_quiz.InitialDirectory = QuizCore.QUIZ_FOLDER;
                int untitledCounter = 1;
                sfd_quiz.FileName = $"Untitled{ untitledCounter }.steelquiz";
                while (File.Exists(Path.Combine(QuizCore.QUIZ_FOLDER, sfd_quiz.FileName)))
                {
                    ++untitledCounter;
                    sfd_quiz.FileName = $"Untitled{ untitledCounter }.steelquiz";
                }

                var sfd = sfd_quiz.ShowDialog();
                if (sfd == DialogResult.OK)
                {
                    QuizPath = sfd_quiz.FileName;
                }
                else
                {
                    return;
                }
            }

            UseWaitCursor = true;

            var quiz = ConstructQuiz();
            using (var writer = new StreamWriter(QuizPath, false))
            {
                writer.Write(JsonConvert.SerializeObject(quiz, Formatting.Indented));
            }

            UseWaitCursor = false;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuiz();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuiz(true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadQuiz();
        }

        private void QuizEditor_SizeChanged(object sender, EventArgs e)
        {
            flp_words.Size = new Size(this.Size.Width - 40, this.Size.Height - 174);
        }
    }
}
