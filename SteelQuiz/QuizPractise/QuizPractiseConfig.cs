using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizPractise
{
    public partial class QuizPractiseConfig : AutoThemeableForm
    {
        public QuizPractiseConfig()
        {
            InitializeComponent();
            SetTheme();

            cmb_langAns.Items.Add(QuizCore.Quiz.Language1);
            cmb_langAns.Items.Add(QuizCore.Quiz.Language2);

            cmb_langAns.SelectedItem = QuizCore.QuizProgress.AnswerLanguage;

            if (QuizCore.QuizProgress.FullTestInProgress)
            {
                btn_switchTestMode.Text = "Enable Intelligent Learning";
            }
            else
            {
                btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
            }
        }

        private void Btn_dontAgree_Click(object sender, EventArgs e)
        {
            Program.frmInQuiz.FixQuizErrors();
        }

        private void Btn_switchTestMode_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Warning: The state of the current round will be lost (current word, word count etc).\r\n\r\nProceed?",
                "Switch mode - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                Program.frmInQuiz.SwitchIntelligentLearningMode();

                if (QuizCore.QuizProgress.FullTestInProgress)
                {
                    btn_switchTestMode.Text = "Enable Intelligent Learning";
                }
                else
                {
                    btn_switchTestMode.Text = "Disable Intelligent Learning (do full test)";
                }
            }
        }

        private void Cmb_langAns_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuizCore.QuizProgress.AnswerLanguage = cmb_langAns.SelectedItem.ToString();
            QuizCore.SaveQuizProgress();

            QuestionSelector.NewRound();
            Program.frmInQuiz.NewWord();
        }
    }
}
