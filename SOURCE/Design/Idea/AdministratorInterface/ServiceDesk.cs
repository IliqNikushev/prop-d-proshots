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

namespace Design.Idea.AdministratorInterface
{
    public partial class ServiceDesk : HomePageWithMap
    {
        private List<Classes.Item> items;
        private List<Classes.RentableItemHistory> itemsHistory;
        private Classes.Item currentItem;
        public ServiceDesk(Form parent) : base()
        {
            InitializeComponent();
            this.itemsHistory = Classes.Database.All<Classes.RentableItemHistory>();
           //currentEmployee = LoggedInUser as Employee;
           // this.comboBoxItems.Items.Clear();
            //this.comboBoxItems.Items.Add("ALL");
            //this.comboBoxItems.Items.AddRange(Classes.Database.ite);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Classes.RentableItemHistory> ItemsToShow = this.itemsHistory;
            
            ItemsToShow = ItemsToShow.Where(x => x.RentedBy.FullName.Contains(textBoxVisitor.Text)).ToList();

            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(ItemsToShow.ToArray());
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

            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(ItemsToShow.ToArray());
        }
    }
}
