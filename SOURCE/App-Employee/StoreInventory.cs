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
    public partial class StoreInventoryForm : Form
    {
        const int sizeOfRestockItem = 96;
        private List<StoreItem> items;
        private List<Panel> panels = new List<Panel>();
        private Employee employee;
        public StoreInventoryForm(List<StoreItem> items, Action callback, Employee employee)
        {
            this.employee = employee;
            //todo open new form similar to confirm with list to add / remove items to restock
            InitializeComponent();

            itemsModifiedLbl.Text = "0";
            uniqueAddedLbl.Text = "0";

            this.FormClosed += (xx, yy) => callback();

            int y = 0;
            this.items = items;
            foreach (var item in items.OrderBy(x => x.Name))
            {
                CreateConfirmItem(item, ref y, vScrollBar1.Left);
                CreateConfirmItem(item, ref y, vScrollBar1.Left);
            }

            StoreItemsCollection collection = new StoreItemsCollection(this, vScrollBar1, y, panels);
            nameTbox.TextChanged += (xx, yy) =>
            {
                int currentY = 0;
                foreach (var item in this.panels)
                {
                    if (item.Visible)
                    {
                        item.Top = currentY;
                        currentY += sizeOfRestockItem;
                    }
                }
                if (currentY > vScrollBar1.Height)
                {
                    vScrollBar1.Visible = true;
                    vScrollBar1.Maximum = currentY - vScrollBar1.Height;
                }
                else
                    vScrollBar1.Visible = false;

                collection.panel.Top = 0;
            };
        }

        private void CreateConfirmItem(StoreItem item, ref int y, int distanceToScrollbar)
        {
            int width = distanceToScrollbar - sizeOfRestockItem;
            Panel restockPanel = new Panel();
            panels.Add(restockPanel);
            restockPanel.BorderStyle = BorderStyle.Fixed3D;
            restockPanel.Width = distanceToScrollbar;
            PictureBox icon = new PictureBox();
            icon.ImageLocation = item.Icon;
            icon.SizeMode = PictureBoxSizeMode.StretchImage;
            icon.Width = sizeOfRestockItem;
            icon.Height = sizeOfRestockItem;
            icon.Parent = restockPanel;

            restockPanel.Height = sizeOfRestockItem;
            restockPanel.Width = distanceToScrollbar;
            restockPanel.Top = y;

            Label name = new Label();
            name.Text = item.Name;
            name.Left = sizeOfRestockItem;
            name.AutoSize = false;
            name.Width = width;
            name.TextAlign = ContentAlignment.MiddleCenter;
            restockPanel.Controls.Add(name);

            NumericUpDown restockCount = new NumericUpDown();
            restockCount.Left = sizeOfRestockItem;
            restockCount.Width = width;
            restockCount.Top = name.Height;
            restockCount.Height = name.Top + name.Height;
            restockPanel.Controls.Add(restockCount);
            restockCount.Text = item.Price.ToString() + StoreItem.Currency;
            restockCount.Font = new System.Drawing.Font(restockCount.Font.FontFamily, restockCount.Font.Size * 2);
            restockCount.Maximum = 500;
            restockCount.Minimum = 0;
            restockCount.ValueChanged += (xx, yy) =>
            {
                item.RestockAmount = (int)restockCount.Value;
                itemsModifiedLbl.Text = items.Sum(x => x.RestockAmount).ToString();
                uniqueAddedLbl.Text = items.Where(x => x.RestockAmount > 0).Count().ToString();
            };

            nameTbox.TextChanged += (xx, yy) =>
            {
                if (nameTbox.Text == "")
                    restockPanel.Visible = true;
                else
                    if (item.Name.ToLower().Contains(nameTbox.Text.ToLower()))
                        restockPanel.Visible = true;
                    else
                        restockPanel.Visible = false;
            };

            y += sizeOfRestockItem;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Restock r = new Restock();
            r = r.Create() as Restock;
            new LogMessage("restock store", "By:{0} for:{1} items:{2}".Args(this.employee.ID, this.employee.Workplace.ID, string.Join(",", items.Select(x => x.Item.ID + " " + x.RestockAmount)))).Create();

            foreach (var item in items)
            {
                if (item.RestockAmount > 0)
                {
                    new RestockItem(item.Item, r, item.RestockAmount).Create();
                    item.RestockAmount = 0;
                }
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
