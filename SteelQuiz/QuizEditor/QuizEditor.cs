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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SteelQuiz.QuizData;
using SteelQuiz.QuizEditor.UndoRedo;
using SteelQuiz.QuizPractise;
using SteelQuiz.Util;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizEditor : AutoThemeableForm, IUndoRedo
    {
        private const int EMPTY_WORD_PAIRS_COUNT = 2;

        public Stack<UndoRedoFuncPair> UndoStack { get; set; } = new Stack<UndoRedoFuncPair>();
        public Stack<UndoRedoFuncPair> RedoStack { get; set; } = new Stack<UndoRedoFuncPair>();

        public bool UpdateUndoRedoStacks { get; private set; } = true;

        public bool ChangedSinceLastSave { get; set; } = false;

        private string _quizPath = null;
        private string QuizPath
        {
            get
            {
                return _quizPath;
            }

            set
            {
                _quizPath = value;
                this.Text = $"{ Path.GetFileName(value) } - Quiz Editor | SteelQuiz";
            }
        }

        private Guid QuizGuid { get; set; } = Guid.NewGuid();
        private QuizRecoveryData QuizRecoveryData { get; set; }

        private bool returningToMainMenu = false;

        public QuizEditor(bool chkRecovery = true)
        {
            InitializeComponent();
            ++Program.QuizEditorsOpen;
            this.Location = new Point(Program.frmWelcome.Location.X + (Program.frmWelcome.Size.Width / 2) - (this.Size.Width / 2),
                              Program.frmWelcome.Location.Y + (Program.frmWelcome.Size.Height / 2) - (this.Size.Height / 2)
                            );
            AddWordPair(EMPTY_WORD_PAIRS_COUNT);
            QuizRecoveryData = new QuizRecoveryData(QuizPath);
            if (chkRecovery)
            {
                ChkRecovery();
            }

            SetTheme();

            this.Text += $" | v{Application.ProductVersion}";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += " PRE-RELEASE";
            }
        }

        public void ChkRecovery()
        {
            var recoveryFiles = Directory.GetFiles(QuizCore.QUIZ_RECOVERY_FOLDER);
            if (recoveryFiles.Length > 0)
            {
                var quizRecovery = new QuizRecovery(recoveryFiles);
                if (quizRecovery.ShowDialog() == DialogResult.OK)
                {
                    QuizRecoveryData = quizRecovery.QuizRecoveryData;
                    //QuizPath = quizRecovery.QuizRecoveryData.QuizPath;
                    LoadQuiz(quizRecovery.QuizRecoveryData.Quiz, quizRecovery.QuizRecoveryData.QuizPath, true);
                    ChangedSinceLastSave = true;
                }
            }
        }

        public void AddWordPair(int count = 1)
        {
            for (int i = 0; i < count; ++i)
            {
                var w = new QuizEditorWordPair(this, flp_words.Controls.Count);
                flp_words.Controls.Add(w);
            }
        }

        public QuizEditorWordPair PrevWord(int wordNumber)
        {
            return wordNumber > 0 ? flp_words.Controls[wordNumber - 1] as QuizEditorWordPair : null;
        }

        public void RemoveQuizEditorWord()
        {
            flp_words.Controls[flp_words.Controls.Count - 1].Dispose();
        }

        public void ChkFixWordsCount()
        {
            // two empty word pairs should always be present
            var wps = flp_words.Controls.OfType<QuizEditorWordPair>();
            int emptyCount = wps.Where(x => QEWordEmpty(x)).Count();
            while (emptyCount > EMPTY_WORD_PAIRS_COUNT && QEWordEmpty(wps.ElementAt(wps.Count() - 1)))
            {
                RemoveQuizEditorWord();
                emptyCount = wps.Where(x => QEWordEmpty(x)).Count();
            }
            while (emptyCount < EMPTY_WORD_PAIRS_COUNT)
            {
                AddWordPair();
                emptyCount = wps.Where(x => QEWordEmpty(x)).Count();
            }
        }

        private bool QEWordEmpty(QuizEditorWordPair qew)
        {
            return qew != null ?
                qew.txt_word1.Text == "" && qew.Synonyms1.IsNullOrEmpty() && qew.txt_word2.Text == "" && qew.Synonyms2.IsNullOrEmpty()
                : false;
        }

        private void SetWordPairs(int count)
        {
            UndoStack.Clear();
            RedoStack.Clear();

            flp_words.Controls.Clear();

            AddWordPair(count);
        }

        private Quiz ConstructQuiz()
        {
            var quiz = new Quiz(cmb_lang1.Text, cmb_lang2.Text, MetaData.QUIZ_FILE_FORMAT_VERSION);

            quiz.GUID = QuizGuid;

            ulong i = 0;
            foreach (var wordPair in flp_words.Controls.OfType<QuizEditorWordPair>().Where(x => !QEWordEmpty(x)))
            {
                wordPair.RemoveSynonymsEqualToWords();

                StringComp.Rules comparisonRules = StringComp.Rules.None;
                if (wordPair.chk_smartComp.Checked)
                {
                    comparisonRules = wordPair.ComparisonRules.Data;
                }

                var wp = new WordPair(wordPair.txt_word1.Text, wordPair.txt_word2.Text, comparisonRules, wordPair.Synonyms1, wordPair.Synonyms2);
                quiz.WordPairs.Add(wp);
                ++i;
            }

            return quiz;
        }

        public void LoadQuiz(Quiz quiz = null, string quizPath = null, bool fromRecovery = false)
        {
            if (ChangedSinceLastSave)
            {
                //var msg = MessageBox.Show("You have unsaved changes. Save before loading a new quiz?", "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                var saveDontSave = new SaveDontSave(this, SystemIcons.Warning, true, "The project contains unsaved changes. Save before loading a new quiz?",
                    "Save before loading new quiz? - SteelQuiz");
                saveDontSave.ShowDialog();
                if (saveDontSave.SaveDialogResult == SaveDontSave.SaveResult.Save)
                {
                    if (!SaveQuiz())
                    {
                        return;
                    }
                }
                else if (saveDontSave.SaveDialogResult == SaveDontSave.SaveResult.Cancel)
                {
                    return;
                }
            }

            if (!fromRecovery)
            {
                DeleteRecovery();
            }

            if (quiz == null)
            {
                //ofd_quiz.InitialDirectory = ConfigManager.Config.SyncConfig.QuizFolders[0];
                var ofd = ofd_quiz.ShowDialog();
                if (ofd == DialogResult.OK)
                {
                    QuizPath = ofd_quiz.FileName;
                }
                else
                {
                    return;
                }

                try
                {
                    quiz = JsonConvert.DeserializeObject<Quiz>(AtomicIO.AtomicRead(QuizPath));
                }
                catch (AtomicException ex)
                {
                    // Should never be reached as path exists
                    throw ex;
                }
            }

            if (quizPath != null)
            {
                QuizPath = quizPath;
            }

            UpdateUndoRedoStacks = false;

            SetWordPairs(quiz.WordPairs.Count + 2);

            QuizGuid = quiz.GUID;
            cmb_lang1.Text = quiz.Language1;
            cmb_lang2.Text = quiz.Language2;

            for (int i = 0; i < quiz.WordPairs.Count; ++i)
            {
                var ctrl = flp_words.Controls.OfType<QuizEditorWordPair>().ElementAt(i);
                var wp = quiz.WordPairs[i];

                ctrl.txt_word1.Text = wp.Word1;
                ctrl.Synonyms1 = wp.Word1Synonyms;
                ctrl.txt_word2.Text = wp.Word2;
                ctrl.Synonyms2 = wp.Word2Synonyms;
                ctrl.ComparisonRules.Data = wp.TranslationRules;
            }

            if (!fromRecovery)
            {
                QuizRecoveryData = new QuizRecoveryData(QuizPath);
                ChangedSinceLastSave = false;
            }

            UndoStack.Clear();
            RedoStack.Clear();
            UpdateUndoRedoStacks = true;

            SetGlobalSmartComparisonState();
        }

        private void DeleteRecovery()
        {
            if (File.Exists(QuizRecoveryData.RecoveryFilePath))
            {
                try
                {
                    File.Delete(QuizRecoveryData.RecoveryFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting recovery files:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        public bool SaveBeforeExit()
        {
            foreach (var wordPair in flp_words.Controls.OfType<QuizEditorWordPair>())
            {
                if (wordPair.EditWordSynonyms != null)
                {
                    if (!wordPair.EditWordSynonyms.ApplyChanges(true))
                    {
                        return false;
                    }
                    wordPair.DisposeEditWordSynonyms();
                }
            }

            var saveDontSave = new SaveDontSave(this, SystemIcons.Warning, true);
            saveDontSave.ShowDialog();
            if (saveDontSave.SaveDialogResult == SaveDontSave.SaveResult.Save)
            {
                if (!SaveQuiz())
                {
                    return false;
                }
            }
            else if (saveDontSave.SaveDialogResult == SaveDontSave.SaveResult.Cancel)
            {
                return false;
            }

            ChangedSinceLastSave = false;
            return true;
        }

        private void QuizEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangedSinceLastSave)
            {
                if (!SaveBeforeExit())
                {
                    e.Cancel = true;
                    return;
                }
            }

            DeleteRecovery();

            if (--Program.QuizEditorsOpen == 0)
            {
                if (Updater.UpdateExitInProgress)
                {
                    // do nothing
                }
                else if (returningToMainMenu || !ConfigManager.Config.QuizEditorConfig.CloseApplicationOnEditorClose)
                {
                    Hide();
                    Program.frmWelcome.PopulateQuizList();
                    Program.frmWelcome.SetControlStates();
                    Program.frmWelcome.GenerateWelcomeMsg();
                    Program.frmWelcome.Show();
                    Program.openQuizEditors.Remove(this);
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public void Undo()
        {
            if (!UpdateUndoRedoStacks)
            {
                return;
            }

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
                    foreach (var qwrd in flp_words.Controls.OfType<QuizEditorWordPair>())
                    {
                        if (peek.OwnerControlData.Parent == qwrd)
                        {
                            qwrd.InitEditWordSynonyms(peek.OwnerControlData.Language);
                            qwrd.EditWordSynonyms.Undo();
                            qwrd.EditWordSynonyms.ApplyChanges();
                            if (peek.OwnerControlData.Language == 1)
                            {
                                qwrd.Synonyms1 = qwrd.EditWordSynonyms.Synonyms;
                            }
                            else
                            {
                                qwrd.Synonyms2 = qwrd.EditWordSynonyms.Synonyms;
                            }
                            qwrd.DisposeEditWordSynonyms();
                            break;
                        }
                    }
                }

                UpdateUndoRedoTooltips();
                ChangedSinceLastSave = true;
            }
        }

        public void Redo()
        {
            if (!UpdateUndoRedoStacks)
            {
                return;
            }

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
                    UpdateUndoRedoTooltips();
                }
                else if (peek.OwnerControlData.Control is EditWordSynonyms)
                {
                    foreach (var qwrd in flp_words.Controls.OfType<QuizEditorWordPair>())
                    {
                        if (peek.OwnerControlData.Parent == qwrd)
                        {
                            qwrd.InitEditWordSynonyms(peek.OwnerControlData.Language);
                            qwrd.EditWordSynonyms.Redo();
                            qwrd.EditWordSynonyms.ApplyChanges();
                            if (peek.OwnerControlData.Language == 1)
                            {
                                qwrd.Synonyms1 = qwrd.EditWordSynonyms.Synonyms;
                            }
                            else
                            {
                                qwrd.Synonyms2 = qwrd.EditWordSynonyms.Synonyms;
                            }
                            qwrd.DisposeEditWordSynonyms();
                            break;
                        }
                    }
                }

                UpdateUndoRedoTooltips();
                ChangedSinceLastSave = true;
            }
        }

        private bool SaveQuiz(bool saveAs = false, string customPath = null)
        {
            string path = null;
            if (customPath == null)
            {
                if (QuizPath == null || saveAs)
                {
                    sfd_quiz.InitialDirectory = ConfigManager.Config.SyncConfig.QuizFolders[0];
                    int untitledCounter = 1;
                    path = $"Untitled{ untitledCounter }.steelquiz";
                    while (File.Exists(Path.Combine(QuizCore.QUIZ_FOLDER_DEFAULT, path)))
                    {
                        ++untitledCounter;
                        path = $"Untitled{ untitledCounter }.steelquiz";
                    }

                    var sfd = sfd_quiz.ShowDialog();
                    if (sfd != DialogResult.OK)
                    {
                        return false;
                    }

                    if (QuizPath != sfd_quiz.FileName)
                    {
                        QuizGuid = Guid.NewGuid(); // create new guid if path is not the same
                    }
                    path = sfd_quiz.FileName;
                }
                else
                {
                    path = QuizPath;
                }
            }
            else
            {
                path = customPath;
            }

            UseWaitCursor = true;

            var quiz = ConstructQuiz();
            AtomicIO.AtomicWrite(path, JsonConvert.SerializeObject(quiz, Formatting.Indented));

            if (customPath == null)
            {
                QuizPath = path;
                ChangedSinceLastSave = false;
            }

            UseWaitCursor = false;

            ShowNotification("Quiz has been saved", 3000);
            return true;
        }

        public void UpdateUndoRedoTooltips()
        {
            if (UndoStack.Count > 0)
            {
                undoToolStripMenuItem.Text = $"Undo {UndoStack.Peek().Description}";
            }
            else
            {
                undoToolStripMenuItem.Text = "Undo";
            }

            if (RedoStack.Count > 0)
            {
                redoToolStripMenuItem.Text = $"Redo {RedoStack.Peek().Description}";
            }
            else
            {
                redoToolStripMenuItem.Text = "Redo";
            }
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
            // resize wordpair collection
            flp_words.Size = new Size(this.Size.Width - 40, this.Size.Height - 124);

            /*
            // resize notification
            int msgWidth = Convert.ToInt32(Size.Width * (277D / 816D));
            int msgHeight = Convert.ToInt32(Size.Height * (100D / 489D));
            pnl_msg.Size = new Size(msgWidth, msgHeight);
            */
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewQuiz();
        }

        private void NewQuiz()
        {
            if (ChangedSinceLastSave)
            {
                //var msg = MessageBox.Show("You have unsaved changes. Save before creating a new quiz?", "SteelQuiz", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                var saveDontSave = new SaveDontSave(this, SystemIcons.Warning, true, "The project contains unsaved changes. Save before creating a new quiz?",
                    "Save before creating new quiz? - SteelQuiz");
                saveDontSave.ShowDialog();
                if (saveDontSave.SaveDialogResult == SaveDontSave.SaveResult.Save)
                {
                    if (!SaveQuiz())
                    {
                        return;
                    }
                }
                else if (saveDontSave.SaveDialogResult == SaveDontSave.SaveResult.Cancel)
                {
                    return;
                }
            }

            Program.OpenQuizEditor(null, null, false);
            //var quizEditor = new QuizEditor(false);
            //quizEditor.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            returningToMainMenu = true;
            Close();
        }

        private void QuizEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                // CTRL is pressed

                switch (e.KeyCode)
                {
                    case Keys.Z:
                        Undo();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;

                    case Keys.Y:
                        Redo();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;

                    case Keys.S:
                        SaveQuiz();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;

                    case Keys.N:
                        NewQuiz();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;

                    case Keys.O:
                        LoadQuiz();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }

        private void UpdateRecoverySave()
        {
            var quiz = ConstructQuiz();
            QuizRecoveryData.Save(quiz);
        }

        private void tmr_autoRecoverySave_Tick(object sender, EventArgs e)
        {
            UpdateRecoverySave();
        }

        public void ShowNotification(string msg, int showMillis)
        {
            pnl_msg.Visible = true;
            var notif = new EditorNotification(msg, showMillis);
            notif.Dock = DockStyle.Fill;
            pnl_msg.Controls.Add(notif);
            notif.BringToFront();
        }

        public bool RemoveNotification(Guid guid)
        {
            foreach (var notif in pnl_msg.Controls.OfType<EditorNotification>())
            {
                if (notif.GUID == guid)
                {
                    notif.Dispose();
                    return true;
                }
            }

            return false;
        }

        private void Pnl_msg_SizeChanged(object sender, EventArgs e)
        {
            /*
            int locXanchor = Size.Width - 305;
            int locYanchor = Size.Height - 151;
            pnl_msg.Location = new Point(locXanchor + (277 - pnl_msg.Size.Width), locYanchor + (100 - pnl_msg.Size.Height));
            */
        }

        private void Cmb_lang1_TextUpdate(object sender, EventArgs e)
        {
            ChangedSinceLastSave = true;
        }

        private void Cmb_lang2_TextUpdate(object sender, EventArgs e)
        {
            ChangedSinceLastSave = true;
        }

        private void EnableSmartComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var undoActions = new List<Action>();
            var redoActions = new List<Action>();

            if (enableSmartComparisonToolStripMenuItem.Checked)
            {
                foreach (var wp in flp_words.Controls.OfType<QuizEditorWordPair>())
                {
                    var compRules = wp.ComparisonRules.Data;
                    undoActions.Add(new Action(wp.ComparisonRules.Set(compRules)));
                    redoActions.Add(new Action(wp.ComparisonRules.Set(StringComp.SMART_RULES)));
                    wp.ComparisonRules.Data = StringComp.SMART_RULES;
                }

                UndoStack.Push(new UndoRedoFuncPair(
                    undoActions.ToArray(),
                    redoActions.ToArray(),
                    "Global enable Smart Comparison",
                    new OwnerControlData(this, this.Parent)
                    ));
            }
            else
            {
                foreach (var wp in flp_words.Controls.OfType<QuizEditorWordPair>())
                {
                    var compRules = wp.ComparisonRules.Data;
                    undoActions.Add(new Action(wp.ComparisonRules.Set(compRules)));
                    redoActions.Add(new Action(wp.ComparisonRules.Set(StringComp.Rules.None)));
                    wp.ComparisonRules.Data = StringComp.Rules.None;
                }

                UndoStack.Push(new UndoRedoFuncPair(
                    undoActions.ToArray(),
                    redoActions.ToArray(),
                    "Global disable Smart Comparison",
                    new OwnerControlData(this, this.Parent)
                    ));
            }

            UpdateUndoRedoTooltips();
        }

        public void SetGlobalSmartComparisonState()
        {
            Debug.Assert(
                !(StringComp.Rules.IgnoreFirstCapitalization
                | StringComp.Rules.TreatWordInParenthesisAsOptional
                | StringComp.Rules.TreatWordsBetweenSlashAsSynonyms
                | StringComp.Rules.IgnoreOpeningWhitespace
                | StringComp.Rules.IgnoreEndingWhitespace).HasFlag(StringComp.SMART_RULES));

            int fullEnableCount = flp_words.Controls.OfType<QuizEditorWordPair>().Where(x => x.ComparisonRules.Data.HasFlag(StringComp.SMART_RULES)).Count();
            int totalCount = flp_words.Controls.OfType<QuizEditorWordPair>().Count();

            if (fullEnableCount == totalCount)
            {
                enableSmartComparisonToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else if (fullEnableCount < totalCount && fullEnableCount > 0)
            {
                enableSmartComparisonToolStripMenuItem.CheckState = CheckState.Indeterminate;
            }
            else if (fullEnableCount == 0)
            {
                enableSmartComparisonToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else
            {
                // should not happen
                throw new Exception("SetGlobalSmartComparisonState() reached end");
            }
        }
    }
}
