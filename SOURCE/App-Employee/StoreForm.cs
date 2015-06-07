using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Employee
{
    public partial class StoreForm : App_Common.Menu
    {
        private Classes.ShopWorkplace Shop { get { return LoggedInEmployee.Workplace as Classes.ShopWorkplace; } }

        private const int iconSize = 64;
        private const int labelHeight = 16;
        private const int itemHeight = iconSize + labelHeight * 5;

        private static string currency { get { return StoreItem.Currency; } }

        private List<StoreItem> items = new List<StoreItem>();
        private bool adding = true;

        public StoreForm(App_Common.Menu parent) : base(parent) 
        {
            InitializeComponent();

            StoreItem example = new StoreItem(new Classes.ShopItem(0, 0, "", "Example imte", "<>", "", "","", 0, 0, null, 0));
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
        }

        protected override void Reset()
        {
            int column = 0;
            int x = 0;
            int y = 0;

            this.items.Clear();
            this.itemsPanel.Controls.Clear();
            foreach (var item in this.Shop.Items)
                this.items.Add(new StoreItem(item));
            totalNumberLbl.Text = "0" + currency;
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
            if (column > 0) y += itemHeight;

            if (y > this.itemsPanel.Height)
            {
                verticalBar.Visible = true;
                verticalBar.Maximum = y - this.itemsPanel.Height;
                verticalBar.Scroll += verticalBar_Scroll;
                this.itemsPanel.Height = y;
            }
            else
                verticalBar.Visible = false;
            this.Text = Shop.Label + ": Order menu";

            storeLogoPbox.ImageLocation = Shop.Icon;

            foreach (var item in this.items)
                item.Reset();
            this.ActiveVisitor = null;
            this.activeVisitorLbl.Text = "No active visitor";

            UpdateTotal();

            reader.OnDetect -= reader_OnDetect;
            reader.OnDetect += reader_OnDetect;

            ActiveVisitor = Classes.Visitor.Authenticate("tester", "test") as Classes.Visitor;

            Classes.Receipt activeOrder = ActiveVisitor.ActiveOrder(this.Shop);
            if (activeOrder != null)
            {
                List<Classes.ReceiptItem> orderItems = activeOrder.Items;
                int itemCount = orderItems.Sum(z => z.Times);
                if (MessageBox.Show(string.Format(
                    "Visitor already has an active order. Does they wish to continue it? ({0} item{1}, price:{2}{3})",
                    itemCount, itemCount == 1 ? "" : "s", orderItems.Sum(z => z.TotalPrice), App_Common.Constants.Currency)
                    , "Active order found", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<Classes.ReceiptItem> notEnoughItems = new List<Classes.ReceiptItem>();
                    foreach (var item in orderItems)
                    {
                        StoreItem found = this.items.Where(z => z.Item.ID == item.Item.ID).FirstOrDefault();

                        if (found != null)
                        {
                            if (item.Times > found.InStock)
                                notEnoughItems.Add(item);
                            found.Update(item.Times);
                        }
                    }
                    UpdateTotal();
                    if (notEnoughItems.Any())
                        MessageBox.Show("Some items could not be fit into the visitor's order.\n" +
                            notEnoughItems.Select(z =>
                                z.Item.Brand + " " +
                                z.Item.Model + " " +
                                " wanted " + z.Times +
                                " but there are " + z.Item.InStock + " (+" + (z.Times - z.Item.InStock) + ")"));
                }
                activeOrder.Clear();
            }
        }

        void reader_OnDetect(string tag)
        {
            ActiveVisitor = Classes.Visitor.Authenticate(tag);
            if (ActiveVisitor)
                activeVisitorLbl.Text = "Active visitor: " + ActiveVisitor.FullName;
            else
                activeVisitorLbl.Text = "Visitor not found in the database!";
            Classes.Receipt activeOrder = ActiveVisitor.ActiveOrder(this.Shop);
            List<Classes.ReceiptItem> orderItems = activeOrder.Items;
            if (activeOrder != null)
            {
                if (MessageBox.Show(string.Format(
                    "Visitor already has an active order. Does he wish to continue it? ({0} item{1}, price:{2}{3})",
                    orderItems.Count, orderItems.Count == 1 ? "" : "s", orderItems.Sum(x => x.TotalPrice), App_Common.Constants.Currency)
                    , "Active order found", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    activeOrder.Clear();
                }
                else
                {
                    List<Classes.ReceiptItem> notEnoughItems = new List<Classes.ReceiptItem>();
                    foreach (var item in orderItems)
                    {
                        StoreItem found = this.items.Where(x => x.Item.ID == item.Item.ID).FirstOrDefault();

                        if (found != null)
                        {
                            if (item.Times > found.InStock)
                                notEnoughItems.Add(item);
                            found.Update(item.Times);
                        }
                    }
                    if (notEnoughItems.Any())
                        MessageBox.Show("Some items could not be fit into the visitor's order.\n" + 
                            notEnoughItems.Select(x => 
                                x.Item.Brand + " " +
                                x.Item.Model + " " +
                                " wanted " + x.Times +
                                " but there are " + x.Item.InStock + " (+" + (x.Times - x.Item.InStock) + ")"));
                }
            }
        }

        void verticalBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.itemsPanel.Top = -verticalBar.Value;
        }

        private Panel GenerateItem(int x, int y, StoreItem i)
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
            icon.ImageLocation = i.Icon;
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

            StoreItem item = items.Where(x => x.PurchaseTimesTBox == purchasedAmount).FirstOrDefault();
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

            StoreItem item = this.items.Where(x => x.PanelAssosiated == i).FirstOrDefault() as StoreItem;

            if (item == null) throw new ArgumentNullException("ITEM NOT FOUND");
            if (adding)
                item.Update(1);
            else
                item.Update(-1);

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            IEnumerable<StoreItem> selected = this.items.Where(x => x.PurchaseTimes > 0);
            totalItemsCountLbl.Text = selected.Sum(x => x.PurchaseTimes).ToString();
            totalNumberLbl.Text = selected.Sum(x => x.Total).ToString() + currency;
        }

        private void addPbox_Click(object sender, EventArgs e)
        {
            addPbox.BackColor = Color.Green;
            subPbox.BackColor = DefaultBackColor;
            adding = true;
        }

        private void subPbox_Click(object sender, EventArgs e)
        {
            subPbox.BackColor = Color.Green;
            addPbox.BackColor = DefaultBackColor;
            adding = false;
        }

        private void OnConfirmClick(StoreConfirmForm.State state)
        {
            switch (state)
            {
                case StoreConfirmForm.State.Ok:
                    MessageBox.Show("The order has been recorded.");
                    Reset();
                    break;
                case StoreConfirmForm.State.Cancel:
                    //Nothing 
                    break;
                case StoreConfirmForm.State.Postpone:
                    MessageBox.Show("The order has been postponed.");
                    Reset();
                    break;
            }
        }

        private Classes.Visitor ActiveVisitor;

        private StoreConfirmForm confirmForm;

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (ActiveVisitor == null)
            {
                MessageBox.Show("No visitor found. Please approach the card first before confirming.");
                return; 
            }
            if (!this.items.Where(x => x.PurchaseTimes > 0).Any())
            {
                MessageBox.Show("No items selected");
                return;
            }
            if(confirmForm != null && confirmForm.IsDisposed)
                confirmForm = new StoreConfirmForm(LoggedInEmployee,this.items.Where(x => x.PurchaseTimes > 0), ActiveVisitor, OnConfirmClick);
            else if(confirmForm == null)
                confirmForm = new StoreConfirmForm(LoggedInEmployee, this.items.Where(x => x.PurchaseTimes > 0), ActiveVisitor, OnConfirmClick);

            confirmForm.Show();

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {

        }
    }
}
