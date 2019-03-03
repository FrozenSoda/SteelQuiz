using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;

namespace SteelQuiz
{
    public static class QuizAI
    {
        public static WordPair GenerateWordPair()
        {
            var alreadyAsked = QuizCore.QuizProgress.WordsAlreadyAsked(); //words already asked this round
            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)))
            {
                
            }
        }
    }
}
