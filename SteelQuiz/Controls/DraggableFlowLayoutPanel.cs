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
        }

        private void DraggableFlowLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            Point? bottomControlPoint = null;
            foreach (var ctrl in Controls.OfType<Control>())
            {
                if (bottomControlPoint == null || ctrl.Location.Y > bottomControlPoint.Value.Y)
                {
                    bottomControlPoint = ctrl.Location;
                }
            }

            if (bottomControlPoint != null)
            {
                e.Control.Top = bottomControlPoint.Value.Y + Padding.Top;
            }
        }
    }
}
