﻿using System;
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

        private RentableItemHistory lastSelectedRentedItem;
        private RentableItemHistory currentSelectedRentedItem { get { return this.cartListView.SelectedItem as RentableItemHistory; } }

        Visitor activeVis;

        public decimal Totalprice
        {
            get
            {
                decimal sum = 0;
                foreach (var i in lbCart.Items)
                {
                    RentableItem item = i as RentableItem;
                    TimeSpan differene = date.Value.AddDays(1) - DateTime.Now;
                    sum += item.Price * decimal.Round((decimal)differene.TotalHours,0);
                }
                sum = Decimal.Round(sum, 2);
                return sum;
            }
        }

        public RentForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
            if (date.MinDate < DateTime.Today) date.MinDate = DateTime.Today;
            btnConfirm.Click += (x, y) => BlockExceptions();

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
                price.Text = (item.Price.ToString()) + " € per hour";
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
                    if (item.InStock - c <= 0) return;
                    c += 1;
                    stock.Text = "Quantity: " + (item.InStock - c).ToString();
                    lbCart.Items.Add(item);
                    lbPrice.Text = Totalprice + App_Common.Constants.Currency;
                };

                btnReturnItem.Click += (x, yy) =>
                {
                    if (lastSelectedRentedItem == null) return;
                    if (activeVis == null) return;
                    if (lastSelectedRentedItem.RentedItem != item) return;
                    c -= 1;
                    stock.Text = "Quantity: " + (item.InStock - c).ToString();
                };

                btnReturn.Click += (x, yy) =>
                {
                    if (item != lbCart.SelectedItem as RentableItem)
                        return;
                    c -= 1;
                    lbCart.Items.RemoveAt(lbCart.SelectedIndex);
                    stock.Text = "Quantity: " + (item.InStock - c).ToString();
                    lbPrice.Text = Totalprice + App_Common.Constants.Currency;
                };

                btnConfirm.Click += (x, yy) =>
                {
                    if (activeVis == null) return;
                    if (activeVis.Balance < Totalprice) return;
                    
                    while (lbCart.Items.Contains(item))
                    {
                        RentableItemHistory h = new RentableItemHistory(item, activeVis, "", date.Value.AddDays(1)).Create() as RentableItemHistory;
                        cartListView.Items.Add(h);
                        Database.ExecuteSQL("UPDATE `rentableitems` SET InStock = {0} WHERE Item_ID = {1}", item.InStock - c, item.ID);
                        lbCart.Items.Remove(item);
                    }
                };

                if (!IsInDebug)
                {
                    reader.Dispose();
                    reader = new RFID();
                    reader.OnDetect += rf_OnDetect;
                }
            }

            btnConfirm.Click += (x, y) => UnBlockExceptions();
            btnConfirm.Click += (x, y) =>
                {
                    if (activeVis == null) return;
                    if (Totalprice == 0) return;
                    if (activeVis.Balance < Totalprice)
                    {
                        MessageBox.Show("Visitor does not have enough funds ({0}{1} more needed)".Args(Totalprice - activeVis.Balance, Constants.Currency));
                        return;
                    }
                    activeVis.ChangeBalanceWith(-Totalprice, "rent " + DateTime.Now);
                };
        }

        void rf_OnDetect(string tag)
        {
            activeVis = Visitor.Authenticate(tag);
            MainMenu.Invoke(new Action(
            () =>
            {
                cartListView.Items.Clear();
                tbID.Text = tag;
                tbFullname.Text = activeVis.FullName;
                picVis.ImageLocation = activeVis.Picture;
                foreach (var item in activeVis.RentedItems)
                {
                    if (item.IsReturned) continue;
                    cartListView.Items.Add(item);
                }
            }));
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (activeVis == null)
            {
                MessageBox.Show("No active visitors found! Please approach the card.");
            }
            if (lbCart.Items.Count == 0)
            {
                MessageBox.Show("No items to rent selected");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
        }

        private void cartListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cartListView.SelectedItem == null)
                btnReturnItem.Enabled = false;
            else
                btnReturnItem.Enabled = true;
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            if (currentSelectedRentedItem == null) return;
            if (activeVis == null)
            {
                MessageBox.Show("No active visitors found! Please approach the card.");
                return;
            }
            currentSelectedRentedItem.Return(activeVis);
            if (Database.HadAnError)
                return;
            MessageBox.Show("Item successfully returned");
            lastSelectedRentedItem = currentSelectedRentedItem;
            this.cartListView.Items.Remove(currentSelectedRentedItem);
        }

        private void lbCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCart.SelectedItem == null)
                btnReturn.Enabled = false;
            else
                btnReturn.Enabled = true;
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            lbPrice.Text = Totalprice + App_Common.Constants.Currency;
        }
    }
}