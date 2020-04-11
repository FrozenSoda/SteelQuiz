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
        private const int MINIMUM_QUESTIONS_PER_ROUND = 5;

        private static int __skipNextMasterNotice = 0;
        /// <summary>
        /// How many times to skip the next "Congratulations - you have learned all the words" notification during this practise session. Can be decremented without checking, it won't allow values under 0
        /// </summary>
        public static int SkipNextMasterNotice
        {
            get
            {
                return __skipNextMasterNotice;
            }

            set
            {
                if (value >= 0)
                {
                    __skipNextMasterNotice = value;
                }
                else
                {
                    __skipNextMasterNotice = 0;
                }
            }
        }

        /// <summary>
        /// Generates a question/word to be asked, while taking current word and Intelligent Learning settings into account
        /// </summary>
        /// <returns>Returns a question/word to be asked</returns>
        public static WordPair GenerateWordPair()
        {
            QuizCore.ResetWordsAskedThisRoundMemo();

            if (QuizCore.QuizProgress.CurrentWordPairs != null && QuizCore.QuizProgress.CurrentWordPairs.Count > 0)
            {
                return QuizCore.QuizProgress.CurrentWordPairs[0];
            }

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                return GenerateWordPair_NoIntelligentLearning();
            }
            else
            {
                return GenerateWordPair_IntelligentLearning();
            }
        }

        private static double GetLearningProgress(WordProgData wordProgData)
        {
            if (QuizCore.QuizProgress.IntelligentLearningLastAnswersBasisCount == 0)
            {
                return wordProgData.GetSuccessRate();
            }
            else
            {
                return wordProgData.GetLearningProgress(QuizCore.QuizProgress.IntelligentLearningLastAnswersBasisCount);
            }
        }

        /// <summary>
        /// Generates a question/word to be asked, without taking Intelligent Learning progress into account, that is, pure random (excluding already asked words)
        /// </summary>
        /// <returns></returns>
        private static WordPair GenerateWordPair_NoIntelligentLearning()
        {
            var wordsNotToAsk = QuizCore.QuizProgress.WordsNotToAsk();

            if (wordsNotToAsk.Count() == QuizCore.Quiz.WordPairs.Count)
            {
                //NewRound();
                return null;
            }

            var wordsNotToAsk_Indexes = new List<int>();

            for (int i = 0; i < QuizCore.Quiz.WordPairs.Count; ++i)
            {
                for (int j = 0; j < wordsNotToAsk.Count(); ++j)
                {
                    if (QuizCore.Quiz.WordPairs[i].Equals(wordsNotToAsk.ElementAt(j)))
                    {
                        wordsNotToAsk_Indexes.Add(i);
                    }
                }
            }

            int index;
            if (QuizCore.QuizProgress.AskQuestionsInRandomOrder)
            {
                index = new Random().RandomNext(0, QuizCore.Quiz.WordPairs.Count, wordsNotToAsk_Indexes.ToArray());
            }
            else
            {
                index = Enumerable.Range(0, int.MaxValue).Except(wordsNotToAsk_Indexes).FirstOrDefault();
            }
            var wordPair = QuizCore.Quiz.WordPairs[index];
            QuizCore.QuizProgress.SetCurrentWordPair(wordPair);
            QuizCore.SaveQuizProgress();
            return wordPair;
        }

        /// <summary>
        /// Generates a question/word to be asked, while taking Intelligent Learning progress into account
        /// </summary>
        /// <returns></returns>
        private static WordPair GenerateWordPair_IntelligentLearning()
        {
            var alreadyAsked = QuizCore.QuizProgress.WordsNotToAsk();

            if (alreadyAsked.Count() == QuizCore.Quiz.WordPairs.Count)
            {
                return null;
            }

            //double askProb(double successRate)
            double askProb(double learningProgress)
            {
                const double PROB_OFFSET = 0.15;
                var prb = 1 - learningProgress;
                if (prb == 0)
                {
                    prb += PROB_OFFSET;
                }

                return prb;
            }

            // universal probability
            //double u = QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)).Sum(p => askProb(p.GetSuccessRate()));
            double u = QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)).Sum(p => askProb(GetLearningProgress(p)));

            // random number between 0 and u
            double r = new Random().NextDouble() * u;

            double sum = 0;
            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)))
            {
                //var askPrb = askProb(wordPairData.GetSuccessRate());
                var askPrb = askProb(GetLearningProgress(wordPairData));
                sum += askPrb;
                if (r <= sum)
                {
                    QuizCore.QuizProgress.SetCurrentWordPair(wordPairData.WordPair);
                    QuizCore.SaveQuizProgress();
                    return wordPairData.WordPair;
                }
            }

            // should never be reached
            throw new Exception("Probability error at QuizAI.GenerateWordPair()");
        }

        /// <summary>
        /// Starts a new round, for instance by re-evaluating words to be asked
        /// </summary>
        public static void NewRound()
        {
            QuizCore.QuizProgress.CurrentWordPairs?.Clear();

            //const int MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING = 2;

            //double dontAskProb(double successRate, int triesCount)
            double dontAskProb(double learningProgress, int triesCount)
            {
                if (triesCount < QuizCore.QuizProgress.MinimumTriesCountToConsiderSkippingQuestion)
                {
                    return 0;
                }

                const double PROB_OFFSET = 0.15;
                var prb = learningProgress;
                if (prb == 1)
                {
                    Debug.Assert((triesCount - (QuizCore.QuizProgress.MinimumTriesCountToConsiderSkippingQuestion - 1)) > 0); // do not divide by zero
                    prb -= PROB_OFFSET / (triesCount - (QuizCore.QuizProgress.MinimumTriesCountToConsiderSkippingQuestion - 1));
                }

                return prb;
            }

            QuizCore.ResetTotalWordsThisRoundCountMemo();
            QuizCore.ResetWordsAskedThisRoundMemo();
            QuizCore.QuizProgress.CorrectAnswersThisRound = 0;

            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas)
            {
                wordPairData.AskedThisRound = false;
                wordPairData.SkipThisRound = false;
            }

            var rnd = new Random();
            var skipCount = 0;

            // prevent the MINIMUM_QUESTIONS_PER_ROUND number of questions with worst success rate, from being skipped
            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas.OrderBy(x => GetLearningProgress(x)).Skip(MINIMUM_QUESTIONS_PER_ROUND))
            {
                // Eventually skip asking the word

                //var dontAskAgainPrb = dontAskProb(wordPairData.GetSuccessRate(), wordPairData.GetWordTriesCount());
                var dontAskAgainPrb = dontAskProb(GetLearningProgress(wordPairData), wordPairData.GetWordTriesCount());

                if (!QuizCore.QuizProgress.FullTestInProgress
                    && wordPairData.GetWordTriesCount() >= QuizCore.QuizProgress.MinimumTriesCountToConsiderSkippingQuestion
                    && rnd.NextBool(dontAskAgainPrb))
                {
                    wordPairData.SkipThisRound = true;
                    ++skipCount;
                }
            }

            if (QuizCore.QuizProgress.AskQuestionsInRandomOrder)
            {
                QuizCore.QuizProgress.WordProgDatas.QuizRandomize();
            }
            else
            {
                QuizCore.QuizProgress.WordProgDatas = QuizCore.QuizProgress.WordProgDatas.OrderBy(x => QuizCore.Quiz.WordPairs.IndexOf(x.WordPair)).ToList();
            }

            QuizCore.SaveQuizProgress();
        }
    }
}