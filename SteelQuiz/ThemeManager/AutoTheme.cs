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
