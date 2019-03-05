using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class WordProgData : ICloneable
    {
        /*
         * TODO: Implement answer strike system/something that prioritizes newer results than older ones, to calculate success rate (asking probability)
         */

        public WordPair WordPair { get; set; }
        public int TriesCount { get; set; } = 0;
        public int SuccessCount { get; set; } = 0;

        public bool AskedThisRound { get; set; } = false;
        public bool SkipThisRound { get; set; } = false;

        public WordProgData(WordPair wordPair)
        {
            WordPair = wordPair;
        }

        public int GetSuccessRate()
        {
            if (TriesCount == 0)
            {
                return 0;
            }

            return SuccessCount / TriesCount;
        }

        public object Clone()
        {
            var cpy = new WordProgData(WordPair);
            cpy.TriesCount = TriesCount;
            cpy.SuccessCount = SuccessCount;
            cpy.AskedThisRound = AskedThisRound;
            cpy.SkipThisRound = SkipThisRound;

            return cpy;
        }
    }
}