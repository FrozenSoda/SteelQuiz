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

namespace SteelQuiz.QuizProgressData.Compatibility._2_0_0
{
    public class WordProgData : ICloneable
    {
        public ulong WordPairID { get; set; }

        [JsonProperty]
        internal List<WordTry> WordTries { get; set; } = null;

        private const int WORD_TRIES_TO_KEEP = 5;

        public bool AskedThisRound { get; set; } = false;
        public bool SkipThisRound { get; set; } = false;

        public WordProgData(ulong wordPairID)
        {
            WordPairID = wordPairID;
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
            var cpy = new WordProgData(WordPairID);
            cpy.WordTries = WordTries;
            cpy.AskedThisRound = AskedThisRound;
            cpy.SkipThisRound = SkipThisRound;

            return cpy;
        }
    }
}