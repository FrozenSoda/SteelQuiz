using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SteelQuiz.QuizImport.QuizImporter;

namespace SteelQuiz.QuizImport.Guide
{
    interface IStep
    {
        ImportSource ImportSource { get; set; }
        int Step { get; set; }
    }
}
