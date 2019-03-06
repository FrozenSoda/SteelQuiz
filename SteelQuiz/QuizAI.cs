using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;

namespace SteelQuiz
{
    public static class QuizAI
    {
        public static WordPair GenerateWordPair()
        {
            if (QuizCore.QuizProgress.CurrentWordPair != null)
            {
                return QuizCore.QuizProgress.CurrentWordPair;
            }

            var alreadyAsked = QuizCore.QuizProgress.WordsNotToAsk(); //words already asked this round

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

        private static void NewRound()
        {
            const int MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING = 2;

            double dontAskProb(double successRate, double triesCount)
            {
                const double PROB_OFFSET = 0.15;
                var prb = successRate;
                if (prb == 1)
                {
                    prb -= PROB_OFFSET / (triesCount - (MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING - 1));
                }

                return prb;
            }

            foreach (var wordPairData in QuizCore.QuizProgress.WordProgDatas)
            {
                wordPairData.AskedThisRound = false;
                wordPairData.SkipThisRound = false;

                // Eventually skip asking the word

                var dontAskAgainPrb = dontAskProb(wordPairData.GetSuccessRate(), wordPairData.GetWordTriesCount());

                if (wordPairData.GetWordTriesCount() >= MINIMUM_TRIES_COUNT_TO_CONSIDER_SKIPPING && new Random().NextBool(dontAskAgainPrb))
                {
                    wordPairData.SkipThisRound = true;
                }
            }
            QuizCore.QuizProgress.WordProgDatas.QuizRandomize();

            QuizCore.SaveProgress();
        }
    }
}