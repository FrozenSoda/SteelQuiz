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
    /// <summary>
    /// Represents a reference type that can be used to store value types, to access them via reference.
    /// </summary>
    /// <typeparam name="T">The type of data to store in the pointer.</typeparam>
    public class Pointer<T>
    {
        private T __data;

        /// <summary>
        /// The data the pointer stores.
        /// </summary>
        public T Data
        {
            get
            {
                return __data;
            }

            set
            {
                BeforeDataChanged?.Invoke(this, value);

                __data = value;

                AfterDataChanged?.Invoke(this, value);
            }
        }

        /// <summary>
        /// The event to invoke when changing Data, before it has been actually changed.
        /// </summary>
        public event EventHandler<T> BeforeDataChanged;

        /// <summary>
        /// The event to invoke when changing Data, after it has been changed.
        /// </summary>
        public event EventHandler<T> AfterDataChanged;

        /// <summary>
        /// Represents a reference type that can be used to store value types, to access them via reference.
        /// </summary>
        public Pointer() { }

        /// <summary>
        /// Represents a reference type that can be used to store value types, to access them via reference.
        /// </summary>
        /// <param name="data">The data to set the pointer to store.</param>
        public Pointer(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Sets the data without invoking Before-/AfterDataChanged events.
        /// </summary>
        /// <param name="value">The value to set data to.</param>
        public void SetCompletelySilent(T value)
        {
            __data = value;
        }

        /// <summary>
        /// Sets the data without invoking BeforeDataChanged events.
        /// </summary>
        /// <param name="value">The value to set data to.</param>
        public void SetSemiSilent(T value)
        {
            __data = value;
            AfterDataChanged.Invoke(this, __data);
        }

        public void InvokeAfterDataChanged()
        {
            AfterDataChanged.Invoke(this, Data);
        }
    }
}
