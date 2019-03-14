using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class TermsOfUse : Form
    {
        private const int AGREE_UNLOCK_DELAY_S = 20;
        private int unlockTimerCount = 0;
        private bool showForm = true;

        public TermsOfUse()
        {
            if (ConfigManager.Config.AcceptedTermsOfUse)
            {
                showForm = false;
                OpenApplication();
            }
            else
            {
                InitializeComponent();
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(showForm);
        }

        private void OpenApplication()
        {
            var welcome = new Welcome();
            welcome.Show();
            Hide();
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
            Application.Exit();
        }

        private void btn_agree_Click(object sender, EventArgs e)
        {
            ConfigManager.Config.AcceptedTermsOfUse = true;
            ConfigManager.SaveConfig();

            OpenApplication();
        }
    }
}
