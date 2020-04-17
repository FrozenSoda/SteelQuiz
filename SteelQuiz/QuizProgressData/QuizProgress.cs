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
    public enum CardsOrderBy
    {
        SuccessRate,
        QuizOrder,
        AlphabeticalTerm1,
        AlphabeticalTerm2,
    }

    public enum CardsOrderByOrder
    {
        Ascending,
        Descending,
    }

    public enum CardSide
    {
        Front,
        Back,
    }

    public class QuizProgress
    {
        /// <summary>
        /// The Guid of the Quiz belonging to this progress data container.
        /// </summary>
        public Guid QuizGUID { get; set; }
        /// <summary>
        /// The progress related to each of the Cards in this quiz.
        /// </summary>
        public List<CardProgress> CardProgress { get; set; } = new List<CardProgress>();
        /// <summary>
        /// The side of the card that is hidden - whose content the user should answer with.
        /// </summary>
        public CardSide AnswerCardSide { get; set; } = CardSide.Back;
        /// <summary>
        /// How many of the last attempts to use as basis for Intelligent Learning question selection. 0 if all attempts ever made should count
        /// </summary>
        public int IntelligentLearningLastAnswersBasisCount { get; set; } = 3;
        /// <summary>
        /// The Minimum number of answer tries per question to consider skipping it with Intelligent Learning.
        /// </summary>
        public int MinimumTriesCountToConsiderSkippingQuestion { get; set; } = 2;
        /// <summary>
        /// A collection of the GUIDs of all Cards that should be answered this round.
        /// </summary>
        public List<Guid> CurrentCards { get; set; } = new List<Guid>();

        [JsonIgnore]
        /// <summary>
        /// True if the question to perform a full test has been asked (during this application instance)
        /// </summary>
        public bool MasterNoticeShowed { get; set; } = false;
        /// <summary>
        /// True if a full test is in progress - that is, Intelligent Learning is disabled.
        /// </summary>
        public bool FullTestInProgress { get; set; } = false;
        /// <summary>
        /// Contains the number of correct answers during a full test.
        /// </summary>
        public int CorrectAnswersThisRound { get; set; } = 0;

        public CardsOrderBy CardsDisplayOrder { get; set; } = CardsOrderBy.SuccessRate;
        public CardsOrderByOrder CardsDisplayOrderOrder { get; set; } = CardsOrderByOrder.Ascending;

        public bool AskQuestionsInRandomOrder { get; set; } = true;

        #region Obsolete properties
        [JsonProperty]
        [Obsolete("Use CardProgress instead", true)]
        private List<CardProgress> WordProgDatas { set => CardProgress = value; }

        [JsonProperty]
        [Obsolete("Use AnswerCardSide instead", true)]
        private int AnswerLanguageNum { set => AnswerCardSide = value == 1 ? CardSide.Front : CardSide.Back; }

        /*
        [JsonProperty]
        [Obsolete("Use CurrentCards instead", true)]
        private List<Card> CurrentWordPairs { set => CurrentCards = value; }
        */

        [JsonProperty]
        [Obsolete("Use CardsDisplayOrder instead", true)]
        private CardsOrderBy TermsDisplayOrder { set => CardsDisplayOrder = value; }

        [JsonProperty]
        [Obsolete("Use CardsDisplayOrderOrder instead", true)]
        private CardsOrderByOrder TermsDisplayOrderOrder { set => CardsDisplayOrderOrder = value; }
        #endregion

        public QuizProgress(Quiz quiz, bool initCardProgress = true)
        {
            if (quiz == null)
            {
                return;
            }

            if (initCardProgress)
            {
                foreach (var card in quiz.Cards)
                {
                    bool found = false;
                    foreach (var c in CardProgress)
                    {
                        if (c.CardGuid.Equals(card.Guid))
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        CardProgress.Add(new CardProgress(card.Guid));
                    }
                }
            }

            QuizGUID = quiz.GUID;
        }

        /// <summary>
        /// Returns the learning progress for this quiz, 
        /// that is, the average of the success rates for all Cards, that is between 0 and 1, for the amount of tries completed decided by IntelligentLearningLastAnswersBasisCount.
        /// </summary>
        /// <returns></returns>
        public double GetLearningProgress()
        {
            double val = CardProgress.Sum(x => x.GetLearningProgress(this)) / CardProgress.Count();
            if (double.IsNaN(val))
            {
                return 0d;
            }
            return val;
        }
    }
}