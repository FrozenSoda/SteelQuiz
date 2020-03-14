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

using Newtonsoft.Json;
using SteelQuiz.QuizPractise;
using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class WordPair
    {
        public string Word1 { get; set; }
        public List<string> Word1Synonyms { get; set; } = new List<string>();
        public Guid Term1Image { get; set; }

        public string Word2 { get; set; }
        public List<string> Word2Synonyms { get; set; } = new List<string>();
        public Guid Term2Image { get; set; }

        public StringComp.Rules TranslationRules { get; set; }

        [JsonIgnore]
        public string Question
        {
            get
            {
                if (QuizCore.Quiz == null || QuizCore.QuizProgress == null || QuizCore.Quiz.GUID != QuizCore.QuizProgress.QuizGUID)
                {
                    return null;
                }

                return QuizCore.QuizProgress.AnswerLanguageNum == 2 ? Word1 : Word2;
            }
        }

        [JsonIgnore]
        public string Answer
        {
            get
            {
                if (QuizCore.Quiz == null || QuizCore.QuizProgress == null || QuizCore.Quiz.GUID != QuizCore.QuizProgress.QuizGUID)
                {
                    return null;
                }

                return QuizCore.QuizProgress.AnswerLanguageNum == 2 ? Word2 : Word1;
            }
        }

        public WordPair(string word1, string word2, StringComp.Rules translationRules, List<string> word1Synonyms = null, List<string> word2Synonyms = null)
        {
            Word1 = word1;
            Word2 = word2;
            TranslationRules = translationRules;

            if (word1Synonyms != null)
            {
                Word1Synonyms = word1Synonyms;
            }
            if (word2Synonyms != null)
            {
                Word2Synonyms = word2Synonyms;
            }
        }

        public Image GetTerm1Image(Quiz quiz)
        {
            return quiz.QuizImages.Where(x => x.Guid == Term1Image).Select(x => x.Image).FirstOrDefault();
        }

        public Image GetTerm2Image(Quiz quiz)
        {
            return quiz.QuizImages.Where(x => x.Guid == Term2Image).Select(x => x.Image).FirstOrDefault();
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
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Term1Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Term2Image);
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

        public void ResetRequiredSynonymsMemo()
        {
            __requiredSynonyms = null;
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

        /// <summary>
        /// Checks the answer to see if it is correct, and returns data about the closest match
        /// </summary>
        /// <param name="input">The user answer</param>
        /// <param name="answerIgnores">In case of a question with multiple answers, contains the answers already provided</param>
        /// <param name="updateProgress">True if progress should be updated, otherwise false</param>
        /// <returns></returns>
        public AnswerDiff AnswerCheck(string input, IEnumerable<string> answerIgnores = null, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            foreach (var wp in GetRequiredSynonyms().Where(x => answerIgnores == null || !answerIgnores.Contains(x.Answer)))
            {
                similarityData = similarityData.Concat(SimilarityData(wp, input, updateProgress)).ToList();
            }

            StringComp.SimilarityData bestSimilarityData = similarityData.OrderBy(x => x.Difference).ThenBy(x => (int)x.Certainty).First();

            var ansDiff = new AnswerDiff(bestSimilarityData.Difference, bestSimilarityData.CorrectAnswer, bestSimilarityData.Certainty, bestSimilarityData.WordPair);

            if (updateProgress)
            {
                ansDiff.WordPair.GetWordProgData().AddWordTry(new WordTry(ansDiff.Correct()));
            }

            if (ansDiff.Correct())
            {
                ansDiff.WordPair.GetWordProgData().AskedThisRound = true;

                if (ansDiff.WordPair.GetRequiredSynonyms().Select(x => x.GetWordProgData().AskedThisRound).All(x => x == true))
                {
                    QuizCore.QuizProgress.SetCurrentWordPair(null);
                }
            }

            QuizCore.SaveQuizProgress();

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
    }
}