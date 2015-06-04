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
            }
            else
            {
                bookedByVisitorPitches = tents.Where(x => x.BookedBy == LoggedInUser);
                bookedForVisitorPitches = tents.Where(x => x.BookedBy != LoggedInUser);
            }

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

            this.bookedByLBox.Items.AddRange(bookedByVisitorPitches.ToArray());
            this.bookedForLBox.Items.AddRange(bookedForVisitorPitches.ToArray());

            this.Width -= this.detailsPanel.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            new BookingForm(this, bookedByVisitorPitches, bookedForVisitorPitches).Show();
        }

        private void cancelPitchBtn_Click(object sender, EventArgs e)
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

            pitchNumberLbl.Text = "#" + tent.ID;
            dateTimeBookedLbl.Text = tent.BookedOn.ToString("dd HH:mm") + " " + tent.BookedTill.ToString("dd HH:mm");
            bookedByLbl.Text = tent.BookedBy.FullName;
            isPaidCbox.Checked = tent.IsPaid;
            isPaidCbox.Text = tent.Price + App_Common.Constants.Currency;
            bookedForDetailsLbox.Items.AddRange(tent.BookedFor);
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
    }
}
