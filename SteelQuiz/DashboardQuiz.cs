﻿using System;
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
    public partial class DashboardQuiz : UserControl
    {
        public Guid QuizGuid { get; private set; }

        public DashboardQuiz()
        {
            InitializeComponent();
        }
    }
}
