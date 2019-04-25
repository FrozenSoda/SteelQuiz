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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor
{
    public partial class EditorNotification : UserControl
    {
        private DateTime CreationDate { get; set; }

        public EditorNotification(string msg, int showMillis = 0)
        {
            InitializeComponent();
            lbl_msg.Text = msg;
            if (showMillis > 0)
            {
                tmr_autoDestruction.Interval = showMillis;
                tmr_autoDestruction.Start();
            }
            CreationDate = DateTime.Now;
        }

        public new void Show()
        {
            // show effects
            base.Show();
        }

        public new void Dispose()
        {
            // disposal effects


            // dispose
            base.Dispose();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Tmr_timeStamp_Tick(object sender, EventArgs e)
        {
            TimeSpan dateDiff = DateTime.Now.Subtract(CreationDate);
            if (dateDiff.TotalSeconds < 15)
            {
                lbl_timeStamp.Text = "Just now";
            }
            else if (dateDiff.TotalSeconds < 60)
            {
                lbl_timeStamp.Text = $"{dateDiff.TotalSeconds}s ago";
            }
            else if (dateDiff.TotalMinutes < 60)
            {
                lbl_timeStamp.Text = $"{dateDiff.TotalMinutes} minutes ago";
            }
            else if (dateDiff.TotalHours < 60)
            {
                lbl_timeStamp.Text = $"{dateDiff.TotalHours} hours ago";
            }
            else if (dateDiff.TotalDays < 365)
            {
                lbl_timeStamp.Text = $"{dateDiff.TotalDays} days ago";
            }
            else
            {
                lbl_timeStamp.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // we show the exact date the message was created, no need to update it anymore.
                tmr_timeStamp.Stop();
            }
        }

        private void Tmr_autoDestruction_Tick(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
