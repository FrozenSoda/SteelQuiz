using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Preferences
{
    public class PrefCategory_old : Panel
    {
        private bool _selected = false;
        public bool Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                if (value)
                {
                    this.TextLabel.BackColor = ThemeManager.GetPreferenceSelectedBackColor();
                    this.SelectedIndicator.Visible = true;
                }
                else
                {
                    this.TextLabel.BackColor = ThemeManager.GetPreferenceBackColor();
                    this.SelectedIndicator.Visible = false;
                }
                _selected = value;
            }
        }

        private Label SelectedIndicator;
        private Label TextLabel;

        public PrefCategory_old() : base()
        {
            this.SelectedIndicator = new Label();
            this.SelectedIndicator.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.SelectedIndicator.Dock = DockStyle.Left;
            this.SelectedIndicator.Location = new System.Drawing.Point(0, 0);
            this.SelectedIndicator.Name = "lbl_prefIndicator";
            this.SelectedIndicator.Size = new System.Drawing.Size(8, 29);
            this.SelectedIndicator.TabIndex = 0;

            this.TextLabel = new Label();
            this.TextLabel.BackColor = ThemeManager.GetPreferenceBackColor();
            this.TextLabel.ForeColor = System.Drawing.Color.White;
            this.TextLabel.Location = new System.Drawing.Point(8, 0);
            this.TextLabel.Name = "lbl_prefText";
            this.TextLabel.Size = new System.Drawing.Size(122, 29);
            this.TextLabel.TabIndex = 1;
            this.TextLabel.Text = "User Interface";
            this.TextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.Controls.Add(this.SelectedIndicator);
            this.Controls.Add(this.TextLabel);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);


        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);


        }
    }
}
