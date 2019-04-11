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
using System.IO;
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizRecoveryUC : UserControl
    {
        public string RecoveryPath { get; set; }
        public string QuizPath { get; set; }
        public DateTime Date { get; set; }

        public QuizRecoveryUC(string recoveryPath)
        {
            InitializeComponent();

            RecoveryPath = recoveryPath;
            LoadProperties();
        }

        private void LoadProperties()
        {
            var recoveryFile = File.ReadAllText(RecoveryPath);
            var recovery = JsonConvert.DeserializeObject<QuizRecoveryData>(recoveryFile);

            QuizPath = recovery.QuizPath;
            Date = recovery.LastUpdated;

            lbl_recoveryPath.Text = $"Recovery path: {RecoveryPath}";
            lbl_quizPath.Text = $"Quiz path: {QuizPath}";
            lbl_date.Text = $"Auto-recovery-save date: {Date.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Are you sure you want to delete the recovery file? If the changes were not saved, they will be permanently lost",
                "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                return;
            }

            try
            {
                File.Delete(RecoveryPath);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the file:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            var recoveryFile = File.ReadAllText(RecoveryPath);
            var recovery = JsonConvert.DeserializeObject<QuizRecoveryData>(recoveryFile);

            ((QuizRecovery)Parent.Parent).QuizRecoveryData = recovery;
            ((QuizRecovery)Parent.Parent).DialogResult = DialogResult.OK;
        }
    }
}
