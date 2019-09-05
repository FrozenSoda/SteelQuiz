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
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz.QuizProgressData
{
    public class QuizProgData
    {
        public Guid QuizGUID { get; set; }
        public List<WordProgData> WordProgDatas { get; set; } = null;

        /// <summary>
        /// 1 if the answer language is Language1, otherwise 2
        /// </summary>
        public int AnswerLanguageNum { get; set; }

        private string __answerLanguage = null;

        /// <summary>
        /// The language to answer in when practising the quiz
        /// </summary>
        public string AnswerLanguage
        {
            get
            {
                return AnswerLanguageNum == 2 ? QuizCore.Quiz.Language2 : QuizCore.Quiz.Language1;

                /*
                if (__answerLanguage != null)
                {
                    return __answerLanguage;
                }
                else if (QuizCore.Quiz.GUID == QuizGUID)
                {
                    __answerLanguage = QuizCore.Quiz.Language2;
                    return __answerLanguage;
                }
                else
                {
                    return __answerLanguage;
                }
                */
            }

            set
            {
                __answerLanguage = value;
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

        [JsonProperty] // required for deserialization of property with private setter
        internal WordPair CurrentWordPair { get; set; } = null;

        /*
         * True if the question to perform a full test has been asked (during this application instance)
         * 
         * RESET THIS PROPERTY AFTER LOADING PROGRESS DATA
         */
        public bool MasterNoticeShowed { get; set; } = false;

        public bool FullTestInProgress { get; set; } = false;

        /// <summary>
        /// Contains the number of correct answers during a full test
        /// </summary>
        public int CorrectAnswersThisRound { get; set; } = 0;

        public QuizProgData(Quiz quiz, bool initWordProgDatas = true)
        {
            if (quiz == null)
            {
                return;
            }

            AnswerLanguage = quiz.Language2;

            if (WordProgDatas == null)
            {
                WordProgDatas = new List<WordProgData>();
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
                        WordProgDatas.Add(new WordProgData(wordPair));
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
            return WordProgDatas.Sum(x => x.GetSuccessRate()) / WordProgDatas.Count();
        }

        /// <summary>
        /// Returns the learning progress for this quiz, 
        /// that is, the average of the success rates for all wordpairs, that is between 0 and 1, divided by total amount of tries to save (WORD_TRIES_TO_KEEP)
        /// </summary>
        /// <returns></returns>
        public double GetLearningProgress()
        {
            return WordProgDatas.Sum(x => x.GetLearningProgress()) / WordProgDatas.Count();
        }

        // due to CurrentWordPair not preserving references due to serialization, implement setter through method instead, to avoid confusion regarding references
        public void SetCurrentWordPair(WordPair wordPair)
        {
            CurrentWordPair = wordPair;
        }

        public IEnumerable<WordPair> WordsNotToAsk()
        {
            // find words already asked this round
            var wordsAlreadyAsked = new List<WordPair>();
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