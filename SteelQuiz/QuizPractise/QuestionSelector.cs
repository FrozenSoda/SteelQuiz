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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;
using SteelQuiz.Util;

namespace SteelQuiz.QuizPractise
{
    public static class QuestionSelector
    {
        private const int MINIMUM_QUESTIONS_PER_ROUND = 5;

        private static int __skipNextMasterNotice = 0;
        /// <summary>
        /// How many times to skip the next "Congratulations - you have learned all the words" notification during this practise session. Can be decremented without checking, it won't allow values under 0
        /// </summary>
        public static int SkipNextMasterNotice
        {
            get
            {
                return __skipNextMasterNotice;
            }

            set
            {
                if (value >= 0)
                {
                    __skipNextMasterNotice = value;
                }
                else
                {
                    __skipNextMasterNotice = 0;
                }
            }
        }

        /// <summary>
        /// Generates a question/word to be asked, while taking current word and Intelligent Learning settings into account
        /// </summary>
        /// <returns>Returns a question/word to be asked</returns>
        public static Card GenerateWordPair(Quiz quiz)
        {
            if (quiz.ProgressData.CurrentCards != null && quiz.ProgressData.CurrentCards.Count > 0)
            {
                return quiz.ProgressData.CurrentCards[0];
            }

            if (quiz.ProgressData.FullTestInProgress)
            {
                return GenerateWordPair_NoIntelligentLearning(quiz);
            }
            else
            {
                return GenerateWordPair_IntelligentLearning(quiz);
            }
        }

        private static double GetLearningProgress(Quiz quiz, CardProgress questionProgressData)
        {
            if (quiz.ProgressData.IntelligentLearningLastAnswersBasisCount == 0)
            {
                return questionProgressData.GetSuccessRate();
            }
            else
            {
                return questionProgressData.GetLearningProgress(quiz.ProgressData.IntelligentLearningLastAnswersBasisCount);
            }
        }

        /// <summary>
        /// Generates a question/word to be asked, without taking Intelligent Learning progress into account, that is, pure random (excluding already asked words)
        /// </summary>
        /// <returns></returns>
        private static Card GenerateWordPair_NoIntelligentLearning(Quiz quiz)
        {
            var wordsNotToAsk = quiz.ProgressData.WordsNotToAsk();

            if (wordsNotToAsk.Count() == quiz.Cards.Count)
            {
                //NewRound();
                return null;
            }

            var wordsNotToAsk_Indexes = new List<int>();

            for (int i = 0; i < quiz.Cards.Count; ++i)
            {
                for (int j = 0; j < wordsNotToAsk.Count(); ++j)
                {
                    if (quiz.Cards[i].Equals(wordsNotToAsk.ElementAt(j)))
                    {
                        wordsNotToAsk_Indexes.Add(i);
                    }
                }
            }

            int index;
            if (quiz.ProgressData.AskQuestionsInRandomOrder)
            {
                index = new Random().RandomNext(0, quiz.Cards.Count, wordsNotToAsk_Indexes.ToArray());
            }
            else
            {
                index = Enumerable.Range(0, int.MaxValue).Except(wordsNotToAsk_Indexes).FirstOrDefault();
            }
            var card = quiz.Cards[index];
            quiz.ProgressData.SetCurrentCard(quiz, card);
            QuizCore.SaveQuizProgress(quiz);
            return card;
        }

        /// <summary>
        /// Generates a question/word to be asked, while taking Intelligent Learning progress into account
        /// </summary>
        /// <returns></returns>
        private static Card GenerateWordPair_IntelligentLearning(Quiz quiz)
        {
            var alreadyAsked = quiz.ProgressData.WordsNotToAsk();

            if (alreadyAsked.Count() == quiz.Cards.Count)
            {
                return null;
            }

            //double askProb(double successRate)
            double askProb(double learningProgress)
            {
                const double PROB_OFFSET = 0.15;
                var prb = 1 - learningProgress;
                if (prb == 0)
                {
                    prb += PROB_OFFSET;
                }

                return prb;
            }

            // universal probability
            //double u = QuizCore.QuizProgress.CardProgress.Where(x => !alreadyAsked.Contains(x.WordPair)).Sum(p => askProb(p.GetSuccessRate()));
            double u = quiz.ProgressData.CardProgress.Where(x => !alreadyAsked.Contains(x.Card)).Sum(p => askProb(GetLearningProgress(quiz, p)));

            // random number between 0 and u
            double r = new Random().NextDouble() * u;

            double sum = 0;
            foreach (var cardProgress in quiz.ProgressData.CardProgress.Where(x => !alreadyAsked.Contains(x.Card)))
            {
                //var askPrb = askProb(wordPairData.GetSuccessRate());
                var askPrb = askProb(GetLearningProgress(quiz, cardProgress));
                sum += askPrb;
                if (r <= sum)
                {
                    quiz.ProgressData.SetCurrentCard(quiz, cardProgress.Card);
                    QuizCore.SaveQuizProgress(quiz);
                    return cardProgress.Card;
                }
            }

            // should never be reached
            throw new Exception("Probability error at QuizAI.GenerateWordPair()");
        }

        /// <summary>
        /// Starts a new round, for instance by re-evaluating words to be asked
        /// </summary>
        public static void NewRound(Quiz quiz)
        {
            quiz.ProgressData.CurrentCards?.Clear();

            //const int MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING = 2;

            //double dontAskProb(double successRate, int triesCount)
            double dontAskProb(double learningProgress, int triesCount)
            {
                if (triesCount < quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion)
                {
                    return 0;
                }

                const double PROB_OFFSET = 0.15;
                var prb = learningProgress;
                if (prb == 1)
                {
                    Debug.Assert((triesCount - (quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion - 1)) > 0); // do not divide by zero
                    prb -= PROB_OFFSET / (triesCount - (quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion - 1));
                }

                return prb;
            }

            quiz.ProgressData.CorrectAnswersThisRound = 0;

            foreach (var wordPairData in quiz.ProgressData.CardProgress)
            {
                wordPairData.AskedThisRound = false;
                wordPairData.SkipThisRound = false;
            }

            var rnd = new Random();
            var skipCount = 0;

            // prevent the MINIMUM_QUESTIONS_PER_ROUND number of questions with worst success rate, from being skipped
            foreach (var wordPairData in quiz.ProgressData.CardProgress.OrderBy(x => GetLearningProgress(quiz, x)).Skip(MINIMUM_QUESTIONS_PER_ROUND))
            {
                // Eventually skip asking the word

                //var dontAskAgainPrb = dontAskProb(wordPairData.GetSuccessRate(), wordPairData.GetWordTriesCount());
                var dontAskAgainPrb = dontAskProb(GetLearningProgress(quiz, wordPairData), wordPairData.GetAnswerAttemptsCount());

                if (!quiz.ProgressData.FullTestInProgress
                    && wordPairData.GetAnswerAttemptsCount() >= quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion
                    && rnd.NextBool(dontAskAgainPrb))
                {
                    wordPairData.SkipThisRound = true;
                    ++skipCount;
                }
            }

            if (quiz.ProgressData.AskQuestionsInRandomOrder)
            {
                QuizCore.QuizRandomize(quiz);
            }
            else
            {
                quiz.ProgressData.CardProgress = quiz.ProgressData.CardProgress.OrderBy(x => quiz.Cards.IndexOf(x.Card)).ToList();
            }

            QuizCore.SaveQuizProgress(quiz);
        }
    }
}