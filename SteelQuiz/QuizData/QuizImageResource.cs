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

namespace SteelQuiz.QuizData
{
    /// <summary>
    /// A container for a quiz image resource.
    /// </summary>
    public class QuizImageResource
    {
        /// <summary>
        /// The Guid for this QuizImage resource, which the terms using this image refers to.
        /// </summary>
        [JsonProperty]
        public Guid Guid { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// The SHA512 hash of this quiz image.
        /// </summary>
        [JsonProperty]
        public string SHA512 { get; private set; }

        [JsonProperty]
        [JsonConverter(typeof(ImageConverter))]
        public Image Image { get; private set; }

        /// <summary>
        /// Creates a new quiz image resource from the specified image.
        /// </summary>
        /// <param name="image">The image to set for this resource.</param>
        public QuizImageResource(Image image)
        {
            ChangeImage(image);
        }

        /// <summary>
        /// Changes the image for this QuizImage resource.
        /// </summary>
        /// <param name="newImage">The new image.</param>
        public void ChangeImage(Image newImage)
        {
            Image = newImage;
            UpdateSHA512();
        }

        /// <summary>
        /// Sets the SHA512 property for the current image.
        /// </summary>
        private void UpdateSHA512()
        {
            SHA512 = Image.CalculateSHA512();
        }
    }
}
