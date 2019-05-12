using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace SteelQuiz
{
    public static class Updates
    {
        private static UpdateMode CurrentUpdateMode { get; set; }

        static Updates()
        {
            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
        }

        public enum UpdateMode
        {
            Startup,
            Notification,
            Verbose
        }

        private static void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable)
            {
                if (args.Mandatory || new UpdateAvailable(args.InstalledVersion, args.CurrentVersion).ShowDialog() == DialogResult.OK)
                {
                    AutoUpdater.DownloadUpdate();
                }
            }
        }

        public static void StartupUpdate()
        {
            if (SUtil.InternetConnectionAvailable())
            {
                try
                {
                    if (SUtil.IsDirectoryWritable(Path.GetDirectoryName(Application.ExecutablePath)))
                    {
                        // if application has write permissions to application folder, admin is not required
                        AutoUpdater.RunUpdateAsAdmin = false;
                    }
                    AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during the update/update check:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
