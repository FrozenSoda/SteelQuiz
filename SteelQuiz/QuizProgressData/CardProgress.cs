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
    public class CardProgress : ICloneable
    {
        public Card Card { get; set; }
        public List<AnswerAttempt> AnswerAttempts { get; set; } = new List<AnswerAttempt>();

        public const int ANSWER_ATTEMPTS_FOR_LEARNING_PROGRESS_DEFAULT = 3;

        /// <summary>
        /// True if this Card has been shown this round.
        /// </summary>
        public bool AskedThisRound { get; set; } = false;
        /// <summary>
        /// The n number of subsequent rounds from the current, where this Card should not be picked.
        /// </summary>
        public int RoundsToSkip { get; set; } = 0;


        #region Obsolete properties
        [JsonProperty]
        [Obsolete("Use RoundsToSkip instead", true)]
        private bool SkipThisRound
        {
            set
            {
                if (value)
                {
                    RoundsToSkip = 1;
                }
            }
        }

        [JsonProperty]
        [Obsolete("Use Card instead", true)]
        private Card WordPair { set => Card = value; }

        [JsonProperty]
        [Obsolete("Use AnswerAttempts instead", true)]
        private List<AnswerAttempt> WordTries { set => AnswerAttempts = value; }
        #endregion

        public CardProgress(Card card)
        {
            Card = card;
        }

        public void AddAnswerAttempt(AnswerAttempt answerAttempt)
        {
            AnswerAttempts.Add(answerAttempt);
        }

        public int GetAnswerAttemptsCount()
        {
            return AnswerAttempts.Count;
        }

        /// <summary>
        /// Calculates the success rate between 0 and 1 for answering this Card, for the total amount of tries completed.
        /// </summary>
        /// <returns>Returns the success rate between 0 and 1 for answering this Card, for the amount of tries completed.</returns>
        public double GetSuccessRate()
        {
            var tries = GetAnswerAttemptsCount();
            if (tries == 0)
            {
                return 0;
            }
            var successCount = AnswerAttempts.Where(x => x.Success).Count();

            return successCount / (double)tries;
        }

        /// <summary>
        /// Calculates the success rate between 0 and 1 for answering this Card, for the amount of tries completed decided by quizProgress.IntelligentLearningLastAnswersBasisCount.
        /// </summary>
        /// <returns>Returns the learning progress.</returns>
        public double GetLearningProgress(QuizProgress quizProgress)
        {
            var latestTries = AnswerAttempts.Skip(Math.Max(0, AnswerAttempts.Count() - quizProgress.IntelligentLearningLastAnswersBasisCount));
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
            var cpy = new CardProgress(Card);
            cpy.AnswerAttempts = AnswerAttempts;
            cpy.AskedThisRound = AskedThisRound;
            cpy.RoundsToSkip = RoundsToSkip;

            return cpy;
        }
    }
}