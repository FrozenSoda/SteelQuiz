using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public class ThemedForm : Form
    {
        public ThemedForm() : base()
        {
            foreach (var control in GetAll(this))
            {
                if (control is Button)
                {
                    if (control.BackColor == Color.FromArgb(80, 80, 80))
                    {
                        control.BackColor = ThemeColor.GetButtonBackColor();
                    }
                }
                else
                {
                    if (control.BackColor == Color.FromArgb(60, 60, 60))
                    {
                        control.BackColor = ThemeColor.GetBackColor();
                    }
                }
            }
        }

        /*
         * Get all child controls recursively
         */ 
        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }
    }
}
