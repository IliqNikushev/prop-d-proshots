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

namespace App_Employee
{
    public partial class RentForm : App_Common.Menu
    {
        
        List<Classes.RentableItem> selectedItems = new List<Classes.RentableItem>();
        List<Classes.RentableItem> AllItems = Classes.Database.All<Classes.RentableItem>();
        List<RentableItem> removedItems = new List<RentableItem>();
        Visitor activeVis;
        public decimal Totalprice
        {
            get
            {
                decimal sum = 0;
                foreach(var item in selectedItems)
                {
                    TimeSpan differene = date.Value - DateTime.Now;
                    sum += item.Price*Convert.ToDecimal(differene.TotalHours);
                }
                sum = Decimal.Round(sum, 2);
                return sum;
            }
        }
        public RentForm(App_Common.Menu parent)
            : base(parent)
        {
            
            InitializeComponent();
            
            plItems.AutoScroll = true;
            int posX = 0;
            int posY = 0;
            foreach (RentableItem item in AllItems)
            {//item reference
                int y = 0;

                Panel box = new Panel();
                box.BackColor = System.Drawing.Color.Azure;
                box.Left = posX;
                box.Top = posY;
                posX += 87;
                plItems.Controls.Add(box);
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
                rent.FlatStyle = FlatStyle.Flat;
                rent.Text = "Rent";
                rent.Top = y;
                box.Controls.Add(rent);
                box.Height = y + rent.Height + 5;
                box.Width = 84;
                int c = 0;
                rent.Click += (xx, yy) =>
                {
                    c += 1;
                    stock.Text = (item.InStock - c).ToString();
                    selectedItems.Add(item);
                    lbCart.Items.Add(item);
                    lbPrice.Text = Totalprice + App_Common.Constants.Currency;
                };
                btnReturn.Click += (x, yy) =>
                    {
                        if (item != lbCart.SelectedItem as RentableItem)
                            return;
                        c -= 1;
                        lbCart.Items.Remove(lbCart.SelectedItem);
                        stock.Text = (item.InStock - c).ToString();
                        lbPrice.Text = Totalprice + App_Common.Constants.Currency;
                    };
                btnConfirm.Click += (x, yy) =>
                    {
                        if (activeVis == null) return;
                        if (!selectedItems.Contains(item))
                            return;
                        while (lbCart.Items.Contains(item))
                        {
                            cartListView.Items.Add(new RentableItemHistory(item,activeVis,""));
                            lbCart.Items.Remove(item);
                        }
                        new RentableItemHistory(item, activeVis, "").Create();
                        Database.ExecuteSQL("UPDATE `rentableitems` SET InStock = {0} WHERE Item_ID = {1}", item.InStock - c, item.ID);
                    };
                if (!IsInDebug)
                {
                    reader.Dispose();
                    reader = new RFID();
                    reader.OnDetect += rf_OnDetect;
                }
            }
        }
        void rf_OnDetect(string tag)
        {
            activeVis = Visitor.Authenticate(tag);
            this.Invoke(new Action(
                () =>
                {

                    cartListView.Items.Clear();
                    tbID.Text = tag;
                    tbFullname.Text = activeVis.FullName;
                    foreach(var item in activeVis.RentedItems)
                    {
                        cartListView.Items.Add(item); 
                    }
                }));
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if(activeVis==null)
            {
                MessageBox.Show("No active visitors found! Please approach the card.");
            }
        }
    }
}
