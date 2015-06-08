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
    public partial class PCDoctorPopup : Form
    {
        public List<AppointmentTask> tasks;
        private EmployeesPCDoc pc;
        public PCDoctorPopup(EmployeesPCDoc pc)
        {
            InitializeComponent();
            this.pc = pc;
            this.tasks = pc.selected().Tasks;
            foreach(AppointmentTask task in tasks)
            {
                listBox1.Items.Add(task);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Appointment app = pc.selected();
            AppointmentTask at = app.AddTask(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
            listBox1.Items.Add(at);
        }
    }
}
