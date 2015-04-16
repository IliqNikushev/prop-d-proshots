using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.AdministratorInterface
{
    public partial class Landing : LandingBase
    {
        private Pointable[] examples = new Pointable[]{
            new ShopExample(0,0,"KFC", "Fried chicken"),
            new ShopExample(100,100,"MC Donalds", "Fast Food"),
            new ShopExample(200,200,"Doctor", "Fast and Easy doctor repairs")
        };

        private int mapX = 0, mapY = 0;
        float zoom = 1;
        float wantedZoom = 1;
        public Landing(Form parent) : base(parent)
        {
            InitializeComponent();
            mapX = mapArea.Left;
            mapY = mapArea.Top;

            mapArea.Image = Properties.Resources.Park_English;
            
            foreach (Pointable pointable in examples)
            {
                pointable.AddToMap(mapArea);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void ChangeZoom(float amount)
        {
            if (wantedZoom + amount <= 0) return;
            //example : change from 1.1 to 1.2
            float target = wantedZoom + amount; //1.2
            float current = zoom; // 1.1
            float difference = target / current; // 1.1 * ? = 1.2

            zoom *= difference;
            wantedZoom += amount;

            mapArea.Scale(new SizeF(difference, difference));
            
            mapArea.Left = mapX;
            mapArea.Top = mapY;
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
            new ShopSubMenu(this).Show();
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
            ChangeZoom(0.1f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeZoom(-0.1f);
        }
    }
}
