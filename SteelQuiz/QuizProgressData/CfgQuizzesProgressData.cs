using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizProgressData
{
    public class CfgQuizzesProgressData
    {
        public List<QuizProgData> QuizProgDatas { get; set; }

        public CfgQuizzesProgressData()
        {
            QuizProgDatas = new List<QuizProgData>();
        }
    }
}