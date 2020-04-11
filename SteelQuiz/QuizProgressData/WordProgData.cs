/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
    public class WordProgData : ICloneable
    {
        public WordPair WordPair { get; set; }

        [JsonProperty]
        internal List<WordTry> WordTries { get; set; }

        public const int WORD_TRIES_FOR_LEARNING_PROGRESS_DEFAULT = 3;

        public bool AskedThisRound { get; set; } = false;
        public bool SkipThisRound { get; set; } = false;

        public WordProgData(WordPair wordPair)
        {
            WordTries = new List<WordTry>();
            WordPair = wordPair;
        }

        public void AddWordTry(WordTry wordTry)
        {
            /*
            while (WordTries.Count >= WORD_TRIES_FOR_LEARNING_PROGRESS)
            {
                WordTries.RemoveAt(0);
            }
            */

            WordTries.Add(wordTry);
        }

        public int GetWordTriesCount()
        {
            return WordTries.Count;
        }

        /// <summary>
        /// Calculates the success rate between 0 and 1 for answering this word, for the amount of tries completed
        /// </summary>
        /// <returns>Returns the success rate between 0 and 1 for answering this word, for the amount of tries completed</returns>
        public double GetSuccessRate()
        {
            var tries = GetWordTriesCount();
            if (tries == 0)
            {
                return 0;
            }
            var successCount = WordTries.Where(x => x.Success).Count();

            return successCount / (double)tries;
        }

        /// <summary>
        /// Calculates the learning progress for this quiz, 
        /// that is, the average of the success rates for all wordpairs, that is between 0 and 1, divided by total amount of tries to save (WORD_TRIES_FOR_LEARNING_PROGRESS)
        /// </summary>
        /// <returns>Returns the learning progress</returns>
        public double GetLearningProgress()
        {
            var latestTries = WordTries.Skip(Math.Max(0, WordTries.Count() - WORD_TRIES_FOR_LEARNING_PROGRESS_DEFAULT));
            var successCount = latestTries.Where(x => x.Success).Count();

            if (successCount == 0)
            {
                return 0d;
            }
            else
            {
                return successCount / (double)latestTries.Count();
            }
        }

        /// <summary>
        /// Calculates the learning progress for this quiz, 
        /// that is, the average of the success rates for all wordpairs, that is between 0 and 1, divided by triesToSave.
        /// </summary>
        /// <param name="triesToSave">The number of tries to use from the end</param>
        /// <returns>Returns the learning progress</returns>
        public double GetLearningProgress(int triesToSave)
        {
            var latestTries = WordTries.Skip(Math.Max(0, WordTries.Count() - triesToSave));
            var successCount = latestTries.Where(x => x.Success).Count();

            if (successCount == 0)
            {
                return 0d;
            }
            else
            {
                return successCount / (double)latestTries.Count();
            }
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