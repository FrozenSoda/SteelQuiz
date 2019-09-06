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

using SteelQuiz.QuizPractise;
using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class WordPair
    {
        public string Word1 { get; set; }
        public List<string> Word1Synonyms { get; set; }

        public string Word2 { get; set; }
        public List<string> Word2Synonyms { get; set; }

        public StringComp.Rules TranslationRules { get; set; }

        public WordPair(string word1, string word2, StringComp.Rules translationRules, List<string> word1Synonyms = null, List<string> word2Synonyms = null)
        {
            Word1 = word1;
            Word2 = word2;
            TranslationRules = translationRules;
            Word1Synonyms = word1Synonyms;
            Word2Synonyms = word2Synonyms;

            if (Word1Synonyms == null)
            {
                Word1Synonyms = new List<string>();
            }

            if (Word2Synonyms == null)
            {
                Word2Synonyms = new List<string>();
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WordPair, true, true);
        }

        public bool Equals(WordPair wp2, bool ignoreSynonyms, bool ignoreTranslationRules)
        {
            if (wp2 == null)
            {
                return false;
            }

            return
                this.Word1 == ((WordPair)wp2).Word1 &&
                (ignoreSynonyms || this.Word1Synonyms.SequenceEqual(((WordPair)wp2).Word1Synonyms)) &&
                this.Word2 == ((WordPair)wp2).Word2 &&
                (ignoreSynonyms || this.Word2Synonyms.SequenceEqual(((WordPair)wp2).Word2Synonyms)) &&
                (ignoreTranslationRules || this.TranslationRules == ((WordPair)wp2).TranslationRules);
        }

        public override int GetHashCode()
        {
            var hashCode = -295472895;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Word1);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Word1Synonyms);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Word2);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Word2Synonyms);
            hashCode = hashCode * -1521134295 + TranslationRules.GetHashCode();
            return hashCode;
        }


        public WordProgData GetWordProgData()
        {
            foreach (var wordProgData in QuizCore.QuizProgress.WordProgDatas)
            {
                if (wordProgData.WordPair.Equals(this, true, true))
                {
                    return wordProgData;
                }
            }

            throw new Exception("No word progress data could be found for this word pair");
        }

        private IEnumerable<WordPair> __requiredSynonyms = null;

        /// <summary>
        /// Finds all synonyms to this wordpair that are required to be provided, including this wordpair. Only valid for the selected language.
        /// </summary>
        /// <returns>Returns the wordpairs that are synonyms to this wordpair (including this wordpair) and are required to be provided</returns>
        public IEnumerable<WordPair> GetRequiredSynonyms()
        {
            if (__requiredSynonyms != null)
            {
                ;
            }
            else if (QuizCore.QuizProgress.AnswerLanguageNum == 2)
            {
                __requiredSynonyms = QuizCore.Quiz.WordPairs.Where(x => x.Word1 == Word1);
            }
            else if (QuizCore.QuizProgress.AnswerLanguageNum == 1)
            {
                __requiredSynonyms = QuizCore.Quiz.WordPairs.Where(x => x.Word2 == Word2);
            }
            else
            {
                // should never be reached
                throw new Exception("RequiredSynonyms() reached end");
            }

            return __requiredSynonyms;
        }

        public class AnswerDiff
        {
            public string MostSimilarAnswer { get; set; }
            public int Difference { get; set; }
            public StringComp.CorrectCertainty Certainty { get; set; }
            public WordPair WordPair { get; set; }

            public AnswerDiff(int difference, string mostSimilarAnswer, StringComp.CorrectCertainty certainty, WordPair wordPair)
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

        public AnswerDiff AnswerCheck(string input, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            foreach (var wp in GetRequiredSynonyms())
            {
                similarityData = similarityData.Concat(SimilarityData(wp, input, updateProgress)).ToList();
            }

            StringComp.SimilarityData bestSimilarityData = similarityData.OrderBy(x => x.Difference).ThenBy(x => (int)x.Certainty).First();

            var ansDiff = new AnswerDiff(bestSimilarityData.Difference, bestSimilarityData.CorrectAnswer, bestSimilarityData.Certainty, bestSimilarityData.WordPair);

            if (updateProgress)
            {
                ansDiff.WordPair.GetWordProgData().AddWordTry(new WordTry(ansDiff.Correct()));
                QuizCore.SaveQuizProgress();

                ansDiff.WordPair.GetWordProgData().AskedThisRound = true;
                QuizCore.QuizProgress.SetCurrentWordPair(null);
            }

            return ansDiff;
        }

        private IEnumerable<StringComp.SimilarityData> SimilarityData(WordPair wordPair, string input, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
            {
                similarityData.Add(StringComp.Similarity(input, wordPair.Word2, wordPair, TranslationRules));
                foreach (var synonym in wordPair.Word2Synonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, wordPair, TranslationRules));
                }
            }
            else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
            {
                similarityData.Add(StringComp.Similarity(input, wordPair.Word1, wordPair, TranslationRules));
                foreach (var synonym in wordPair.Word1Synonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, wordPair, TranslationRules));
                }
            }
            else
            {
                throw new NotImplementedException("Error in WordPair.CharacterMismatches: All translation modes haven't been implemented!");
            }

            return similarityData;
        }

        /*
        public StringComp.CharacterMismatch CharacterMismatches_old(string input, bool updateProgress = true, bool recurse = false)
        {
            var mismatches = new List<StringComp.CharacterMismatch>();
            if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
            {
                mismatches.Add(StringComp.CharacterMismatches(Word2, input, TranslationRules));
                foreach (var synonym in Word2Synonyms)
                {
                    mismatches.Add(StringComp.CharacterMismatches(synonym, input, TranslationRules));
                }
            }
            else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
            {
                mismatches.Add(StringComp.CharacterMismatches(Word1, input, TranslationRules));
                foreach (var synonym in Word1Synonyms)
                {
                    mismatches.Add(StringComp.CharacterMismatches(synonym, input, TranslationRules));
                }
            }
            else
            {
                throw new NotImplementedException("Error in WordPair.CharacterMismatches: All translation modes haven't been implemented!");
            }

            // find CharacterMismatch with the least mismatch
            StringComp.CharacterMismatch bestCharacterMismatch = null;
            foreach (var mismatch in mismatches)
            {
                if (bestCharacterMismatch == null)
                {
                    bestCharacterMismatch = mismatch;
                }
                else
                {
                    if (mismatch.Cmp.Length <= bestCharacterMismatch.Cmp.Length && mismatch.Input.Length <= bestCharacterMismatch.Input.Length)
                    {
                        bestCharacterMismatch = mismatch;
                    }
                }
            }

            if (bestCharacterMismatch.Correct())
            {
                if (!recurse)
                {
                    GetWordProgData().AskedThisRound = true;
                    QuizCore.QuizProgress.SetCurrentWordPair(null);
                }
                if (updateProgress)
                {
                    GetWordProgData().AddWordTry(new WordTry(true));
                    QuizCore.SaveQuizProgress();
                }
            }
            else if (!recurse)
            {
                // check if a synonym for the was being asked as a separate word
                foreach (var wordPair in QuizCore.Quiz.WordPairs)
                {
                    if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
                    {
                        if (wordPair.Word1 == Word1 && wordPair.Word2 != Word2)
                        {
                            // check if the answer to this wordpair was correct
                            var mismatch2 = wordPair.CharacterMismatches(input, false, true);
                            if (mismatch2.Correct())
                            {
                                // a synonym for this word was being asked, the user could not know this, so don't count it as a miss in the progress
                                return new StringComp.CharacterMismatch(bestCharacterMismatch.Cmp.ToList(), bestCharacterMismatch.Input.ToList(), true);
                            }
                        }
                    }
                    else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
                    {
                        if (wordPair.Word2 == Word2 && wordPair.Word1 != Word1)
                        {
                            // check if the answer to this wordpair was correct
                            var mismatch2 = wordPair.CharacterMismatches(input, false, true);
                            if (mismatch2.Correct())
                            {
                                // a synonym for this word was being asked, the user could not know this, so don't count it as a miss in the progress
                                return new StringComp.CharacterMismatch(bestCharacterMismatch.Cmp.ToList(), bestCharacterMismatch.Input.ToList(), true);
                            }
                        }
                    }
                }

                if (updateProgress)
                {
                    GetWordProgData().AddWordTry(new WordTry(false));
                    QuizCore.SaveQuizProgress();
                }
            }

            return bestCharacterMismatch;
        }
        */
    }
}