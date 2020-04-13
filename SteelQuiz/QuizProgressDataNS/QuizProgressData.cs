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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressDataNS
{
    public enum TermsOrderBy
    {
        SuccessRate,
        QuizOrder,
        AlphabeticalTerm1,
        AlphabeticalTerm2,
    }

    public enum TermsOrderByOrder
    {
        Ascending,
        Descending,
    }

    public class QuizProgressData
    {
        public Guid QuizGUID { get; set; }
        public List<QuestionProgressData> QuestionProgressData { get; set; } = new List<QuestionProgressData>();

        [JsonProperty]
        [Obsolete("Use QuestionProgressData instead", true)]
        private List<QuestionProgressData> WordProgDatas { set => QuestionProgressData = value; }

        private int __answerLanguageNum = 2;
        /// <summary>
        /// 1 if the answer language is Language1, otherwise 2
        /// </summary>
        public int AnswerLanguageNum
        {
            get
            {
                return __answerLanguageNum;
            }

            set
            {
                __answerLanguageNum = value;

                if (QuizCore.Quiz != null && QuizCore.Quiz.GUID == QuizGUID)
                {
                    foreach (var wordPair in QuizCore.Quiz.WordPairs)
                    {
                        wordPair.ResetRequiredSynonymsMemo();
                    }
                }
            }
        }

        [JsonIgnore]
        /// <summary>
        /// The language to answer in when practising the quiz
        /// </summary>
        public string AnswerLanguage
        {
            get
            {
                if (QuizCore.Quiz != null && QuizCore.Quiz.GUID == QuizGUID)
                {
                    return AnswerLanguageNum == 2 ? QuizCore.Quiz.Language2 : QuizCore.Quiz.Language1;
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonIgnore]
        public string QuestionLanguage
        {
            get
            {
                if (QuizCore.Quiz.GUID != QuizGUID)
                {
                    return null;
                }

                return QuizCore.Quiz.Language2 == AnswerLanguage ? QuizCore.Quiz.Language1 : QuizCore.Quiz.Language2;
            }
        }

        /// <summary>
        /// How many of the last attempts to use as basis for Intelligent Learning question selection. 0 if all attempts ever made should count
        /// </summary>
        public int IntelligentLearningLastAnswersBasisCount { get; set; } = 3;

        /// <summary>
        /// The Minimum number of answer tries per question to consider skipping it with Intelligent Learning.
        /// </summary>
        public int MinimumTriesCountToConsiderSkippingQuestion { get; set; } = 2;

        [JsonProperty] // required for deserialization of property with private setter
        internal List<QuestionAnswerPair> CurrentWordPairs { get; set; } = new List<QuestionAnswerPair>();

        [JsonIgnore]
        /// <summary>
        /// True if the question to perform a full test has been asked (during this application instance)
        /// </summary>
        public bool MasterNoticeShowed { get; set; } = false;

        public bool FullTestInProgress { get; set; } = false;

        /// <summary>
        /// Contains the number of correct answers during a full test
        /// </summary>
        public int CorrectAnswersThisRound { get; set; } = 0;

        public TermsOrderBy TermsDisplayOrder { get; set; } = TermsOrderBy.SuccessRate;
        public TermsOrderByOrder TermsDisplayOrderOrder { get; set; } = TermsOrderByOrder.Ascending;

        public bool AskQuestionsInRandomOrder { get; set; } = true;

        public QuizProgressData(Quiz quiz, bool initWordProgDatas = true)
        {
            if (quiz == null)
            {
                return;
            }

            if (initWordProgDatas)
            {
                foreach (var wordPair in quiz.WordPairs)
                {
                    bool found = false;
                    foreach (var wordProgData in WordProgDatas)
                    {
                        if (wordProgData.WordPair.Equals(wordPair))
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        WordProgDatas.Add(new QuestionProgressData(wordPair));
                    }
                }
            }

            QuizGUID = quiz.GUID;
        }

        /// <summary>
        /// Calculates the success rate between 0 and 1 for answering this word, for the amount of tries completed
        /// </summary>
        /// <returns>Returns the success rate between 0 and 1 for answering this word, for the amount of tries completed</returns>
        public double GetSuccessRate()
        {
            double val = WordProgDatas.Sum(x => x.GetSuccessRate()) / WordProgDatas.Count();
            if (double.IsNaN(val))
            {
                return 0d;
            }
            return val;
        }

        /// <summary>
        /// Returns the learning progress for this quiz, 
        /// that is, the average of the success rates for all wordpairs, that is between 0 and 1, divided by total amount of tries to save (WORD_TRIES_TO_KEEP)
        /// </summary>
        /// <returns></returns>
        public double GetLearningProgress()
        {
            double val = WordProgDatas.Sum(x => x.GetLearningProgress()) / WordProgDatas.Count();
            if (double.IsNaN(val))
            {
                return 0d;
            }
            return val;
        }

        // due to CurrentWordPair not preserving references due to serialization, implement setter through method instead, to avoid confusion regarding references
        public void SetCurrentQuestion(QuestionAnswerPair question)
        {
            if (question == null)
            {
                CurrentWordPairs.Clear();
            }
            else
            {
                CurrentWordPairs = question.GetRequiredSynonyms().ToList();
            }
        }

        public IEnumerable<QuestionAnswerPair> WordsNotToAsk()
        {
            // find words already asked this round
            var wordsAlreadyAsked = new List<QuestionAnswerPair>();
            for (int i = 0; i < WordProgDatas.Count; ++i)
            {
                if (WordProgDatas[i].AskedThisRound || WordProgDatas[i].SkipThisRound)
                {
                    wordsAlreadyAsked.Add(WordProgDatas[i].WordPair);
                }
            }

            return wordsAlreadyAsked;
        }
    }
}