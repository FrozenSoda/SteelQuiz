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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SteelQuiz.Preferences
{
    public partial class PrefsStorage : AutoThemeableUserControl, IPreferenceCategory, ICustomSaveCategory
    {
        public PrefsStorage()
        {
            InitializeComponent();
            LoadPreferences();
            SetTheme();
        }

        private void Btn_browseQuizProgPath_Click(object sender, EventArgs e)
        {
            fbd_quizProgFolder.SelectedPath = Path.GetDirectoryName(ConfigManager.Config.StorageConfig.QuizProgressFile);
            if (fbd_quizProgFolder.ShowDialog() == DialogResult.OK)
            {
                txt_quizProgPath.Text = fbd_quizProgFolder.SelectedPath;
                Save(true);
            }
        }

        public void LoadPreferences()
        {
            txt_quizProgPath.Text = Path.GetDirectoryName(ConfigManager.Config.StorageConfig.QuizProgressFile);
            txt_defaultQuizSaveFolder.Text = ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder;
        }

        public bool Save(bool writeToDisk)
        {
            if (!Directory.Exists(txt_defaultQuizSaveFolder.Text))
            {
                MessageBox.Show("Specified default quiz save folder path doesn't exist", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder = txt_defaultQuizSaveFolder.Text;

            var oldPath = ConfigManager.Config.StorageConfig.QuizProgressFile;

            string newPath;
            if (txt_quizProgPath.Text == Path.GetDirectoryName(QuizCore.PROGRESS_FILE_DEFAULT))
            {
                // quiz progress file should have the filename "QuizProgress.json" in the default folder, for compatibility reasons
                newPath = QuizCore.PROGRESS_FILE_DEFAULT;
            }
            else
            {
                newPath = Path.Combine(txt_quizProgPath.Text, "SteelQuizProgress.json");
            }

            if (newPath == oldPath)
            {
                return true;
            }

            if (!Directory.Exists(Path.GetDirectoryName(newPath)))
            {
                MessageBox.Show("Selected directory to store quiz progress data in does not exist", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                QuizCore.BackupProgress();
            }
            catch (Exception ex)
            {
                txt_quizProgPath.Text = Path.GetDirectoryName(oldPath);
                throw ex;
            }

            if (File.Exists(newPath) && File.Exists(oldPath))
            {
                var conflictSolution = new QuizProgressConflict();
                if (conflictSolution.ShowDialog() != DialogResult.OK)
                {
                    txt_quizProgPath.Text = Path.GetDirectoryName(oldPath);
                    return false;
                }

                if (conflictSolution.ConflictResult == ConflictResult.MergePrioTarget)
                {
                    var merge = QuizProgressMerger.Merge(newPath, oldPath, newPath);
                    if (!merge)
                    {
                        return false;
                    }
                    File.Delete(oldPath);
                }
                else if (conflictSolution.ConflictResult == ConflictResult.MergePrioCurrent)
                {
                    var merge = QuizProgressMerger.Merge(oldPath, newPath, newPath);
                    if (!merge)
                    {
                        return false;
                    }
                    File.Delete(oldPath);
                }
                else if (conflictSolution.ConflictResult == ConflictResult.KeepTarget)
                {
                    try
                    {
                        QuizCore.BackupProgress();
                    }
                    catch (Exception ex)
                    {
                        txt_quizProgPath.Text = Path.GetDirectoryName(oldPath);
                        throw ex;
                    }
                    File.Delete(oldPath);
                }
                else if (conflictSolution.ConflictResult == ConflictResult.OverwriteTarget)
                {
                    try
                    {
                        QuizCore.BackupProgress();
                    }
                    catch (Exception ex)
                    {
                        txt_quizProgPath.Text = Path.GetDirectoryName(oldPath);
                        throw ex;
                    }
                    File.Delete(newPath);
                    File.Move(oldPath, newPath);
                }
            }
            else if (File.Exists(oldPath))
            {
                File.Move(oldPath, newPath);
            }

            ConfigManager.Config.StorageConfig.QuizProgressFile = newPath;

            if (writeToDisk)
            {
                ConfigManager.SaveConfig();
            }

            QuizCore.LoadQuizAccessData();
            // Reload quiz
            Program.frmWelcome.LoadedQuiz = QuizCore.LoadQuiz(Program.frmWelcome.LoadedQuiz.QuizIdentity.FindQuizPath());
            Program.frmWelcome.PopulateQuizList();
            Program.frmWelcome.UpdateQuizOverview();

            return true;
        }

        private void Btn_resetToDefaults_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Reset quiz progress folder path to the default value? Your current progress data will be moved to the new (default) path", "SteelQuiz",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
            {
                return;
            }

            txt_quizProgPath.Text = Path.GetDirectoryName(QuizCore.PROGRESS_FILE_DEFAULT);
            Save(true);
        }

        private void Txt_quizProgPath_Leave(object sender, EventArgs e)
        {
            Save(true);
        }

        private void btn_browseDefaultQuizSavePath_Click(object sender, EventArgs e)
        {
            fbd_defaultQuizSaveFolder.SelectedPath = ConfigManager.Config.StorageConfig.DefaultQuizSaveFolder;
            if (fbd_defaultQuizSaveFolder.ShowDialog() == DialogResult.OK)
            {
                txt_defaultQuizSaveFolder.Text = fbd_defaultQuizSaveFolder.SelectedPath;
                Save(true);
            }
        }

        private void btn_resetToDefaultsQuizSavePath_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Reset default quiz save folder path to the default value?", "SteelQuiz",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
            {
                return;
            }

            txt_defaultQuizSaveFolder.Text = QuizCore.QUIZ_FOLDER_DEFAULT;
            Save(true);
        }
    }
}
