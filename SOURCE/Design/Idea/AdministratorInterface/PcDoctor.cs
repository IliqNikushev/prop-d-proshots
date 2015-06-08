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
    public partial class PcDoctor : HomePageWithMap
    {
        private List<Classes.Appointment> appointments;

        public PcDoctor(Form parent) : base()
        {
            InitializeComponent();
            appointments = Database.Appointments;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Home().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string status = comboBoxDate.Text;
            List<Classes.Appointment> ItemsToShow = this.appointments;

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "" )
            {
                if (comboBoxStatus.Text=="All" || comboBoxStatus.Text=="")
                {


                    if (textBoxVisitor.Text == "")
                    {
                        ItemsToShow.AddRange(appointments);
                    }
                    else
                    {

                        ItemsToShow.AddRange(
                        appointments.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                    }
                }
                else
                {
                    
                    if (textBoxVisitor.Text == "")
                    {
                        appointments.Where(x => x.Status.ToString().Contains(comboBoxStatus.Text));
                        ItemsToShow.AddRange(appointments);
                    }
                    else
                    {

                        ItemsToShow.AddRange(
                        appointments.Where(x =>x.Status.ToString().Contains(comboBoxStatus.Text) && x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                    }


                }
            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    if (comboBoxStatus.Text == "All" || comboBoxStatus.Text == "")
                    {
                        ItemsToShow.AddRange(appointments.Where(x => x.AppointedOn.Day == day));
                    }
                }
                else
                {

                    ItemsToShow.AddRange(appointments.Where(x => x.Status.ToString().Contains(comboBoxStatus.Text) &&  x.AppointedOn.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }
            }
                

            




            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(ItemsToShow.ToArray());
        }
    }
}
