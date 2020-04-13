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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteelQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelQuiz.QuizData;
using SteelQuiz.QuizPractise;
using SteelQuiz.QuizProgressDataNS;

namespace SteelQuiz.Tests
{
    [TestClass()]
    public class QuizProgressMergerTests
    {
        [TestMethod()]
        public void Merge_BestProgressSelectionTest()
        {
            var progRoot1 = new QuizProgressDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);

            var quizProg1 = new QuizProgressData(new QuizData.Quiz("lang1", "lang2", MetaData.QUIZ_FILE_FORMAT_VERSION, Guid.Empty));
            var wp1 = new QuestionAnswerPair("What's 1 + 1?", "2", StringComp.Rules.None, null, new List<string>() { "two" });
            var wpProg1 = new QuestionProgressData(wp1);
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));

            quizProg1.QuestionProgressData.Add(wpProg1);
            progRoot1.QuizProgressData.Add(quizProg1);

            var progRoot2 = new QuizProgressDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);

            var quizProg2 = new QuizProgressData(new QuizData.Quiz("lang1", "lang2", MetaData.QUIZ_FILE_FORMAT_VERSION, Guid.Empty));
            var wp2 = new QuestionAnswerPair("What's 1 + 1?", "2", StringComp.Rules.None, null, new List<string>() { "two" });
            var wpProg2 = new QuestionProgressData(wp2);
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(false));
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(true));

            quizProg2.QuestionProgressData.Add(wpProg2);
            progRoot2.QuizProgressData.Add(quizProg2);

            var merged = QuizProgressMerger.Merge(progRoot1, progRoot2);

            /*
             * Only one quiz progress data should be selected
             */ 
            Assert.IsTrue(merged.QuizProgressData.Count == 1, "More than one quiz progress data was selected");

            /*
             * The quiz progress data with the best success rate should be selected
             */ 
            Assert.IsTrue(merged.QuizProgressData[0].QuestionProgressData[0].GetLearningProgress() == 1, "The best quiz progress data was not selected");
        }

        [TestMethod()]
        public void Merge_EqualProgressPriorityTest()
        {
            var progRoot1 = new QuizProgressDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);

            var quizProg1 = new QuizProgressData(new QuizData.Quiz("lang1", "lang2", MetaData.QUIZ_FILE_FORMAT_VERSION, Guid.Empty));
            var wp1 = new QuestionAnswerPair("What's 2 + 2?", "4", StringComp.Rules.None, null, new List<string>() { "two" });
            var wpProg1 = new QuestionProgressData(wp1);
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));
            wpProg1.AddWordTry(new AnswerAttempt(true));

            quizProg1.QuestionProgressData.Add(wpProg1);
            progRoot1.QuizProgressData.Add(quizProg1);

            var progRoot2 = new QuizProgressDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);

            var quizProg2 = new QuizProgressData(new QuizData.Quiz("lang1", "lang2", MetaData.QUIZ_FILE_FORMAT_VERSION, Guid.Empty));
            var wp2 = new QuestionAnswerPair("What's 1 + 1?", "2", StringComp.Rules.None, null, new List<string>() { "two" });
            var wpProg2 = new QuestionProgressData(wp2);
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(true));
            wpProg2.AddWordTry(new AnswerAttempt(true));

            quizProg2.QuestionProgressData.Add(wpProg2);
            progRoot2.QuizProgressData.Add(quizProg2);

            var merged = QuizProgressMerger.Merge(progRoot1, progRoot2);

            /*
             * Only one quiz progress data should be selected
             */
            Assert.IsTrue(merged.QuizProgressData.Count == 1, "More than one quiz progress data was selected");

            /*
             * The first quiz progress data should be selected when the progress is equal, as it has priority
             */
            Assert.IsTrue(merged.QuizProgressData[0].WordProgDatas[0].WordPair.Word1 == "What's 2 + 2?", "The first quiz progress data did not have priority");
        }
    }
}