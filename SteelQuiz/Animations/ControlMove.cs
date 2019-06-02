﻿/*
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Animations
{
    public static class ControlMove
    {
        public static List<Control> ControlsMoving = new List<Control>();
        public static List<Control> ControlsStopMoving = new List<Control>();

        public static void SmoothMove(this Control control, Point from, Point to, int time)
        {
            double dX_d = (to.X - from.X) / (time / 10D);
            double dY_d = (to.Y - from.Y) / (time / 10D);

            int dX = 0;
            int dY = 0;

            if (dX_d > 0D)
            {
                dX = (int)Math.Ceiling(dX_d);
            }
            else if (dX_d < 0D)
            {
                dX = (int)Math.Floor(dX_d);
            }

            if (dY_d > 0D)
            {
                dY = (int)Math.Ceiling(dY_d);
            }
            else if (dY_d < 0D)
            {
                dY = (int)Math.Floor(dY_d);
            }

            var tmr = new System.Timers.Timer()
            {
                Interval = 10,
                SynchronizingObject = control,
                AutoReset = false
            };
            tmr.Elapsed += delegate
            {
                if (!ControlsMoving.Contains(control))
                {
                    ControlsMoving.Add(control);
                }

                if (!ControlsStopMoving.Contains(control))
                {
                    if ((dX >= 0 && control.Location.X >= to.X) || (dX <= 0 && control.Location.X <= to.X)
                        && (dY >= 0 && control.Location.Y >= to.Y) || (dY <= 0 && control.Location.Y <= to.Y))
                    {
                        control.Location = to;
                        ControlsMoving.Remove(control);
                        ControlsStopMoving.Remove(control);
                    }
                    else
                    {
                        tmr.Enabled = true;
                    }
                }
                else
                {
                    ControlsMoving.Remove(control);
                    ControlsStopMoving.Remove(control);
                }
            };
            tmr.Start();
        }
    }
}