﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea
{
    public partial class Store : Form
    {
        public Classes.ShopJob Shop { get; private set; }
        public Classes.Visitor ActiveVisitor { get; private set; }

        private const int iconSize = 64;
        private const int labelHeight = 16;
        private const int itemHeight = iconSize + labelHeight * 5;

        private static char currency { get { return ShopItem.currency; } }
        
        private List<ShopItem> items = new List<ShopItem>();
        private bool adding = true;

        public Store()
        {
            Random r = new Random();
            for (int i = 0; i < 30; i++)
            {
                items.Add(new ShopItem(new Classes.ShopItem(0, r.Next(5000) / 1000m, "", "Back","<>","","", i+1, (i+1)/2, null)));
            }

            InitializeComponent();

            totalNumberLbl.Text = "0" + currency;

            ShopItem example = new ShopItem(new Classes.ShopItem(0, 0, "", "Back","<>","","", 0, 0, null));
            this.Controls.Add(GenerateItem(exampleLbl.Left, exampleLbl.Top, example));

            foreach (var item in example.PanelAssosiated.Controls)
                (item as Control).Enabled = false;
            example.PanelAssosiated.Enabled = false;

            example.NameLabel.Text = "Product";
            example.InStockLabel.Text = "In stock";
            example.PriceLabel.Text = "Price";
            example.PurchaseTimesTBox.Text = "Order";
            example.TotalLabel.Text = " Total";

            this.Controls.Remove(exampleLbl);

            int column = 0;
            int x = 0;
            int y = 0;
            Panel holder = new Panel();
            holder.Width = this.itemsPanel.Width;
            holder.Height = this.itemsPanel.Height;
            holder.Left = itemsPanel.Left;
            holder.Top = itemsPanel.Top;
            this.itemsPanel.Parent = holder;
            this.itemsPanel.Left = 0;
            this.itemsPanel.Top = 0;
            this.Controls.Add(holder);
            holder.SendToBack();
            int row = 1;
            foreach (var i in items)
            {
                Panel layout = GenerateItem(x, y, i);
                this.itemsPanel.Controls.Add(layout);
                column += 1;
                if (column > this.itemsPanel.Width / iconSize)
                {
                    column = 0;
                    row += 1;
                    y += itemHeight;
                    x = -iconSize;
                }
                x += iconSize;
            }
            if(column > 0) y += itemHeight;

            if (y > this.itemsPanel.Height)
            {
                verticalBar.Visible = true;
                verticalBar.Maximum = y - this.itemsPanel.Height;
                verticalBar.Scroll += verticalBar_Scroll;
                this.itemsPanel.Height = y;
            }
            else
                verticalBar.Visible = false;

            pictureBox7_Click(null, null);
        }

        //todo listen for visitor
        //activeVisitor = phidgitVisitor

        void verticalBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.itemsPanel.Top = -verticalBar.Value;
        }

        private Panel GenerateItem(int x, int y, ShopItem i)
        {
            Panel layout = new Panel();
            layout.Left = x;
            layout.Top = y;
            layout.Width = iconSize;
            layout.Height = itemHeight;
            layout.BorderStyle = BorderStyle.Fixed3D;

            PictureBox icon = new PictureBox();
            icon.BorderStyle = BorderStyle.Fixed3D;
            icon.Width = iconSize;
            icon.Height = iconSize;
            icon.Image = i.Icon;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;

            Label name = new Label();
            name.Text = i.Name;
            
#warning check if every item fits in the label;
            name.Top = icon.Height;

            Label inStock = new Label();
            inStock.AutoSize = true;
            inStock.Text = i.InStock.ToString();

            Label price = new Label();
            TextBox purchasedAmount = new TextBox();
            Label total = new Label();

            price.AutoSize = false;
            purchasedAmount.AutoSize = false;
            total.AutoSize = false;

            price.Width = iconSize;
            purchasedAmount.Width = price.Width;
            total.Width = price.Width;

            price.TextAlign = ContentAlignment.MiddleCenter;
            purchasedAmount.TextAlign = HorizontalAlignment.Center;
            total.TextAlign = price.TextAlign;

            total.Text = "0" + currency;
            purchasedAmount.Text = "0";
            price.Text = i.Price.ToString() + currency;

            price.Top = name.Top + labelHeight;
            purchasedAmount.Top = price.Top + labelHeight;
            total.Top = purchasedAmount.Top + labelHeight;

            layout.Controls.Add(icon);
            layout.Controls.Add(name);
            layout.Controls.Add(price);
            layout.Controls.Add(purchasedAmount);
            layout.Controls.Add(total);
            layout.Controls.Add(inStock);

            inStock.BringToFront();
            name.BringToFront();
            price.BringToFront();
            purchasedAmount.BringToFront();
            total.BringToFront();

            layout.Click += item_Click;
            foreach (var child in layout.Controls)
                (child as Control).Click += item_Click;
            purchasedAmount.Click -= item_Click;
            purchasedAmount.KeyPress += purchasedAmount_KeyPress;

            i.PanelAssosiated = layout;
            i.InStockLabel = inStock;
            i.PriceLabel = price;
            i.PurchaseTimesTBox = purchasedAmount;
            i.TotalLabel = total;
            i.NameLabel = name;

            return layout;
        }

        void purchasedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox purchasedAmount = sender as TextBox;

            ShopItem item = items.Where(x => x.PurchaseTimesTBox == purchasedAmount).FirstOrDefault();
            if (item == null)
                throw new ArgumentNullException("ITEM NOT FOUND");

            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != '\b')
                {
                    if (e.KeyChar == (char)Keys.Return)
                    {
                        item.UpdateTo(int.Parse(purchasedAmount.Text));
                        UpdateTotal();
                    }
                    e.KeyChar = '\0';
                }
                else
                    if (purchasedAmount.Text.Length <= 1 || (int.Parse(purchasedAmount.Text) == 0))
                        item.UpdateTo(0);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            Panel i;
            if (sender is Panel)
                i = sender as Panel;
            else
            {
                i = (sender as Control).Parent as Panel;
                if (i == null)
                    throw new NotImplementedException("Child elements must be 1 below the panel");
            }

            ShopItem item = this.items.Where(x => x.PanelAssosiated == i).FirstOrDefault() as ShopItem;

            if (item == null) throw new ArgumentNullException("ITEM NOT FOUND");
            if (adding)
                item.Update(1);
            else
                item.Update(-1);

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            IEnumerable<ShopItem> selected = this.items.Where(x => x.PurchaseTimes > 0);
            totalItemsCountLbl.Text = selected.Sum(x=>x.PurchaseTimes).ToString();
            totalNumberLbl.Text = selected.Sum(x => x.Total).ToString() + currency;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Green;
            pictureBox1.BackColor = DefaultBackColor;
            adding = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Green;
            pictureBox7.BackColor = DefaultBackColor;
            adding = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<ShopItem> selectedItems = this.items.Where(x=>x.PurchaseTimes > 0);
            IEnumerable<Classes.ReceiptItem> selection = selectedItems.Select(x => new Classes.ReceiptItem(0, x.Item, null, x.PurchaseTimes,0));

            new StoreConfirm(selectedItems).Show();

            //Classes.Receipt receipt = new Classes.Receipt(ActiveVisitor, this.Shop, selection.ToList());

            //save receipt;

            //ActiveVisitor = null;

            //foreach (ShopItem item in selectedItems)
                //item.Reset();

        }
    }

    public class ShopItem
    {
        public const char currency = '€';
        Bitmap cachedIcon = null;

        public Bitmap Icon
        {
            get
            {
                if (cachedIcon == null)
                {
                    Bitmap b = (Bitmap)Design.Properties.Resources.ResourceManager.GetObject(this.Name.Replace(" ","_"));
                    if (b == null) { } // ICON NOT FOUND
                    cachedIcon = b;
                }
                return cachedIcon;
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

        public ShopItem(Classes.ShopItem item)
        {
            this.Item = item;
        }

        public void Update(int times)
        {
            int current = PurchaseTimes + times;
            if (current < 0) current = 0;
            if (current > InStock) current = InStock; // WARN THAT THERE IS NOT ENOUGH

            this.PurchaseTimes = current;
            TotalLabel.Text = (((int)(Price * 100 * PurchaseTimes)/100.0f)).ToString() + currency;
            PurchaseTimesTBox.Text = this.PurchaseTimes.ToString();

            int resultAfterPurchase = this.InStock - this.PurchaseTimes;

            if (resultAfterPurchase <= this.WarningLevel)
            {
                float deltaPercent = 0;
                if(this.WarningLevel != 0)
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
            this.TotalLabel.Text = "0" + currency;
        }
    }

    public class ItemsCollection
    {
        public VScrollBar Bar;
        public Panel panel;
        public IEnumerable<Control> Controls;
        public int X;
        public int Y;

        public ItemsCollection(Control parent, VScrollBar verticalBar, int neededHeight,IEnumerable<Control> controls, int x = 0, int y = 0)
        {
            this.Bar = verticalBar;
            this.X = x;
            this.Y = y;

            Panel holder = new Panel();
            
            this.panel = new Panel();
            holder.Controls.Add(panel);
            parent.Controls.Add(holder);

            holder.Left = x;
            holder.Top = y;
            holder.Height = verticalBar.Height;
            panel.Height = neededHeight;

            foreach (Control control in controls)
                control.Parent = panel;

            if (neededHeight > verticalBar.Height)
            {
                verticalBar.Visible = true;
                verticalBar.Maximum = neededHeight - verticalBar.Height;
                verticalBar.Scroll += (xx,yy) => this.panel.Top = -verticalBar.Value;
            }
            else
                verticalBar.Visible = false;
        }
    }
}
