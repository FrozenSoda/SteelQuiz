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

namespace SteelQuiz.QuizImport.Guide
{
    public partial class Step1 : UserControl, IStep
    {
        private const int STEP_NUMBER = 1;

        public string Language1 { get; set; } = "";

        public Step1(IEnumerable<WordPair> wordPairs)
        {
            InitializeComponent();
            foreach (var wordPair in wordPairs)
            {
                lst_words.Items.Add(wordPair.Word1);
            }
        }

        public int GetStepNumber()
        {
            return STEP_NUMBER;
        }
    }
}
