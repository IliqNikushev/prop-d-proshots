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
        List<Classes.Tent> bookedForVisitorPitches;
        List<Classes.Tent> bookedByVisitorPitches;

        public CampingMenu(App_Common.Menu parent) : base(parent)
        {
            InitializeComponent();
        }

        protected override void Reset()
        {
           bookedForVisitorPitches = Classes.Database.GetTentsBookedForVisitor(LoggedInUser as Classes.Visitor);
           bookedByVisitorPitches = Classes.Database.GetTentsBookedByVisitor(LoggedInUser as Classes.Visitor);

            this.todayLbl.Text = "Today it is It is " + DateTime.Now.ToString("dddd dd");

            long total = Classes.Database.Count<Classes.TentPitch>();
            long taken = Classes.Database.Count<Classes.Tent>("|T|.bookedOn > {0} and |T|.bookedTill < {1}", DateTime.Today, DateTime.Today.AddDays(1));
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

            this.bookedByLBox.Items.Clear();
            this.bookedForLBox.Items.Clear();

            this.bookedByLBox.Items.AddRange(bookedByVisitorPitches.ToArray());
            this.bookedForLBox.Items.AddRange(bookedForVisitorPitches.ToArray());

            if(!this.detailsPanel.Visible)
                this.Width -= this.detailsPanel.Width;

            this.detailsPanel.Visible = false;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            new BookingForm(this, bookedByVisitorPitches, bookedForVisitorPitches).Show();
        }

        private void cancelPitchBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel this booking?", "Confirm cancelation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                ActiveTent.Cancel();

                bookedByVisitorPitches = Classes.Database.GetTentsBookedByVisitor(LoggedInUser as Classes.Visitor);
                this.bookedByLBox.Items.Clear();
                this.ShowDetails(null as Classes.Tent);
                this.bookedByLBox.Items.AddRange(bookedByVisitorPitches.ToArray());
            }
        }

        private void ShowDetails(ListBox lb)
        {
            ShowDetails(lb.SelectedItem as Classes.Tent);
        }

        private Classes.Tent ActiveTent = null;

        private void ShowDetails(Classes.Tent tent)
        {
            if (tent == null)
            {
                closeDetailsBtn_Click(null, null);
                return;
            }
            if (!detailsPanel.Visible)
            {
                detailsPanel.Visible = true;
                MainMenu.Width += detailsPanel.Width;
            }

            pitchNumberLbl.Text = "#" + tent.ID;
            dateTimeBookedLbl.Text = tent.BookedOn.ToString("dd HH:mm") + " untill " + tent.BookedTill.ToString("dd HH:mm");
            bookedByLbl.Text = tent.BookedBy.FullName;
            isPaidCbox.Checked = tent.IsPaid;

            isPaidCbox.Text = tent.Price + App_Common.Constants.Currency;
            bookedForDetailsLbox.Items.AddRange(tent.BookedFor);

            if (!tent.IsPaid && tent.BookedBy == LoggedInVisitor)
            {
                ActiveTent = tent;
                cancelPitchBtn.Visible = true;
            }
            else
            {
                cancelPitchBtn.Visible = false;
            }
        }

        private void bookedForDetailsBtn_Click(object sender, EventArgs e)
        {
            ShowDetails(bookedForLBox);
        }

        private void bookedByDetailsBtn_Click(object sender, EventArgs e)
        {
            ShowDetails(bookedByLBox);
        }

        private void closeDetailsBtn_Click(object sender, EventArgs e)
        {
            if (!detailsPanel.Visible) return;
            detailsPanel.Visible = false;
            MainMenu.Width -= detailsPanel.Width;
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            //todo PAY FOR TENT
        }

        private void bookedByLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detailsPanel.Visible)
                ShowDetails(bookedByLBox);
        }

        private void bookedForLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detailsPanel.Visible)
                ShowDetails(bookedForLBox);
        }
    }
}
