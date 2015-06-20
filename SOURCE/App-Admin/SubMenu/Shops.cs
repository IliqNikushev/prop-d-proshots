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

namespace App_Admin.SubMenu
{
    public partial class Shops : App_Common.HomePageWithMap
    {
        public Shops(App_Common.Menu parent) : base(parent)
        {
            Fix();
            InitializeComponent();
            Unfix();
             
             int xC = 0;
             int yC = 0;
             int countShops = 0;
             Panel panel = new Panel();
             panel.Left = 22;
             panel.Top = 177;
             panel.Width = 300;
             panel.Height = 450;
             panel.AutoScroll = true;
             this.Controls.Add(panel);
             

                 foreach (var item in Database.Shops)
                 {
                     
                     countShops++;
                     PictureBox p = new PictureBox();
                     p.ImageLocation = item.Icon;
                     panel.Controls.Add(p);
                     p.SizeMode = PictureBoxSizeMode.StretchImage;
                     p.Width = 128;
                     p.Height = 128;
                     p.Left = xC;
                     p.Top = yC;
                     ShopWorkplace shop = item;
                     p.Click += (x, y) => new ShopInformation(shop, this).Show();
                     object rr = Database.ExecuteScalar("SELECT sum(TotalAmount) FROM `receiptitems` WHERE item_id in(select id from ShopItems where shopitems.shop_id= {0});", item.ID);
                     if (rr==null)
                     {
                         rr = 0;
                     }
                     Label l = new Label();
                     l.Left = xC;
                     l.Top = yC + 128;
                     l.Text = item.Label;
                     panel.Controls.Add(l);
                     Label prof = new Label();
                     prof.Left = xC;
                     prof.Top =yC+ 138 + l.Height;
                     prof.Text = "Profit: " + rr.ToString()+Constants.Currency;
                     panel.Controls.Add(prof);
                     xC += 150;
                     if (countShops % 2 == 0)
                     {
                         yC += 200;
                         xC = 0;
                     }

                 }
             PictureBox q = new PictureBox();
             q.Image = Properties.Resources.KFC;
             panel.Controls.Add(q);
             q.SizeMode = PictureBoxSizeMode.StretchImage;
             q.Width = 128;
             q.Height = 128;
             q.Left = xC;
             q.Top = yC;
             q.Parent = null;

        }

        private void btnBack_Click(object sender, EventArgs e)
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

        private void btnBack_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            //new ShopInformation(Classes.Database.Find<Classes.ShopWorkplace>("|T|.id = 41"), this).Show();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            //new ShopInformation(Classes.Database.Find<Classes.ShopWorkplace>("|T|.id = 41"), this).Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            //new ShopInformation(Classes.Database.Find<Classes.ShopWorkplace>("|T|.id = 43"), this).Show();
        }
    }
}