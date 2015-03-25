﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea
{
    public partial class LandingBase : Form
    {
        public LandingBase() { InitializeComponent(); }
        public LandingBase(Form parent)
        {
            if (parent == null) throw new ArgumentNullException("Parent of " + this.GetType() + " cannot be null!");
            this.FormClosed += (x, y) => parent.Close();
            InitializeComponent();
        }
    }
}