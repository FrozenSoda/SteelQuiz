using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class WordProgData : ICloneable
    {
        public WordPair WordPair { get; set; }

        [JsonProperty]
        private List<WordTry> WordTries { get; set; } = null;

        const int WORD_TRIES_TO_KEEP = 5;

        public bool AskedThisRound { get; set; } = false;
        public bool SkipThisRound { get; set; } = false;

        public WordProgData(WordPair wordPair)
        {
            WordPair = wordPair;
            if (WordTries == null)
            {
                WordTries = new List<WordTry>();
            }
        }

        public void AddWordTry(WordTry wordTry)
        {
            while (WordTries.Count >= WORD_TRIES_TO_KEEP)
            {
                WordTries.RemoveAt(0);
            }

            WordTries.Add(wordTry);
        }

        public int GetWordTriesCount()
        {
            return WordTries.Count;
        }

        public int GetSuccessRate()
        {
            var tries = GetWordTriesCount();
            if (tries == 0)
            {
                return 0;
            }
            var successCount = WordTries.Where(x => x.Success).Count();

            return successCount / tries;
        }

        public object Clone()
        {
            var cpy = new WordProgData(WordPair);
            cpy.WordTries = WordTries;
            cpy.AskedThisRound = AskedThisRound;
            cpy.SkipThisRound = SkipThisRound;

            return cpy;
        }
    }
}