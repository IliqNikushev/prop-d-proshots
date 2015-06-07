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
            const int rowHeight = 22;
            public static List<PersonRow> rows = new List<PersonRow>();
            public Classes.Visitor Visitor;
            public TextBox nameTbox;
            public Label priceLbl;
            public Button removeBtn;
            public ListBox autoCompleteLbox;

            public PersonRow(int x, int y, Control parent, Action onRemove)
            {
                y = y + rows.Count * rowHeight;
                this.nameTbox = new TextBox();
                this.nameTbox.Left = x;
                this.nameTbox.Top = y;

                this.nameTbox.Width = 160;
                this.nameTbox.Height = 20;

                x += this.nameTbox.Width;

                this.priceLbl = new Label();
                priceLbl.Visible = false;
                this.priceLbl.Left = x;
                this.priceLbl.Top = y;
                this.priceLbl.Width = 30;
                this.priceLbl.AutoSize = false;
                this.priceLbl.Text = "+" + App_Common.Constants.PricePerPersonForCamp + App_Common.Constants.Currency;

                x += priceLbl.Width;

                this.removeBtn = new Button();
                this.removeBtn.Left = x;
                this.removeBtn.Top = y;
                this.removeBtn.Text = "-";
                this.removeBtn.Width = 17;
                this.removeBtn.Height = 21;

                this.removeBtn.Click += (xx,yy) =>
                {
                    this.Remove();
                    onRemove();
                };
                
                parent.Controls.Add(nameTbox);
                parent.Controls.Add(priceLbl);
                parent.Controls.Add(removeBtn);

                this.nameTbox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                this.nameTbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.nameTbox.AutoCompleteMode = AutoCompleteMode.None;

                rows.Add(this);
            }

            public void Remove()
            {
                this.removeBtn.Parent.Controls.Remove(this.nameTbox);
                this.removeBtn.Parent.Controls.Remove(this.priceLbl);
                this.removeBtn.Parent.Controls.Remove(this.removeBtn);

                int y = 0;
                foreach (PersonRow row in rows)
                {
                    if (row == this)
                        y += rowHeight;
                    else
                    {
                        if (y == 0) continue;

                        row.nameTbox.Top -= rowHeight;
                        row.priceLbl.Top -= rowHeight;
                        row.removeBtn.Top -= rowHeight;
                        row.autoCompleteLbox.Top -= rowHeight;

                        y += rowHeight;
                    }
                }
                rows.Remove(this);
            }
        }

        private IEnumerable<Classes.Tent> bookedByVisitorPitches;
        private IEnumerable<Classes.Tent> bookedForVisitorPitches;
        private IEnumerable<Classes.TentPitch> freeTentPitches;
        private List<Classes.Visitor> Visitors = new List<Classes.Visitor>();

        private string[] NotSelectedVisitors
        {
            get
            {
                if (findByEmailCbox.Checked)
                    return this.Visitors.Select(x => x.Email).Where(x => !PersonRow.rows.Select(y => y.nameTbox.Text).Contains(x)).ToArray();
                else if (findByNameCbox.Checked)
                    return this.Visitors.Select(x => GetVisitor(x)).Where(x => !PersonRow.rows.Select(y => y.nameTbox.Text).Contains(x)).ToArray();
                return new string[] { };
            }
        }

        private int NumberOfRows { get { return PersonRow.rows.Count; } }
        private int NumberOfPeople { get { return People.Count + 1; } }
        private List<Classes.Visitor> People { get { return PersonRow.rows.Select(x => x.Visitor).Where(x => x != null).ToList(); } }

        private decimal TotalPrice { get { return App_Common.Constants.PriceInitialForCamp + App_Common.Constants.PricePerPersonForCamp * NumberOfPeople; } }
        private Classes.TentPitch SelectedPitch { get { return this.pitchesCBox.SelectedItem as Classes.TentPitch; } }

        public BookingForm(App_Common.Menu parent, IEnumerable<Classes.Tent> bookedByVisitorPitches, IEnumerable<Classes.Tent> bookedForVisitorPitches)
            : base(parent)
        {
            InitializeComponent();

            this.bookedByVisitorPitches = bookedByVisitorPitches;
            this.bookedForVisitorPitches = bookedForVisitorPitches;

            base.findByNameLbl.Visible = false;
            base.findByNameTb.Visible = false;
            base.findByTypeLbl.Visible = false;
            base.findByTypeTb.Visible = false;

            dateTimePicker.MinDate = App_Common.Constants.EventStart;
            dateTimePicker.MaxDate = App_Common.Constants.EventEnd;

            this.initialPriceLbl.Text = App_Common.Constants.PriceInitialForCamp + App_Common.Constants.Currency;
            this.pricePerPersonlbl.Text = App_Common.Constants.PricePerPersonForCamp + App_Common.Constants.Currency;

            currentBalanceLbl.Text = "Your balance is : " + LoggedInVisitor.Balance + App_Common.Constants.Currency;

            if (PersonRow.rows != null)
                PersonRow.rows.Clear();

            Visitors = Classes.Database.Where<Classes.Visitor>("Visitors.user_id != {0}", LoggedInVisitor.ID);

            freeTentPitches = Classes.Database.FreeTentPitches;

            UpdateMap();

            ProcessBookedFor();
            ProcessBookedBy();

            pitchesCBox.Items.AddRange(freeTentPitches.ToArray());

            findByTypeTb.Text = "all";

            UpdateState();
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

            foreach (PersonRow row in PersonRow.rows)
            {
                row.nameTbox.AutoCompleteCustomSource.Clear();
                row.nameTbox.AutoCompleteCustomSource.AddRange(NotSelectedVisitors);
                if (row.Visitor != null)
                    row.nameTbox.Text = GetVisitor(row.Visitor);
            }
        }

        private void findByEmailCbox_CheckedChanged(object sender, EventArgs e)
        {
            //todo on changed -> change the collection
            if (findByEmailCbox.Checked && findByNameCbox.Checked) findByNameCbox.Checked = false;
            if (!findByEmailCbox.Checked && !findByNameCbox.Checked) findByNameCbox.Checked = true;

            foreach (PersonRow row in PersonRow.rows)
            {
                row.nameTbox.AutoCompleteCustomSource.Clear();
                row.nameTbox.AutoCompleteCustomSource.AddRange(NotSelectedVisitors);
                if (row.Visitor != null)
                    row.nameTbox.Text = row.Visitor.Email;
            }
        }

        private void confrimBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPitch == null)
            {
                MessageBox.Show("Please select a tent pitch to book.");
                return;
            }
            if (LoggedInVisitor.Balance < TotalPrice)
            {
                MessageBox.Show(string.Format("You do not have enough money in your account.\nYou have {0}, you need {1}.\nYou need {2} more",
                    LoggedInVisitor.Balance + App_Common.Constants.Currency, 
                    TotalPrice + App_Common.Constants.Currency,
                    (TotalPrice - LoggedInVisitor.Balance)+App_Common.Constants.Currency
                    ), "Balance is too low");
                return;
            }

            int nights = (App_Common.Constants.EventEnd - dateTimePicker.Value).Days;
            if (MessageBox.Show(string.Format(
                "Are you sure you wish to book tent pitch #{0}\nFrom {1} evening\nUntill {2} morning ({3} night{4})\nfor {5} visitor{6}?\n- You\n{7}\nTotal price is :{8}{9}",
                SelectedPitch.ID,
                dateFromTbox.Text,
                toDateTbox.Text,
                nights,
                nights == 1 ? "" : "s",
                NumberOfPeople,
                NumberOfPeople == 1 ? "" : "s",
                string.Join("\n", People.Select(x => "- " + x.FullName + " " + x.Email)),
                TotalPrice,
                App_Common.Constants.Currency), "Confirm booking", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Classes.Record result = new Classes.Tent(SelectedPitch, dateFromTbox.Text, toDateTbox.Text, LoggedInVisitor, People).Create();
                if (result == null)
                {
                    MessageBox.Show("The tent pitch was just booked before you by another visitor. Sorry for the inconvenience.");
                }
                else
                {
                    MessageBox.Show("The tent pitch has been reserved!");
                    this.Close();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPersonBtn_Click(object sender, EventArgs e)
        {
            if (NumberOfRows == 4)
                addPersonBtn.Visible = false;
            PersonRow row = new PersonRow(peopleLocation.Left, peopleLocation.Top, this, () => { addPersonBtn.Visible = true; UpdateState(); });

            row.nameTbox.AutoCompleteCustomSource.Clear();
            row.nameTbox.AutoCompleteCustomSource.AddRange(NotSelectedVisitors);

            AddAutoCompleteTo(row.nameTbox,
                (ee) =>
                {
                    if (ee.KeyChar == (char)Keys.Return) // enter
                    {
                        OnAutoComplete[row.nameTbox].Action(row.nameTbox.Text);
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
                    row.priceLbl.Visible = v != null;
                    UpdateState();
                });

            row.autoCompleteLbox = OnAutoComplete[row.nameTbox].ListBox;

            UpdateState();
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

        private void UpdateMap()
        {
            SetMapItems(this.freeTentPitches);
        }

        private void UpdatePitches()
        {
            Classes.TentPitch selectedPitch = SelectedPitch;
            freeTentPitches = Classes.Database.Where<Classes.TentPitch>("|T|.id not in (select {0}.location from {0}) or |T|.id in (select {0}.location from {0} where {0}.bookedTill < {1} or {0}.bookedOn > {2})",
                Classes.Database.TableName<Classes.Tent>(), dateTimePicker.Value, App_Common.Constants.EventEnd);
            UpdateMap();
            pitchesCBox.Items.Clear();
            pitchesCBox.Items.AddRange(freeTentPitches.ToArray());
            if (selectedPitch != null)
            {
                if (!freeTentPitches.Where(x => x.ID == selectedPitch.ID).Any()) // not free any more
                {
                    MessageBox.Show("Tent pitch that you had selected is not free for the new specified period");
                    pitchesCBox.SelectedIndex = 0;
                }
                else
                    for (int i = 0; i < pitchesCBox.Items.Count; i++)
                        if (selectedPitch == pitchesCBox.Items[i] as Classes.TentPitch)
                        {
                            pitchesCBox.SelectedIndex = i;
                            return;
                        }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdatePitches();
            UpdateState();
        }

        private void nightsNUD_ValueChanged(object sender, EventArgs e)
        {
            UpdatePitches();
            UpdateState();
        }

        private void UpdateState()
        {
            dateFromTbox.Text = dateTimePicker.Value.ToString(dateTimePicker.CustomFormat);
            toDateTbox.Text = App_Common.Constants.EventEnd.ToString(dateTimePicker.CustomFormat);

            totalPriceLbl.Text = TotalPrice + App_Common.Constants.Currency;

            if (NumberOfPeople == 1)
                bookedForPeopleLbl.Text = "Booked for 1 person";
            else
                bookedForPeopleLbl.Text = "Booked for " + NumberOfPeople + " people";
        }

        private void pitchesCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.SelectItem(pitchesCBox.SelectedItem as Classes.Landmark);
        }
    }
}
