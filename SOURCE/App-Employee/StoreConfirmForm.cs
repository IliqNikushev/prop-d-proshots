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
    public partial class StoreConfirmForm : Form
    {
        const int sizeOfConfirmItem = 96;
        private IEnumerable<StoreItem> items;
        public StoreConfirmForm() { InitializeComponent(); }
        public enum State
        {
            Ok,
            Cancel,
            Postpone
        }

        public StoreItemsCollection collection;
        private Action<State> onResult = null;
        private Classes.Employee employee;
        private Classes.Receipt receipt;

        public StoreConfirmForm(Classes.Employee employee, IEnumerable<StoreItem> items, Classes.Visitor visitor, Action<State> onResult = null)
            : this()
        {
            this.onResult = onResult;
            this.employee = employee;
            this.items = items;

            int y = 0;

            List<Control> controls = new List<Control>();

            foreach (var item in items)
                CreateConfirmItem(item, ref y, controls, vScrollBar1.Left);

            this.collection = new StoreItemsCollection(this, vScrollBar1, y, controls);
            decimal sum = items.Sum(x => x.Price * x.PurchaseTimes);
            this.totalValueLbl.Text = sum.ToString() + StoreItem.Currency;
            this.numberValueLbl.Text = items.Sum(x => x.PurchaseTimes).ToString();

            confirmBtn.Enabled = true;
            insufficientLbl.Visible = false;

            this.Name = "Order confirm for " + visitor.FullName + " for " + sum + StoreItem.Currency;
            if (visitor.Balance < sum)
            {
                confirmBtn.Enabled = false;
                insufficientLbl.Visible = true;
                insufficientLbl.Text = "Visitor needs " + (sum - visitor.Balance).ToString() + StoreItem.Currency;
            }

            this.receipt = new Classes.Receipt(visitor, items.Select(x=>x.ToReceiptItem()).ToList());
        }

        private void CreateConfirmItem(StoreItem item, ref int y, List<Control> controls, int distanceToScrollbar)
        {
            int delta = distanceToScrollbar - sizeOfConfirmItem;
            Panel confirmPanel = new Panel();
            confirmPanel.BorderStyle = BorderStyle.Fixed3D;
            confirmPanel.Width = distanceToScrollbar;
            PictureBox icon = new PictureBox();
            icon.ImageLocation = item.Icon;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.Width = sizeOfConfirmItem;
            icon.Height = sizeOfConfirmItem;
            icon.Parent = confirmPanel;

            confirmPanel.Height = sizeOfConfirmItem;
            confirmPanel.Width = distanceToScrollbar;
            confirmPanel.Top = y;

            Label name = new Label();
            name.Text = item.Name;
            name.Left = sizeOfConfirmItem;
            name.AutoSize = false;
            name.Width = delta;
            name.TextAlign = ContentAlignment.MiddleCenter;
            confirmPanel.Controls.Add(name);

            Label price = new Label();
            price.Left = sizeOfConfirmItem;
            price.Width = delta;
            price.Top = name.Height;
            price.Height = name.Top + name.Height;
            price.TextAlign = ContentAlignment.MiddleCenter;
            confirmPanel.Controls.Add(price);
            price.Text = item.Price.ToString() + StoreItem.Currency;
            price.Font = new System.Drawing.Font(price.Font.FontFamily, price.Font.Size * 2);

            Label times = new Label();
            times.Left = sizeOfConfirmItem;
            times.Top = price.Top + price.Height;
            times.AutoSize = false;
            times.Width = delta;
            times.TextAlign = ContentAlignment.MiddleCenter;
            confirmPanel.Controls.Add(times);
            times.Text = item.PurchaseTimes + " Time" + (item.PurchaseTimes == 1 ? "" : "s");
            times.Font = new System.Drawing.Font(times.Font.FontFamily, times.Font.Size * 2);

            Label total = new Label();
            total.Left = sizeOfConfirmItem;
            total.Top = times.Top + times.Height;
            total.Text = (item.Price * item.PurchaseTimes).ToString() + StoreItem.Currency;
            total.AutoSize = false;
            total.Width = delta;
            total.Font = new System.Drawing.Font(total.Font.FontFamily, total.Font.Size * 2);
            total.TextAlign = ContentAlignment.MiddleCenter;
            confirmPanel.Controls.Add(total);

            controls.Add(confirmPanel);
            confirmPanel.SendToBack();
            icon.BringToFront();

            y += sizeOfConfirmItem;
        }

        private void totalLbl_Click(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            receipt.UnPostpone();
            receipt = receipt.Create() as Classes.Receipt;
            employee.PerformDuty(receipt.ID + " > confirm");

            receipt.PurchasedBy.ChangeBalanceWith(-receipt.Price, "purchase " + receipt.ID);

            foreach (var item in receipt.Items)
            {
                item.Item.Deplete(item.Times);
            }

            this.Close();
            if (this.onResult != null) onResult(State.Ok);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.onResult != null) onResult(State.Cancel);
        }

        private void postponeBtn_Click(object sender, EventArgs e)
        {
            receipt.Postpone();
            receipt = receipt.Create() as Classes.Receipt;
            employee.PerformDuty(receipt.ID + " > postpone");

            this.cancelBtn_Click(sender, e);
            if (this.onResult != null) onResult(State.Postpone);
        }
    }
}
