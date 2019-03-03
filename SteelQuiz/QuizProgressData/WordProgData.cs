using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class WordProgData
    {
        public WordPair WordPair { get; set; }
        public int TriesCount { get; set; } = 0;
        public int SuccessCount { get; set; } = 0;
        public bool AskedThisRound { get; set; } = false;

        public int GetSuccessRate()
        {
            if (TriesCount == 0)
            {
                return 0;
            }

            return SuccessCount / TriesCount;
        }
    }
}