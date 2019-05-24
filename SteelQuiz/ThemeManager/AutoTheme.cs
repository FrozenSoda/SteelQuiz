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

using SteelQuiz.Extensions;
using SteelQuiz.ThemeManager.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.ThemeManager
{
    public static class AutoTheme
    {
        private static GeneralTheme GeneralTheme = new GeneralTheme();

        public static void AutoSetTheme(Control control)
        {
            control.BackColor = GeneralTheme.GetBackColor();

            foreach (var btn in control.GetAllChildrenRecursive(typeof(Button)))
            {
                btn.BackColor = GeneralTheme.GetButtonBackColor();
                btn.ForeColor = GeneralTheme.GetButtonForeColor();
            }

            foreach (var lbl in control.GetAllChildrenRecursive(typeof(Label)))
            {
                lbl.ForeColor = GeneralTheme.GetMainLabelForeColor();
            }

            foreach (var chk in control.GetAllChildrenRecursive(typeof(CheckBox)))
            {
                chk.ForeColor = GeneralTheme.GetMainLabelForeColor();
            }

            foreach (var rdo in control.GetAllChildrenRecursive(typeof(RadioButton)))
            {
                rdo.ForeColor = GeneralTheme.GetMainLabelForeColor();
            }

            foreach (var pnl in control.GetAllChildrenRecursive(typeof(Panel)))
            {
                pnl.BackColor = GeneralTheme.GetBackColor();
            }

            foreach (var flp in control.GetAllChildrenRecursive(typeof(FlowLayoutPanel)))
            {
                flp.BackColor = GeneralTheme.GetBackColor();
            }

            foreach (var lst in control.GetAllChildrenRecursive(typeof(ListBox)))
            {
                lst.BackColor = GeneralTheme.GetBackColor();
                lst.ForeColor = GeneralTheme.GetMainLabelForeColor();
            }

            foreach (var txt in control.GetAllChildrenRecursive(typeof(TextBox)))
            {
                txt.BackColor = GeneralTheme.GetTextBoxBackColor();
                txt.ForeColor = GeneralTheme.GetTextBoxForeColor();
            }

            foreach (var nud in control.GetAllChildrenRecursive(typeof(NumericUpDown)))
            {
                nud.BackColor = GeneralTheme.GetTextBoxBackColor();
                nud.ForeColor = GeneralTheme.GetTextBoxForeColor();
            }

            foreach (var rtf in control.GetAllChildrenRecursive(typeof(RichTextBox)))
            {
                rtf.BackColor = GeneralTheme.GetTextBoxBackColor();
                rtf.ForeColor = GeneralTheme.GetTextBoxForeColor();
            }

            foreach (var cmb in control.GetAllChildrenRecursive(typeof(ComboBox)))
            {
                cmb.BackColor = GeneralTheme.GetTextBoxBackColor();
                cmb.ForeColor = GeneralTheme.GetTextBoxForeColor();
            }

            foreach (var mns in control.GetAllChildrenRecursive(typeof(MenuStrip)))
            {
                mns.ForeColor = GeneralTheme.GetMainLabelForeColor();
                mns.BackColor = GeneralTheme.GetBackColor();
                foreach (var tsmi in ((MenuStrip)mns).Items)
                {
                    ((ToolStripMenuItem)tsmi).ForeColor = GeneralTheme.GetMainLabelForeColor();
                }
            }
        }
    }
}
