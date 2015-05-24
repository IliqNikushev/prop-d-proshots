using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Common
{
    public partial class LoginForm : Form
    {
        protected virtual void OnLogin() { throw new System.InvalidOperationException("Not implemented btn"); }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            OnLogin();
        }
    }
}
