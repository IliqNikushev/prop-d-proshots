﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Camps
{
    public partial class CampingLoginForm : App_Common.LoginForm
    {
        public CampingLoginForm()
        {
            InitializeComponent();
        }

        protected override bool OnLogin()
        {
            if (!(LoggedInUser is Classes.Visitor))
            {
                MessageBox.Show("You are not a visitor");
                return false;
            }

            List<Classes.Tent> bookedTents = Classes.Database.GetVisitorBookedTent(LoggedInUser as Classes.Visitor);
            bookedTents.AddRange(Classes.Database.GetVisitorTent(LoggedInUser as Classes.Visitor));

            new CampingMenu(bookedTents).Show(this);
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CampingMenu(new List<Classes.Tent>()).Show(this);
        }
    }
}
