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
    public class ImageResourceContainer : ResourceContainer
    {
        [JsonProperty]
        [JsonConverter(typeof(ImageConverter))]
        public override Image Object { get; protected set; }

        /// <summary>
        /// Creates a new image resource container from the specified image.
        /// </summary>
        /// <param name="obj">The image to set for this resource container.</param>
        public ImageResourceContainer(Image img)
        {
            ChangeResource(img);
        }

        protected override string CalculateHash()
        {
            return Object.CalculateSHA512();
        }
    }
}
