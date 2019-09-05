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
using static SteelQuiz.QuizImport.QuizImporter;

namespace SteelQuiz.QuizImport.Guide.TextImport
{
    public partial class Step4 : AutoThemeableUserControl, IStep
    {
        public ImportSource ImportSource { get; set; } = ImportSource.TextImport;
        public int Step { get; set; } = 4;

        public string QuizFolder
        {
            get
            {
                foreach (var rdo in flp_quizFolders.Controls.OfType<RadioButton>())
                {
                    if (rdo.Checked)
                    {
                        return rdo.Text;
                    }
                }

                return null;
            }
        }

        public Step4()
        {
            InitializeComponent();
            for (int i = 0; i < ConfigManager.Config.SyncConfig.QuizFolders.Count; ++i)
            {
                var folder = ConfigManager.Config.SyncConfig.QuizFolders[i];

                var rdo = new RadioButton();
                rdo.AutoSize = true;
                rdo.MaximumSize = new Size(flp_quizFolders.Size.Width - 20, 0);
                rdo.Text = folder;
                rdo.Font = new Font("Segoe UI", 12);
                if (i == 0)
                {
                    rdo.Checked = true;
                }
                else
                {
                    rdo.Checked = false;
                }
                flp_quizFolders.Controls.Add(rdo);
            }
            SetTheme();
        }
    }
}
