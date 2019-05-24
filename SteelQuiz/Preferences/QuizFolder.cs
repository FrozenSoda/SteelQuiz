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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SteelQuiz.Preferences
{
    public partial class QuizFolder : AutoThemeableUserControl
    {
        public string QuizFolderPath
        {
            get
            {
                return txt_path.Text;
            }

            set
            {
                txt_path.Text = value;
            }
        }

        public QuizFolder(string path = null)
        {
            InitializeComponent();
            if (path == null)
            {
                if (fbd_path.ShowDialog() == DialogResult.OK)
                {
                    txt_path.Text = fbd_path.SelectedPath;
                }
            }
            else
            {
                txt_path.Text = path;
            }

            SetTheme();
        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Btn_browse_Click(object sender, EventArgs e)
        {
            if (txt_path.Text != "" && Directory.Exists(txt_path.Text))
            {
                fbd_path.SelectedPath = txt_path.Text;
            }
            else
            {
                fbd_path.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            
            if (fbd_path.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = fbd_path.SelectedPath;
            }
        }
    }
}
