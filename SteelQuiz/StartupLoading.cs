﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.Animations;
using SteelQuiz.ThemeManager.Colors;

namespace SteelQuiz
{
    public partial class StartupLoading : AutoThemeableForm
    {
        public bool StopAnimation { get; set; } = false;
        public bool AnimationStopped { get; private set; } = false;
        public System.Timers.Timer AnimTimer { get; set; }
        private int animElapsed = 0;
        private GeneralTheme GeneralTheme = new GeneralTheme();
        private System.Timers.Timer tmr_notice = new System.Timers.Timer();

        public StartupLoading(string msg = null, string notice = null, int noticeDelay = -1)
        {
            InitializeComponent();
            SetTheme();
            if (msg != null)
            {
                lbl_msg.Text = msg;
            }
            if (notice != null)
            {
                lbl_notice.Text = notice;
                lbl_notice.Visible = true;
            }
            if (noticeDelay > -1)
            {
                lbl_notice.Visible = false;
                tmr_notice = new System.Timers.Timer()
                {
                    Interval = noticeDelay,
                    SynchronizingObject = this,
                    AutoReset = false
                };
                tmr_notice.Elapsed += delegate
                {
                    lbl_notice.Fade(BackColor, GeneralTheme.GetMainLabelForeColor(), 500);
                };
                tmr_notice.Start();
            }
        }

        private void AnimTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lbl_dot1.Location.X > Width)
            {
                animElapsed = 0;
                this.Invoke(new Action(() =>
                {
                    lbl_dot1.Location = new Point(-60, lbl_dot1.Location.Y);
                    lbl_dot2.Location = new Point(-38, lbl_dot2.Location.Y);
                    lbl_dot3.Location = new Point(-16, lbl_dot3.Location.Y);
                }));
            }

            this.Invoke(new Action(() =>
            {
                lbl_dot1.Location = new Point(lbl_dot1.Location.X + animElapsed / 9, lbl_dot1.Location.Y);
                lbl_dot2.Location = new Point(lbl_dot2.Location.X + animElapsed / 6, lbl_dot2.Location.Y);
                lbl_dot3.Location = new Point(lbl_dot3.Location.X + animElapsed / 3, lbl_dot3.Location.Y);
            }));

            ++animElapsed;
            if (!StopAnimation)
            {
                AnimTimer.Enabled = true;
            }
            else
            {
                AnimationStopped = true;
            }
        }

        private void StartupLoading_Shown(object sender, EventArgs e)
        {
            Activate();
            AnimTimer = new System.Timers.Timer()
            {
                Interval = 1,
                SynchronizingObject = this,
                AutoReset = false
            };
            AnimTimer.Elapsed += AnimTimer_Elapsed;
            AnimTimer.Start();
        }
    }
}
