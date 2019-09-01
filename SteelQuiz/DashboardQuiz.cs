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

            var bc = WelcomeTheme.GetBackColor();
            BackColor = Color.FromArgb(bc.A, bc.R - 10, bc.G - 10, bc.B - 10);
            lbl_name.BackColor = BackColor;
            ForeColor = WelcomeTheme.GetBackColor();
        }

        private void SetHoverColors(bool hover)
        {
            var bc = WelcomeTheme.GetBackColor();
            if (hover)
            {
                BackColor = Color.FromArgb
                    (bc.A, bc.R - 30, bc.G - 30, bc.B - 30);
            }
            else
            {
                BackColor = Color.FromArgb(bc.A, bc.R - 10, bc.G - 10, bc.B - 10);
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
            (ParentForm as Welcome).SwitchQuizProgressInfo(QuizIdentity);
        }

        private void RemoveFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show($"Are you sure you want to remove the quiz '{QuizIdentity.FindName()}' from the 'Recent Quizzes' list? The quiz file will not be removed.",
                "Remove Quiz - SteelQuiz", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                Program.frmWelcome.RemoveQuiz(QuizIdentity.QuizGuid);
            }
        }
    }
}
