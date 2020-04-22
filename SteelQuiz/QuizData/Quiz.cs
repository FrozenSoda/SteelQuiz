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
using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class Quiz
    {
        public Guid GUID { get; set; }
        public string FileFormatVersion { get; set; }

        /// <summary>
        /// The type of text at the front of the flashcards - for example "Spanish", "Question", "Animal", etc.
        /// </summary>
        public string CardFrontType { get; set; }
        /// <summary>
        /// The type of text at the back of the flashcards - for example "Spanish", "Question", "Animal", etc.
        /// </summary>
        public string CardBackType { get; set; }
        /// <summary>
        /// The Cards, that is the question-answer-pairs, contained in this quiz.
        /// </summary>
        public List<Card> Cards { get; set; } = new List<Card>();

        /// <summary>
        /// The QuizIdentity object belonging to this quiz, during this session.
        /// </summary>
        [JsonIgnore]
        public QuizIdentity QuizIdentity { get; set; }
        /// <summary>
        /// The progress data belonging to this quiz, during this session.
        /// </summary>
        [JsonIgnore]
        public QuizProgress ProgressData { get; set; }

        #region Obsolete properties
        [JsonProperty]
        [Obsolete("Use CardFrontType instead", true)]
        private string Language1 { set => CardFrontType = value; }

        [JsonProperty]
        [Obsolete("Use CardBackType instead", true)]
        private string Language2 { set => CardBackType = value; }

        [JsonProperty]
        [Obsolete("Use Cards instead", true)]
        private List<Card> WordPairs { set => Cards = value; }
        #endregion

        public Quiz(string cardFrontType, string cardBackType, string quizFileFormatVersion, Guid? guid = null)
        {
            if (guid == null)
            {
                GUID = Guid.NewGuid();
            }
            else
            {
                GUID = (Guid)guid;
            }
            CardFrontType = cardFrontType;
            CardBackType = cardBackType;
            FileFormatVersion = quizFileFormatVersion;
        }

        /// <summary>
        /// Finds the card with the specified Guid.
        /// </summary>
        /// <param name="guid">The Guid of the card to find.</param>
        /// <returns>Returns the found card if found; otherwise returns null.</returns>
        public Card GetCard(Guid guid)
        {
            return Cards.Where(x => x.Guid == guid).FirstOrDefault();
        }
    }
}