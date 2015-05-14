using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Idea.EmployeeInterface
{
    public partial class EmployeesPCDoctor : Menu
    {
        public EmployeesPCDoctor()
        {
            InitializeComponent();

            List<Classes.Appointment> appointments = Classes.Database.Appointments;
            
            foreach (var item in appointments)
            {
                this.listBox1.Items.Add(item);
            }
        }

        private void topNavContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddAppointment()
        {
        }

        private void ViewAppointment()
        {
        }

        private void EditAppointment()
        {
        }
    }
}
