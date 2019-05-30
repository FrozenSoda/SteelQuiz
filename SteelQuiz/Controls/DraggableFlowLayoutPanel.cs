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
            
        }

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
                if (dY > 0)
                {
                    control.Top = closestControl.Bottom + Padding.Top;
                }
                else
                {
                    control.Top = -control.Size.Height + closestControl.Top - Padding.Bottom;
                }
            }
        }
    }
}
