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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    /// <summary>
    /// Contains identification data for a quiz, so that it can be found quickly, and even when it's moved.
    /// </summary>
    public class QuizIdentity
    {
        [JsonProperty]
        /// <summary>
        /// The GUID of the quiz. This will not change if the quiz is moved.
        /// </summary>
        public Guid QuizGuid { get; private set; }

        [JsonProperty]
        /// <summary>
        /// The last known path to the quiz. If the quiz at this path doesn't match QuizGuid, this property will be ignored.
        /// </summary>
        public string LastKnownPath { get; private set; }

        public QuizIdentity(Guid quizGuid, string quizPath)
        {
            QuizGuid = quizGuid;
            LastKnownPath = quizPath;
        }

        /// <summary>
        /// Finds the quiz path, even when the quiz has been moved to a different location in a quiz folder.
        /// </summary>
        /// <returns>Returns the path of the quiz. Returns null if it can't be found.</returns>
        public string FindQuizPath()
        {
            if (File.Exists(LastKnownPath))
            {
                Quiz quiz = JsonConvert.DeserializeObject<Quiz>(AtomicIO.AtomicRead(LastKnownPath));
                if (quiz.GUID == QuizGuid)
                {
                    // QuizPath is correct
                    return LastKnownPath;
                }
            }


            // QuizPath is incorrect
            var path = QuizCore.QuickFindQuizPath(QuizGuid, LastKnownPath);
            if (path != null)
            {
                LastKnownPath = path;
                return LastKnownPath;
            }

            var quizNotFound = new QuizNotFound(QuizGuid, LastKnownPath);
            if (quizNotFound.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LastKnownPath = quizNotFound.NewQuizPath;
                return LastKnownPath;
            }

            return null;
        }

        public string GetLastKnownName()
        {
            return Path.GetFileNameWithoutExtension(LastKnownPath);
        }

        [Obsolete("Use GetLastKnownName() instead")]
        /// <summary>
        /// Finds the name of this quiz, even when the quiz has been moved to a different location in a quiz folder.
        /// </summary>
        /// <returns>Returns the name of the quiz. Returns null if it can't be found.</returns>
        public string FindName()
        {
            var path = FindQuizPath();
            if (path == null)
            {
                return null;
            }

            var name = Path.GetFileNameWithoutExtension(path);
            return name;
        }
    }
}
