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
    public partial class Camping : App_Common.HomePageWithMap
    {
        private List<Classes.Tent> tents;
        public Camping(App_Common.Menu parent)
            : base(parent)
        {
            Fix();
            InitializeComponent();
            Unfix();
            tents = Database.All<Tent>();

            this.comboBoxTent.Items.Clear();
            this.comboBoxTent.Items.Add("All");

            foreach (TentPitch pitch in Database.All<TentPitch>())
                this.comboBoxTent.Items.Add(pitch.ID);

            findByTypeTb.Visible = false;
            findByTypeLbl.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Classes.Tent> ItemsToShow = this.tents;
            ItemsToShow = ItemsToShow.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text)).ToList();
            this.listBox1.Items.Clear();
            foreach (var item in ItemsToShow)
            {
                string result = item.ID + " " + item.BookedBy + " for " + item.NumberOfPeople + " additional people, on " + item.BookedOn + " price=" + item.Price;
                listBox1.Items.Add(result);
            }

        }

        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = comboBoxDate.Text;
            List<Classes.Tent> ItemsToShow = this.tents;

            if (!(comboBoxDate.Text == "ALL" || comboBoxDate.Text == ""))
            {
                int day = int.Parse(comboBoxDate.Text);

                ItemsToShow = ItemsToShow.Where(x => x.BookedOn.Day == day).ToList();
            }


            if (!(comboBoxTent.Text == "ALL" || comboBoxTent.Text == ""))
            {
                int tentNr = int.Parse(comboBoxTent.Text);
                ItemsToShow = ItemsToShow.Where(x => x.ID == tentNr).ToList();
            }

            if (!(textBoxVisitor.Text == ""))
            {
                ItemsToShow = ItemsToShow.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text)).ToList();
            }


            this.listBox1.Items.Clear();
            foreach (var item in ItemsToShow)
            {
                string result = item.ID + " " + item.BookedBy + " for " + item.NumberOfPeople + " additional people, on " + item.BookedOn + " price=" + item.Price;
                listBox1.Items.Add(result);
            }

            SetMapItems(ItemsToShow.Select(x=>x.Location));
        }
    }
}