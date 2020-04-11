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

using SteelQuiz.QuizData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizProgressData
{
    public class QuizProgDataRoot
    {
        public string FileFormatVersion { get; set; }
        public Dictionary<Guid, QuizIdentity> QuizIdentities { get; set; } = new Dictionary<Guid, QuizIdentity>();
        public Dictionary<Guid, DateTime> QuizAccessTimes { get; set; } = new Dictionary<Guid, DateTime>();
        public List<QuizProgData> QuizProgDatas { get; set; } = new List<QuizProgData>();

        public QuizProgDataRoot(string fileFormatVersion)
        {
            FileFormatVersion = fileFormatVersion;
            //QuizProgDatas = new List<QuizProgData>();
        }
    }
}