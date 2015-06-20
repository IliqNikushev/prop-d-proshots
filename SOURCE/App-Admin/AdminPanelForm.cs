using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Admin
{
    public partial class AdminPanelForm : App_Common.LoginForm
    {
        public AdminPanelForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
            
            this.ControlBox = true;
        }

        protected override bool OnLogin()
        {
            if (LoggedInUser.GetType() !=  typeof(Classes.AdminUser)) return false;
            new Home(this).Show();
            return true;
        }
    }
}
