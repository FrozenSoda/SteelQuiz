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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Controls
{
    public class SmoothFlowLayoutPanel : FlowLayoutPanel
    {
        private SuperStopwatch scrollElapsedStopwatch = new SuperStopwatch();
        private System.Timers.Timer scrollAnimationTimer = null;
        private bool animationRunning = false;

        /*
        public SmoothFlowLayoutPanel() : base()
        {
            DoubleBuffered = true;
        }
        */

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
                scrollElapsedStopwatch.Reset(new TimeSpan(0, 0, 0, 0, 250));
                return;
            }

            animationRunning = true;

            if (scrollAnimationTimer == null)
            {
                scrollAnimationTimer = new System.Timers.Timer
                {
                    Interval = 8,
                    SynchronizingObject = this,
                    AutoReset = false
                };
            }

            System.Diagnostics.Debug.Print("\r\nStarting new scroll timer actions");

            scrollAnimationTimer.Elapsed += delegate
            {
                System.Diagnostics.Debug.Print("\r\nscrollAnimationTimer elapsed START");
                bool stop = false;
                try
                {
                    double deltaScrollD = DeltaScroll(scrollElapsedStopwatch.ElapsedMilliseconds);
                    System.Diagnostics.Debug.Print($"deltaScrollD: {deltaScrollD}");
                    System.Diagnostics.Debug.Print($"scrollElapsed: {scrollElapsedStopwatch.ElapsedMilliseconds}");
                    if (scrollElapsedStopwatch.ElapsedMilliseconds > 0 && deltaScrollD == 0D)
                    {
                        stop = true;
                        return;
                    }
                    int deltaScroll = Convert.ToInt32(Math.Ceiling(deltaScrollD * e.Delta)) * -1;
                    if (this.VerticalScroll.Value + deltaScroll < this.VerticalScroll.Minimum)
                    {
                        this.VerticalScroll.Value = this.VerticalScroll.Minimum;

                        stop = true;
                        return;
                    }
                    else if (this.VerticalScroll.Value + deltaScroll > this.VerticalScroll.Maximum)
                    {
                        this.VerticalScroll.Value = this.VerticalScroll.Maximum;

                        stop = true;
                        return;
                    }
                    else
                    {
                        this.VerticalScroll.Value += deltaScroll;
                    }
                }
                finally
                {
                    if (!stop)
                    {
                        scrollAnimationTimer.Enabled = true;
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print("Stopping scroll animation");
                        scrollElapsedStopwatch.Reset();
                        scrollAnimationTimer.Stop();
                        animationRunning = false;
                        System.Diagnostics.Debug.Print("Stopped scroll animation");
                    }
                    System.Diagnostics.Debug.Print("scrollAnimationTimer elapsed STOP");
                }
            };

            scrollElapsedStopwatch.Restart();
            scrollAnimationTimer.Start();
        }

        private double DeltaScroll(long millis)
        {
            //double d = -0.00032D * millis * (millis - 50.0D);
            //double d = -0.000016D * millis * (millis - 500.0D);
            double d = -0.000008D * millis * (millis - 500.0D);
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
