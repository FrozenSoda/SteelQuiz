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
        /// <summary>
        /// A container for an item that should be picked from a collection based off of the items' probabilities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class ProbabilityItem<T>
        {
            /// <summary>
            /// The item with the specified Probability.
            /// </summary>
            public T Item { get; set; }

            private double __probability;
            /// <summary>
            /// The probability of this item getting picked.
            /// </summary>
            public double Probability
            {
                get
                {
                    return __probability;
                }

                set
                {
                    if (value < 0 || value >= 1)
                    {
                        throw new FormatException("Probability must be in the interval 0 <= x < 1");
                    }
                    __probability = value;
                }
            }
        }

        /// <summary>
        /// Picks an item from a collection of ProbabilityItems
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="items">The items to pick from.</param>
        /// <returns>The picked item.</returns>
        private static T PickItem<T>(IEnumerable<ProbabilityItem<T>> items)
        {
            var converted = new List<ProbabilityItem<T>>(items.Count());
            var probabilitySum = 0.0;
            foreach (var item in items.Take(items.Count() - 1))
            {
                probabilitySum += item.Probability;
                converted.Add(new ProbabilityItem<T>() { Item = item.Item, Probability = probabilitySum });
            }
            converted.Add(new ProbabilityItem<T>() { Item = items.Last().Item, Probability = 1 });

            var rnd = new Random();
            var r = rnd.NextDouble();
            var selected = converted.SkipWhile(x => x.Probability < r).First();

            return selected.Item;
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

        }

        public static Card GenerateCardWithoutIntelligentLearning(Quiz quiz)
        {

        }
    }
}