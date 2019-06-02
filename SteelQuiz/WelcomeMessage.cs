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
    public class WelcomeMessage
    {
        private string _message;

        /// <summary>
        /// The message to be displayed
        /// </summary>
        public string Message
        {
            get
            {
                if (ConfigManager.Config.ShowNameOnWelcomeScreen && ConfigManager.Config.FullName != null)
                {
                    return _message.Replace(@"\firstname", ConfigManager.Config.FullName.Split(' ')[0]);
                }
                else
                {
                    return _message.Replace(@" \firstname", "");
                }
            }

            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// A function which evaluates conditions that needs to be fulfilled to select the welcome message. The conditions NEED to be fulfilled during re-checking
        /// </summary>
        public Func<bool> Conditions { get; set; }

        /// <summary>
        /// A function which evaluates conditions that needs to be fulfilled to select the welcome message. The conditions do NOT need to be fulfilled during re-checking
        /// </summary>
        public Func<bool> ConditionsSelection { get; set; }

        public WelcomeMessage(string msg, Func<bool> conditions, Func<bool> conditionsSelection = null)
        {
            Message = msg;

            if (conditions != null)
            {
                Conditions = conditions;
            }
            else
            {
                Conditions = new Func<bool>(() => { return true; });
            }

            if (conditionsSelection != null)
            {
                ConditionsSelection = conditionsSelection;
            }
            else
            {
                ConditionsSelection = new Func<bool>(() => { return true; });
            }
        }
    }
}
