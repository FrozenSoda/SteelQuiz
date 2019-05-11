using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager;

namespace SteelQuiz
{
    public class ThemedForm : Form
    {
        public ThemedForm() : base()
        {
            foreach (var control in GetAll(this))
            {
                if (control.BackColor == Color.FromArgb(60, 60, 60))
                {
                    control.BackColor = ThemeCore.
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
