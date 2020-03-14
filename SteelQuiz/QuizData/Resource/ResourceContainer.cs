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
    public abstract class ResourceContainer<T>
    {
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

        /// <summary>
        /// Calculates the hash of the current resource object.
        /// </summary>
        protected abstract string CalculateHash();
    }
}
