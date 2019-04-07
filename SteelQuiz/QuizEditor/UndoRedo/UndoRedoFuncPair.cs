using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor.UndoRedo
{
    public class UndoRedoFuncPair
    {
        public Func<object>[] UndoActions { get; set; }
        public Func<object>[] RedoActions { get; set; }
        public OwnerControlData OwnerControlData { get; set; }

        public UndoRedoFuncPair(Func<object>[] undoActions, Func<object>[] redoActions, OwnerControlData ownerControlData)
        {
            UndoActions = undoActions;
            RedoActions = redoActions;
            OwnerControlData = ownerControlData;
        }
    }
}