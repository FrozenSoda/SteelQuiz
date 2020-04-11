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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.Extensions;

namespace SteelQuiz.Animations
{
    public static class LabelFade
    {
        public static List<Label> LabelsFading = new List<Label>();
        public static List<Label> LabelsFadeCancel = new List<Label>();

        /// <summary>
        /// Fades a color change of a label
        /// </summary>
        /// <param name="lbl">The label to fade a color change</param>
        /// <param name="from">The starting color</param>
        /// <param name="to">The target color</param>
        /// <param name="time">The interval for the fade</param>
        public static void Fade(this Label lbl, Color from, Color to, int time)
        {
            lbl.ForeColor = from;
            lbl.Visible = true;

            double dA_d = (to.A - from.A) / (time / 10D);
            double dR_d = (to.R - from.R) / (time / 10D);
            double dG_d = (to.G - from.G) / (time / 10D);
            double dB_d = (to.B - from.B) / (time / 10D);

            int dA = 0;
            int dR = 0;
            int dG = 0;
            int dB = 0;

            if (dA_d > 0)
            {
                dA = (int)Math.Ceiling(dA_d);
            }
            else if (dA_d < 0)
            {
                dA = (int)Math.Floor(dA_d);
            }

            if (dR_d > 0)
            {
                dR = (int)Math.Ceiling(dR_d);
            }
            else if (dR_d < 0)
            {
                dR = (int)Math.Floor(dR_d);
            }

            if (dG_d > 0)
            {
                dG = (int)Math.Ceiling(dG_d);
            }
            else if (dG_d < 0)
            {
                dG = (int)Math.Floor(dG_d);
            }

            if (dB_d > 0)
            {
                dB = (int)Math.Ceiling(dB_d);
            }
            else if (dB_d < 0)
            {
                dB = (int)Math.Floor(dB_d);
            }

            var tmr = new System.Timers.Timer()
            {
                Interval = 10,
                SynchronizingObject = lbl,
                AutoReset = false
            };
            tmr.Elapsed += delegate
            {
                if (!LabelsFading.Contains(lbl))
                {
                    LabelsFading.Add(lbl);
                }

                int A = (lbl.ForeColor.A + dA).FixBounds(0, 255);
                int R = (lbl.ForeColor.R + dR).FixBounds(0, 255);
                int G = (lbl.ForeColor.G + dG).FixBounds(0, 255);
                int B = (lbl.ForeColor.B + dB).FixBounds(0, 255);

                lbl.ForeColor = Color.FromArgb(A, R, G, B);
                if (!LabelsFadeCancel.Contains(lbl))
                {
                    if (((dA >= 0 && lbl.ForeColor.A >= to.A) || (dA <= 0 && lbl.ForeColor.A <= to.A))
                        && ((dR >= 0 && lbl.ForeColor.R >= to.R) || (dR <= 0 && lbl.ForeColor.R <= to.R))
                        && ((dG >= 0 && lbl.ForeColor.G >= to.G) || (dG <= 0 && lbl.ForeColor.G <= to.G))
                        && ((dB >= 0 && lbl.ForeColor.B >= to.B) || (dB <= 0 && lbl.ForeColor.B <= to.B)))
                    {
                        lbl.ForeColor = to;
                        LabelsFading.Remove(lbl);
                        LabelsFadeCancel.Remove(lbl);
                    }
                    else
                    {
                        tmr.Enabled = true;
                    }
                }
                else
                {
                    LabelsFading.Remove(lbl);
                    LabelsFadeCancel.Remove(lbl);
                }
            };
            tmr.Start();
        }
    }
}
