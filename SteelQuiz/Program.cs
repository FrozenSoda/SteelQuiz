/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Microsoft.Win32;
using SteelQuiz.QuizData;
using SteelQuiz.QuizEditor;
using SteelQuiz.QuizPractise;

namespace SteelQuiz
{
    static class Program
    {
        public static string[] Args { get; set; }

        public static Dashboard frmWelcome = null;
        public static InQuiz frmInQuiz = null;
        public static Preferences.Preferences frmPreferences = null;
        public static List<QuizEditor.QuizEditor> openQuizEditors = new List<QuizEditor.QuizEditor>();

        public static int QuizEditorsOpen { get; set; } = 0;

        private static Mutex mutex = new Mutex(true, "40467036-2cfe-4c10-a190-426d3544496a");

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

            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("SteelQuiz is already running.", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            if (!QuizCore.CheckInitDirectories())
            {
                Environment.Exit(1);
            }

            if (!ConfigManager.LoadConfig())
            {
                return;
            }

            ++ConfigManager.Config.Statistics.LaunchCount.Data;
            ConfigManager.SaveConfig();
            ConfigManager.Configure();

            Application.Run(new TermsOfUse());
        }

        /// <summary>
        /// Checks if the OS supports global app themes (as in newer versions of Windows 10)
        /// </summary>
        /// <returns>True if the OS supports global app themes, otherwise false </returns>
        [Obsolete("This method is not reliable. If the user runs a compatible version of Windows 10, but has never changed their theme, this method will return " +
            "false. Do not rely on this method.", true)]
        public static bool Win10AppThemeSupported()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
            {
                if (key == null)
                {
                    return false;
                }

                object lightObj = key.GetValue("AppsUseLightTheme");

                if (lightObj == null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the Windows 10 app theme currently being used
        /// </summary>
        /// <returns>If Windows version supports app themes, returns the set theme. Otherwise, returns null</returns>
        public static ThemeManager.ThemeCore.Theme? GetWin10Theme()
        {
            ThemeManager.ThemeCore.Theme theme;
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
            {
                if (key == null)
                {
                    return null;
                }

                object lightObj = key.GetValue("AppsUseLightTheme");

                if (lightObj == null)
                {
                    // User don't have Windows 10, or the Windows 10 build is too old for app theme
                    return null;
                }

                bool light = Convert.ToBoolean((int)lightObj);
                if (light)
                {
                    theme = ThemeManager.ThemeCore.Theme.Light;
                }
                else
                {
                    theme = ThemeManager.ThemeCore.Theme.Dark;
                }
            }

            return theme;
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
