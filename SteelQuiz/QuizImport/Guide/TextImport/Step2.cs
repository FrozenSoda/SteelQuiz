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
using static SteelQuiz.QuizImport.QuizImporter;

namespace SteelQuiz.QuizImport.Guide.TextImport
{
    public partial class Step2 : AutoThemeableUserControl, IStep
    {
        public ImportSource ImportSource { get; set; } = ImportSource.TextImport;
        public int Step { get; set; } = 2;

        public Step2()
        {
            InitializeComponent();

            SetTheme();
        }

        private void Rdo_addMultipleTranslationsAsSynonyms_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_multipleDefinitionsAsSynonyms.Checked)
            {
                var msg = MessageBox.Show("Warning! If this option is selected, you will not necessarily learn all the synonyms of the words (which are added" +
                    " to the quiz). Continue?",
                    "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                {
                    rdo_multipleDefinitionsAsSynonyms.Checked = false;
                    rdo_multipleDefinitionsAsSeparateCards.Checked = true;
                }
            }
        }
    }
}
