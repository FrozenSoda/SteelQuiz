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
        private System.Timers.Timer scrollTimer = null;
        private int scrollElapsed = 0;
        private bool animationRunning = false;

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
#warning application freezes frequently when scrolling
            // smooth scrolling

            if (animationRunning)
            {
                scrollElapsed = 25;
                return;
            }

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
            };

            animationRunning = true;
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
