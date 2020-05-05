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
        private static void Swap<T>(List<T> list, int index1, int index2)
        {
            T tmp = list[index1];
            list[index1] = list[index2];
            list[index2] = tmp;
        }

        private static void Shuffle<T>(List<T> list)
        {
            var rnd = new Random();
            for (int i = list.Count - 1; i >= 0; --i)
            {
                Swap(list, i, rnd.Next(0, i));
            }
        }

        /// <summary>
        /// Marks all Cards as not answered this round, lowers the RoundToSkip variables and updated CurrentCards with a new selection.
        /// </summary>
        /// <param name="quiz"></param>
        public static void NewRound(Quiz quiz)
        {
            if (!quiz.ProgressData.FullTestInProgress)
            {
                quiz.ProgressData.CorrectAnswersThisRound = 0;
                var possibleCards = (from x in quiz.Cards
                                     let progress = x.GetProgressData(quiz)
                                     where progress.RoundsToSkip == 0
                                     orderby progress.GetLearningProgress(quiz.ProgressData) ascending
                                     select x.Guid).ToList();

                if (possibleCards.Count > 0)
                {
                    quiz.ProgressData.CurrentCards = possibleCards.Take(10).ToList();
                }
                else
                {
                    var indexes = Enumerable.Range(0, 5).ToList();
                    Shuffle(indexes);
                    quiz.ProgressData.CurrentCards = indexes
                        .Where(i => i <= quiz.Cards.Count() - 1)
                        .Select(i => quiz.Cards[i].Guid).ToList();
                }
            }
            else
            {
                quiz.ProgressData.CurrentCards = quiz.Cards.Select(x => x.Guid).ToList();
                Shuffle(quiz.ProgressData.CurrentCards);
            }

            quiz.ProgressData.CurrentCard = Guid.Empty;

            // Update RoundsToSkip
            foreach (var cardProgress in quiz.ProgressData.CardProgress)
            {
                cardProgress.AskedThisRound = false;

                if (cardProgress.RoundsToSkip > 0)
                {
                    --cardProgress.RoundsToSkip;
                }
            }

            QuizCore.SaveQuizProgress(quiz);
        }

        public static Card GenerateCard(Quiz quiz)
        {
            if (quiz.ProgressData.FullTestInProgress)
            {
                return GenerateCardWithoutIntelligentLearning(quiz);
            }
            else
            {
                return GenerateCardWithIntelligentLearning(quiz);
            }
        }

        public static Card GenerateCardWithIntelligentLearning(Quiz quiz)
        {
            if (quiz.ProgressData.CurrentCards == null)
            {
                return null;
            }

            if (quiz.ProgressData.CurrentCard != Guid.Empty)
            {
                return quiz.GetCard(quiz.ProgressData.CurrentCard);
            }

            var r = new Random();
            var cardGuid = quiz.ProgressData.CurrentCards
                .Where(x => !quiz.GetCard(x).GetProgressData(quiz).AskedThisRound)
                .OrderBy(x => quiz.GetCard(x).GetProgressData(quiz).GetLearningProgress(quiz.ProgressData))
                .ThenBy(x => r.NextDouble())
                .FirstOrDefault();

            var card = quiz.GetCard(cardGuid);

            return card;
        }

        public static Card GenerateCardWithoutIntelligentLearning(Quiz quiz)
        {
            if (quiz.ProgressData.CurrentCards == null)
            {
                return null;
            }

            if (quiz.ProgressData.CurrentCard != Guid.Empty)
            {
                return quiz.GetCard(quiz.ProgressData.CurrentCard);
            }

            var r = new Random();

            var cardGuid = quiz.ProgressData.CurrentCards
                .Where(x => !quiz.GetCard(x).GetProgressData(quiz).AskedThisRound)
                .OrderBy(x => r.NextDouble())
                .FirstOrDefault();

            quiz.ProgressData.CurrentCard = cardGuid;

            var card = quiz.GetCard(cardGuid);

            return card;
        }
    }
}