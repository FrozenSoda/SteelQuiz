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
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class QuizProgData
    {
        public Guid QuizGUID { get; set; }
        public List<WordProgData> WordProgDatas { get; set; } = null;

        [JsonProperty] // required for deserialization of property with private setter
        internal ulong? CurrentWordPairID { get; set; } = null;

        /*
         * True if the question to perform a full test has been asked (during this application instance)
         * 
         * RESET THIS PROPERTY AFTER LOADING PROGRESS DATA
         */
        public bool MasterNoticeShowed { get; set; } = false;

        public bool FullTestInProgress { get; set; } = false;

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
                    if (wordProgData.WordPairID == wordPair.ID)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    WordProgDatas.Add(new WordProgData(wordPair.ID));
                }
            }

            QuizGUID = quiz.GUID;
        }

        // due to CurrentWordPair not preserving references due to serialization, implement setter through method instead, to avoid confusion regarding references
        public void SetCurrentWordPair(ulong? wordPairID)
        {
            CurrentWordPairID = wordPairID;
        }

        public ulong[] WordsNotToAsk()
        {
            // find words already asked this round
            var wordsAlreadyAsked = new List<ulong>();
            for (int i = 0; i < WordProgDatas.Count; ++i)
            {
                if (WordProgDatas[i].AskedThisRound || WordProgDatas[i].SkipThisRound)
                {
                    wordsAlreadyAsked.Add(WordProgDatas[i].WordPairID);
                }
            }

            return wordsAlreadyAsked.ToArray();
        }
    }
}