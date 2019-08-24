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
        private WelcomeTheme WelcomeTheme = new WelcomeTheme();

        public QuizIdentity QuizIdentity { get; private set; }

        public DashboardQuiz(QuizIdentity quizIdentity)
        {
            InitializeComponent();

            SetTheme(WelcomeTheme);

            QuizIdentity = quizIdentity;

            lbl_name.Text = Path.GetFileNameWithoutExtension(QuizIdentity.FindQuizPath());
        }

        public override void SetTheme(GeneralTheme theme)
        {
            base.SetTheme(theme);

            BackColor = WelcomeTheme.GetBackColor();
            lbl_name.BackColor = BackColor;
            ForeColor = WelcomeTheme.GetBackColor();
        }

        private void SetHoverColors(bool hover)
        {
            if (hover)
            {
                BackColor = Color.FromArgb
                    (WelcomeTheme.GetBackColor().A, WelcomeTheme.GetBackColor().R - 20, WelcomeTheme.GetBackColor().G - 20, WelcomeTheme.GetBackColor().B - 20);
            }
            else
            {
                BackColor = WelcomeTheme.GetBackColor();
            }
            lbl_name.BackColor = BackColor;
        }

        private void DashboardQuiz_MouseEnter(object sender, EventArgs e)
        {
            SetHoverColors(true);
        }

        private void DashboardQuiz_MouseLeave(object sender, EventArgs e)
        {
            SetHoverColors(false);
        }

        private void Lbl_name_MouseEnter(object sender, EventArgs e)
        {
            SetHoverColors(true);
        }

        private void Lbl_name_MouseLeave(object sender, EventArgs e)
        {
            SetHoverColors(false);
        }

        private void Lbl_name_Click(object sender, EventArgs e)
        {

        }
    }
}
