﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void adminGUIBtn_Click(object sender, EventArgs e)
        {
            new Idea.Login(Idea.Login.For.Admin).Show();
        }

        private void visitorGUIBtn_Click(object sender, EventArgs e)
        {
            new Idea.Login(Idea.Login.For.Visitor).Show();
        }

        private void employeeGUIBtn_Click(object sender, EventArgs e)
        {
            new Idea.Login(Idea.Login.For.Employee).Show();
        }
    }
}
