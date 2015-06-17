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
            string status = comboBoxDate.Text;
            List<Classes.Tent> ItemsToShow = this.tents;


            if (!(comboBoxDate.Text == "All" || comboBoxDate.Text == ""))
            {
                int day = int.Parse(comboBoxDate.Text);

                ItemsToShow = ItemsToShow.Where(x => x.BookedOn.Day == day).ToList();

            }


            if (!(comboBoxTent.Text == "All" || comboBoxDate.Text == ""))
            {
                int tentNr = int.Parse(comboBoxTent.Text);
                ItemsToShow = ItemsToShow.Where(x => x.ID == tentNr).ToList();
                
            }

            if (!(textBoxVisitor.Text == ""))
            {
                ItemsToShow = ItemsToShow.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text)).ToList();

            }


            this.listBox1.Items.Clear();
            listBox1.Items.AddRange(ItemsToShow.ToArray());

        }
    }
}
