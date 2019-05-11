using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz
{
    public partial class PrefCategory : UserControl
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
                    this.lbl_text.BackColor = ThemeManager.GetPreferenceSelectedBackColor();
                    this.lbl_selectedIndicator.BackColor = Color.FromArgb(255, 128, 0);
                }
                else
                {
                    this.lbl_text.BackColor = ThemeManager.GetPreferenceBackColor();
                    this.lbl_selectedIndicator.BackColor = ThemeManager.GetPreferenceBackColor();
                }
                _selected = value;
            }
        }

        public PrefCategory()
        {
            InitializeComponent();
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
