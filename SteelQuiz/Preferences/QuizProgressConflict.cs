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

namespace SteelQuiz.Preferences
{
    public enum ConflictResult
    {
        /// <summary>
        /// Tries to merge both progress data files, but prioritizes progress data from the file in the selected folder, if it can't decide which 
        /// progress data to keep for a specific quiz
        /// </summary>
        MergePrioTarget,

        /// <summary>
        /// Tries to merge both progress data files, but prioritizes progress data from the file in the current folder, if it can't decide which 
        /// progress data to keep for a specific quiz
        /// </summary>
        MergePrioCurrent,

        /// <summary>
        /// Remove the currently used progress data file, and use the one in the selected folder
        /// </summary>
        KeepTarget,

        /// <summary>
        /// Overwrite the progress data file in the target, with the currently used one
        /// </summary>
        OverwriteTarget
    }

    public partial class QuizProgressConflict : AutoThemeableForm
    {
        public ConflictResult ConflictResult { get; set; }

        public QuizProgressConflict()
        {
            InitializeComponent();
            SetTheme();
        }

        private void Btn_continue_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Confirm selection", "SteelQuiz", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (msg != DialogResult.OK)
            {
                return;
            }

            if (rdo_mergePrioTarget.Checked)
            {
                ConflictResult = ConflictResult.MergePrioTarget;
            }
            else if (rdo_mergePrioCurrent.Checked)
            {
                ConflictResult = ConflictResult.MergePrioCurrent;
            }
            else if (rdo_keepTarget.Checked)
            {
                ConflictResult = ConflictResult.KeepTarget;
            }
            else
            {
                ConflictResult = ConflictResult.OverwriteTarget;
            }

            DialogResult = DialogResult.OK;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
