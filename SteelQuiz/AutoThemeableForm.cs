using SteelQuiz.Extensions;
using SteelQuiz.ThemeManager;
using SteelQuiz.ThemeManager.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public abstract class AutoThemeableForm : Form, IThemeable
    {
        private GeneralTheme GeneralTheme = new GeneralTheme();

        public void SetTheme()
        {
            BackColor = GeneralTheme.GetBackColor();

            foreach (var btn in this.GetAllChildrenRecursive(typeof(Button)))
            {
                btn.BackColor = GeneralTheme.GetButtonBackColor();
                btn.ForeColor = GeneralTheme.GetButtonForeColor();
            }

            foreach (var lbl in this.GetAllChildrenRecursive(typeof(Label)))
            {
                lbl.ForeColor = GeneralTheme.GetLabelForeColor();
            }

            foreach (var rdo in this.GetAllChildrenRecursive(typeof(RadioButton)))
            {
                rdo.ForeColor = GeneralTheme.GetLabelForeColor();
            }
        }
    }
}
