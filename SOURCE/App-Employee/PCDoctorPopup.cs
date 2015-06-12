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

namespace App_Employee
{
    public partial class PCDoctorPopup : Form
    {
        public List<AppointmentTask> tasks;
        private PCDoctorForm pc;
        public PCDoctorPopup(PCDoctorForm pc)
        {
            InitializeComponent();
            this.pc = pc;
            this.tasks = pc.selected().Tasks;
            foreach (AppointmentTask task in tasks)
            {
                listBox1.Items.Add(task);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
