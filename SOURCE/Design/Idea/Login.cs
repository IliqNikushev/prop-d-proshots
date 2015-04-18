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
    public partial class Login : Form
    {
        private For forWho;
        public enum For { Admin, Visitor, Employee }
        public Login(For forWho)
        {
            this.forWho = forWho;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (forWho == For.Admin)
                new AdministratorInterface.Home(this).Show();
            else if (forWho == For.Employee)
                new EmployeeInterface.Home(this).Show();
            else if (forWho == For.Visitor)
                new VisitorInterface.Home(this).Show();
            this.Hide();
        }
    }
}
