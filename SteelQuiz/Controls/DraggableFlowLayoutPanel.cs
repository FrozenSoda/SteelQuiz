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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Controls
{
    public class DraggableFlowLayoutPanel : Panel
    {
        /// <summary>
        /// A panel that automatically orders the controls, which you can drag around to reorder. Only supports up-to-down ordering
        /// </summary>
        public DraggableFlowLayoutPanel() : base()
        {
            ControlAdded += DraggableFlowLayoutPanel_ControlAdded;
            ControlRemoved += DraggableFlowLayoutPanel_ControlRemoved;
        }

        private void DraggableFlowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            Control bottomControl = null;
            foreach (var ctrl in Controls.OfType<Control>().Where(x => x != e.Control))
            {
                if (bottomControl == null || ctrl.Bottom > bottomControl.Bottom)
                {
                    bottomControl = ctrl;
                }
            }

            if (bottomControl != null)
            {
                e.Control.Top = bottomControl.Bottom + Padding.Top;
            }
        }

        private void DraggableFlowLayoutPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            AlignAll();
        }

        /// <summary>
        /// Returns the closest control to a control
        /// </summary>
        /// <param name="control">The control (being dragged)</param>
        /// <returns></returns>
        private Control ClosestControl(Control control)
        {
            Control closestControl = null;
            foreach (var ctrl in Controls.OfType<Control>().Where(x => x != control))
            {
                if (closestControl == null || Math.Abs(ctrl.Location.Y - control.Location.Y) < Math.Abs(closestControl.Location.Y - control.Location.Y))
                {
                    closestControl = ctrl;
                }
            }

            return closestControl;
        }

        /// <summary>
        /// Alligns a dragged control in the panel
        /// </summary>
        /// <param name="control">The control being dragged</param>
        public void Align(Control control)
        {
            var closestControl = ClosestControl(control);

            if (closestControl == null)
            {
                control.Location = new Point(Padding.Left, Padding.Top);
            }
            else
            {
                control.Left = Padding.Left;

                int dY = control.Top - closestControl.Top;
                if (dY > 1)
                {
                    control.Top = closestControl.Bottom + Padding.Top;
                }
                else
                {
                    control.Top = -control.Size.Height + closestControl.Top - Padding.Bottom;
                }
            }

            AlignAll();
        }

        /// <summary>
        /// Aligns all the controls in the panel
        /// </summary>
        /// <param name="draggedControl">The control being dragged, if being dragged</param>
        public void AlignAll(Control draggedControl = null)
        {
            List<Control> controlsAligned = Controls.Cast<Control>().OrderBy(x => x.Location.Y).ToList();

            // the dragged control should be put first if it has the same Y-position as another control
#warning NOT IMPLEMENTED FEATURE

            controlsAligned[0].Location = new Point(Padding.Left, Padding.Top);
            for (int i = 1; i < controlsAligned.Count; ++i)
            {
                if (controlsAligned[i] != draggedControl)
                {
                    controlsAligned[i].Top = controlsAligned[i - 1].Bottom + Padding.Top;
                }
            }
        }
    }
}
