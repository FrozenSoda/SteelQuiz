using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    static class Program
    {
        public static InQuiz inQuiz = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ConfigManager.LoadConfig();

            Application.Run(new TermsOfUse());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
#if DEBUG
            return;
#endif

            MessageBox.Show("An application error has occurred:\r\n\r\n" + (e.ExceptionObject as Exception).ToString()
                , "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
#if DEBUG
            return;
#endif

            MessageBox.Show("An application error has occurred:\r\n\r\n" + e.Exception.ToString(),
                "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
