using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Animations
{
    public static class LabelFade
    {
        public static List<Label> LabelsFading = new List<Label>();
        public static List<Label> LabelFadeCancel = new List<Label>();

        public static void Fade(this Label lbl, Color from, Color to, int time)
        {
            int dA = (to.A - from.A) / time;
            int dR = (to.R - from.R) / time;
            int dG = (to.G - from.G) / time;
            int dB = (to.B - from.B) / time;

            var tmr = new System.Timers.Timer()
            {
                Interval = 1,
                SynchronizingObject = lbl,
                AutoReset = false
            };
            tmr.Elapsed += delegate
            {
                if (!LabelsFading.Contains(lbl))
                {
                    LabelsFading.Add(lbl);
                }

                lbl.ForeColor = Color.FromArgb(lbl.ForeColor.A + dA, lbl.ForeColor.R + dR, lbl.ForeColor.G + dG, lbl.ForeColor.B + dB);
                if (!LabelFadeCancel.Contains(lbl) && !lbl.ForeColor.Equals(to))
                {
                    tmr.Enabled = true;
                }
                else
                {
                    LabelsFading.Remove(lbl);
                }
            };
            tmr.Start();
        }
    }
}
