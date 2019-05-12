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
    public partial class UpdateAvailable : AutoThemeableForm
    {
        public UpdateAvailable(Version installedVersion, Version newVersion)
        {
            InitializeComponent();
            SetTheme();

            lbl_top.Text = $"A software update for SteelQuiz is available (v{newVersion.ToString()})";
            lbl_installedVer.Text = $"Current version: v{installedVersion.ToString()}";
        }

        private void Btn_notNow_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}