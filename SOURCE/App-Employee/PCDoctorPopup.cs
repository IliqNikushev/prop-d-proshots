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
            this.tasks = pc.Selected().Tasks;
            foreach (AppointmentTask task in tasks)
            {
                lbTasks.Items.Add(task);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppointmentTask task = new AppointmentTask(tbName.Text, tbDescr.Text, nudPrice.Value, pc.Selected()).Create() as AppointmentTask;
            if(!Database.HadAnError)
            this.lbTasks.Items.Add(task);
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            AppointmentTask selected = this.lbTasks.SelectedItem as AppointmentTask;
            Database.Delete(selected, "|T|.id = {0}", selected.ID);
            if(!Database.HadAnError)
                this.lbTasks.Items.RemoveAt(this.lbTasks.SelectedIndex);
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTasks.SelectedItem == null)
                btnRem.Enabled = false;
            else
                btnRem.Enabled = true;
        }
    }
}
