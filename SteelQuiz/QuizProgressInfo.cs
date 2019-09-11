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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizData;
using System.IO;
using SteelQuiz.QuizProgressData;
using System.Diagnostics;

namespace SteelQuiz
{
    public partial class QuizProgressInfo : AutoThemeableUserControl
    {
        private WelcomeTheme WelcomeTheme { get; set; } = new WelcomeTheme();
        public QuizIdentity QuizIdentity { get; private set; }

        public QuizProgressInfo(QuizIdentity quizIdentity)
        {
            InitializeComponent();

            QuizIdentity = quizIdentity;
            lbl_quizNameHere.Text = Path.GetFileNameWithoutExtension(QuizIdentity.FindQuizPath());

            SetTheme(WelcomeTheme);
            LoadLearningProgressPercentage();
            LoadWordPairs();

            switch (QuizCore.QuizProgress.TermsDisplayOrder)
            {
                case TermsOrderBy.SuccessRate:
                    cmb_order.SelectedItem = "Success Rate";
                    break;

                case TermsOrderBy.QuizOrder:
                    cmb_order.SelectedItem = "Quiz Order";
                    break;

                case TermsOrderBy.AlphabeticalTerm1:
                    cmb_order.SelectedItem = "Alphabetical Term 1";
                    break;

                case TermsOrderBy.AlphabeticalTerm2:
                    cmb_order.SelectedItem = "Alphabetical Term 2";
                    break;
            }

            switch (QuizCore.QuizProgress.TermsDisplayOrderOrder)
            {
                case TermsOrderByOrder.Ascending:
                    cmb_orderAscendingDescending.SelectedItem = "Ascending";
                    break;

                case TermsOrderByOrder.Descending:
                    cmb_orderAscendingDescending.SelectedItem = "Descending";
                    break;
            }

            lbl_termsCount.Text = QuizCore.Quiz.WordPairs.Count().ToString();
        }

