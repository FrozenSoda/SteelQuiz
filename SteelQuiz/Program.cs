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
            ConfigManager.LoadConfig();
            Application.Run(new TermsOfUse());
        }
    }
}
