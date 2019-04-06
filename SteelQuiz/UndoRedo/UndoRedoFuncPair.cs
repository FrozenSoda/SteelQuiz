using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.UndoRedo
{
    public class UndoRedoFuncPair
    {
        public Func<object>[] UndoActions { get; set; }
        public Func<object>[] RedoActions { get; set; }
        public UserControl OwnerControl { get; set; }

        public UndoRedoFuncPair(Func<object>[] undoActions, Func<object>[] redoActions, UserControl ownerControl = null)
        {
            UndoActions = undoActions;
            RedoActions = redoActions;
            OwnerControl = ownerControl;
        }
    }
}