using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData.Resource
{
    public class ResourceCollection<T> where T : ResourceContainer<T>
    {
        private List<T> resources = new List<T>();
        
        /// <summary>
        /// A function that calculates the hash of the resource object.
        /// </summary>
        private Func<T, string> CalculateHash { get; set; }

        /// <summary>
        /// A collection of resources.
        /// </summary>
        /// <param name="calculateHash">A function that calculates the hash of the resource object.</param>
        public ResourceCollection(Func<T, string> calculateHash)
        {
            CalculateHash = calculateHash;
        }

        /// <summary>
        /// Adds a resource with the specified object to the collection, and returns its Guid. If a resource with the specified object already exists, its Guid will be returned.
        /// </summary>
        /// <param name="img">The resource object to add.</param>
        /// <returns>Guid of the resource with the object.</returns>
        public Guid Add(T obj)
        {
            // Calculate SHA512 of image
            string sha512 = CalculateHash(obj);

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
            //var res = new ResourceContainer<T>(obj, CalculateHash);
            var res = ResourceContainerFactory.CreateResourceContainer(obj);
            resources.Add(res);
            return res.Guid;
        }
    }
}
