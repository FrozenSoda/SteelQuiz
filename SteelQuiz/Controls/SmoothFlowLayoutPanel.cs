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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Controls
{
    public class SmoothFlowLayoutPanel : FlowLayoutPanel
    {
        private Synchronizer synchronizer = new Synchronizer();
        private System.Timers.Timer scrollTimer = null;
        private int scrollElapsed = 0;
        private bool animationRunning = false;

        public SmoothFlowLayoutPanel() : base()
        {
            DoubleBuffered = true;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
#warning application and the whole Windows system freezes frequently when scrolling
            // smooth scrolling

            if (animationRunning)
            {
                scrollElapsed = 25;
                return;
            }

            animationRunning = true;

            if (scrollTimer == null)
            {
                scrollTimer = new System.Timers.Timer
                {
                    Interval = 8,
                    SynchronizingObject = this,
                    AutoReset = false
                };
            }

            scrollTimer.Elapsed += delegate
            {
                lock (synchronizer[scrollElapsed])
                {
                    System.Diagnostics.Debug.Print("\r\nscrollTimer elapsed START");
                    try
                    {
                        double deltaScrollD = DeltaScroll(scrollElapsed);
                        if (scrollElapsed > 0 && deltaScrollD == 0)
                        {
                            scrollElapsed = 0;
                            scrollTimer.Stop();
                            animationRunning = false;
                            return;
                        }
                        int deltaScroll = Convert.ToInt32(Math.Ceiling(deltaScrollD * e.Delta)) * -1;
                        if (this.VerticalScroll.Value + deltaScroll < this.VerticalScroll.Minimum)
                        {
                            this.VerticalScroll.Value = this.VerticalScroll.Minimum;

                            scrollElapsed = 0;
                            scrollTimer.Stop();
                            animationRunning = false;
                            return;
                        }
                        else if (this.VerticalScroll.Value + deltaScroll > this.VerticalScroll.Maximum)
                        {
                            this.VerticalScroll.Value = this.VerticalScroll.Maximum;

                            scrollElapsed = 0;
                            scrollTimer.Stop();
                            animationRunning = false;
                            return;
                        }
                        else
                        {
                            this.VerticalScroll.Value += deltaScroll;
                        }
                        ++scrollElapsed;
                    }
                    finally
                    {
                        if (scrollElapsed > 0)
                        {
                            scrollTimer.Enabled = true;
                        }
                        System.Diagnostics.Debug.Print("scrollTimer elapsed STOP");
                    }
                }
            };

            scrollTimer.Start();
        }

        private double DeltaScroll(int millis)
        {
            double d = -0.00032D * millis * (millis - 50.0D);
            if (d >= 0)
            {
                return d;
            }
            else
            {
                return 0;
            }
        }
    }
}
