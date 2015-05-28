using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Camps
{
    public partial class CampingMenu : App_Common.Menu
    {
        IEnumerable<Classes.Tent> bookedByVisitorPitches;
        IEnumerable<Classes.Tent> bookedForVisitorPitches;

        public CampingMenu(List<Classes.Tent> tents, App_Common.Menu parent) : base(parent)
        {
            InitializeComponent();

            if (!tents.Any())
            {
                this.bookedByVisitorPitches = new List<Classes.Tent>();
                this.bookedForVisitorPitches = new List<Classes.Tent>();
                return;
            }

            bookedByVisitorPitches = tents.Where(x => x.BookedBy == LoggedInUser);
            bookedForVisitorPitches = tents.Where(x => x.BookedBy != LoggedInUser);

            this.todayLbl.Text = "It is " + DateTime.Now.ToString();

            long total = Classes.Database.Count<Classes.TentAreaLandmark>();
            long taken = Classes.Database.Count<Classes.Tent>();
            long freeTents = total - taken;
            freeTentsLbl.Text = "Number of free tent pitches : " + freeTents;
            takenTentsLbl.Text = "Number of tent pitches taken : " + taken;

            if (bookedByVisitorPitches.Count() == 0)
            {
                bookedByLBox.Enabled = false;
                bookedByDetailsBtn.Enabled = false;
            }

            if (bookedForVisitorPitches.Count() == 0)
            {
                bookedForLBox.Enabled = false;
                bookedForDetailsBtn.Enabled = false;
            }

            this.bookedByLBox.Items.AddRange(bookedByVisitorPitches.ToArray());
            this.bookedForLBox.Items.AddRange(bookedForVisitorPitches.ToArray());
        }

        protected override void OnSet()
        {
            MainMenu.Width -= this.detailsPanel.Width;
        }

        private void ProcessBookedBy()
        {
            IEnumerable<Classes.Tent> booked = bookedByVisitorPitches;
            if (booked.Any())
            {
                booked = booked.Where(x => x.BookedTill < DateTime.Now);
                if (booked.Count() > 1)
                {
                    //more than 1
                    booked = booked.Where(x => x.BookedOn.Day == DateTime.Today.Day);
                    if (booked.Any())
                    {
                        if (booked.Count() > 1)
                        {
                            //too many bookings for 1 day
                            return;
                        }
                        //exactly 1
                        if (!booked.First().IsPaid)
                        {
                            //not paid;
                            return;
                        }
                        //OK
                        return;
                    }
                    //no bookings for today
                    return;
                }
                if (booked.Any())
                {
                    //exactly 1
                    if (booked.First().BookedOn.Day == DateTime.Today.Day)
                    {
                        //not booked for today
                        return;
                    }

                    if (!booked.First().IsPaid)
                    {
                        //not paid
                        return;
                    }
                    //OK
                    return;
                }
            }
        }

        private void ProcessBookedFor()
        {
            IEnumerable<Classes.Tent> booked = bookedForVisitorPitches;
            if (booked.Any())
            {
                if (booked.Count() > 1)
                {
                    //is present in more than 1 and is still in time
                    return;
                }
                if (booked.First().BookedOn.Day == DateTime.Today.Day)
                {
                    //not booked for today
                    return;
                }
                // is present in exactly one
                if (!booked.First().IsPaid)
                {
                    //not paid by person who booked it
                    return;
                }
                //OK
                return;
            }
            //all tents have past their booking time
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new BookingForm(this).Show();
        }

        private void showOnMapBtn_Click(object sender, EventArgs e)
        {
            //todo show on map
        }

        private void ShowDetails(ListBox lb)
        {
            ShowDetails(lb.SelectedItem as Classes.Tent);
        }

        private void ShowDetails(Classes.Tent tent)
        {
            if (!detailsPanel.Visible)
                MainMenu.Width += detailsPanel.Width;

            //todo show details
        }

        private void bookedForDetailsBtn_Click(object sender, EventArgs e)
        {
            ShowDetails(bookedForLBox);
        }

        private void bookedByDetailsBtn_Click(object sender, EventArgs e)
        {
            ShowDetails(bookedForLBox);
        }

        private void closeDetailsBtn_Click(object sender, EventArgs e)
        {
            detailsPanel.Visible = false;
            MainMenu.Width -= detailsPanel.Width;
        }
    }
}
