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
    public partial class PCDoctorForm : App_Common.Menu
    {
        public List<Appointment> queue = Database.All<Appointment>();
        Visitor activeVis;
        public PCDoctorForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
            if (!IsInDebug)
            {
                reader.Dispose();
                reader = new RFID();
                reader.OnDetect += rf_OnDetect;
            }
            foreach (Appointment app in queue)
            {
                if (app.Status)
                {
                    lbCompleted.Items.Add(app);
                }
                else lbQueue.Items.Add(app);
            }
        }

        void rf_OnDetect(string tag)
        {
            activeVis = Visitor.Authenticate(tag);
            if (activeVis == null)
                return;
            MainMenu.Invoke(new Action(
                ()=>{
                    picVis.ImageLocation = activeVis.Picture;
                     tbVisCard.Text = tag;
                     tbVisName.Text = activeVis.FullName;
                }));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (activeVis != null)
            {
                AppointedItem item = new AppointedItem(tbBrand.Text, tbModel.Text);
                item = item.Create() as AppointedItem;
                Appointment app = new Appointment(item, activeVis, tbDesc.Text);
                app = app.Create() as Appointment;
                if(!Database.HadAnError)
                    lbQueue.Items.Add(app);
            }
            else MessageBox.Show("No visitor found. Please approach the card first before confirming.");
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(lbQueue.SelectedItem == null) return;
            Appointment appointment = lbQueue.SelectedItem as Appointment;
            if (activeVis == null)
            {
                MessageBox.Show("No visitor found. Please approach the card");
                return;
            }
            if (activeVis.ID != appointment.Visitor.ID)
            {
                MessageBox.Show("Item does not belong to current visitor");
                return;
            }
            if (activeVis.Balance < appointment.Price)
            {
                MessageBox.Show("Visitor cannot pay for the appointment ({0}{1} more is needed)".Arg(appointment.Price - activeVis.Balance));
                return;
            }
            activeVis.ChangeBalanceWith(-appointment.Price, "Appointment " + appointment.ID);
            appointment.Complete();
            lbCompleted.Items.Add(lbQueue.SelectedItem);
            lbQueue.Items.Remove(lbQueue.SelectedItem);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lbQueue.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
            }
            else
            {
                PCDoctorPopup newform = new PCDoctorPopup(this);
                newform.ShowDialog();
            }
        }
        public Appointment Selected()
        {
            return lbQueue.SelectedItem as Appointment;
        }
    }
}
