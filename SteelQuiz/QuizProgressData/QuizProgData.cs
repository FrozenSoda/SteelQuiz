using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class QuizProgData
    {
        public Guid QuizGUID { get; set; }
        public List<WordProgData> WordProgDatas { get; set; } = null;

        [JsonProperty] // required for deserialization of property with private setter
        public WordPair CurrentWordPair { get; private set; } = null;

        public bool MasterNoticeShowed { get; set; } = false; // RESET THIS PROPERTY AFTER LOADING

        public QuizProgData(Quiz quiz)
        {
            if (quiz == null)
            {
                return;
            }

            if (WordProgDatas == null)
            {
                WordProgDatas = new List<WordProgData>();
            }

            foreach (var wordPair in quiz.WordPairs)
            {
                bool found = false;
                foreach (var wordProgData in WordProgDatas)
                {
                    if (wordProgData.WordPair == wordPair)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    WordProgDatas.Add(new WordProgData(wordPair));
                }
            }

            QuizGUID = quiz.GUID;
        }

        // due to CurrentWordPair not preserving references due to serialization, implement setter through method instead, to avoid confusion regarding references
        public void SetCurrentWordPair(WordPair wordPair)
        {
            CurrentWordPair = wordPair;
        }

        public WordPair[] WordsNotToAsk()
        {
            // find words already asked this round, return indexes
            var wordsAlreadyAsked = new List<WordPair>();
            for (int i = 0; i < WordProgDatas.Count; ++i)
            {
                if (WordProgDatas[i].AskedThisRound || WordProgDatas[i].SkipThisRound)
                {
                    wordsAlreadyAsked.Add(WordProgDatas[i].WordPair);
                }
            }

            return wordsAlreadyAsked.ToArray();
        }
    }
}