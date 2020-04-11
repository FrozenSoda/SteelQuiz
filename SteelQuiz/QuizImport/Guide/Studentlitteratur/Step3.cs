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

namespace SteelQuiz.QuizImport.Guide.Studentlitteratur
{
    public partial class Step3 : AutoThemeableUserControl, IStep
    {
        public ImportSource ImportSource { get; set; } = ImportSource.Studentlitteratur;
        public int Step { get; set; } = 3;

        public Step3(QuizImporter.ImportSource importSource)
        {
            InitializeComponent();

            if (importSource == QuizImporter.ImportSource.Studentlitteratur)
            {
                lbl_instructions.Text = "To find it:\r\n\r\n1. Start the exercise.\r\n2. Open developer tools in your browser (Ctrl+Shift+I in Chrome).\r\n" +
                    "3. Go to the Network tab.\r\n4. Write/click on one word in the exercise and press ENTER.\r\n5. Double click the entry which appeared in the Network tab." +
                    "\r\n6. Copy the URL of the opened tab and paste it in the URL field in SteelQuiz.\r\n\r\nSupported exercises: Spelling, Vocabulary bank and Idioms" +
                    "\r\nTrying to import an unsupported exercise might cause an error, or undefined behavior.";
            }

            SetTheme();
        }

        private void Txt_url_DoubleClick(object sender, EventArgs e)
        {
            txt_url.SelectAll();
            txt_url.Focus();
        }
    }
}
