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
    public partial class Visitors : Menu
    {
        private List<Visitor> visitors;
        private List<RentableItemHistory> rentableItems;
        private List<ReceiptItem> receiptItems;
        private List<Appointment> appointments;
        private List<Tent> bookedTents;
        private List<Deposit> deposits;
       
        private AdminUser currentAdmin;
        public Visitors(Form parent) : base()
        {
            InitializeComponent();
            visitors = Database.Visitors;
            rentableItems = Database.All<RentableItemHistory>();
            receiptItems = Database.All<ReceiptItem>();
            appointments = Database.Appointments;
            bookedTents = Database.All<Tent>();
            deposits = Database.All<Deposit>();


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
            
            listBox1.Items.AddRange(visitors.ToArray());
        }
    }
}
