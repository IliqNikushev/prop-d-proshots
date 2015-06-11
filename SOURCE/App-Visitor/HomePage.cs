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

namespace App_Visitor
{
    public partial class HomePage : App_Common.HomePageWithMap
    {
        Visitor LogedinVisitor = LoggedInUser as Visitor;
        public HomePage(App_Common.Menu menu):base(menu)
        {
            InitializeComponent();

            SetMapItems(Classes.Database.All<Classes.Landmark>().Where(x=>
            {
                Classes.TentPitch tent = x as Classes.TentPitch;
                if(tent)
                    if(tent.IsBooked) return false;
                return true;
            }
            ));

            labelName.Text += LogedinVisitor.FullName;
            labelEmail.Text += LogedinVisitor.Email;
            labelBalance.Text += LogedinVisitor.Balance;
            ProfilePicture.ImageLocation = @"C:\user_images\" + LogedinVisitor.Picture;
        }

        protected override void OnSet()
        {
            mainMenuHeight = MainMenu.Height;
            base.OnSet();
        }

        private int mainMenuHeight = -1;

        protected override void OnTogglingMap(bool state)
        {
            base.OnTogglingMap(state);
            if (!state)
                MainMenu.Height = mainMenuHeight;
        }

        private void BookedPicture_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Tent T in LogedinVisitor.BookedTents)
            {
                listBox1.Items.Add("Booked " + T);
            }
            foreach (Tent T in LogedinVisitor.BookedInTents)
            {
                listBox1.Items.AddRange(T.BookedFor);
            }
        }

        private void PurchasedPicture_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (ReceiptItem T in LogedinVisitor.PurchasedItems)
            {
                listBox1.Items.Add(T);
            }
        }

        private void RentedPicture_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (RentableItemHistory T in LogedinVisitor.RentedItems)
            {
                string returned = "";
                if (T.IsReturned == false)
                {
                    returned = " returned at " + T.ReturnedAt;
                }
                listBox1.Items.Add(T.RentedItem + " rented by " + T.RentedBy + " Price " + T.Price + " Euro Rented till " + T.RentedTill + " " + returned);
            }
        }

        private void AppointmentsPicture_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Appointment T in LogedinVisitor.Appointments)
            {
                string Compleated = "";
                if (T.CompletedOn == DateTime.MinValue)
                {

                }
                else
                {
                    Compleated = " Compleated on " + T.CompletedOn.ToString();
                }
                listBox1.Items.Add(T + "" + Compleated);
            }
        }

        private void ExitPicture_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
