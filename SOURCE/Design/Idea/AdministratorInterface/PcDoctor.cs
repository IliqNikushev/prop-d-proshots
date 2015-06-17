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
            

            if (!(comboBoxDate.Text == "All" || comboBoxDate.Text == "") )
            {
                int day = int.Parse(comboBoxDate.Text);
                
                ItemsToShow = ItemsToShow.Where(x => x.AppointedOn.Day == day).ToList();
                 
            }
            

            if (!(comboBoxStatus.Text=="All" || comboBoxStatus.Text==""))
                {
                   if (comboBoxStatus.Text == "Finished")
                       {
                            ItemsToShow= ItemsToShow.Where(x => x.Status == true).ToList();
                            
                        }
                        else if(comboBoxStatus.Text=="Unfinished")
                        {
                            ItemsToShow= ItemsToShow.Where(x=>x.Status==false).ToList();
                            
                        }
                        else if(comboBoxStatus.Text=="Returned")
                        {
                            ItemsToShow= ItemsToShow.Where(x=> x.IsReturned==true).ToList();
                            
                        }
                        else if(comboBoxStatus.Text=="unreturned")
                        {
                            ItemsToShow = ItemsToShow.Where(x=> x.IsReturned==false).ToList();
                            
                        }
                    else
                        throw new NotImplementedException(comboBoxStatus.Text + " < UNKNOWN STATUS");
                }

                    if (!(textBoxVisitor.Text == ""))
                    {
                        ItemsToShow= ItemsToShow.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text)).ToList();
                        
                    }
        

                    this.listBox1.Items.Clear();
                    listBox1.Items.AddRange(ItemsToShow.ToArray());
    


            
        }
    }
}
