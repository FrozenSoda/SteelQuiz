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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor
{
    public partial class SaveDontSave : AutoThemeableForm
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

        public SaveDontSave(Form owner, Icon icon, bool confirmDoNotSave, string msg = null, string title = null)
        {
            InitializeComponent();

            this.Location = new Point(owner.Location.X + (owner.Size.Width / 2) - (this.Size.Width / 2),
                              owner.Location.Y + (owner.Size.Height / 2) - (this.Size.Height / 2)
                            );
            // for some reason, the size gets changed automatically when centering with the parent. change the size back
            this.Size = new Size(411, 157);

            if (msg != null)
            {
                lbl_msg.Text = msg;
            }
            if (title != null)
            {
                Text = title;
            }
            pic_icon.Image = icon.ToBitmap();
            if (!confirmDoNotSave)
            {
                btn_doNotSave.Enabled = true;
                chk_doNotSave.Visible = false;
            }

            SetTheme();
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

        private void Chk_doNotSave_CheckedChanged(object sender, EventArgs e)
        {
            btn_doNotSave.Enabled = chk_doNotSave.Checked;
        }
    }
}
