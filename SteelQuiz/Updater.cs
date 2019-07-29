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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AutoUpdaterDotNET;
using SteelQuiz.Util;

namespace SteelQuiz
{
    public static class Updater
    {
        /// <summary>
        /// True if an application exit triggered by an update is pending
        /// </summary>
        public static bool UpdateExitInProgress { get; private set; } = false;

        /// <summary>
        /// The update mode that the updater is currently using
        /// </summary>
        private static UpdateMode CurrentUpdateMode { get; set; }

        /// <summary>
        /// The object used as a lock, to prevent multiple simultaneous updates
        /// </summary>
        private static readonly object updateLock = new object();

        static Updater()
        {
            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
        }

        public enum UpdateMode
        {
            /// <summary>
            /// Update automatically (if mandatory or auto update mode is set to full auto), show update dialog if an update is available (if auto update mode is set to notify), 
            /// otherwise do nothing
            /// </summary>
            Normal,

            /// <summary>
            /// Show update dialog if an update is available, otherwise show a message stating no updates are available
            /// </summary>
            Verbose,

            /// <summary>
            /// Show a notification if an update is available and auto update mode is not set to disabled, otherwise do nothing
            /// </summary>
            Notification,

            /// <summary>
            /// Update even if no update is available (force update)
            /// </summary>
            Force,

            /// <summary>
            /// Do nothing (used when a custom eventhandler for update checking is used)
            /// </summary>
            Manual
        }

