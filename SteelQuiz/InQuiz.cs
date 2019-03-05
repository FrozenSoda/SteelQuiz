using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.QuizData;

namespace SteelQuiz
{
    public partial class InQuiz : Form
    {
        private WordPair currentWordPair = null;
        private string currentInput = "";
        private WordPair.TranslationMode translationMode = WordPair.TranslationMode.L1_to_L2;
        private bool waitingForEnter = false;
        private bool userCopyWord = false;

        public InQuiz()
        {
            InitializeComponent();
            NewWord();
        }

        private void NewWord()
        {
            currentWordPair = QuizAI.GenerateWordPair();

            if (currentWordPair == null)
            {
                NewRound();
                return;
            }

            if (translationMode == WordPair.TranslationMode.L1_to_L2)
            {
                lbl_word1.Text = currentWordPair.Word1;
            }
            else if (translationMode == WordPair.TranslationMode.L2_to_L1)
            {
                lbl_word1.Text = currentWordPair.Word2;
            }
            currentInput = "";
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
        }

        private void NewRound()
        {
            lbl_word1.Text = "Round completed! Press enter to continue";
            waitingForEnter = true;
            lbl_progress.Text = $"Progress this round: { QuizCore.GetWordsAskedThisRound() } / { QuizCore.GetTotalWordsThisRound() }";
        }

        private void CheckWord()
        {
            var wrongCh = currentWordPair.WrongChIndexes(currentInput, translationMode, !userCopyWord);
            userCopyWord = false;
            if (wrongCh.Length == 0)
            {
                lbl_word1.Text = "Correct! Press enter to continue";
                waitingForEnter = true;
            }
            else
            {
                if (translationMode == WordPair.TranslationMode.L1_to_L2)
                {
                    lbl_word1.Text = "Wrong\r\n\r\nCorrect word is: " + currentWordPair.Word2 + "\r\n\r\nType the correct word";
                }
                else if (translationMode == WordPair.TranslationMode.L2_to_L1)
                {
                    lbl_word1.Text = "Wrong\r\n\r\nCorrect word is: " + currentWordPair.Word1 + "\r\n\r\nType the correct word";
                }
                userCopyWord = true;
                currentInput = "";
                lbl_word2.Text = "";
            }
        }

        private void InQuiz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentInput == "")
            {
                lbl_word2.Text = "";
            }

            if (e.KeyChar == '\b')
            {
                //backspace
                if (currentInput.Length > 0)
                {
                    currentInput = currentInput.Remove(currentInput.Length - 1);
                }
            }
            else if (e.KeyChar == '\r')
            {
                //enter
                if (waitingForEnter)
                {
                    waitingForEnter = false;
                    NewWord();
                }
                else
                {
                    CheckWord();
                }
            }
            else
            {
                currentInput += e.KeyChar.ToString();
            }
            lbl_word2.Text = currentInput;
        }

        private void InQuiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuizCore.SaveProgress();
            Application.Exit();
        }
    }
}
