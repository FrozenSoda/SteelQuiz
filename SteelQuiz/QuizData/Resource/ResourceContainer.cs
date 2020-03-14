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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData.Resource
{
    /// <summary>
    /// A container for a resource.
    /// </summary>
    [JsonConverter(typeof(ResourceContainerConverter))]
    public abstract class ResourceContainer<T>
    {
        public string ObjType { get; private set; } = typeof(T).ToString();

        /// <summary>
        /// The Guid for this resource.
        /// </summary>
        [JsonProperty]
        public Guid Guid { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// The hash of this quiz image.
        /// </summary>
        [JsonProperty]
        public string Hash { get; private set; }

        /// <summary>
        /// The object stored in this ResourceContainer.
        /// </summary>
        public abstract T Object { get; protected set; }

        /// <summary>
        /// Changes the image for this QuizImage resource.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void ChangeResource(T newObj)
        {
            Object = newObj;
            UpdateHash();
        }

        /// <summary>
        /// Sets the Hash property for the current resource object.
        /// </summary>
        protected void UpdateHash()
        {
            Hash = CalculateHash();
        }

        private string CalculateHash()
        {
            return CalculateHash(Object);
        }

        /// <summary>
        /// Calculates the hash of the current resource object.
        /// </summary>
        public abstract string CalculateHash(T obj);
    }
}
