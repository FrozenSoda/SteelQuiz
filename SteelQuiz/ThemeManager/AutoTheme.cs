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

        public static void AutoSetTheme(Control control, GeneralTheme theme = null)
        {
            if (theme == null)
            {
                theme = new GeneralTheme();
            }

            control.BackColor = theme.GetBackColor();

            foreach (var btn in control.GetAllChildrenRecursive(typeof(Button)))
            {
                btn.BackColor = theme.GetButtonBackColor();
                btn.ForeColor = theme.GetButtonForeColor();
            }

            foreach (var lbl in control.GetAllChildrenRecursive(typeof(Label)))
            {
                lbl.ForeColor = theme.GetMainLabelForeColor();
            }

            foreach (var chk in control.GetAllChildrenRecursive(typeof(CheckBox)))
            {
                chk.ForeColor = theme.GetMainLabelForeColor();
            }

            foreach (var rdo in control.GetAllChildrenRecursive(typeof(RadioButton)))
            {
                rdo.ForeColor = theme.GetMainLabelForeColor();
            }

            foreach (var pnl in control.GetAllChildrenRecursive(typeof(Panel)))
            {
                pnl.BackColor = theme.GetBackColor();
            }

            foreach (var flp in control.GetAllChildrenRecursive(typeof(FlowLayoutPanel)))
            {
                flp.BackColor = theme.GetBackColor();
            }

            foreach (var lst in control.GetAllChildrenRecursive(typeof(ListBox)))
            {
                lst.BackColor = theme.GetBackColor();
                lst.ForeColor = theme.GetMainLabelForeColor();
            }

            foreach (var txt in control.GetAllChildrenRecursive(typeof(TextBox)))
            {
                txt.BackColor = theme.GetTextBoxBackColor();
                txt.ForeColor = theme.GetTextBoxForeColor();
            }

            foreach (var nud in control.GetAllChildrenRecursive(typeof(NumericUpDown)))
            {
                nud.BackColor = theme.GetTextBoxBackColor();
                nud.ForeColor = theme.GetTextBoxForeColor();
            }

            foreach (var rtf in control.GetAllChildrenRecursive(typeof(RichTextBox)))
            {
                rtf.BackColor = theme.GetTextBoxBackColor();
                rtf.ForeColor = theme.GetTextBoxForeColor();
            }

            foreach (var cmb in control.GetAllChildrenRecursive(typeof(ComboBox)))
            {
                cmb.BackColor = theme.GetTextBoxBackColor();
                cmb.ForeColor = theme.GetTextBoxForeColor();
            }

            foreach (var mns in control.GetAllChildrenRecursive(typeof(MenuStrip)))
            {
                mns.ForeColor = theme.GetMainLabelForeColor();
                mns.BackColor = theme.GetBackColor();
                foreach (var tsmi in ((MenuStrip)mns).Items)
                {
                    ((ToolStripMenuItem)tsmi).ForeColor = theme.GetMainLabelForeColor();
                }
            }

            foreach (var a in control.GetAllChildrenRecursiveDerives(typeof(AutoThemeableUserControl)).Cast<AutoThemeableUserControl>())
            {
                a.SetTheme();
            }
        }
    }
}
