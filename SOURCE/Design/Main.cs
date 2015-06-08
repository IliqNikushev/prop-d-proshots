using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class Main : Form
    {
        public Main()
        {
            //var qqq = Classes.Database.All<Classes.User>();
            //var qq = Classes.Database.All<Classes.Item>();
            //var q = Classes.Database.All<Classes.ShopItem>();
            InitializeComponent();
            IEnumerable<Type> notTableDefined = Classes.Database.notTableDefinedRecords;
            if(notTableDefined.Any())
                MessageBox.Show("Not table defined records:\n"+string.Join("\n", Classes.Database.notTableDefinedRecords));

            if(false)
            if(!Idea.Menu.IsInDebug)
                if (Classes.Database.CanConnect)
                {
                    Classes.Database.CheckConsistency();
                    if (Classes.Database.consistencyExceptions.Count > 0)
                        MessageBox.Show("Not all classes are implemented. Check consistency.txt for details");
                    Classes.Database.consistencyExceptions.Clear();
                }
        }

        private void adminGUIBtn_Click(object sender, EventArgs e)
        {
            new Idea.Login(Idea.Login.For.Admin).Show();
        }

        private void visitorGUIBtn_Click(object sender, EventArgs e)
        {
            new Idea.Login(Idea.Login.For.Visitor).Show();
        }

        private void employeeGUIBtn_Click(object sender, EventArgs e)
        {
           new Idea.Login(Idea.Login.For.Employee).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //new Idea.Store().Show();
            //new Idea.EmployeeInterface.EmployeeITDesk().Show();
            new Idea.EmployeeV1.EmployeesPCDoc().Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://athena.fhict.nl/webdir/i317294/Prop/img/Back.png";
        }
    }
}
