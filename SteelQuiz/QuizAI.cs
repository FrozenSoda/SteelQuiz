﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;

namespace SteelQuiz
{
    public static class QuizAI
    {
        public static bool SkipNextMasterNotice { get; set; } = false;

        public static WordPair GenerateWordPair()
        {
            if (QuizCore.QuizProgress.CurrentWordPair != null)
            {
                return QuizCore.QuizProgress.CurrentWordPair;
            }

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                return GenerateWordPairWithoutAI();
            }
            else
            {
                return GenerateWordPairAI();
            }
        }

        public static WordPair GenerateWordPairWithoutAI()
        {
            var wordsNotToAsk = QuizCore.QuizProgress.WordsNotToAsk();

            if (wordsNotToAsk.Length == QuizCore.Quiz.WordPairs.Length)
            {
                NewRound();
                return null;
            }

            var wordsNotToAsk_Indexes = new List<int>();

            for (int i = 0; i < QuizCore.Quiz.WordPairs.Length; ++i)
            {
                for (int j = 0; j < wordsNotToAsk.Length; ++j)
                {
                    if (QuizCore.Quiz.WordPairs[i].Equals(wordsNotToAsk[j]))
                    {
                        wordsNotToAsk_Indexes.Add(i);
                    }
                }
            }

            var rndIndex = new Random().RandomNext(0, QuizCore.Quiz.WordPairs.Length, wordsNotToAsk_Indexes.ToArray());
            var wordPair = QuizCore.Quiz.WordPairs[rndIndex];
            QuizCore.QuizProgress.SetCurrentWordPair(wordPair);
            QuizCore.SaveProgress();
            return wordPair;
        }

        public static WordPair GenerateWordPairAI()
        {
            var alreadyAsked = QuizCore.QuizProgress.WordsNotToAsk();

            if (alreadyAsked.Length == QuizCore.Quiz.WordPairs.Length)
            {
                //new round
                NewRound();
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
                    QuizCore.SaveProgress();
                    return wordPairData.WordPair;
                }
            }

            // should never be reached
            throw new Exception("Probability error at QuizAI.GenerateWordPair()");
        }

        /*
         * Inefficient method - waiting for occurrence in while loop
         */
        public static WordPair GenerateWordPair_old()
        {
            var alreadyAsked = QuizCore.QuizProgress.WordsNotToAsk(); //words already asked this round

            if (alreadyAsked.Length == QuizCore.Quiz.WordPairs.Length)
            {
                //new round
                NewRound();
                return null;
            }

            while (true)
            {
                foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas.Where(x => !alreadyAsked.Contains(x.WordPair)))
                {
                    double askProb = 1 - wordPairData.GetSuccessRate() + 0.05;
                    if (askProb > 1)
                    {
                        askProb = 1;
                    }

                    if (new Random().NextBool(askProb))
                    {
                        wordPairData.AskedThisRound = true;
                        QuizCore.SaveProgress();
                        return wordPairData.WordPair;
                    }
                }
            }
        }

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
                    var allSuccess100 = true;
                    foreach (var word in QuizCore.QuizProgress.WordProgDatas)
                    {
                        if (word.GetSuccessRate() < 1)
                        {
                            allSuccess100 = false;
                        }
                    }

                    if (allSuccess100)
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
                                Program.inQuiz.SwitchAIMode();
                                return;
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

            QuizCore.SaveProgress();
        }
    }
}