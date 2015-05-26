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
        IEnumerable<Classes.Tent> bookedByVisitor;
        IEnumerable<Classes.Tent> bookedForVisitor;
        public CampingMenu(List<Classes.Tent> tents, App_Common.Menu parent) : base(parent)
        {
            InitializeComponent();

            if (!tents.Any())
            {
                this.bookedByVisitor = new List<Classes.Tent>();
                this.bookedForVisitor = new List<Classes.Tent>();
                return;
            }

            bookedByVisitor = tents.Where(x => x.BookedBy == LoggedInUser);
            bookedForVisitor = tents.Where(x => x.BookedBy != LoggedInUser);
        }

        private void ProcessBookedBy()
        {
            IEnumerable<Classes.Tent> booked = bookedByVisitor;
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
            IEnumerable<Classes.Tent> booked = bookedForVisitor;
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
    }
}
