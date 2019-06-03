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
using System.IO;
using SteelQuiz.Controls;
using System.Diagnostics;

namespace SteelQuiz.Preferences
{
    public partial class QuizFolder : AutoThemeableUserControl
    {
        public string QuizFolderPath
        {
            get
            {
                return txt_path.Text;
            }

            set
            {
                txt_path.Text = value;
            }
        }

        /// <summary>
        /// The user control that owns this control
        /// </summary>
        private PrefsQuizFolders ParentUC { get; set; }

        public QuizFolder(PrefsQuizFolders parentUC, string path = null)
        {
            InitializeComponent();

            ParentUC = parentUC;

            if (path == null)
            {
                if (fbd_path.ShowDialog() == DialogResult.OK)
                {
                    txt_path.Text = fbd_path.SelectedPath;
                    ParentUC.Save(true, txt_path.Text);
                }
            }
            else
            {
                txt_path.Text = path;
            }

            SetTheme();
        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Remove quiz folder from list?\r\n\r\nWarning: Progress data for the quizzes in this folder might be lost in the future as the " +
                "quizzes will not be tracked by SteelQuiz anymore. This might happen during clean ups and upgrades for instance.\r\n\r\nContinue?", "Remove Quiz Folder - SteelQuiz",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                Dispose();
                ParentUC.Save(true);
            }
        }

        private void Btn_browse_Click(object sender, EventArgs e)
        {
            if (txt_path.Text != "" && Directory.Exists(txt_path.Text))
            {
                fbd_path.SelectedPath = txt_path.Text;
            }
            else
            {
                fbd_path.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            
            if (fbd_path.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = fbd_path.SelectedPath;
            }
        }

        private void Txt_path_Leave(object sender, EventArgs e)
        {
            ParentUC.Save(true);
        }

        private Point MouseDownLocation { get; set; }
        private Stopwatch hoverStopwatch = new Stopwatch();

        private void Pnl_drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                hoverStopwatch.Start();
                MouseDownLocation = e.Location;
                BringToFront();
            }
        }

        private void Pnl_drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int left = e.X + Left - MouseDownLocation.X;
                int top = e.Y + Top - MouseDownLocation.Y;

                /*
                // LOCK CONTROL TO DFLP BOUNDS
                if (left > 0 && left + Size.Width <= (Parent as DraggableFlowLayoutPanel).Size.Width)
                {
                    Left = left;
                }
                if (top > 0 && top + Size.Height <= (Parent as DraggableFlowLayoutPanel).Size.Height)
                {
                    Top = top;
                }
                */
                Left = left;
                Top = top;

                if (hoverStopwatch.ElapsedMilliseconds > 100)
                {
                    (Parent as DraggableFlowLayoutPanel).AlignAll(this);
                    hoverStopwatch.Restart();
                }
            }
        }

        private void Pnl_drag_MouseUp(object sender, MouseEventArgs e)
        {
            hoverStopwatch.Reset();
            (Parent as DraggableFlowLayoutPanel).Align(this, () =>
            {
                ParentUC.Save(true);
            });
        }
    }
}