        private static void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs uargs)
        {
            if ((CurrentUpdateMode == UpdateMode.Normal || CurrentUpdateMode == UpdateMode.Notification) && uargs != null && uargs.IsUpdateAvailable)
            {
                if (ConfigManager.Config.UpdateConfig.LatestVersionRun != null
                    && ConfigManager.Config.UpdateConfig.VersionSkip != uargs.CurrentVersion.ToString())
                {
                    var acceptVer = new Version(ConfigManager.Config.UpdateConfig.LatestVersionRun);
                    if (acceptVer.CompareTo(new Version(Application.ProductVersion)) > 0)
                    {
                        // user has downgraded, skip available update

                        ConfigManager.Config.UpdateConfig.VersionSkip = uargs.CurrentVersion.ToString();
                        ConfigManager.SaveConfig();

                        MessageBox.Show("It seems that you have downgraded SteelQuiz, so SteelQuiz will not automatically update to the latest version " +
                            "available now. As soon as a newer update is released than the latest one available now, the automatic updates will resume though. " +
                            "This can be changed at any time in Preferences > Updates.", "Skipping available update - SteelQuiz",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (CurrentUpdateMode == UpdateMode.Normal)
            {
                if (ConfigManager.Config.UpdateConfig.AutoUpdateMode == ConfigData.AutomaticUpdateMode.Disabled)
                {
                    return;
                }

                if (uargs != null && uargs.IsUpdateAvailable)
                {
                    if (ConfigManager.Config.UpdateConfig.VersionSkip == uargs.CurrentVersion.ToString())
                    {
                        return;
                    }
                    else
                    {
                        if (ConfigManager.Config.UpdateConfig.VersionSkip != null)
                        {
                            ConfigManager.Config.UpdateConfig.VersionSkip = null;
                        }
                        ConfigManager.Config.UpdateConfig.LatestVersionRun = uargs.InstalledVersion.ToString();
                        ConfigManager.SaveConfig();
                    }

                    if (uargs.Mandatory && uargs.UpdateMode == Mode.Forced)
                    {
                        var msg = MessageBox.Show("A mandatory software update is available. You can not continue using SteelQuiz without updating. Press OK to " +
                            "update, or Cancel to exit", "SteelQuiz", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (msg == DialogResult.OK)
                        {
                            UpdateExitInProgress = true;
                            if (Program.CloseQuizEditors())
                            {
                                AutoUpdater.DownloadUpdate();
                                Application.Exit();
                            }
                            UpdateExitInProgress = false;
                        }
                        else
                        {
                            UpdateExitInProgress = true;
                            if (Program.CloseQuizEditors())
                            {
                                Application.Exit();
                            }
                            UpdateExitInProgress = false;
                        }
                    }
                    else if (uargs.Mandatory && uargs.UpdateMode == Mode.ForcedDownload)
                    {
                        UpdateExitInProgress = true;
                        if (Program.CloseQuizEditors())
                        {
                            AutoUpdater.DownloadUpdate();
                            Application.Exit();
                        }
                        UpdateExitInProgress = false;
                    }
                    else
                    {
                        if (ConfigManager.Config.UpdateConfig.AutoUpdateMode == ConfigData.AutomaticUpdateMode.CheckOnly)
                        {
                            var frmUpdate = new UpdateAvailable(uargs.InstalledVersion, uargs.CurrentVersion);
                            var result = frmUpdate.ShowDialog();
                            if (result != DialogResult.OK)
                            {
                                return;
                            }
                        }

                        UpdateExitInProgress = true;
                        if (Program.CloseQuizEditors())
                        {
                            AutoUpdater.DownloadUpdate();
                            Application.Exit();
                        }
                        UpdateExitInProgress = false;
                    }
                }
            }
            else if (CurrentUpdateMode == UpdateMode.Notification)
            {
                if (ConfigManager.Config.UpdateConfig.AutoUpdateMode == ConfigData.AutomaticUpdateMode.Disabled)
                {
                    return;
                }

                if (uargs != null && uargs.IsUpdateAvailable)
                {
                    if (ConfigManager.Config.UpdateConfig.VersionSkip == uargs.CurrentVersion.ToString())
                    {
                        return;
                    }
                    else
                    {
                        if (ConfigManager.Config.UpdateConfig.VersionSkip != null)
                        {
                            ConfigManager.Config.UpdateConfig.VersionSkip = null;
                        }
                        ConfigManager.Config.UpdateConfig.LatestVersionRun = uargs.InstalledVersion.ToString();
                        ConfigManager.SaveConfig();
                    }

                    Program.frmWelcome.tmr_chkUpdate.Interval = 2 * 60 * 60 * 1000; // dont check for updates again for 2h

                    var notifyIcon = new NotifyIcon
                    {
                        Visible = true,
                        Icon = Properties.Resources.Logo,
                        BalloonTipTitle = "SteelQuiz"
                    };

                    if (uargs.Mandatory)
                    {
                        if (uargs.UpdateMode == Mode.Forced)
                        {
                            notifyIcon.BalloonTipText = "Mandatory software update is available. Click here to update now";
                        }
                        else // automatic download and installation (at startup of app)
                        {
                            notifyIcon.BalloonTipText = "A software update is available. Click here to update now";
                        }
                    }
                    else
                    {
                        if (ConfigManager.Config.UpdateConfig.AutoUpdateMode == ConfigData.AutomaticUpdateMode.CheckDownloadInstall)
                        {
                            notifyIcon.BalloonTipText = "A software update is available. Click here to update now";
                        }
                        else
                        {
                            notifyIcon.BalloonTipText = "A software update is available. Click here for more info";
                        }
                    }
                    notifyIcon.BalloonTipClosed += (sender, args) => Dispose(notifyIcon);
                    notifyIcon.BalloonTipClicked += (sender, args) => UpdateNotificationClick(notifyIcon);
                    notifyIcon.ShowBalloonTip(10000);
                }
            }
            else if (CurrentUpdateMode == UpdateMode.Verbose)
            {
                if (uargs != null && uargs.IsUpdateAvailable)
                {
                    if (uargs.Mandatory || new UpdateAvailable(uargs.InstalledVersion, uargs.CurrentVersion).ShowDialog() == DialogResult.OK)
                    {
                        if (Program.CloseQuizEditors())
                        {
                            AutoUpdater.DownloadUpdate();
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"No updates are available.\r\n\r\nYou are running SteelQuiz v{Application.ProductVersion}",
                        "Update Check - SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (CurrentUpdateMode == UpdateMode.Force)
            {
                if (Program.CloseQuizEditors())
                {
                    AutoUpdater.DownloadUpdate();
                    Application.Exit();
                }
            }
        }

        private class ChannelVersion
        {
            public string MetaURL { get; set; }
            public Version Version { get; set; }

            public ChannelVersion(string metaURL, Version version)
            {
                MetaURL = metaURL;
                Version = version;
            }
        }

        private static ChannelVersion NewestUpdateChannel(params string[] metaUrls)
        {
            var newestChannel = new ChannelVersion(null, new Version(0, 0, 0));

            foreach (var metaURL in metaUrls)
            {
                using (var client = new WebClient())
                {
                    string xml = client.DownloadString(metaURL);
                    var doc = new XmlDocument();
                    doc.LoadXml(xml);

                    XmlNode versionNode = doc.SelectSingleNode("/item/version");
                    string strVersion = versionNode.InnerText;

                    Version version = new Version(strVersion);

                    if (version.CompareTo(newestChannel.Version) > 0)
                    {
                        newestChannel = new ChannelVersion(metaURL, version);
                    }
                }
            }

            return newestChannel;
        }

        private static ChannelVersion NewestUpdateChannel()
        {
            return NewestUpdateChannel("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml",
                "https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/channel_dev/update_meta.xml");
        }

        /// <summary>
        /// Checks for updates, and eventually downloads/installs them/does other stuff, depending on the update mode
        /// </summary>
        /// <param name="updateMode">The update mode to be used for the update</param>
        public static void Update(UpdateMode updateMode)
        {
            lock (updateLock)
            {
                CurrentUpdateMode = updateMode;

                if (SUtil.InternetConnectionAvailable())
                {
                    try
                    {
                        if (SUtil.IsDirectoryWritable(Path.GetDirectoryName(Application.ExecutablePath)))
                        {
                            // if application has write permissions to application folder, admin is not required
                            AutoUpdater.RunUpdateAsAdmin = false;
                        }

                        if (ConfigManager.Config.UpdateConfig.UpdateChannel == ConfigData.UpdateChannel.Stable)
                        {
                            AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
                        }
                        else if (ConfigManager.Config.UpdateConfig.UpdateChannel == ConfigData.UpdateChannel.Development)
                        {
                            var newestChannel = NewestUpdateChannel();
                            AutoUpdater.Start(newestChannel.MetaURL);
                        }

                        //AutoUpdater.Start("http://localhost:8000/update_meta.xml");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred during the update/update check:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (CurrentUpdateMode == UpdateMode.Verbose || CurrentUpdateMode == UpdateMode.Notification)
                {
                    MessageBox.Show("Internet connection could not be established", "Update Check Failed - SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void UpdateNotificationClick(NotifyIcon notifyIcon)
        {
            Update(UpdateMode.Normal);
            Dispose(notifyIcon);
        }

        private static void Dispose(NotifyIcon notifyIcon)
        {
            notifyIcon.Dispose();
        }
    }
}
