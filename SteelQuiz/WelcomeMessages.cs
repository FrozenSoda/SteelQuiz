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

namespace SteelQuiz
{
    public static class WelcomeMessages
    {
        /// <summary>
        /// Selects a welcome message to show, by evaluating all the conditions and selecting a random one
        /// </summary>
        /// <param name="welcomeMessages">Collection of welcome messages to choose from</param>
        /// <returns>Returns a welcome message to show</returns>
        public static WelcomeMessage SelectWelcomeMessage(this WelcomeMessage[] welcomeMessages)
        {
            var possible = new List<WelcomeMessage>();
            foreach (var msg in welcomeMessages)
            {
                if (msg.Conditions() && msg.ConditionsSelection())
                {
                    possible.Add(msg);
                }
            }

            int rnd = new Random().Next(0, possible.Count);
            return possible[rnd];
        }
    }
}
