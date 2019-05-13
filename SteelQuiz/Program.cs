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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using SteelQuiz.QuizData;
using SteelQuiz.QuizEditor;
using SteelQuiz.QuizPractise;

namespace SteelQuiz
{
    static class Program
    {
        public static string[] Args { get; set; }

        public static Welcome frmWelcome = null;
        public static InQuiz frmInQuiz = null;
        public static Preferences.Preferences frmPreferences = null;
        public static List<QuizEditor.QuizEditor> openQuizEditors = new List<QuizEditor.QuizEditor>();

        public static int QuizEditorsOpen { get; set; } = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Args = args;

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            QuizCore.CheckInitDirectories();
            if (!ConfigManager.LoadConfig())
            {
                return;
            }

            var progDataUpgrade = QuizCore.ChkUpgradeProgressData();
            if (progDataUpgrade == QuizCore.ChkUpgradeProgressDataResult.Fail)
            {
                return;
            }

            Application.Run(new TermsOfUse());
        }

        public static bool CloseQuizEditors()
        {
            foreach (var quizEditor in openQuizEditors)
            {
                if (!quizEditor.SaveBeforeExit())
                {
                    return false;
                }
                quizEditor.Close();
            }

            return true;
        }

        public static void OpenQuizEditor(Quiz quiz = null, string quizPath = null, bool chkRecovery = true)
        {
            var quizEditor = new QuizEditor.QuizEditor(chkRecovery);
            openQuizEditors.Add(quizEditor);
            if (quiz != null)
            {
                quizEditor.LoadQuiz(quiz, quizPath);
            }
            quizEditor.Show();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
#pragma warning disable CS0162 // Unreachable code detected
#if DEBUG
            return;
#endif
            MessageBox.Show("An application error has occurred:\r\n\r\n" + (e.ExceptionObject as Exception).ToString()
                , "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
#pragma warning restore CS0162 // Unreachable code detected
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
#pragma warning disable CS0162 // Unreachable code detected
#if DEBUG
            return;
#endif
            MessageBox.Show("An application error has occurred:\r\n\r\n" + e.Exception.ToString(),
                "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
#pragma warning restore CS0162 // Unreachable code detected
        }
    }
}
