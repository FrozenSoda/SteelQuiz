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
using System.Windows.Forms;

namespace SteelQuiz.Extensions
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Gets all children controls of a control, of a specific type
        /// </summary>
        /// <param name="control">The control whose children to return</param>
        /// <param name="type">The child type to search fore</param>
        /// <returns>Returns all children controls of a control, of a specific type</returns>
        public static IEnumerable<Control> GetAllChildrenRecursive(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllChildrenRecursive(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        /// <summary>
        /// Gets all children controls of a control
        /// </summary>
        /// <param name="control">The control whose children to return</param>
        /// <returns>Returns all children controls of a control</returns>
        public static IEnumerable<Control> GetAllChildrenRecursive(this Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllChildrenRecursive(ctrl))
                                      .Concat(controls);
        }
    }
}
