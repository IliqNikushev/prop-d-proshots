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
    public partial class Calendar : App_Common.HomePageWithMap
    {
        List<EventLandmark> events;

        public Calendar(App_Common.Menu parent) : base(parent)
        {
            Fix();
            InitializeComponent();
            Unfix();
        }

        protected override void Reset()
        {
            events = Database.All<EventLandmark>();
            lbResult.Items.Clear();
            lbResult.Items.AddRange(events.ToArray());

            SetMapItems(events);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbResult.Items.Clear();
            if (comboBoxDate.SelectedItem.ToString() == "ALL")
            {
                lbResult.Items.AddRange(events.ToArray());

            }
            else
                lbResult.Items.AddRange(events.Where(
                    x =>  x.TimeStart.Day > int.Parse (comboBoxDate.SelectedItem.ToString())-1).ToArray() );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelDescription.Text ="Description: " +(lbResult.SelectedItem as EventLandmark).Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddNewEvent(this).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.lbResult.Items.Remove(this.lbResult.SelectedItem);
        }
    }
}
