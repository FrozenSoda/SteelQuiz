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
        public Guid GUID = Guid.NewGuid();
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


            // hide notification panel if no messages are there anymore
            if (Parent.Controls.Count == 1) // == 1 instead of 0 because this notification still exists
            {
                Parent.Visible = false;
            }

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

            double s_round = Math.Round(dateDiff.TotalSeconds);
            double m_round = Math.Round(dateDiff.TotalMinutes);
            double h_round = Math.Round(dateDiff.TotalHours);
            double d_round = Math.Round(dateDiff.TotalDays);

            if (s_round < 15)
            {
                lbl_timeStamp.Text = "Just now";
            }
            else if (s_round < 60)
            {
                lbl_timeStamp.Text = $"{s_round}s ago";
            }
            else if (m_round < 2)
            {
                lbl_timeStamp.Text = $"{m_round} minute ago";
            }
            else if (m_round < 60)
            {
                lbl_timeStamp.Text = $"{m_round} minutes ago";
            }
            else if (h_round < 2)
            {
                lbl_timeStamp.Text = $"{h_round} hour ago";
            }
            else if (h_round < 24)
            {
                lbl_timeStamp.Text = $"{h_round} hours ago";
            }
            else if (d_round < 2)
            {
                lbl_timeStamp.Text = $"{d_round} day ago";
            }
            else if (d_round < 365)
            {
                lbl_timeStamp.Text = $"{d_round} days ago";
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

        private void EditorNotification_SizeChanged(object sender, EventArgs e)
        {
            /*
            lbl_msg.Size = new Size(Size.Width - 41, Size.Height - 36);
            lbl_timeStamp.Size = new Size(Size.Width - 41, lbl_timeStamp.Size.Height);

            // resize message font size
            while (lbl_msg.Height * lbl_msg.Width > TextRenderer.MeasureText(lbl_msg.Text,
                new Font(lbl_msg.Font.FontFamily, lbl_msg.Font.Size, lbl_msg.Font.Style)).Width)
            {
                lbl_msg.Font = new Font(lbl_msg.Font.FontFamily, lbl_msg.Font.Size + 0.5f, lbl_msg.Font.Style);
            }
            while (lbl_msg.Height * lbl_msg.Width < TextRenderer.MeasureText(lbl_msg.Text,
                new Font(lbl_msg.Font.FontFamily, lbl_msg.Font.Size, lbl_msg.Font.Style)).Width)
            {
                lbl_msg.Font = new Font(lbl_msg.Font.FontFamily, lbl_msg.Font.Size - 0.5f, lbl_msg.Font.Style);
            }
            */
        }
    }
}
