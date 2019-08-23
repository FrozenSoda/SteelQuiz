using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizData;
using System.IO;

namespace SteelQuiz
{
    public partial class DashboardQuiz : UserControl
    {
        public QuizIdentity QuizIdentity { get; private set; }

        public DashboardQuiz(QuizIdentity quizIdentity)
        {
            InitializeComponent();

            QuizIdentity = quizIdentity;

            lbl_name.Text = Path.GetFileNameWithoutExtension(QuizIdentity.FindQuizPath());
        }
    }
}
