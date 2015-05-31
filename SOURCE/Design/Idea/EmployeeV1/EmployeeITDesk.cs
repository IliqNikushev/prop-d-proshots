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
        List<RentableItem> removedItems = new List<RentableItem>();
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
                int c = 0;
                rent.Click += (xx, yy) =>
                {
                    c += 1;
                    stock.Text = (item.InStock - c).ToString();
                    //currentStock = Convert.ToInt32(stock.Text);
                    selectedItems.Add(item);
                    listBox1.Items.Add(item);
                };
                button2.Click += (x, yy) =>
                    {
                        if (item != listBox1.SelectedItem as RentableItem)
                        return;
                        c -= 1;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        stock.Text = (item.InStock - c).ToString();
                        //currentStock=Convert.ToInt32(stock.Text);
                        
                    };
                button5.Click += (x, yy) =>
                    {
                        if (!selectedItems.Contains(item)) 
                            return;
                        cartListView.Items.Add(item.Brand + " " + item.Model + " rented at " + DateTime.Now + " until " + date.Value + " for " + item.Price + " euros an hour");
                        Database.ExecuteSQL("UPDATE `rentableitems` SET InStock = {0} WHERE Item_ID = {1}", item.InStock-c, item.ID);  
                    };
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
              
        }

        



       

        
    }
}
