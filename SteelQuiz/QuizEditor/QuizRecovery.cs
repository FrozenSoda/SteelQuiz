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

using Newtonsoft.Json;
using SteelQuiz.QuizData;
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

namespace SteelQuiz.QuizEditor
{
    public partial class QuizRecovery : Form
    {
        public QuizRecoveryData QuizRecoveryData { get; set; }

        public QuizRecovery(string[] recoveryFiles)
        {
            InitializeComponent();

            foreach (var file in recoveryFiles)
            {
                lst_recovered.Items.Add(file);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var msg =
                MessageBox.Show("Are you sure you want to delete the selected quiz recovery file(s)? " +
                "If they were not saved, they will be permanently lost if you continue",
                "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                return;
            }

            var filesRemoved = new List<string>();

            foreach (var file in lst_recovered.SelectedItems.OfType<string>())
            {
                try
                {
                    File.Delete(file);
                    filesRemoved.Add(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the file:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            foreach (var file in filesRemoved)
            {
                lst_recovered.Items.Remove(file);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (lst_recovered.SelectedItems.Count < 1 || lst_recovered.SelectedItems.Count > 1)
            {
                MessageBox.Show("Only one quiz can be loaded at a time", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var recoveryFile = File.ReadAllText((string)lst_recovered.SelectedItems[0]);
            var recovery = JsonConvert.DeserializeObject<QuizRecoveryData>(recoveryFile);

            QuizRecoveryData = recovery;
            DialogResult = DialogResult.OK;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void UpdateButtonStates()
        {
            btn_load.Enabled = lst_recovered.SelectedItems.Count == 1;
            btn_delete.Enabled = lst_recovered.SelectedItems.Count > 0;
        }

        private void lst_recovered_Click(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void lst_recovered_DoubleClick(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void lst_recovered_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
    }
}
