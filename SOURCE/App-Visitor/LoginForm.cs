using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Visitor
{
    public partial class LoginForm : App_Common.LoginForm
    {
        public LoginForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
        }

        protected override bool OnLogin()
        {
            if (LoggedInVisitor == null) return false;
            new HomePage(this).Show();
            return true;
        }
    }
}
