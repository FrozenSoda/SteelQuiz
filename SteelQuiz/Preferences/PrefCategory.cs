using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager;

namespace SteelQuiz
{
    public partial class PrefCategory : UserControl
    {
        public event EventHandler OnPrefSelected;

        private bool _selected = false;
        public bool Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                if (value == _selected)
                {
                    // selection is already set
                    return;
                }

                // update color
                if (value)
                {
                    this.lbl_text.BackColor = ThemeCore.GetPreferenceSelectedBackColor();
                    this.lbl_selectedIndicator.BackColor = Color.FromArgb(255, 128, 0);

                    if (Parent != null)
                    {
                        // deselect other categories
                        foreach (var cat in Parent.Controls.OfType<PrefCategory>())
                        {
                            if (cat != this)
                            {
                                cat.Selected = false;
                            }
                        }
                    }

                    this.OnPrefSelected?.Invoke(this, null);
                }
                else
                {
                    this.lbl_text.BackColor = ThemeCore.GetPreferenceBackColor();
                    this.lbl_selectedIndicator.BackColor = ThemeCore.GetPreferenceBackColor();
                }

                _selected = value;
            }
        }

        public string PrefText
        {
            get
            {
                return this.lbl_text.Text;
            }

            set
            {
                this.lbl_text.Text = value;
            }
        }

        public PrefCategory()
        {
            InitializeComponent();
        }

        private void StartHover()
        {
            if (Selected)
            {
                this.lbl_text.BackColor = ThemeCore.GetPreferenceSelectedHoverBackColor();
            }
            else
            {
                this.lbl_text.BackColor = ThemeCore.GetPreferenceHoverBackColor();
                this.lbl_selectedIndicator.BackColor = ThemeCore.GetPreferenceHoverBackColor();
            }
        }

        private void StopHover()
        {
            if (Selected)
            {
                this.lbl_text.BackColor = ThemeCore.GetPreferenceSelectedBackColor();
            }
            else
            {
                this.lbl_text.BackColor = ThemeCore.GetPreferenceBackColor();
                this.lbl_selectedIndicator.BackColor = ThemeCore.GetPreferenceBackColor();
            }
        }

        private void Lbl_text_MouseEnter(object sender, EventArgs e)
        {
            StartHover();
        }

        private void Lbl_text_MouseLeave(object sender, EventArgs e)
        {
            StopHover();
        }

        private void Lbl_selectedIndicator_MouseEnter(object sender, EventArgs e)
        {
            StartHover();
        }

        private void Lbl_selectedIndicator_MouseLeave(object sender, EventArgs e)
        {
            StopHover();
        }

        private void Lbl_text_Click(object sender, EventArgs e)
        {
            Selected = true;
        }

        private void Lbl_selectedIndicator_Click(object sender, EventArgs e)
        {
            Selected = true;
        }
    }
}
