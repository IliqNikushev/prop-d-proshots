using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.AdministratorInterface.SubMenu
{
    public partial class ShopInformation : HomePageWithMap
    {
        private List<Classes.ShopItem> items;
        private List<Classes.ReceiptItem> purchasedItems;
        private Classes.ShopWorkplace shop;
        private List<Classes.Visitor> visitors = new List<Classes.Visitor>();

        public ShopInformation(Classes.ShopWorkplace shop = null)
        {
            InitializeComponent();
            if (shop == null)
                return;

            this.shop = shop;
            this.items = shop.Items;

            this.purchasedItems = Classes.Database.Where<Classes.ReceiptItem>("Shopitems.shop_id = {0}", shop.ID);

            foreach (Classes.ReceiptItem item in this.purchasedItems)
            {
                if (this.visitors.Contains(item.Receipt.PurchasedBy)) continue;
                this.visitors.Add(item.Receipt.PurchasedBy);
            }

            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("All");
            this.comboBox1.Items.AddRange(this.items.ToArray());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Shops().Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.SelectedItem is string)
                if (comboBox1.SelectedItem.ToString() == "All")
                    listBox1.Items.AddRange(this.purchasedItems.ToArray());
                else
                {
                    //UNKNOWN STRING IN THE COLLECTION
                }
            else if (comboBox1.SelectedItem is Classes.ShopItem)
            {
                listBox1.Items.AddRange(this.purchasedItems.Where(x => x.Item.ID == (comboBox1.SelectedItem as Classes.ShopItem).ID).ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search
            List<Classes.ReceiptItem> itemsToShow = this.purchasedItems;
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "All" && comboBox1.SelectedItem is Classes.ShopItem)
                itemsToShow = itemsToShow.Where(x => x.Item.ID == (comboBox1.SelectedItem as Classes.ShopItem).ID).ToList();

            if (textBox1.Text.Trim() != "")
                itemsToShow = itemsToShow.Where(x =>
                    x.Receipt.PurchasedBy.FirstName.ToLower().Contains(textBox1.Text.ToLower()) ||
                    x.Receipt.PurchasedBy.LastName.ToLower().Contains(textBox1.Text.ToLower())).
                    OrderBy(x=>x.Receipt.PurchasedBy.FirstName).
                    ThenBy(x=>x.Receipt.PurchasedBy.LastName).
                    ToList();

            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(itemsToShow.ToArray());
        }
    }
}
