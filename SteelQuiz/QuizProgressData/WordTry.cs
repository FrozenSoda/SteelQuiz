using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizProgressData
{
    public class WordTry
    {
        public bool Success { get; set; }

        public WordTry(bool success)
        {
            Success = success;
        }
    }
}
