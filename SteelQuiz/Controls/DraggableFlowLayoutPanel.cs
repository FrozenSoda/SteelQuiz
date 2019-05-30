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
