using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor.UndoRedo
{
    public class OwnerControlData
    {
        public Control Control { get; set; }
        public Control Parent { get; set; }

        public OwnerControlData(Control control, Control parent)
        {
            Control = control;
            Parent = parent;
        }
    }
}
