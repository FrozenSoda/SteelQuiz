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
using SteelQuiz.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData.Resource
{
    /// <summary>
    /// A container for a quiz image resource.
    /// </summary>
    public class ImageResourceContainer : ResourceContainer<Image>
    {
        [JsonProperty]
        [JsonConverter(typeof(ImageConverter))]
        public override Image Object { get; protected set; }

        public ImageResourceContainer() { }
        /// <summary>
        /// Creates a new image resource container from the specified image.
        /// </summary>
        /// <param name="obj">The image to set for this resource container.</param>
        public ImageResourceContainer(Image img)
        {
            ChangeResource(img);
        }

        public override string CalculateHash(Image obj)
        {
            return obj.CalculateSHA512();
        }
    }
}
