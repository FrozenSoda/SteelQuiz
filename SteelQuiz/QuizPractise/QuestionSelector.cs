﻿/*
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
using System.Windows.Forms;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;
using SteelQuiz.Util;

namespace SteelQuiz.QuizPractise
{
    public static class QuestionSelector
    {
        /// <summary>
        /// Skips the next "Congratulations - you have learned all the words" notification during this practise session
        /// </summary>
        public static bool SkipNextMasterNotice { get; set; } = false;

        /// <summary>
        /// Generates a question/word to be asked, while taking current word and Intelligent Learning settings into account
        /// </summary>
        /// <returns>Returns a question/word to be asked</returns>
        public static WordPair GenerateWordPair()
        {
            QuizCore.ResetWordsAskedThisRoundMemo();

            if (QuizCore.QuizProgress.CurrentWordPair != null)
            {
                return QuizCore.QuizProgress.CurrentWordPair;
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

            var rndIndex = new Random().RandomNext(0, QuizCore.Quiz.WordPairs.Count, wordsNotToAsk_Indexes.ToArray());
            var wordPair = QuizCore.Quiz.WordPairs[rndIndex];
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

            double askProb(double successRate)
            {
                const double PROB_OFFSET = 0.15;
                var prb = 1 - successRate;
                if (prb == 0)
                {
                    prb += PROB_OFFSET;
                }

                return prb;
            }

            // universal probability
            double u = QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)).Sum(p => askProb(p.GetSuccessRate()));

            // random number between 0 and u
            double r = new Random().NextDouble() * u;

            double sum = 0;
            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)))
            {
                var askPrb = askProb(wordPairData.GetSuccessRate());
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
            const int MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING = 2;

            double dontAskProb(double successRate, int triesCount)
            {
                if (triesCount == 0)
                {
                    return 0;
                }

                const double PROB_OFFSET = 0.15;
                var prb = successRate;
                if (prb == 1)
                {
                    prb -= PROB_OFFSET / (triesCount - (MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING - 1));
                }

                return prb;
            }

            QuizCore.ResetTotalWordsThisRoundCountMemo();
            QuizCore.ResetWordsAskedThisRoundMemo();
            QuizCore.QuizProgress.CorrectAnswersThisRound = 0;

            var rnd = new Random();
            var skipCount = 0;
            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas)
            {
                wordPairData.AskedThisRound = false;
                wordPairData.SkipThisRound = false;

                // Eventually skip asking the word

                var dontAskAgainPrb = dontAskProb(wordPairData.GetSuccessRate(), wordPairData.GetWordTriesCount());

                if (!QuizCore.QuizProgress.FullTestInProgress
                    && wordPairData.GetWordTriesCount() >= MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING
                    && rnd.NextBool(dontAskAgainPrb))
                {
                    wordPairData.SkipThisRound = true;
                    ++skipCount;
                }
            }

            if (skipCount == QuizCore.QuizProgress.WordProgDatas.Count)
            {
                if (!QuizCore.QuizProgress.MasterNoticeShowed)
                {
                    var allLearned100 = true;
                    foreach (var word in QuizCore.QuizProgress.WordProgDatas)
                    {
                        if (word.GetLearningProgress() < 1 && word.GetWordTriesCount() >= WordProgData.WORD_TRIES_FOR_LEARNING_PROGRESS)
                        {
                            allLearned100 = false;
                        }
                    }

                    if (allLearned100)
                    {
                        if (!SkipNextMasterNotice)
                        {
                            QuizCore.QuizProgress.MasterNoticeShowed = true;
                            var msg = MessageBox.Show("Congratulations! It seems that you have mastered this quiz. " +
                                "Repeat it to make sure you don't forget it, and don't remember to do a full test of the words to make sure you still know them all."
                                + "\r\n\r\nPerform a full test now?",
                                "SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (msg == DialogResult.Yes)
                            {
                                Program.frmInQuiz.SwitchIntelligentLearningMode();
                                return;
                            }
                            else
                            {
                                SkipNextMasterNotice = true;
                            }
                        }
                        else
                        {
                            SkipNextMasterNotice = false;
                        }
                    }
                }

                // if all words are skipped, select five random words to ask (remove skip sign)
                const int MAXIMUM_WORDS_TO_GENERATE = 5;
                var toAsk = new Random().RandomUnique(0, QuizCore.QuizProgress.WordProgDatas.Count,
                    QuizCore.QuizProgress.WordProgDatas.Count >= MAXIMUM_WORDS_TO_GENERATE ? MAXIMUM_WORDS_TO_GENERATE : QuizCore.QuizProgress.WordProgDatas.Count);
                for (int i = 0; i < QuizCore.QuizProgress.WordProgDatas.Count; ++i)
                {
                    if (toAsk.Contains(i))
                    {
                        QuizCore.QuizProgress.WordProgDatas[i].SkipThisRound = false;
                    }
                }
            }

            QuizCore.QuizProgress.WordProgDatas.QuizRandomize();

            QuizCore.SaveQuizProgress();
        }
    }
}