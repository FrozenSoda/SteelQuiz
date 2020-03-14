using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData.Resource
{
    public static class ResourceContainerFactory
    {
        public static ResourceContainer<T> CreateResourceContainer<T>(T obj)
        {
            if (typeof(T) == typeof(Image))
            {
                return new ImageResourceContainer(obj);
            }
        }
    }
}
