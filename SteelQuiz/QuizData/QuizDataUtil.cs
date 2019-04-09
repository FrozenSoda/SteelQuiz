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

namespace SteelQuiz.QuizData
{
    public static class QuizDataUtil
    {
        public static ulong GenerateID(IList<WordPair> wordPairs)
        {
            ulong? maxId = null;
            foreach (var wp in wordPairs)
            {
                if (maxId == null || wp.ID > maxId)
                {
                    maxId = wp.ID;
                }
            }

            return maxId == null ? 0 : (ulong)maxId + 1;
        }

        public static WordPair GetWordPair(this ulong? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (var wp in QuizCore.Quiz.WordPairs)
            {
                if (wp.ID == id)
                {
                    return wp;
                }
            }

            return null;
        }
    }
}