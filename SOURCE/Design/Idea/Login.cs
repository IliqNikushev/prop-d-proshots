using System;
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
    public partial class Login : Menu
    {
        private For forWho;
        public enum For { Admin, Visitor, Employee }
        public Login(For forWho)
        {
            this.forWho = forWho;
            InitializeComponent();
            if (!Classes.Database.CanConnect)
                MessageBox.Show("Unable to connect to database");
            if (forWho == For.Visitor)
                if (reader.IsAttached)
                {
                    label1.Text += " OR Approach your card to the reader \n";
                    reader.OnDetect += Authenticate;
                }
        }

        private void Authenticate(string id)
        {
            Authenticate(Classes.User.Authenticate(id));
        }

        private void Authenticate(string name, string password)
        {
            Authenticate(Classes.User.Authenticate(name, password));
        }

        private void Authenticate(Classes.User user)
        {
            if (!Classes.Database.CanConnect)
            {
                MessageBox.Show("Unable to connect to database");
                //uncomment when we have real users to authenticate
                //return;
            }
            LoggedInUser = user;
            this.Invoke(new Action(ProccessLogin));
        }

        private void ProccessLogin()
        {
            if (LoggedInUser == null)
            {
                MessageBox.Show("Invalid credentials");
                //uncomment when we have real users to authenticate
                //return;
            }
            reader.OnDetect -= Authenticate;
            if (forWho == For.Admin)
                new AdministratorInterface.Home().Show();
            else if (forWho == For.Employee)
                new EmployeeInterface.Home().Show();
            else if (forWho == For.Visitor)
                new VisitorInterface.Home().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Authenticate(username, password);
        }
    }
}
