﻿/*
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
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.Extensions;
using System.IO;

namespace SteelQuiz.Preferences
{
    public partial class PrefsQuizFolders : AutoThemeableUserControl, IPreferenceCategory, ICustomSaveCategory
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();
        private bool skipConfigApply = true;

        public PrefsQuizFolders()
        {
            InitializeComponent();

            LoadPreferences();
            SetTheme();
            skipConfigApply = false;
        }

        public void LoadPreferences()
        {
            foreach (var quizFolder in ConfigManager.Config.SyncConfig.QuizFolders)
            {
                dflp_quizFolders.Controls.Add(new QuizFolder(this, quizFolder));
            }
        }

        public void Save(bool saveConfig)
        {
            var quizFolders = new List<string>();
            var qfDispose = new List<QuizFolder>();

            foreach (var qf in dflp_quizFolders.ControlsOrdered().OfType<QuizFolder>())
            {
                if (Directory.Exists(qf.QuizFolderPath))
                {
                    quizFolders.Add(qf.QuizFolderPath);
                }
                else
                {
                    MessageBox.Show($"Folder '{qf.QuizFolderPath}' does not exist; it will be removed from the list", "SteelQuiz", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    qfDispose.Add(qf);
                }
            }

            ConfigManager.Config.SyncConfig.QuizFolders = quizFolders;
            if (saveConfig)
            {
                ConfigManager.SaveConfig();
            }

            foreach (var qf in qfDispose)
            {
                qf.Dispose();
            }
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            dflp_quizFolders.Controls.Add(new QuizFolder(this));
        }
    }
}