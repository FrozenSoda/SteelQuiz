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
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class DashboardQuiz : AutoThemeableUserControl
    {
        private GeneralTheme GeneralTheme = new GeneralTheme();

        public QuizIdentity QuizIdentity { get; private set; }

        public DashboardQuiz(QuizIdentity quizIdentity)
        {
            InitializeComponent();

            SetTheme();

            QuizIdentity = quizIdentity;

            lbl_name.Text = Path.GetFileNameWithoutExtension(QuizIdentity.FindQuizPath());
        }

        public override void SetTheme()
        {
            base.SetTheme();

            BackColor = GeneralTheme.GetButtonBackColor();
            ForeColor = GeneralTheme.GetButtonForeColor();
        }
    }
}
