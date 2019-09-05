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

namespace SteelQuiz
{
    public class SAssertException : Exception
    {
        public SAssertException() : base()
        {
        }

        public SAssertException(string message)
            : base(message)
        {
        }

        public SAssertException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public static class SAssert
    {
        public static void Assert(bool condition)
        {
            if (!condition)
            {
                throw new SAssertException("Assertion error");
            }
        }
    }
}
