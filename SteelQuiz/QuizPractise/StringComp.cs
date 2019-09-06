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
        public enum CorrectCertainty
        {
            CompletelyCorrect = 0,
            ProbablyCorrect = 1,
            MaybeCorrect = 2,
        }

        public class SimilarityData
        {
            /// <summary>
            /// How different the words were. A value where 0 equals total similarity. The higher Difference, the less similar.
            /// </summary>
            public int Difference { get; set; }

            /// <summary>
            /// How certain the comparison algorithm is that the user answer was correct.
            /// </summary>
            public CorrectCertainty Certainty { get; set; }

            /// <summary>
            /// The correct answer the user answer was compared to
            /// </summary>
            public string CorrectAnswer { get; set; }

            public SimilarityData(int difference, CorrectCertainty certainty, string correctAnswer)
            {
                Difference = difference;
                Certainty = certainty;
                CorrectAnswer = correctAnswer;
            }
        }

        [Flags]
        public enum Rules
        {
            IgnoreFirstCapitalization = 1 << 5,
            TreatWordInParenthesisAsOptional = 1 << 4,
            TreatWordsBetweenSlashAsSynonyms = 1 << 3,
            IgnoreOpeningWhitespace = 1 << 2,
            IgnoreEndingWhitespace = 1 << 1,
            None = 1 << 0,
        }

        public const Rules SMART_RULES =
            Rules.IgnoreFirstCapitalization
            | Rules.TreatWordInParenthesisAsOptional
            | Rules.TreatWordsBetweenSlashAsSynonyms
            | Rules.IgnoreOpeningWhitespace
            | Rules.IgnoreEndingWhitespace;

        public static SimilarityData Similarity(string userAnswer, string correctAnswer, Rules rules)
        {
            return Similarity(userAnswer, correctAnswer, rules, CorrectCertainty.CompletelyCorrect);
        }

        private static SimilarityData Similarity(string userAnswer, string correctAnswer, Rules rules, CorrectCertainty certainty)
        {
            var similarityDatas = new List<SimilarityData>();

            void KeepBestSimilarityData()
            {
                // Keep best similarity data
                similarityDatas = similarityDatas.OrderBy(x => x.Difference).ThenBy(x => (int)x.Certainty).ToList();
                similarityDatas = similarityDatas.Take(1).ToList();
            }

            if (rules.HasFlag(Rules.IgnoreOpeningWhitespace))
            {
                similarityDatas.Add(Similarity(userAnswer.TrimStart(' '), correctAnswer.TrimStart(' '), rules & ~Rules.IgnoreOpeningWhitespace,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                // Math.Max to use worst certainty (if the certainty when calling this method was 'maybe correct', new certainty can't be 'probably correct' for instance)
            }

            if (rules.HasFlag(Rules.IgnoreEndingWhitespace))
            {
                similarityDatas.Add(Similarity(userAnswer.TrimEnd(' '), correctAnswer.TrimEnd(' '), rules & ~Rules.IgnoreEndingWhitespace,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
            }

            if (rules.HasFlag(Rules.IgnoreFirstCapitalization))
            {
                similarityDatas.Add(Similarity(CapitalizeFirstChar(userAnswer), CapitalizeFirstChar(correctAnswer), rules & ~Rules.IgnoreFirstCapitalization,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
            }

            if (rules.HasFlag(Rules.TreatWordsBetweenSlashAsSynonyms))
            {
                if (correctAnswer.Contains("/"))
                {
                    string[] correctAnswers = correctAnswer.Split('/');
                    foreach (var ans in correctAnswers)
                    {
                        similarityDatas.Add(Similarity(userAnswer, ans.TrimStart(' '), rules,
                            (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                    }
                }
            }

            if (rules.HasFlag(Rules.TreatWordInParenthesisAsOptional))
            {
                if (correctAnswer.Contains("(") && correctAnswer.Contains(")"))
                {
                    string w1 = correctAnswer.Split('(')[0].TrimEnd(' '); // tarp (tarpaulin) => tarp
                    string w2 = correctAnswer.Split('(')[1].Split(')')[0].TrimStart(' ').TrimEnd(' '); // tarp (tarpaulin) => tarpaulin
                    string w3 = correctAnswer.Replace("(", "").Replace(")", ""); // (eye)lash => eyelash
                    string w4 = correctAnswer.Split(')')[1].TrimStart(' '); // (eye)lash => lash
                    //string w2 = spl[1].Split(')')[0];

                    similarityDatas.Add(Similarity(userAnswer, w1, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                    similarityDatas.Add(Similarity(userAnswer, w2, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.MaybeCorrect, (int)certainty)));
                    similarityDatas.Add(Similarity(userAnswer, w3, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                    similarityDatas.Add(Similarity(userAnswer, w4, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                }
            }

            int difference = Fastenshtein.Levenshtein.Distance(userAnswer, correctAnswer);
            similarityDatas.Add(new SimilarityData(difference, certainty, correctAnswer));
            KeepBestSimilarityData();
            SimilarityData best = similarityDatas.First();

            return best;
        }

        private static string CapitalizeFirstChar(string s)
        {
            if (s == "")
            {
                return s;
            }

            s = char.ToUpper(s.First()) + string.Concat(s.Skip(1));
            return s;
        }
    }
}
