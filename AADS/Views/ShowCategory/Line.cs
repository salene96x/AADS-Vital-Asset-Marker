﻿using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADS.Views.ShowCategory
{
    public partial class Line : UserControl
    {
        private mainForm main = mainForm.GetInstance();
        public Line()
        {
            InitializeComponent();

        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            if (!main.isOnRouteFuncClicked)
            {
                main.isOnRouteFuncClicked = true;
            }
            else
            {
                main.isOnRouteFuncClicked = false;
            }
            
        }

    }
}
