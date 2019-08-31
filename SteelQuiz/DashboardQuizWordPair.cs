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
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class DashboardQuizWordPair : AutoThemeableUserControl
    {
        public WordPair WordPair { get; set; }
        public double LearningProgress { get; set; }

        public DashboardQuizWordPair(WordPair wordPair)
        {
            InitializeComponent();
            SetTheme(new WelcomeTheme());

            WordPair = wordPair;
            LearningProgress = WordPair.GetWordProgData().GetSuccessRateStrict();

            cpb_learningProgress.Value = (int)Math.Floor(LearningProgress * 100d);
            cpb_learningProgress.Text = cpb_learningProgress.Value.ToString() + " %";

            lbl_word1.Text = WordPair.Word1;
            lbl_word2.Text = WordPair.Word2;
        }
    }
}
