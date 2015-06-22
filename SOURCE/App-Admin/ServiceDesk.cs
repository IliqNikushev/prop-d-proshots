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

namespace App_Admin
{
    public partial class ServiceDesk : App_Common.HomePage
    {
        private List<Classes.Item> items;
        private List<Classes.RentableItemHistory> itemsHistory;
        private Classes.Item currentItem;
        public ServiceDesk(App_Common.Menu parent) : base(parent)
        {
           // Fix();
            InitializeComponent();
//Unfix();
            this.itemsHistory = Classes.Database.All<Classes.RentableItemHistory>();
           //currentEmployee = LoggedInUser as Employee;
           // this.comboBoxItems.Items.Clear();
            //this.comboBoxItems.Items.Add("ALL");
            //this.comboBoxItems.Items.AddRange(Classes.Database.ite);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Classes.RentableItemHistory> ItemsToShow = this.itemsHistory;
            
            ItemsToShow = ItemsToShow.Where(x => x.RentedBy.FullName.Contains(textBoxVisitor.Text)).ToList();

            this.lbResult.Items.Clear();
            this.lbResult.Items.AddRange(ItemsToShow.ToArray());
        }

        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Classes.RentableItemHistory> ItemsToShow = new List<RentableItemHistory>();
            ItemsToShow.AddRange(this.itemsHistory);
            if (!(comboBoxDate.Text == "ALL" || comboBoxDate.Text == ""))
            {
                int day = int.Parse(comboBoxDate.Text);
                ItemsToShow.Clear();
                ItemsToShow.AddRange(itemsHistory.Where(x => x.RentedAt.Day == day));

            }

            if (!(textBoxVisitor.Text == ""))
            {
                ItemsToShow = ItemsToShow.Where(x => x.RentedBy.FullName.Contains(textBoxVisitor.Text)).ToList();

            }

            this.lbResult.Items.Clear();
            this.lbResult.Items.AddRange(ItemsToShow.ToArray());
        }
    }
}
