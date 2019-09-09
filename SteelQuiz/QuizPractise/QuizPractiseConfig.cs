/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

            if (QuizCore.QuizProgress.IntelligentLearningLastAnswersBasisCount == 3)
            {
                rdo_last3attemptsIntelligentLearning.Checked = true;
            }
            else if (QuizCore.QuizProgress.IntelligentLearningLastAnswersBasisCount == 0)
            {
                rdo_allAttemptsIntelligentLearning.Checked = true;
            }
            else
            {
                rdo_lastNattemptsIntelligentLearning.Checked = true;
                nud_intelligentLearningAttempsCount.Value = QuizCore.QuizProgress.IntelligentLearningLastAnswersBasisCount;
            }


            cmb_langAns.SelectedIndexChanged += new EventHandler(Cmb_langAns_SelectedIndexChanged);
            rdo_last3attemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_last3attemptsIntelligentLearning_CheckedChanged);
            rdo_allAttemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_allAttemptsIntelligentLearning_CheckedChanged);
            rdo_lastNattemptsIntelligentLearning.CheckedChanged += new EventHandler(Rdo_lastNattemptsIntelligentLearning_CheckedChanged);
            nud_intelligentLearningAttempsCount.ValueChanged += new EventHandler(Nud_intelligentLearningAttempsCount_ValueChanged);
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
            //QuizCore.QuizProgress.AnswerLanguage = cmb_langAns.SelectedItem.ToString();
            if (cmb_langAns.SelectedItem.ToString() == QuizCore.Quiz.Language1)
            {
                QuizCore.QuizProgress.AnswerLanguageNum = 1;
            }
            else if (cmb_langAns.SelectedItem.ToString() == QuizCore.Quiz.Language2)
            {
                QuizCore.QuizProgress.AnswerLanguageNum = 2;
            }

            QuizCore.SaveQuizProgress();

            QuestionSelector.NewRound();
            Program.frmInQuiz.NewWord();
        }

        private void Rdo_last3attemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rdo_allAttemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rdo_lastNattemptsIntelligentLearning_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Nud_intelligentLearningAttempsCount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
