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

using Newtonsoft.Json.Linq;
using SteelQuiz.QuizPractise;
using SteelQuiz.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class TermsOfUse : AutoThemeableForm
    {
        private const int AGREE_UNLOCK_DELAY_S = 5;
        private int unlockTimerCount = 0;
        private bool showForm = true;

        private int __stage;
        private int Stage
        {
            get
            {
                return __stage;
            }

            set
            {
                __stage = value;
                if (Stage == -1)
                {
                    Application.Exit();
                }
                else if (Stage == 0)
                {
                    btn_cancel.Text = "Cancel";
                    rtf_license.Text = SUtil.ReadEmbeddedResource("LICENSE");
                }
                else if (Stage == 1)
                {
                    btn_cancel.Text = "Back";
                    rtf_license.Text = SUtil.ReadEmbeddedResource("LICENSE_3RD_PARTY");
                }
                else if (Stage == 2)
                {
                    ConfigManager.Config.AcceptedTermsOfUse = true;
                    ConfigManager.SaveConfig();

                    OpenApplication();
                }
            }
        }

        public TermsOfUse()
        {
            SetTermsOfUseAccepted();

            if (ConfigManager.Config.AcceptedTermsOfUse)
            {
                showForm = false;
                OpenApplication();
            }
            else
            {
                InitializeComponent();
                this.Text += $" v{Application.ProductVersion}";
                if (MetaData.PRE_RELEASE)
                {
                    this.Text += " PRE-RELEASE";
                }
                Stage = 0;

                SetTheme();
            }
        }

        private void SetTermsOfUseAccepted()
        {
            // Check if TOS was accepted from setup, and if that's true, set the config variable

            string licenseAcceptedPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "ACCEPTED_LICENSE");
            if (File.Exists(licenseAcceptedPath))
            {
                using (var reader = new StreamReader(licenseAcceptedPath))
                {
                    if (reader.ReadToEnd() == "ACCEPTED_LICENSE=true")
                    {
                        ConfigManager.Config.AcceptedTermsOfUse = true;
                        ConfigManager.SaveConfig();
                    }
                }
            }

            string installInfoPath = "InstallInfo.json";
            if (File.Exists(installInfoPath))
            {
                var installInfoRaw = File.ReadAllText(installInfoPath);
                var installInfo = JObject.Parse(installInfoRaw);
                var acceptedLicense = installInfo["accepted_license"];

                if (acceptedLicense != null && (bool)acceptedLicense)
                {
                    ConfigManager.Config.AcceptedTermsOfUse = true;
                    ConfigManager.SaveConfig();
                }
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(!value ? value : showForm);
            // if form should be hidden (value is false), then hide it, no setting prevents hiding it
            // but it the form should be shown, only show it if showForm is true
        }

        private void OpenApplication()
        {
            Hide();

            Program.frmWelcome = new Dashboard();
            Program.frmWelcome.Show();

            /*
            if (!QuizCore.ChkCreateQuizProgress())
            {
                // open troubleshooting
                Program.frmWelcome.ShowPreferences(typeof(Preferences.PrefsTroubleshooting), typeof(Preferences.CategoriesMaintenance));
            }
            else
            {
                var progDataUpgrade = QuizCore.ChkUpgradeProgressData();
                if (progDataUpgrade == QuizCore.ChkUpgradeProgressDataResult.Fail)
                {
                    return;
                }
            }
            */
        }

        private void timer_agree_unlock_Tick(object sender, EventArgs e)
        {
            ++unlockTimerCount;
            btn_agree.Text = "I agree (" + (AGREE_UNLOCK_DELAY_S - unlockTimerCount) + " s)";
            if (unlockTimerCount >= AGREE_UNLOCK_DELAY_S)
            {
                btn_agree.Text = "I agree";
                btn_agree.Enabled = true;
                timer_agree_unlock.Stop();
            }
        }

        private void TermsOfUse_Load(object sender, EventArgs e)
        {
            btn_agree.Text = "I agree (" + AGREE_UNLOCK_DELAY_S + " s)";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            --Stage;
        }

        private void btn_agree_Click(object sender, EventArgs e)
        {
            ++Stage;
        }
    }
}
