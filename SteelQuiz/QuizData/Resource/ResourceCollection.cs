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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData.Resource
{
    public class ResourceCollection<T>
    {
        private List<ResourceContainer<T>> resources = new List<ResourceContainer<T>>();

        /// <summary>
        /// Adds a resource with the specified object to the collection, and returns its Guid. If a resource with the specified object already exists, its Guid will be returned.
        /// </summary>
        /// <param name="img">The resource object to add.</param>
        /// <returns>Guid of the resource with the object.</returns>
        public Guid Add(T obj)
        {
            // Calculate SHA512 of image
            string sha512 = Hasher.CalculateSHA512(obj);

            // Look if a resource with the specified image already exists
            foreach (var x in resources)
            {
                if (x.Hash == sha512)
                {
                    // A resource with the image already exists
                    return x.Guid;
                }
            }

            // Resource with same image does not exist - create new
            var res = ResourceContainerFactory.CreateFrom(obj);
            resources.Add(res);
            return res.Guid;
        }

        public ReadOnlyCollection<ResourceContainer<T>> GetAll()
        {
            return new ReadOnlyCollection<ResourceContainer<T>>(resources);
        }

        public T Get(Guid guid)
        {
            return resources.Where(x => x.Guid == guid).Select(x => x.Object).FirstOrDefault();
        }

        public void Remove(Guid guid)
        {
            resources = resources.Where(x => x.Guid != guid).ToList();
        }
    }
}
