using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.UndoRedo
{
    public class UndoRedoFuncPair
    {
        public Func<object>[] UndoActions { get; set; }
        public Func<object>[] RedoActions { get; set; }

        public UndoRedoFuncPair(Func<object>[] undoActions, Func<object>[] redoActions)
        {
            UndoActions = undoActions;
            RedoActions = redoActions;
        }
    }
}
