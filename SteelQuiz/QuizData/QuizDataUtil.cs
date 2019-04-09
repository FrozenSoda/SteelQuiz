using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public static class QuizDataUtil
    {
        public static ulong GenerateID(IList<WordPair> wordPairs)
        {
            ulong? maxId = null;
            foreach (var wp in wordPairs)
            {
                if (maxId == null || wp.ID > maxId)
                {
                    maxId = wp.ID;
                }
            }

            return maxId == null ? 0 : (ulong)maxId;
        }

        public static WordPair GetWordPair(this ulong? id)
        {
            if (id == null)
            {
                return null;
            }

            foreach (var wp in QuizCore.Quiz.WordPairs)
            {
                if (wp.ID == id)
                {
                    return wp;
                }
            }

            return null;
        }
    }
}