using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizEditor.UndoRedo
{
    interface IUndoRedo
    {
        void Undo();
        void Redo();
    }
}
