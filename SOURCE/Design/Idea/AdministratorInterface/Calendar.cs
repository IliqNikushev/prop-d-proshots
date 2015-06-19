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
    public partial class Calendar : HomePageWithMap
    {
        List<EventLandmark> events;


        public Calendar(Form parent) : base()
        {
            InitializeComponent();
            events = Database.All<EventLandmark>();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(events.ToArray());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBoxDate.SelectedItem.ToString() == "ALL")
            {
                listBox1.Items.AddRange(events.ToArray());

            }
            else
                listBox1.Items.AddRange(events.Where(
                    x =>  x.TimeStart.Day > int.Parse (comboBoxDate.SelectedItem.ToString())-1).ToArray() );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelDescription.Text ="Description: " +(listBox1.SelectedItem as EventLandmark).Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddNewEvent().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
#warning remove at database?
            this.listBox1.Items.Remove(this.listBox1.SelectedItem);
        }
    }
}
