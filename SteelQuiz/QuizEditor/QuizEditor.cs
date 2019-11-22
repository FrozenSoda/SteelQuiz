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
    public partial class QuizEditor : AutoThemeableUndoRedoForm
    {
        //private const int EMPTY_WORD_PAIRS_COUNT = 2;
        private const int EMPTY_WORD_PAIRS_COUNT = 10;

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

            if (Program.openQuizEditors.Count > 0)
            {
                var last = Program.openQuizEditors.Last();
                WindowState = last.WindowState;
                if (WindowState == FormWindowState.Normal)
                {
                    Size = last.Size;
                }
            }
            else
            {
                WindowState = Program.frmWelcome.WindowState;
                if (WindowState == FormWindowState.Normal)
                {
                    Size = Program.frmWelcome.Size;
                }
            }

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
                var w = new QuizEditorWordPair(this, dflp_words.Controls.Count);
                dflp_words.Controls.Add(w);
                //dflp_words.SetFlowBreak(w, true);
                w.Size = new Size(dflp_words.Size.Width - 46, w.Size.Height);
            }
        }

        public QuizEditorWordPair PrevWord(int wordNumber)
        {
            return wordNumber > 0 ? dflp_words.Controls[wordNumber - 1] as QuizEditorWordPair : null;
        }

        public void RemoveQuizEditorWord()
        {
            dflp_words.Controls[dflp_words.Controls.Count - 1].Dispose();
        }

        public void ChkFixWordsCount()
        {
            // two empty word pairs should always be present
            var wps = dflp_words.Controls.OfType<QuizEditorWordPair>();
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
                qew.rtf_word1.Text == "" && qew.Synonyms1.IsNullOrEmpty() && qew.rtf_word2.Text == "" && qew.Synonyms2.IsNullOrEmpty()
                : false;
        }

        private void SetWordPairs(int count)
        {
            UndoStack.Clear();
            RedoStack.Clear();

            dflp_words.Controls.Clear();

            AddWordPair(count);
        }

        private Quiz ConstructQuiz()
        {
            var quiz = new Quiz(cmb_lang1.Text, cmb_lang2.Text, MetaData.QUIZ_FILE_FORMAT_VERSION);

            quiz.GUID = QuizGuid;

            ulong i = 0;
            foreach (var wordPair in dflp_words.ControlsOrdered().OfType<QuizEditorWordPair>().Where(x => !QEWordEmpty(x)))
            {
                wordPair.RemoveSynonymsEqualToWords();

                StringComp.Rules comparisonRules = wordPair.ComparisonRules.Data;

                var wp = new WordPair(wordPair.rtf_word1.Text, wordPair.rtf_word2.Text, comparisonRules, wordPair.Synonyms1, wordPair.Synonyms2);
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
                var ctrl = dflp_words.Controls.OfType<QuizEditorWordPair>().ElementAt(i);

                ctrl.alignOnResize = false;

                var wp = quiz.WordPairs[i];

                ctrl.rtf_word1.Text = wp.Word1;
                ctrl.Synonyms1 = wp.Word1Synonyms;
                ctrl.rtf_word2.Text = wp.Word2;
                ctrl.Synonyms2 = wp.Word2Synonyms;
                ctrl.ComparisonRules.Data = (StringComp.Rules)FixEnum(wp.TranslationRules);

                ctrl.alignOnResize = true;
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

        /// <summary>
        /// Fixes an enum that contains values that doesn't exist.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="theEnum">The enum.</param>
        /// <returns>Returns an integer representing the fixed enum.</returns>
        private int FixEnum<T>(T theEnum) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be enum type");
            }

            int result = 0x0;
            foreach (T val in (T[])Enum.GetValues(typeof(T)))
            {
                if ((Convert.ToInt32(theEnum) & Convert.ToInt32(val)) != 0)
                {
                    result |= Convert.ToInt32(val);
                }
            }

            return result;
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
            foreach (var wordPair in dflp_words.Controls.OfType<QuizEditorWordPair>())
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

                    Program.frmWelcome.WindowState = WindowState;
                    if (WindowState == FormWindowState.Normal)
                    {
                        Program.frmWelcome.Size = Size;
                    }

                    Program.frmWelcome.Show();
                    Program.openQuizEditors.Remove(this);
                }
                else
                {
                    Application.Exit();
                }
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

            if (QuizCore.LoadQuizAccessData())
            {
                QuizCore.QuizIdentities[quiz.GUID] = new QuizIdentity(quiz.GUID, QuizPath);
                QuizCore.QuizAccessTimes[quiz.GUID] = DateTime.Now;

                QuizCore.SaveQuizData();
            }

            UseWaitCursor = false;

            ShowNotification("Quiz has been saved", 3000);
            return true;
        }

        public override void UpdateUndoRedoTooltips()
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
            dflp_words.Size = new Size(this.Size.Width - 40, this.Size.Height - 124);

            foreach (var c in dflp_words.Controls.OfType<QuizEditorWordPair>())
            {
                c.Size = new Size(dflp_words.Size.Width - 46, c.Size.Height);
            }

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

            if (enableSmartComparisonToolStripMenuItem.CheckState == CheckState.Checked)
            {
                foreach (var wp in dflp_words.Controls.OfType<QuizEditorWordPair>())
                {
                    var compRules = wp.ComparisonRules.Data;
                    undoActions.Add(wp.ComparisonRules.SetSemiSilentUR(compRules));
                    redoActions.Add(wp.ComparisonRules.SetSemiSilentUR(StringComp.SMART_RULES));
                    wp.ComparisonRules.SetSemiSilent(StringComp.SMART_RULES);
                }

                UndoStack.Push(new UndoRedoFuncPair(
                    undoActions.ToArray(),
                    redoActions.ToArray(),
                    "Global enable Smart Comparison",
                    new OwnerControlData(this, this.Parent)
                    ));
            }
            else if (enableSmartComparisonToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                foreach (var wp in dflp_words.Controls.OfType<QuizEditorWordPair>())
                {
                    var compRules = wp.ComparisonRules.Data;
                    undoActions.Add(wp.ComparisonRules.SetSemiSilentUR(compRules));
                    redoActions.Add(wp.ComparisonRules.SetSemiSilentUR(StringComp.Rules.None));
                    wp.ComparisonRules.SetSemiSilent(StringComp.Rules.None);
                }

                UndoStack.Push(new UndoRedoFuncPair(
                    undoActions.ToArray(),
                    redoActions.ToArray(),
                    "Global disable Smart Comparison",
                    new OwnerControlData(this, this.Parent)
                    ));
            }

            UpdateUndoRedoTooltips();
            ChangedSinceLastSave = true;
        }

        public void SetGlobalSmartComparisonState()
        {
            Debug.Assert(
                !(StringComp.Rules.IgnoreFirstCapitalization
                | StringComp.Rules.TreatWordInParenthesisAsOptional
                | StringComp.Rules.TreatWordsBetweenSlashAsSynonyms
                | StringComp.Rules.IgnoreOpeningWhitespace
                | StringComp.Rules.IgnoreEndingWhitespace).HasFlag(StringComp.SMART_RULES));

            int fullEnableCount = dflp_words.Controls.OfType<QuizEditorWordPair>().Where(x => x.ComparisonRules.Data.HasFlag(StringComp.SMART_RULES)).Count();
            int totalCount = dflp_words.Controls.OfType<QuizEditorWordPair>().Count();

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

        private UndoRedoFuncPair SetGlobalRuleState(StringComp.Rules rules, bool enabled)
        {
            var undoActions = new List<Action>();
            var redoActions = new List<Action>();

            foreach (var wprules in dflp_words.Controls.OfType<QuizEditorWordPair>().Select(x => x.ComparisonRules))
            {
                StringComp.Rules newval;
                StringComp.Rules oldval = wprules.Data;

                if (enabled)
                {
                    newval = wprules.Data | rules;
                }
                else
                {
                    newval = wprules.Data & ~rules;
                }

                if (newval == oldval)
                {
                    continue;
                }

                undoActions.Add(wprules.SetSemiSilentUR(oldval));
                redoActions.Add(wprules.SetSemiSilentUR(newval));

                wprules.SetSemiSilent(newval);
            }

            return new UndoRedoFuncPair(
                    undoActions.ToArray(),
                    redoActions.ToArray(),
                    "Global set comparison rules state",
                    new OwnerControlData(this, this.Parent)
                    );
        }

        private void ModifySmartComparisonSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var smartCompSettings = new SmartComparisonSettings(dflp_words.Controls.OfType<QuizEditorWordPair>().Select(x => x.ComparisonRules.Data));
            var result = smartCompSettings.ShowDialog();
            var undoRedoes = new List<UndoRedoFuncPair>();

            if (result != DialogResult.OK)
            {
                return;
            }

            if (smartCompSettings.chk_ignoreCapitalizationFirstChar.CheckState == CheckState.Checked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreFirstCapitalization, true));
            }
            else if (smartCompSettings.chk_ignoreCapitalizationFirstChar.CheckState == CheckState.Unchecked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreFirstCapitalization, false));
            }


            if (smartCompSettings.chk_ignoreOpeningWhitespace.CheckState == CheckState.Checked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreOpeningWhitespace, true));
            }
            else if (smartCompSettings.chk_ignoreOpeningWhitespace.CheckState == CheckState.Unchecked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreOpeningWhitespace, false));
            }


            if (smartCompSettings.chk_ignoreEndingWhitespace.CheckState == CheckState.Checked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreEndingWhitespace, true));
            }
            else if (smartCompSettings.chk_ignoreEndingWhitespace.CheckState == CheckState.Unchecked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreEndingWhitespace, false));
            }


            if (smartCompSettings.chk_ignoreDotsInEnd.CheckState == CheckState.Checked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreDotsInEnd, true));
            }
            else if (smartCompSettings.chk_ignoreDotsInEnd.CheckState == CheckState.Unchecked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.IgnoreDotsInEnd, false));
            }


            if (smartCompSettings.chk_treatTextInParenthesisAsSynonym.CheckState == CheckState.Checked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.TreatWordInParenthesisAsOptional, true));
            }
            else if (smartCompSettings.chk_treatTextInParenthesisAsSynonym.CheckState == CheckState.Unchecked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.TreatWordInParenthesisAsOptional, false));
            }


            if (smartCompSettings.chk_treatWordsBetweenSlashAsSynonyms.CheckState == CheckState.Checked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.TreatWordsBetweenSlashAsSynonyms, true));
            }
            else if (smartCompSettings.chk_treatWordsBetweenSlashAsSynonyms.CheckState == CheckState.Unchecked)
            {
                undoRedoes.Add(SetGlobalRuleState(StringComp.Rules.TreatWordsBetweenSlashAsSynonyms, false));
            }

            UndoRedoFuncPair undoRedo = new UndoRedoFuncPair(undoRedoes.SelectMany(x => x.UndoActions).ToArray(), undoRedoes.SelectMany(x => x.RedoActions).ToArray(),
                "Global set comparison rules state", new OwnerControlData(this, this.Parent));

            if (undoRedo.UndoActions.Length > 0)
            {
                UndoStack.Push(undoRedo);

                ChangedSinceLastSave = true;
            }

            UpdateUndoRedoTooltips();
            SetGlobalSmartComparisonState();
        }

        private void dflp_words_Scroll(object sender, ScrollEventArgs e)
        {
            /*
            if (dflp_words.Controls.Count == 0)
            {
                return;
            }

            Debug.WriteLine(dflp_words.Controls[0].Location.Y);
            */
        }
    }
}