        public void LoadLearningProgressPercentage()
        {
            /*
            if (!QuizCore.Load(QuizIdentity.QuizGuid))
            {
                return;
            }
            */

            //lbl_learningProgressPercentage.Text = Math.Round(QuizCore.QuizProgress.GetSuccessRate() * 100D, 1).ToString() + " %";
            //cpb_learningProgress.Value = (int)Math.Floor(QuizCore.QuizProgress.GetSuccessRateStrict() * 100D);
            //cpb_learningProgress.Text = cpb_learningProgress.Value.ToString() + " %";
            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * QuizCore.QuizProgress.GetLearningProgress()), lbl_learningProgress_bar.Size.Height);
            lbl_learningProgress.Text = Math.Floor(QuizCore.QuizProgress.GetLearningProgress() * 100D).ToString() + " %";
        }

        /// <summary>
        /// Re-colors the word pairs in the list, to have every other wordpair in a different color, to make reading easier
        /// </summary>
        public void RecolorWordPairs()
        {
            int count = 0;
            foreach (var c in flp_words.Controls.OfType<Control>())
            {
                // Every other wordpair should have a slighly different color to make reading them easier
                var bc = WelcomeTheme.GetBackColor();
                if (count % 2 == 0)
                {
                    c.BackColor = Color.FromArgb(bc.A, bc.R - 5, bc.G - 5, bc.B - 5);
                }
                else
                {
                    c.BackColor = bc;
                }

                ++count;
            }
        }

        public void LoadWordPairs()
        {
            foreach (var c in flp_words.Controls.OfType<Control>())
            {
                c.Dispose();
            }

            flp_words.Controls.Clear();

            var controls = new List<DashboardQuizWordPair>();
            foreach (var wordPair in QuizCore.Quiz.WordPairs)
            {
                var c = new DashboardQuizWordPair(wordPair);
                c.Size = new Size(flp_words.Size.Width - 34, c.Size.Height);
                controls.Add(c);
            }

            //controls = controls.OrderBy(x => x.SuccessRate).ToList();
            /*
            controls = controls.OrderBy(x =>
            {
                switch (cmb_order.SelectedItem)
                {
                    case "Success Rate":
                        return x.SuccessRate;
                    case "Quiz Order":
                        return x;
                    case "Alphabetical Phrase 1":
                        return x.WordPair.Word1;
                    case "Alphabetical Phrase 2":
                        return x.WordPair.Word2;
                    default:
                        return x;
                }
            });
            */

            switch (cmb_orderAscendingDescending.SelectedItem)
            {
                case "Ascending":
                    switch (cmb_order.SelectedItem)
                    {
                        case "Success Rate":
                            controls = controls.OrderBy(x => x.SuccessRate).ToList();
                            break;
                        case "Quiz Order":
                            break;
                        case "Alphabetical Term 1":
                            controls = controls.OrderBy(x => x.WordPair.Word1).ToList();
                            break;
                        case "Alphabetical Term 2":
                            controls = controls.OrderBy(x => x.WordPair.Word2).ToList();
                            break;
                    }
                    break;

                case "Descending":
                    switch (cmb_order.SelectedItem)
                    {
                        case "Success Rate":
                            controls = controls.OrderByDescending(x => x.SuccessRate).ToList();
                            break;
                        case "Quiz Order":
                            controls.Reverse();
                            break;
                        case "Alphabetical Term 1":
                            controls = controls.OrderByDescending(x => x.WordPair.Word1).ToList();
                            break;
                        case "Alphabetical Term 2":
                            controls = controls.OrderByDescending(x => x.WordPair.Word2).ToList();
                            break;
                    }
                    break;
            }

            int count = 0;
            foreach (var c in controls)
            {
                // Every other wordpair should have a slighly different color to make reading them easier
                var bc = WelcomeTheme.GetBackColor();
                if (count % 2 == 0)
                {
                    c.BackColor = Color.FromArgb(bc.A, bc.R - 5, bc.G - 5, bc.B - 5);
                }
                else
                {
                    c.BackColor = bc;
                }
                flp_words.Controls.Add(c);
                flp_words.SetFlowBreak(c, true);

                ++count;
            }
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null || theme.GetType() != typeof(WelcomeTheme))
            {
                theme = new WelcomeTheme();
            }

            var lbl_learningProgress_bar_color = lbl_learningProgress_bar.ForeColor;

            base.SetTheme(theme);

            lbl_learningProgress_bar.ForeColor = lbl_learningProgress_bar_color;

            //btn_resetProgress.ForeColor = ((WelcomeTheme)theme).GetButtonRedForeColor();

            //cpb_learningProgress.BackColor = theme.GetBackColor();
            //cpb_learningProgress.InnerColor = theme.GetBackColor();
            //cpb_learningProgress.ForeColor = theme.GetMainLabelForeColor();

            RecolorWordPairs();
        }

        private void Btn_practiseQuiz_Click(object sender, EventArgs e)
        {
            if (QuizCore.Quiz.WordPairs.Count == 0)
            {
                MessageBox.Show("Cannot practise quiz with no terms", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            (ParentForm as Welcome).LoadQuiz(QuizIdentity.FindQuizPath());
        }

        public void UpdateLearningProgressBar()
        {
            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * QuizCore.QuizProgress.GetLearningProgress()), lbl_learningProgress_bar.Size.Height);
            foreach (var c in flp_words.Controls.OfType<DashboardQuizWordPair>())
            {
                c.UpdateLearningProgressBar();
            }
        }

        private void QuizProgressInfo_SizeChanged(object sender, EventArgs e)
        {
            flp_words.Size = new Size(Size.Width - 12, Size.Height - 157);
            foreach (var c in flp_words.Controls.OfType<Control>())
            {
                c.Size = new Size(flp_words.Size.Width - 34, c.Size.Height);
            }

            UpdateLearningProgressBar();
        }

        private void Btn_editQuiz_Click(object sender, EventArgs e)
        {
            Program.frmWelcome.OpenQuizEditor(QuizCore.Quiz, QuizCore.QuizPath);
        }

        private void Btn_resetProgress_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show($"Are you sure you want to start over learning the quiz '{QuizIdentity.FindName()}'? This action cannot be undone.",
                "Reset Quiz Progress data - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg != DialogResult.Yes)
            {
                return;
            }

            // Ensure we are not resetting the wrong progress data
            SAssert.Assert(QuizCore.QuizProgress.QuizGUID == QuizIdentity.QuizGuid);
            SAssert.Assert(QuizCore.Quiz.GUID == QuizIdentity.QuizGuid);

            QuizCore.QuizProgress = new QuizProgData(QuizCore.Quiz);
            QuizCore.SaveQuizProgress();

            LoadLearningProgressPercentage();
            LoadWordPairs();
        }

        private void Lbl_learningProgress_bar_SizeChanged(object sender, EventArgs e)
        {
            //double progress = lbl_learningProgress_bar.Size.Width / (double)Size.Width;
            double progress = QuizCore.QuizProgress.GetLearningProgress();

            lbl_learningProgress_bar.ForeColor = Color.FromArgb(
                255,
                (int)Math.Floor(255 - progress * 255),
                (int)Math.Floor(progress * 255),
                0);
        }

        private void Btn_more_Click(object sender, EventArgs e)
        {
            var cm = new ContextMenu();
            cm.MenuItems.Add("Export", (a, b) =>
            {
                var quizExport = new QuizExport(QuizCore.Quiz);
                quizExport.ShowDialog();
            });

            cm.Show(btn_more, new Point(0, btn_more.Size.Height));
        }

        private void Cmb_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_order.SelectedItem)
            {
                case "Success Rate":
                    QuizCore.QuizProgress.TermsDisplayOrder = TermsOrderBy.SuccessRate;
                    break;

                case "Quiz Order":
                    QuizCore.QuizProgress.TermsDisplayOrder = TermsOrderBy.QuizOrder;
                    break;

                case "Alphabetical Term 1":
                    QuizCore.QuizProgress.TermsDisplayOrder = TermsOrderBy.AlphabeticalTerm1;
                    break;

                case "Alphabetical Term 2":
                    QuizCore.QuizProgress.TermsDisplayOrder = TermsOrderBy.AlphabeticalTerm2;
                    break;
            }

            switch (cmb_orderAscendingDescending.SelectedItem)
            {
                case "Ascending":
                    QuizCore.QuizProgress.TermsDisplayOrderOrder = TermsOrderByOrder.Ascending;
                    break;

                case "Descending":
                    QuizCore.QuizProgress.TermsDisplayOrderOrder = TermsOrderByOrder.Descending;
                    break;
            }

            QuizCore.SaveQuizProgress();

            LoadWordPairs();
        }
    }
}
