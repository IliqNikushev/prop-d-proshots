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

namespace Design.Idea.AdministratorInterface.SubMenu
{
    public partial class Shops : HomePageWithMap
    {
        public Shops()
        {
            InitializeComponent();
             object r1 = Database.ExecuteScalar("Select Sum(Price*Quantity) from Shopitems Group by Shop_id having Shop_id= 1");
             labelShop1.Text = "Profit: " + r1.ToString() + " €";
             object r2 = Database.ExecuteScalar("Select Sum(Price*Quantity) from Shopitems Group by Shop_id having Shop_id= 2");
             labelShop2.Text = "Profit: " + r2.ToString() + " €";
             object r3 = Database.ExecuteScalar("Select Sum(Price*Quantity) from Shopitems Group by Shop_id having Shop_id= 3");
             labelShop3.Text = "Profit: " + r3.ToString() + " €";
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
            //new ShopSubMenu(this).Show();
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

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            new ShopInformation(Classes.Database.Find<Classes.ShopWorkplace>("Shops.id = 1")).Show();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            new ShopInformation(Classes.Database.Find<Classes.ShopWorkplace>("Shops.id = 2")).Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            new ShopInformation(Classes.Database.Find<Classes.ShopWorkplace>("Shops.id = 3")).Show();
        }
    }
}