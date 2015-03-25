﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.VisitorInterface
{
    public partial class Home : LandingBase
    {
        public Home(Form parent) : base(parent)
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Bookings(this).Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Purchases(this).Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Appointments(this).Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new Rent(this).Show();
        }
    }
}