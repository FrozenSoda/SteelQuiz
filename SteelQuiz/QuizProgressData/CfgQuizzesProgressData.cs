using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizProgressData
{
    public class CfgQuizzesProgressData
    {
        public string FileFormatVersion { get; set; }
        public List<QuizProgData> QuizProgDatas { get; set; }

        public CfgQuizzesProgressData()
        {
            FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
            QuizProgDatas = new List<QuizProgData>();
        }
    }
}