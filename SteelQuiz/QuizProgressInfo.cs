using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizData;
using System.IO;

namespace SteelQuiz
{
    public partial class QuizProgressInfo : AutoThemeableUserControl
    {
        public QuizIdentity QuizIdentity { get; private set; }

        public QuizProgressInfo(QuizIdentity quizIdentity)
        {
            InitializeComponent();

            QuizIdentity = quizIdentity;
            lbl_quizNameHere.Text = Path.GetFileNameWithoutExtension(QuizIdentity.FindQuizPath());

            SetTheme(new WelcomeTheme());
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null || theme.GetType() != typeof(WelcomeTheme))
            {
                theme = new WelcomeTheme();
            }

            base.SetTheme(theme);

            btn_deleteQuiz.ForeColor = Color.LightCoral;
        }
    }
}
