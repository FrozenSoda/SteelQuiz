using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizEditor.UndoRedo
{
    public class AutoThemeableUndoRedoForm : AutoThemeableForm, IUndoRedo
    {
        public Stack<UndoRedoFuncPair> UndoStack { get; set; } = new Stack<UndoRedoFuncPair>();
        public Stack<UndoRedoFuncPair> RedoStack { get; set; } = new Stack<UndoRedoFuncPair>();

        public bool UpdateUndoRedoStacks { get; set; } = true;
        public bool ChangedSinceLastSave { get; set; } = false;

        public void Undo()
        {
            if (!UpdateUndoRedoStacks)
            {
                return;
            }

            if (UndoStack.Count > 0)
            {
                var pop = UndoStack.Pop();
                foreach (var undo in pop.UndoActions.Reverse())
                {
                    undo();
                }
                RedoStack.Push(pop);

                UpdateUndoRedoTooltips();
                ChangedSinceLastSave = true;
            }
        }

        public void Redo()
        {
            if (!UpdateUndoRedoStacks)
            {
                return;
            }

            if (RedoStack.Count > 0)
            {
                var pop = RedoStack.Pop();
                foreach (var redo in pop.RedoActions.Reverse())
                {
                    redo();
                }
                UndoStack.Push(pop);

                UpdateUndoRedoTooltips();
                ChangedSinceLastSave = true;
            }
        }

        public virtual void UpdateUndoRedoTooltips() { }
    }
}
