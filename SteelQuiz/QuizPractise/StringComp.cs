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

using SteelQuiz.QuizData;
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

            /// <summary>
            /// The wordpair belonging to this class instance
            /// </summary>
            public Card WordPair { get; set; }

            public SimilarityData(int difference, CorrectCertainty certainty, string correctAnswer, Card wordPair)
            {
                Difference = difference;
                Certainty = certainty;
                CorrectAnswer = correctAnswer;
                WordPair = wordPair;
            }
        }

        [Flags]
        public enum Rules
        {
            IgnoreDotsInEnd                     = 1 << 6,
            IgnoreFirstCapitalization           = 1 << 5,
            TreatWordInParenthesisAsOptional    = 1 << 4,
            TreatWordsBetweenSlashAsSynonyms    = 1 << 3,
            IgnoreOpeningWhitespace             = 1 << 2,
            IgnoreEndingWhitespace              = 1 << 1,
            None                                = 0,
        }

        public const Rules SMART_RULES =
            Rules.IgnoreDotsInEnd
            | Rules.IgnoreFirstCapitalization
            | Rules.TreatWordInParenthesisAsOptional
            | Rules.TreatWordsBetweenSlashAsSynonyms
            | Rules.IgnoreOpeningWhitespace
            | Rules.IgnoreEndingWhitespace;

        public static SimilarityData Similarity(string userAnswer, string correctAnswer, Card wordPair, Rules rules)
        {
            return Similarity(userAnswer, correctAnswer, wordPair, rules, CorrectCertainty.CompletelyCorrect);
        }

        private static SimilarityData Similarity(string userAnswer, string correctAnswer, Card wordPair, Rules rules, CorrectCertainty certainty)
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
                similarityDatas.Add(Similarity(userAnswer.TrimStart(' '), correctAnswer.TrimStart(' '), wordPair, rules & ~Rules.IgnoreOpeningWhitespace,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                // Math.Max to use worst certainty (if the certainty when calling this method was 'maybe correct', new certainty can't be 'probably correct' for instance)
            }

            if (rules.HasFlag(Rules.IgnoreEndingWhitespace))
            {
                similarityDatas.Add(Similarity(userAnswer.TrimEnd(' '), correctAnswer.TrimEnd(' '), wordPair, rules & ~Rules.IgnoreEndingWhitespace,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
            }

            if (rules.HasFlag(Rules.IgnoreFirstCapitalization))
            {
                similarityDatas.Add(Similarity(CapitalizeFirstChar(userAnswer), CapitalizeFirstChar(correctAnswer), wordPair, rules & ~Rules.IgnoreFirstCapitalization,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
            }

            if (rules.HasFlag(Rules.IgnoreDotsInEnd))
            {
                similarityDatas.Add(Similarity(userAnswer.TrimEnd('.'), correctAnswer.TrimEnd('.'), wordPair, rules & ~Rules.IgnoreDotsInEnd,
                    (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
            }

            if (rules.HasFlag(Rules.TreatWordsBetweenSlashAsSynonyms))
            {
                if (correctAnswer.Contains("/"))
                {
                    var synonymSimilarities = new List<SimilarityData>();
                    bool any = false;
                    foreach (var userSynonym in userAnswer.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        any = true;

                        var matches = new List<SimilarityData>();
                        foreach (var correctSynonym in correctAnswer.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)))
                        {
                            matches.Add(Similarity(userSynonym, correctSynonym.TrimStart(' '), wordPair, rules,
                                (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                        }

                        // Add best match
                        synonymSimilarities.Add(matches.OrderBy(x => x.Difference).First());
                    }

                    if (any)
                    {
                        // At least one synonym was entered!

                        if (synonymSimilarities.All(x => x.Difference == 0))
                        {
                            // Provided synonyms are correct
                            similarityDatas.Add(
                                new SimilarityData(0, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty), correctAnswer, wordPair));
                        }
                        else
                        {
                            similarityDatas.Add(
                                new SimilarityData(synonymSimilarities.Select(x => x.Difference).Max(),
                                (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty), correctAnswer, wordPair));
                        }
                    }
                }
            }

            if (rules.HasFlag(Rules.TreatWordInParenthesisAsOptional))
            {
                if (correctAnswer.Contains("(") && correctAnswer.Contains(")"))
                {
                    if (!correctAnswer.TrimStart().StartsWith("("))
                    {
                        string w1 = correctAnswer.Split('(')[0].TrimEnd(' '); // tarp (tarpaulin) => tarp
                        similarityDatas.Add(Similarity(userAnswer, w1, wordPair, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                    }

                    string w2 = correctAnswer.Split('(')[1].Split(')')[0].TrimStart(' ').TrimEnd(' '); // tarp (tarpaulin) => tarpaulin
                    similarityDatas.Add(Similarity(userAnswer, w2, wordPair, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.MaybeCorrect, (int)certainty)));

                    string w3 = correctAnswer.Replace("(", "").Replace(")", ""); // (eye)lash => eyelash
                    similarityDatas.Add(Similarity(userAnswer, w3, wordPair, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));

                    if (!correctAnswer.TrimEnd().EndsWith(")"))
                    {
                        string w4 = correctAnswer.Split(')')[1].TrimStart(' '); // (eye)lash => lash
                        similarityDatas.Add(Similarity(userAnswer, w4, wordPair, rules, (CorrectCertainty)Math.Max((int)CorrectCertainty.ProbablyCorrect, (int)certainty)));
                    }
                }
            }

            int difference = Fastenshtein.Levenshtein.Distance(userAnswer, correctAnswer);
            similarityDatas.Add(new SimilarityData(difference, certainty, correctAnswer, wordPair));
            KeepBestSimilarityData();
//#warning the best similarity data that is being kept is not necessarily equal to the written answer in the quiz!!! this potentially shows a wrong answer in "ProbablyCorrectAnswer" dialog
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
