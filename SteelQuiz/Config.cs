using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    public class Config
    {
        public string FileFormatVersion { get; set; }
        public bool AcceptedTermsOfUse { get; set; } = false;

        public Config()
        {
            FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
        }
    }
}
