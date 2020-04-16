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
        /// A collection of items with a specified weight, which affects their chances of getting picked.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        private class WeightedCollection<T>
        {
            /// <summary>
            /// A container for an item that should be picked from a collection based off of the items' weight.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            private class Entry
            {
                /// <summary>
                /// The item with the specified Probability.
                /// </summary>
                public T Item { get; set; }

                /// <summary>
                /// The weight, which is a value affecting the chance of this item getting picked. The higher weight, the higher chance of getting picked.
                /// </summary>
                public double Weight { get; set; }
            }

            private List<Entry> entries = new List<Entry>();
            private double accumulatedWeight = 0.0;
            private Random random = new Random();

            /// <summary>
            /// Adds a item to the collection.
            /// </summary>
            /// <param name="item">The item to add.</param>
            /// <param name="weight">The weight of the item.</param>
            public void Add(T item, double weight)
            {
                accumulatedWeight += weight;
                entries.Add(new Entry() { Item = item, Weight = weight });
            }

            /// <summary>
            /// Picks a random item from the collection, based off of their weights.
            /// </summary>
            /// <returns>The picked item.</returns>
            public T Pick()
            {
                double rnd = random.NextDouble() * accumulatedWeight;
                var picked = entries.TakeWhile(x => x.Weight >= rnd).FirstOrDefault();
                return picked.Item;
            }
        }

        private static void Swap<T>(List<T> list, int index1, int index2)
        {
            T tmp = list[index1];
            list[index1] = list[index2];
            list[index2] = tmp;
        }

        private static void Shuffle<T>(List<T> list)
        {
            var rnd = new Random();
            for (int i = list.Count - 1; i >= 0; ++i)
            {
                Swap(list, i, rnd.Next(0, i));
            }
        }

        public static void NewRound(Quiz quiz)
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

        private static void NewRoundWithIntelligentLearning(Quiz quiz)
        {

        }

        private static void NewRoundWithoutIntelligentLearning(Quiz quiz)
        {

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
            var possibleCards = from x in quiz.Cards
                                let progress = x.GetProgressData(quiz)
                                where !progress.AskedThisRound
                                select x;

            var weightedCollection = new WeightedCollection<Card>();
            possibleCards.ToList().ForEach(x => weightedCollection.Add(x, x.GetProgressData(quiz).GetLearningProgress(quiz.ProgressData)));

            return weightedCollection.Pick();
        }

        public static Card GenerateCardWithoutIntelligentLearning(Quiz quiz)
        {
            var possibleCards = from x in quiz.Cards
                           let progress = x.GetProgressData(quiz)
                           where !progress.AskedThisRound
                           select x;

            int r = new Random().Next(0, possibleCards.Count());
            return possibleCards.ElementAt(r);
        }
    }
}