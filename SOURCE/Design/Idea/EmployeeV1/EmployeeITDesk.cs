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

namespace Design.Idea.EmployeeInterface
{
    public partial class EmployeeITDesk : Menu
    {
        List<Classes.RentableItem> selectedItems = new List<Classes.RentableItem>();
        List<Classes.RentableItem> AllItems = Classes.Database.All<Classes.RentableItem>();
        RentableItem ren;

        public EmployeeITDesk()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            //panel1.MouseWheel += panel1_MouseWheel;
            int posX = 0;
            int posY = 0;
            
            foreach (RentableItem item in AllItems)
            {//item reference
                int y = 0;
                
                Panel box = new Panel();
                box.Left = posX;
                box.Top = posY;
                posX += 87;
                panel1.Controls.Add(box);
                box.BorderStyle = BorderStyle.Fixed3D;

                if (posX >= 348)
                {
                    posY += 100;
                    posX = 0;
                }
                
                Label name = new Label();
                name.Text = item.Brand + " " + item.Model;
                name.Top = y;
                y += name.Height;
                box.Controls.Add(name);

                Label price = new Label();
                price.Text = item.Price.ToString();
                price.Top = y;
                y += price.Height;
                box.Controls.Add(price);

                Label stock = new Label();
                stock.Text = "Quantity: " + item.InStock;
                stock.Top = y;
                y += stock.Height;
                box.Controls.Add(stock);

                Button rent = new Button();
                rent.Text = "Rent";
                rent.Top = y;
                box.Controls.Add(rent);
                box.Height = y+ rent.Height+5;
                box.Width = 84;
                rent.Click += (xx, yy) => 
                {
                    //item.InStock -= 1;
                    cartListView.Items.Add(item.Brand+ " " + item.Model + " rented at " + DateTime.Now + " until "+ date.Value + " for " + item.Price + " euros an hour");
                };
                //rent.Click += rent_Click;
            }
        }

        //void panel1_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    panel1.VerticalScroll.Value += e.Delta*200;
        //}

        void rent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yes");
        }



       

        
    }
}
