﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace App_Employee
{
    public class StoreItem
    {
        public static string Currency { get { return App_Common.Constants.Currency; } }

        public string Icon
        {
            get
            {
#warning todo real address
                if (!Item.Icon.StartsWith("http"))
                    return "http://<ADDRESS AT ATHENA>/" + Item.Icon;
                return Item.Icon;
            }
        }

        public Panel PanelAssosiated;
        public Label InStockLabel;
        public TextBox PurchaseTimesTBox;
        public Label PriceLabel;
        public Label TotalLabel;
        public Label NameLabel;

        public Classes.ShopItem Item { get; private set; }
        public int PurchaseTimes { get; private set; }

        public string Name { get { if (Item.Brand == "" || Item.Brand == null) return Item.Model; return Item.Brand + " " + Item.Model; } }
        public int InStock { get { return Item.InStock; } }

        public decimal Price { get { return Item.Price; } }
        public int WarningLevel { get { return Item.WarningLevel; } }
        public decimal Total { get { return this.Price * this.PurchaseTimes; } }

        public StoreItem(Classes.ShopItem item)
        {
            this.Item = item;
        }

        public void Update(int times)
        {
            int current = PurchaseTimes + times;
            if (current < 0) current = 0;
            if (current > InStock) current = InStock; // WARN THAT THERE IS NOT ENOUGH

            this.PurchaseTimes = current;
            TotalLabel.Text = (((int)(Price * 100 * PurchaseTimes) / 100.0f)).ToString() + Currency;
            PurchaseTimesTBox.Text = this.PurchaseTimes.ToString();

            int resultAfterPurchase = this.InStock - this.PurchaseTimes;

            if (resultAfterPurchase <= this.WarningLevel)
            {
                float deltaPercent = 0;
                if (this.WarningLevel != 0)
                    deltaPercent = resultAfterPurchase / (float)this.WarningLevel;
                this.PanelAssosiated.BackColor = Color.FromArgb(220, (int)(180 * deltaPercent), 0);
            }
            else
            {
                if (PurchaseTimes == 0)
                    this.PanelAssosiated.BackColor = new Color();
                else
                    this.PanelAssosiated.BackColor = Color.FromArgb(220, 220, 200);
            }
        }

        public void UpdateTo(int times)
        {
            this.Update(times - PurchaseTimes);
        }

        public void Reset()
        {
            this.InStockLabel.Text = this.InStock.ToString();
            this.PurchaseTimes = 0;
            this.PurchaseTimesTBox.Text = "0";
            this.TotalLabel.Text = "0" + Currency;
        }
    }
}