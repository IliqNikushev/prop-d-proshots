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

namespace App_Admin
{
    public partial class Home : App_Common.HomePageWithMap
    {
        public Home(App_Common.Menu parent) : base(parent) 
        {
            Fix();
            InitializeComponent();
            Unfix();
            object r = Database.ExecuteScalar("select (COALESCE(({0}),0))+(COALESCE(({1}),0))+(COALESCE(({2}),0)) as sum from dual;",
                                                             "Select sum(amount) from " + Database.TableFor<Deposit>().Name,
                                                             "SELECT sum(totalamount) from " + Database.TableFor<ReceiptItem>().Name,
                                                             "SELECT sum(price) FROM "+ Database.TableFor<AppointmentTask>().Name
                                                             );

            decimal amount = (decimal) r;
            string totalVisitor = Convert.ToString(Database.Visitors.Count);
            //string logedin= Convert.ToString(Database.Visitors.Where(x=>x.log));
            object VisitorInEvent = Database.ExecuteScalar("Select Count(*) from Visitors Where IsInTheEvent= 1" );
            labelLogedInVisitor.Text = "In event: " + VisitorInEvent.ToString();
            labeltotalVisitor.Text = "Total Visitors: "+totalVisitor;
            int warn= Database.Warning.Count;
            labelWarning.Text +=  " " + warn;
            labelMoney.Text = "Total: " + amount + " €";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new Warnings().Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack0_Click(object sender, EventArgs e)
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
            new SubMenu.Shops(this).Show();
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

        private void btnBack_Click_1(object sender, EventArgs e)
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

        private void btnBack1_Click(object sender, EventArgs e)
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