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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.Extensions
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Limits an integer to entered bounds
        /// </summary>
        /// <param name="num">The integer to limit</param>
        /// <param name="min">The minimum value for the integer</param>
        /// <param name="max">The maximum value for the integer</param>
        /// <returns>Returns the integer if it is within the bounds, otherwise returns the minimum value if the integer is lower than it,
        /// or returns the maximum value of the integer is greater than it</returns>
        public static int FixBounds(this int num, int min, int max)
        {
            if (num < min)
            {
                return min;
            }
            else if (num > max)
            {
                return max;
            }
            return num;
        }
    }
}
