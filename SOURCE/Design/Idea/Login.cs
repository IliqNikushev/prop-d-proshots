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

            // for who is visitor -> show the 'show your identificator'
        }

        private void Authenticate(string id)
        {
            LoggedInUser = Classes.User.Authenticate(id);
        }

        private void Authenticate(string name, string password)
        {
            LoggedInUser = Classes.User.Authenticate(name, password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Classes.Database.CanConnect)
            {
                MessageBox.Show("Unable to connect to database");
                return;
            }
            string username = "";
            string password = "";
            Authenticate(username, password);
            if (forWho == For.Admin)
                new AdministratorInterface.Home().Show();
            else if (forWho == For.Employee)
                new EmployeeInterface.Home().Show();
            else if (forWho == For.Visitor)
                new VisitorInterface.Home().Show();
        }
    }
}
