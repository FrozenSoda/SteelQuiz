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

namespace SteelQuiz.QuizPractise
{
    public static class StringComp
    {
        public class SimilarityData
        {
            /// <summary>
            /// How different the words were. A value where 0 equals total similarity. The higher Difference, the less similar.
            /// </summary>
            public int Difference { get; set; }

            /// <summary>
            /// True if they were deemed similar due to Rules, but it *might* be wrong, so show the user the correct answer.
            /// </summary>
            public bool ProbablyCorrect { get; set; }

            public SimilarityData(int difference, bool probablyCorrect)
            {
                Difference = difference;
                ProbablyCorrect = probablyCorrect;
            }
        }

        [Flags]
        public enum Rules
        {
            IgnoreFirstCapitalization = 1 << 5,
            TreatWordInParenthesisAsSynonym = 1 << 4,
            TreatWordsBetweenSlashAsSynonyms = 1 << 3,
            IgnoreOpeningWhitespace = 1 << 2,
            IgnoreEndingWhitespace = 1 << 1,
            None = 1 << 0,
        }

        public const Rules SMART_RULES =
            Rules.IgnoreFirstCapitalization
            | Rules.TreatWordInParenthesisAsSynonym
            | Rules.TreatWordsBetweenSlashAsSynonyms
            | Rules.IgnoreOpeningWhitespace
            | Rules.IgnoreEndingWhitespace;

        public static SimilarityData Similarity(string userAnswer, string correctAnswer, Rules rules)
        {
            return Similarity(userAnswer, correctAnswer, rules, false);
        }

        private static SimilarityData Similarity(string userAnswer, string correctAnswer, Rules rules, bool probablyCorrect)
        {
            var similarityDatas = new List<SimilarityData>();

            void KeepBestSimilarityData()
            {
                // Keep best similarity data
                similarityDatas = similarityDatas.OrderBy(x => x.Difference).ThenBy(x => x.ProbablyCorrect).ToList();
                similarityDatas = similarityDatas.Take(1).ToList();
            }

            if (rules.HasFlag(Rules.IgnoreOpeningWhitespace))
            {
                similarityDatas.Add(Similarity(userAnswer.TrimStart(' '), correctAnswer.TrimStart(' '), rules & ~Rules.IgnoreOpeningWhitespace, true));
            }

            if (rules.HasFlag(Rules.IgnoreEndingWhitespace))
            {
                similarityDatas.Add(Similarity(userAnswer.TrimEnd(' '), correctAnswer.TrimEnd(' '), rules & ~Rules.IgnoreEndingWhitespace, true));
            }

            if (rules.HasFlag(Rules.IgnoreFirstCapitalization))
            {
                similarityDatas.Add(Similarity(CapitalizeFirstChar(userAnswer), CapitalizeFirstChar(correctAnswer), rules & ~Rules.IgnoreFirstCapitalization, true));
            }

            if (rules.HasFlag(Rules.TreatWordsBetweenSlashAsSynonyms))
            {
                if (correctAnswer.Contains("/"))
                {
                    string[] correctAnswers = correctAnswer.Split('/');
                    foreach (var ans in correctAnswers)
                    {
                        similarityDatas.Add(Similarity(userAnswer, ans.TrimStart(' '), rules, true));
                    }
                }
            }

            if (rules.HasFlag(Rules.TreatWordInParenthesisAsSynonym))
            {
                if (correctAnswer.Contains("(") && correctAnswer.Contains(")"))
                {
                    string[] spl = correctAnswer.Split('(');

                    string w1 = spl[0].TrimEnd(' ');
                    string w2 = spl[1].Split(')')[0];

                    similarityDatas.Add(Similarity(userAnswer, w1, rules, true));
                    similarityDatas.Add(Similarity(userAnswer, w2, rules, true));
                }
            }

            int difference = Fastenshtein.Levenshtein.Distance(userAnswer, correctAnswer);
            similarityDatas.Add(new SimilarityData(difference, probablyCorrect));
            KeepBestSimilarityData();
            SimilarityData best = similarityDatas.First();

            return best;
        }

        private static string CapitalizeFirstChar(string s)
        {
            s = char.ToUpper(s.First()) + string.Concat(s.Skip(1));
            return s;
        }
    }
}
