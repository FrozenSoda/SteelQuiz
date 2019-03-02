using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizProgressData
{
    public class CfgQuizzesProgressData
    {
        public List<QuizProgData> QuizStates { get; set; }

        public CfgQuizzesProgressData()
        {
            QuizStates = new List<QuizProgData>();
        }
    }
}