using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizPractise
{
    public partial class WrongAnswer : AutoThemeableUserControl
    {
        public WrongAnswer(string questionWord, string questionLang, string correctAnswer, string answerLang)
        {
            InitializeComponent();
            SetTheme();

            lbl_questionLang.Text = $"{questionLang} word:";
            lbl_questionWord.Text = questionWord;
            toolTip1.SetToolTip(lbl_questionWord, questionWord);

            lbl_answerLang.Text = $"Correct {answerLang} word:";
            lbl_correctAnswer.Text = correctAnswer;
            toolTip1.SetToolTip(lbl_correctAnswer, correctAnswer);

            lbl_instruction.Text = $"Type the {answerLang} word";
        }
    }
}
