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

namespace Design.Idea.EmployeeV1
{
    public partial class EmployeesPCDoc : Menu
    {
        public List<Appointment> queue = Database.All<Appointment>();
        Visitor activeVis = Visitor.Authenticate("tester", "test") as Visitor;
        public EmployeesPCDoc()
        {
            InitializeComponent();
            //reader.OnDetect += reader_OnDetect;
            foreach (Appointment app in queue)
            {
                if (app.Status)
                {
                    appList2.Items.Add(app);
                }
                else appList1.Items.Add(app);
            }

        }

        void reader_OnDetect(string tag)
        {
            activeVis = Visitor.Authenticate(tag);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppointedItem item = new AppointedItem(textBox1.Text,textBox3.Text);
            item = item.Create() as AppointedItem;
            Appointment app = new Appointment(item,activeVis,textBox2.Text);
            app = app.Create() as Appointment;
            appList1.Items.Add(app);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (appList1.SelectedItem as Appointment).Complete();
            appList2.Items.Add(appList1.SelectedItem);
            appList1.Items.Remove(appList1.SelectedItem);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PCDoctorPopup newform = new PCDoctorPopup(this);
            if(appList1.SelectedItem ==null)
            {
                MessageBox.Show("Please select an item");
            }
            else newform.ShowDialog();
        }
        public Appointment selected()
        {
            return appList1.SelectedItem as Appointment;
        }
    }
}
