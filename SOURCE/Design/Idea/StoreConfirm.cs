using System;
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
    public partial class StoreConfirm : Form
    {
        const int sizeOfConfirmItem = 64;
        private IEnumerable<ShopItem> items;
        public StoreConfirm() { InitializeComponent(); }

        public ItemsCollection collection;

        public StoreConfirm(IEnumerable<ShopItem> items) : this()
        {
            this.items = items;

            int y = 0;

            List<Control> controls = new List<Control>();

            foreach (var item in items)
                CreateConfirmItem(item, ref y, controls, vScrollBar1.Left);

            this.collection = new ItemsCollection(this, vScrollBar1, y, controls);
        }

        private void CreateConfirmItem(ShopItem item, ref int y, List<Control> controls, int distanceToScrollbar)
        {
            int delta = distanceToScrollbar - sizeOfConfirmItem;
            Panel confirmItem = new Panel();
            PictureBox icon = new PictureBox();
            icon.Image = item.Icon;
            icon.Width = sizeOfConfirmItem;
            icon.Height = sizeOfConfirmItem;
            icon.Parent = confirmItem;

            confirmItem.Height = sizeOfConfirmItem;
            confirmItem.Width = distanceToScrollbar;
            confirmItem.Top = y;

            Label name = new Label();
            name.Text = item.Name;
            name.Left = sizeOfConfirmItem;
            name.AutoSize = false;
            name.Width = delta;
            name.TextAlign = ContentAlignment.MiddleCenter;
            confirmItem.Controls.Add(name);

            Label price = new Label();
            price.Left = sizeOfConfirmItem + delta / 2;
            price.Width = delta / 2;
            price.Top = name.Height;
            price.Height = sizeOfConfirmItem - name.Height;
            confirmItem.Controls.Add(price);
            price.Text = item.Price.ToString() + ShopItem.currency;
            price.Font = new System.Drawing.Font(price.Font.FontFamily, price.Font.Size * 2);

            Label times = new Label();
            times.Left = sizeOfConfirmItem;
            times.Top = name.Height;
            times.AutoSize = false;
            times.Height = sizeOfConfirmItem - name.Height;
            times.Width = delta / 2;
            confirmItem.Controls.Add(times);
            times.Text = item.PurchaseTimes + " Time" + (item.PurchaseTimes == 1 ? "" : "s");
            times.Font = new System.Drawing.Font(price.Font.FontFamily, price.Font.Size * 2);

            times.BackColor = Color.Red;
            price.BackColor = Color.Green;
            name.BackColor = Color.Yellow;
            icon.BackColor = Color.Blue;

            controls.Add(confirmItem);
            confirmItem.SendToBack();
            icon.BringToFront();

            y += sizeOfConfirmItem;
        }

        private void totalLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
