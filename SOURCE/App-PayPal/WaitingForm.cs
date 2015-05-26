using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_PayPal
{
    public partial class WaitingForm : App_Common.LoginForm
    {
        protected override bool OnLogin()
        {
            if (LoggedInUser is Classes.Visitor)
            {
                new ProcessingForm(this).Show();
                return true;
            }
            return false;
        }

        public WaitingForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
        }
    }
}
