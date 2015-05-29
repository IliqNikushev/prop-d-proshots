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
    public partial class LoginForm : Menu
    {
        public LoginForm() : this(null) { }
        public LoginForm(Menu parent) : base(parent)
        {
            InitializeComponent();

            if(!IsInDebug)
                if (reader.IsAttached)
                {
                    infoLbl.Text += " Or approach your card";
                    reader.OnDetect += Authenticate;
                }
        }

        protected virtual bool OnLogin() { throw new System.InvalidOperationException("Not implemented btn"); }

        private bool HandleLogin()
        {
            if (!Classes.Database.CanConnect)
            {
                MessageBox.Show("Unable to connect to database");
                return false;
            }
            if (LoggedInUser == null)
            {
                MessageBox.Show("Invalid credentials");
                return false;
            }
            
            return OnLogin();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = idTbox.Text;
            string password = passwordTbox.Text;

            Authenticate(username, password);
        }

        private void Authenticate(string id)
        {
            Authenticate(Classes.User.Authenticate(id));
        }

        private void Authenticate(string name, string password)
        {
            Authenticate(Classes.User.Authenticate(name, password));
        }

        protected void Authenticate(Classes.User user)
        {
            LoggedInUser = user;
            this.Invoke(new Action(
                () => 
                    {
                        if (HandleLogin())
                        {
                            if (reader != null)
                                reader.OnDetect -= Authenticate;
                            this.idTbox.Text = "username";
                            this.passwordTbox.Text = "";
                        }
                    }));
        }
    }
}
