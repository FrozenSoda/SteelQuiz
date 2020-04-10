/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

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
