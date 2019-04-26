using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor
{
    public partial class SaveDontSave : Form
    {
        private SaveResult _saveDialogResult;
        public SaveResult SaveDialogResult
        {
            get
            {
                return _saveDialogResult;
            }

            set
            {
                _saveDialogResult = value;
                DialogResult = DialogResult.OK;
            }
        }

        public SaveDontSave(string msg, Icon icon, bool confirmDoNotSave)
        {
            InitializeComponent();
            lbl_msg.Text = msg;
            pic_icon.Image = icon.ToBitmap();
            if (!confirmDoNotSave)
            {
                btn_doNotSave.Enabled = true;
                chk_doNotSave.Visible = false;
            }
        }

        public enum SaveResult
        {
            Save,
            DoNotSave,
            Cancel
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            SaveDialogResult = SaveResult.Cancel;   
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            SaveDialogResult = SaveResult.Save;
        }

        private void Btn_doNotSave_Click(object sender, EventArgs e)
        {
            SaveDialogResult = SaveResult.DoNotSave;
        }
    }
}
