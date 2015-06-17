using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Design.Idea.AdministratorInterface
{
    public partial class Home : HomePageWithMap
    {
        public Home() : base() 
        { 
            InitializeComponent();
            object r = Database.ExecuteScalar("select (COALESCE(({0}),0))+(COALESCE(({1}),0))+(COALESCE(({2}),0)) as sum from dual;",
                                                             "Select sum(amount) from " + Database.TableName<Deposit>().Name,
                                                             "SELECT sum(totalamount) from " + Database.TableName<ReceiptItem>().Name,
                                                             "SELECT sum(price) FROM "+ Database.TableName<AppointmentTask>().Name
                                                             );

            decimal amount = (decimal) r;
            string totalVisitor = Convert.ToString(Database.Visitors.Count);
            string logedin= Convert.ToString(Database.Visitors.Where(x=>x.))
            labeltotalVisitor.Text = "Total Visitors: "+totalVisitor;
            int warn= Database.Warning.Count;
            labelWarning.Text +=  " " + warn;
            labelMoney.Text = "Total: "+amount;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new SubMenu.Shops().Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Calendar(this).Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            new Camping(this).Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new ServiceDesk(this).Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new Visitors(this).Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new PcDoctor(this).Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new Employees(this).Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}