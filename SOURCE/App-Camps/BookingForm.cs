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
    public partial class BookingForm : App_Common.HomePageWithMap
    {
        class PersonRow
        {
            const int personHeight = 22;
            public static List<PersonRow> people = new List<PersonRow>();
            public Classes.Visitor Visitor;
            public TextBox name;
            public Label price;
            public Label remove;

            public PersonRow(int x, int y, Control parent, Action onRemove)
            {
                y = y + people.Count * personHeight;
                this.name = new TextBox();
                this.name.Left = x;
                this.name.Top = y;

                this.name.Width = 160;
                this.name.Height = 20;

                x += this.name.Width;

                this.price = new Label();
                price.Visible = false;
                this.price.Left = x;
                this.price.Top = y;
                this.price.Text = "+" + App_Common.Constants.PricePerPersonForCamp + App_Common.Constants.Currency;

                x += 20;

                this.remove = new Label();
                this.remove.Left = x;
                this.remove.Top = int.Parse(y.ToString());
                this.remove.Text = "-";
                this.remove.Width = 17;
                this.remove.Height = 21;

                this.remove.Click += (xx,yy) =>
                {
                    onRemove();
                    this.Remove();
                };
                
                parent.Controls.Add(name);
                parent.Controls.Add(price);
                parent.Controls.Add(remove);

                this.name.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                this.name.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.name.AutoCompleteMode = AutoCompleteMode.None;

                people.Add(this);
            }

            public void Remove()
            {
                this.name.Parent.Controls.Remove(this.name);
                this.name.Parent.Controls.Remove(this.price);
                this.name.Parent.Controls.Remove(this.remove);

                int y = personHeight;
                foreach (PersonRow person in people)
                {
                    if (y > 0) y += personHeight;
                    if (person == this)
                        y += personHeight;
                }
                people.Remove(this);
            }
        }

        private IEnumerable<Classes.Tent> bookedByVisitorPitches;
        private IEnumerable<Classes.Tent> bookedForVisitorPitches;
        private IEnumerable<Classes.TentPitch> freeTents;
        private List<Classes.Visitor> Visitors = new List<Classes.Visitor>();

        private int NumberOfPeople { get { return PersonRow.people.Count; } }

        public BookingForm(App_Common.Menu parent, IEnumerable<Classes.Tent> bookedByVisitorPitches, IEnumerable<Classes.Tent> bookedForVisitorPitches)
            : base(parent)
        {
            if (PersonRow.people != null)
                PersonRow.people.Clear();

            InitializeComponent();

            this.bookedByVisitorPitches = bookedByVisitorPitches;
            this.bookedForVisitorPitches = bookedForVisitorPitches;

            Visitors = Classes.Database.Where<Classes.Visitor>("Visitors.user_id != {0}", LoggedInVisitor.ID);

            ProcessBookedFor();
            ProcessBookedBy();

            freeTents = Classes.Database.FreeTentPitches;

            base.findByNameLbl.Visible = false;
            base.findByNameTb.Visible = false;
            base.findByTypeLbl.Visible = false;
            base.findByTypeTb.Visible = false;

            dateTimePicker.MinDate = App_Common.Constants.EventStart;
            dateTimePicker.MaxDate = App_Common.Constants.EventEnd;

            this.initialPriceLbl.Text = App_Common.Constants.PriceInitialForCamp + App_Common.Constants.Currency;
            this.pricePerPersonlbl.Text = App_Common.Constants.PricePerPersonForCamp + App_Common.Constants.Currency;
        }

        protected override void OnSet()
        {
            peopleLocation.Visible = false;
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

        private void findByNameCbox_CheckedChanged(object sender, EventArgs e)
        {
            if (findByEmailCbox.Checked && findByNameCbox.Checked) findByEmailCbox.Checked = false;
            if (!findByEmailCbox.Checked && !findByNameCbox.Checked) findByEmailCbox.Checked = true;
        }

        private void findByEmailCbox_CheckedChanged(object sender, EventArgs e)
        {
            //todo on changed -> change the collection
            if (findByEmailCbox.Checked && findByNameCbox.Checked) findByNameCbox.Checked = false;
            if (!findByEmailCbox.Checked && !findByNameCbox.Checked) findByNameCbox.Checked = true;
        }

        private void confrimBtn_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPersonBtn_Click(object sender, EventArgs e)
        {
            if (NumberOfPeople == 4)
                addPersonBtn.Visible = false;
            PersonRow row = new PersonRow(peopleLocation.Left, peopleLocation.Top, this, () => { addPersonBtn.Visible = true; UpdatePrice(); });

            IEnumerable<string> items = new string[] { };

            if (findByEmailCbox.Checked)
                items = this.Visitors.Select(x => x.Email).Where(x => !PersonRow.people.Select(y => y.name.Text).Contains(x));
            else if (findByNameCbox.Checked)
                items = this.Visitors.Select(x => GetVisitor(x)).Where(x => !PersonRow.people.Select(y => y.name.Text).Contains(x));

            row.name.AutoCompleteCustomSource.AddRange(items.ToArray());

            AddAutoCompleteTo(row.name,
                (ee) =>
                {
                    if (ee.KeyChar == (char)Keys.Return) // enter
                    {
                        OnAutoComplete[row.name].Action(row.name);
                        ee.KeyChar = '\0';
                    }
                },
                (selection) =>
                {
                    Classes.Visitor v = null;
                    if (findByNameCbox.Checked)
                        v = this.Visitors.Where(x => GetVisitor(x) == ((string)selection)).FirstOrDefault();
                    else if (findByEmailCbox.Checked)
                        v = this.Visitors.Where(x => x.Email == (string)selection).FirstOrDefault();
                    row.Visitor = v;
                    row.price.Visible = v != null;
                    row.remove.Visible = v != null;
                });
        }

        private string GetVisitor(Classes.Visitor v)
        {
            if (this.Visitors.Where(x => x.FullName == v.FullName).Count() > 1)
                return v.FullName + " " + v.Email;
            return v.FullName;
        }

        private Classes.Visitor FindVisitor(string name)
        {
            return this.Visitors.Where(x => GetVisitor(x) == name).First();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateFromTbox.Text = dateTimePicker.Value.ToString(dateTimePicker.CustomFormat);
            toDateTbox.Text = (dateTimePicker.Value.AddDays((double)nightsNUD.Value)).ToString(dateTimePicker.CustomFormat);

            UpdatePrice();
        }

        private void UpdatePrice()
        {
            decimal price = App_Common.Constants.PricePerPersonForCamp * NumberOfPeople;
            totalPriceLbl.Text = price+App_Common.Constants.Currency;
        }

        private void nightsNUD_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
