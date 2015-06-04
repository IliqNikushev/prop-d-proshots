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
        public List<Appointment> completed = new List<Appointment>();
        Appointment app;
        Visitor activeVis;
        public EmployeesPCDoc()
        {
            InitializeComponent();
            reader.OnDetect += reader_OnDetect;
            foreach (Appointment app in queue)
            {
                appList1.Items.Add(app);
            }
        }

        void reader_OnDetect(string tag)
        {
            activeVis = Visitor.Authenticate(tag);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppointedItem item = new AppointedItem(textBox1.Text,textBox3.Text);
            //item = item.Create() as AppointedItem;
            
            Appointment app = new Appointment(item,activeVis,textBox2.Text);
            //app.Create();
            appList1.Items.Add(app);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appList2.Items.Add(appList1.SelectedItem as Appointment);
            appList1.Items.Remove(appList1.SelectedItem);
        }
    }
}
