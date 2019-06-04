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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteelQuiz.QuizProgressData;

namespace SteelQuiz
{
    public class QuizProgressMerger
    {
        public bool Merge(string progressFile1, string progressFile2, string savePath)
        {
            QuizProgDataRoot prog1;
            using (var reader = new StreamReader(progressFile1))
            {
                prog1 = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
            }

            QuizProgDataRoot prog2;
            using (var reader = new StreamReader(progressFile2))
            {
                prog2 = JsonConvert.DeserializeObject<QuizProgDataRoot>(reader.ReadToEnd());
            }

            QuizProgDataRoot merged = Merge(prog1, prog2);

            using (var writer = new StreamWriter(savePath, false))
            {
                writer.Write(JsonConvert.SerializeObject(merged, Formatting.Indented));
            }

            return true;
        }

        /// <summary>
        /// Merges two QuizProgDataRoots into one, by adding all quiz progress datas into one. If duplicates exist, the one with best progress will be selected. If same, prog1 will have priority
        /// </summary>
        /// <param name="prog1">The first QuizProgDataRoot to merge. This one has priority over prog2</param>
        /// <param name="prog2">The second QuizProgDataRoot to merge</param>
        /// <returns></returns>
        private QuizProgDataRoot Merge(QuizProgDataRoot prog1, QuizProgDataRoot prog2)
        {
            var result = new QuizProgDataRoot(MetaData.QUIZ_FILE_FORMAT_VERSION);

            foreach (var q in prog1.QuizProgDatas)
            {
                result.QuizProgDatas.Add(q);
            }

            foreach (var q in prog2.QuizProgDatas)
            {
                result.QuizProgDatas.Add(q);
            }

            // select best ones from duplicates
            var duplicatePairs = result.QuizProgDatas.GroupBy(x => x.QuizGUID);
            foreach (var duplicatePair in duplicatePairs)
            {
                
            }

            return result;
        }
    }
}
