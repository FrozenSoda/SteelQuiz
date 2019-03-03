using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class QuizProgData
    {
        public Guid QuizGUID { get; set; }
        public List<WordProgData> WordProgDatas { get; set; }

        public QuizProgData(Quiz quiz)
        {
            if (quiz == null)
            {
                return;
            }

            QuizGUID = quiz.GUID;
        }

        public WordPair[] WordsAlreadyAsked()
        {
            // find words already asked this round, return indexes
            var wordsAlreadyAsked = new List<WordPair>();
            for (int i = 0; i < WordProgDatas.Count; ++i)
            {
                if (WordProgDatas[i].AskedThisRound)
                {
                    wordsAlreadyAsked.Add(WordProgDatas[i].WordPair);
                }
            }

            return wordsAlreadyAsked.ToArray();
        }
    }
}