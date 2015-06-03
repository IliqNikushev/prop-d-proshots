using System;
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
        public CampingLoginForm(App_Common.Menu parent)
            : base(parent)
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

            new CampingMenu(this).Show();
            return true;
        }
    }
}
