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
    public partial class Camping : HomePageWithMap
    {
        private List<Classes.Tent> tents;
        private List<Classes.Tent> tentToShow;
        public Camping(Form parent) : base()
        {
            InitializeComponent();
            tents = Database.All<Tent>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Classes.Tent> ItemsToShow = this.tents;
            ItemsToShow = ItemsToShow.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text)).ToList();
            this.listBox1.Items.Clear();
            foreach (var item in ItemsToShow)
            {
                string result = item.ID + " " + item.BookedBy + " for " + item.NumberOfPeople + " people, on " + item.BookedOn + " price=" + item.Price;
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
                string  result= item.ID+" "+item.BookedBy+" for "+item.NumberOfPeople+" people, on "+ item.BookedOn+ " price="+item.Price;
                listBox1.Items.Add(result);    
            }
            
        }
    }
}
