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
                label1.Text += " OR Approach your card to the reader \n";
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
                //UNCOMMENT WHEN USING DATABASE return;
            }
            string username = "";
            string password = "";
            //UNCOMMENT WHEN USING DATABASE Authenticate(username, password);
            //if(LoggedInUser == null)
            //{ //if valid sql invalid credentials; else - invalid sql message already logged 
            if (forWho == For.Admin)
                new AdministratorInterface.Home().Show();
            else if (forWho == For.Employee)
                new EmployeeInterface.Home().Show();
            else if (forWho == For.Visitor)
                new VisitorInterface.Home().Show();
        }
    }
}
