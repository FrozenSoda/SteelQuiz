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
        System.Timers.Timer scrollTimer = null;
        int scrollElapsed = 0;

        protected override void OnScroll(ScrollEventArgs se)
        {
            return;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // smooth scrolling

            if (scrollTimer != null && scrollTimer.Enabled)
            {
                return;
            }

            scrollTimer = new System.Timers.Timer
            {
                Interval = 8,
                SynchronizingObject = this
            };

            scrollTimer.Elapsed += delegate
            {
                double deltaScrollD = DeltaScroll(scrollElapsed);
                if (scrollElapsed > 0 && deltaScrollD == 0)
                {
                    scrollElapsed = 0;
                    scrollTimer.Stop();
                    return;
                }
                int deltaScroll = Convert.ToInt32(Math.Ceiling(deltaScrollD * e.Delta)) * -1;
                if (this.VerticalScroll.Value + deltaScroll <= this.VerticalScroll.Minimum)
                {
                    this.VerticalScroll.Value = this.VerticalScroll.Minimum;
                }
                else if (this.VerticalScroll.Value + deltaScroll >= this.VerticalScroll.Maximum)
                {
                    this.VerticalScroll.Value = this.VerticalScroll.Maximum;
                }
                else
                {
                    this.VerticalScroll.Value += deltaScroll;
                }
                ++scrollElapsed;
            };

            scrollTimer.Start();
        }

        private double DeltaScroll(int millis)
        {
            double d = -1D / 10000D * millis * (millis - 50D);
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
