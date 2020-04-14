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
        /// Current card(s) to answer. Contains multiple elements if a card has multiple definitions through multiple cards.
        /// </summary>
        [JsonProperty]
        internal List<Card> CurrentCards { get; set; } = new List<Card>();

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

        [JsonProperty]
        [Obsolete("Use CurrentCards instead", true)]
        private List<Card> CurrentWordPairs { set => CurrentCards = value; }

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
                        if (c.Card.Equals(card))
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        CardProgress.Add(new CardProgress(card));
                    }
                }
            }

            QuizGUID = quiz.GUID;
        }

        /// <summary>
        /// Calculates the success rate between 0 and 1 for answering this word, for the amount of tries completed
        /// </summary>
        /// <returns>Returns the success rate between 0 and 1 for answering this word, for the amount of tries completed</returns>
        public double GetSuccessRate()
        {
            double val = CardProgress.Sum(x => x.GetSuccessRate()) / CardProgress.Count();
            if (double.IsNaN(val))
            {
                return 0d;
            }
            return val;
        }

        /// <summary>
        /// Returns the learning progress for this quiz, 
        /// that is, the average of the success rates for all Cards, that is between 0 and 1, divided by total amount of tries to save (WORD_TRIES_TO_KEEP)
        /// </summary>
        /// <returns></returns>
        public double GetLearningProgress()
        {
            double val = CardProgress.Sum(x => x.GetLearningProgress()) / CardProgress.Count();
            if (double.IsNaN(val))
            {
                return 0d;
            }
            return val;
        }

        // due to CurrentCards not preserving references due to serialization, implement setter through method instead, to avoid confusion regarding references
        public void SetCurrentCard(Quiz quiz, Card card)
        {
            if (card == null)
            {
                CurrentCards.Clear();
            }
            else
            {
                CurrentCards = card.GetRequiredAnswerSynonyms(quiz).ToList();
            }
        }

        public IEnumerable<Card> WordsNotToAsk()
        {
            // find words already asked this round
            var wordsAlreadyAsked = new List<Card>();
            for (int i = 0; i < CardProgress.Count; ++i)
            {
                if (CardProgress[i].AskedThisRound || CardProgress[i].SkipThisRound)
                {
                    wordsAlreadyAsked.Add(CardProgress[i].Card);
                }
            }

            return wordsAlreadyAsked;
        }
    }
}