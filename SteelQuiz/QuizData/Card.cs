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

using Newtonsoft.Json;
using SteelQuiz.QuizPractise;
using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    /// <summary>
    /// A pair of a question and its answer.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The term/word/question/answer on the front of the "flashcard"
        /// </summary>
        public string Front { get; set; }
        /// <summary>
        /// The synonym(s) to Front
        /// </summary>
        public List<string> FrontSynonyms { get; set; } = new List<string>();

        /// <summary>
        /// The term/word/question/answer on the back of the "flashcard"
        /// </summary>
        public string Back { get; set; }
        /// <summary>
        /// The synonym(s) to Back
        /// </summary>
        public List<string> BackSynonyms { get; set; } = new List<string>();

        public StringComp.Rules SmartComparisonRules { get; set; }

        #region Obsolete properties
        [JsonProperty]
        [Obsolete("Use Front instead", true)]
        private string Word1 { set => Front = value; }

        [JsonProperty]
        [Obsolete("Use Back instead", true)]
        private string Word2 { set => Back = value; }

        [JsonProperty]
        [Obsolete("Use FrontSynonyms instead", true)]
        private List<string> Word1Synonyms { set => FrontSynonyms = value; }

        [JsonProperty]
        [Obsolete("Use BackSynonyms instead", true)]
        private List<string> Word2Synonyms { set => BackSynonyms = value; }

        [JsonProperty]
        [Obsolete("Use SmartComparisonRules instead", true)]
        private StringComp.Rules TranslationRules { set => SmartComparisonRules = value; }
        #endregion

        public Card(string word1, string word2, StringComp.Rules smartComparisonRules, List<string> frontSynonyms = null, List<string> backSynonyms = null)
        {
            Front = word1;
            Back = word2;
            SmartComparisonRules = smartComparisonRules;

            if (FrontSynonyms != null)
            {
                FrontSynonyms = frontSynonyms;
            }
            if (BackSynonyms != null)
            {
                BackSynonyms = backSynonyms;
            }
        }

        /// <summary>
        /// Retrieves the content of the side of the flashcard which the user should be prompted with - and give an answer to.
        /// </summary>
        /// <param name="quiz">The Quiz which this Card belongs to.</param>
        /// <returns>Returns the content of the question card.</returns>
        public string GetSideToAsk(Quiz quiz)
        {
            return quiz.ProgressData.AnswerCardSide == CardSide.Back ? Front : Back;
        }

        /// <summary>
        /// Retrieves the content of the side of the flashcard which the user's answer should be equal/similar to.
        /// </summary>
        /// <param name="quiz">The Quiz which this Card belongs to.</param>
        /// <returns>Returns the content of the answer card.</returns>
        public string GetSideToAnswer(Quiz quiz)
        {
            return quiz.ProgressData.AnswerCardSide == CardSide.Back ? Back : Front;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card, true, true);
        }

        public bool Equals(Card wp2, bool ignoreSynonyms, bool ignoreTranslationRules)
        {
            if (wp2 == null)
            {
                return false;
            }

            return
                this.Front == ((Card)wp2).Front &&
                (ignoreSynonyms || this.FrontSynonyms.SequenceEqual(((Card)wp2).FrontSynonyms)) &&
                this.Back == ((Card)wp2).Back &&
                (ignoreSynonyms || this.BackSynonyms.SequenceEqual(((Card)wp2).BackSynonyms)) &&
                (ignoreTranslationRules || this.SmartComparisonRules == ((Card)wp2).SmartComparisonRules);
        }

        public override int GetHashCode()
        {
            var hashCode = -295472895;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Front);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(FrontSynonyms);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Back);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(BackSynonyms);
            hashCode = hashCode * -1521134295 + SmartComparisonRules.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Retrieves the progress data belonging to this Card, from the specified Quiz.
        /// </summary>
        /// <param name="quiz">The quiz this Card belongs to, and that contains the progress data for this Card.</param>
        /// <returns>The CardProgress object belonging to this Card.</returns>
        public CardProgress GetProgressData(Quiz quiz)
        {
            foreach (var p in quiz.ProgressData.CardProgress)
            {
                if (p.Card.Equals(this, true, true))
                {
                    return p;
                }
            }

            throw new Exception("No progress data could be found for this card");
        }

        /// <summary>
        /// Finds all synonyms to the answer side of this Card that are required to be provided, including the content in this Card.
        /// </summary>
        /// <returns>A collection of Cards required to be provided.</returns>
        public IEnumerable<Card> GetRequiredAnswerSynonyms(Quiz quiz)
        {
            if (quiz.ProgressData.AnswerCardSide == CardSide.Back)
            {
                return quiz.Cards.Where(x => x.Front == Front);
            }
            else if (quiz.ProgressData.AnswerCardSide == CardSide.Front)
            {
                return quiz.Cards.Where(x => x.Back == Back);
            }
            else
            {
                // should never be reached
                throw new Exception("GetRequiredAnswerSynonyms() reached end");
            }
        }

        public class AnswerDiff
        {
            public string MostSimilarAnswer { get; set; }
            public int Difference { get; set; }
            public StringComp.CorrectCertainty Certainty { get; set; }
            public Card WordPair { get; set; }

            public AnswerDiff(int difference, string mostSimilarAnswer, StringComp.CorrectCertainty certainty, Card wordPair)
            {
                Difference = difference;
                MostSimilarAnswer = mostSimilarAnswer;
                Certainty = certainty;
                WordPair = wordPair;
            }

            public bool Correct()
            {
                return Difference == 0;
            }
        }

        /// <summary>
        /// Checks the answer to see if it is correct, and returns data about the closest match
        /// </summary>
        /// <param name="input">The user answer</param>
        /// <param name="answerIgnores">In case of a question with multiple answers, contains the answers already provided</param>
        /// <param name="updateProgress">True if progress should be updated, otherwise false</param>
        /// <returns></returns>
        public AnswerDiff AnswerCheck(Quiz quiz, string input, IEnumerable<string> answerIgnores = null, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            foreach (var card in GetRequiredAnswerSynonyms(quiz).Where(x => answerIgnores == null || !answerIgnores.Contains(x.GetSideToAnswer(quiz))))
            {
                similarityData = similarityData.Concat(SimilarityData(quiz, card, input, updateProgress)).ToList();
            }

            StringComp.SimilarityData bestSimilarityData = similarityData.OrderBy(x => x.Difference).ThenBy(x => (int)x.Certainty).First();

            var ansDiff = new AnswerDiff(bestSimilarityData.Difference, bestSimilarityData.CorrectAnswer, bestSimilarityData.Certainty, bestSimilarityData.WordPair);

            if (updateProgress)
            {
                ansDiff.WordPair.GetProgressData(quiz).AddAnswerAttempt(new AnswerAttempt(ansDiff.Correct()));
            }

            if (ansDiff.Correct())
            {
                ansDiff.WordPair.GetProgressData(quiz).AskedThisRound = true;

                if (ansDiff.WordPair.GetRequiredAnswerSynonyms(quiz).Select(x => x.GetProgressData(quiz).AskedThisRound).All(x => x == true))
                {
                    quiz.ProgressData.SetCurrentQuestion(null);
                }
            }

            QuizCore.SaveQuizProgress(quiz);

            return ansDiff;
        }

        private IEnumerable<StringComp.SimilarityData> SimilarityData(Quiz quiz, Card wordPair, string input, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            if (quiz.ProgressData.AnswerCardSide == CardSide.Back)
            {
                similarityData.Add(StringComp.Similarity(input, wordPair.Back, wordPair, SmartComparisonRules));
                foreach (var synonym in wordPair.BackSynonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, wordPair, SmartComparisonRules));
                }
            }
            else if (quiz.ProgressData.AnswerCardSide == CardSide.Front)
            {
                similarityData.Add(StringComp.Similarity(input, wordPair.Front, wordPair, SmartComparisonRules));
                foreach (var synonym in wordPair.FrontSynonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, wordPair, SmartComparisonRules));
                }
            }
            else
            {
                throw new NotImplementedException("What");
            }

            return similarityData;
        }
    }
}