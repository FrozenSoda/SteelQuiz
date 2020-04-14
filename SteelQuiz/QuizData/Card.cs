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
        #endregion

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

                return QuizCore.QuizProgress.AnswerLanguageNum == 2 ? Front : Back;
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

                return QuizCore.QuizProgress.AnswerLanguageNum == 2 ? Back : Front;
            }
        }

        public Card(string word1, string word2, StringComp.Rules translationRules, List<string> frontSynonyms = null, List<string> backSynonyms = null)
        {
            Front = word1;
            Back = word2;
            TranslationRules = translationRules;

            if (FrontSynonyms != null)
            {
                FrontSynonyms = frontSynonyms;
            }
            if (BackSynonyms != null)
            {
                BackSynonyms = backSynonyms;
            }
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
                (ignoreTranslationRules || this.TranslationRules == ((Card)wp2).TranslationRules);
        }

        public override int GetHashCode()
        {
            var hashCode = -295472895;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Front);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(FrontSynonyms);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Back);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(BackSynonyms);
            hashCode = hashCode * -1521134295 + TranslationRules.GetHashCode();
            return hashCode;
        }


        public CardProgress GetQuestionProgressData(QuizProgress quizProgress)
        {
            foreach (var wordProgData in quizProgress.CardProgress)
            {
                if (wordProgData.Card.Equals(this, true, true))
                {
                    return wordProgData;
                }
            }

            throw new Exception("No word progress data could be found for this word pair");
        }

        private IEnumerable<Card> __requiredSynonyms = null;

        /// <summary>
        /// Finds all synonyms to this wordpair that are required to be provided, including this wordpair. Only valid for the selected language.
        /// </summary>
        /// <returns>Returns the wordpairs that are synonyms to this wordpair (including this wordpair) and are required to be provided</returns>
        public IEnumerable<Card> GetRequiredSynonyms(Quiz quiz)
        {
            if (__requiredSynonyms != null)
            {
                ;
            }
            else if (quiz.ProgressData.AnswerCardSide == CardSide.Back)
            {
                __requiredSynonyms = quiz.Cards.Where(x => x.Front == Front);
            }
            else if (quiz.ProgressData.AnswerCardSide == CardSide.Front)
            {
                __requiredSynonyms = quiz.Cards.Where(x => x.Back == Back);
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

            foreach (var wp in GetRequiredSynonyms(quiz).Where(x => answerIgnores == null || !answerIgnores.Contains(x.Answer)))
            {
                similarityData = similarityData.Concat(SimilarityData(wp, input, updateProgress)).ToList();
            }

            StringComp.SimilarityData bestSimilarityData = similarityData.OrderBy(x => x.Difference).ThenBy(x => (int)x.Certainty).First();

            var ansDiff = new AnswerDiff(bestSimilarityData.Difference, bestSimilarityData.CorrectAnswer, bestSimilarityData.Certainty, bestSimilarityData.WordPair);

            if (updateProgress)
            {
                ansDiff.WordPair.GetQuestionProgressData(quiz).AddAnswerAttempt(new AnswerAttempt(ansDiff.Correct()));
            }

            if (ansDiff.Correct())
            {
                ansDiff.WordPair.GetQuestionProgressData(quiz).AskedThisRound = true;

                if (ansDiff.WordPair.GetRequiredSynonyms(quiz).Select(x => x.GetQuestionProgressData(quiz).AskedThisRound).All(x => x == true))
                {
                    quiz.ProgressData.SetCurrentQuestion(null);
                }
            }

            QuizCore.SaveQuizProgress(quiz);

            return ansDiff;
        }

        private IEnumerable<StringComp.SimilarityData> SimilarityData(Card wordPair, string input, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language2)
            {
                similarityData.Add(StringComp.Similarity(input, wordPair.Back, wordPair, TranslationRules));
                foreach (var synonym in wordPair.BackSynonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, wordPair, TranslationRules));
                }
            }
            else if (QuizCore.QuizProgress.AnswerLanguage == QuizCore.Quiz.Language1)
            {
                similarityData.Add(StringComp.Similarity(input, wordPair.Front, wordPair, TranslationRules));
                foreach (var synonym in wordPair.FrontSynonyms)
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