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

namespace App_Admin
{
    public partial class Visitors : App_Common.Menu
    {
        private List<Visitor> visitors;
        private List<RentableItemHistory> rentableItems;
        private List<ReceiptItem> receiptItems;
        private List<Appointment> appointments;
        private List<Tent> bookedTents;
        private List<Deposit> deposits;
        Color defaultColor = Color.White;
        
        List<Record> listToShow ;
        private Button currentButton;
       
        private AdminUser currentAdmin;
        public Visitors(App_Common.Menu parent) : base(parent)
        {
            InitializeComponent();
            visitors = Database.Visitors;
            rentableItems = Database.All<RentableItemHistory>();
            receiptItems = Database.All<ReceiptItem>();
            appointments = Database.Appointments;
            bookedTents = Database.All<Tent>();
            deposits = Database.All<Deposit>();
            defaultColor = buttonTopUps.BackColor;

            currentButton = buttonAll;
            ButtonAll_Click(null,null);

        }
        public void AddToListBox(List<Record> r)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(r.ToArray());

        }

        public void AddToListBox(List<string> r)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(r.ToArray());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            listToShow = new List<Record>();

            if (comboBoxDate.Text== "All" || comboBoxDate.Text=="")
            {
                if (textBoxVisitor.Text== "")
                {
                    listToShow.AddRange(
                rentableItems,
                receiptItems,
                appointments,
                bookedTents,
                deposits);
                }
                else
                {

                    listToShow.AddRange(
                rentableItems.Where(x=> x.RentedBy.FullName.Contains(textBoxVisitor.Text)),
                receiptItems.Where(x=> x.Receipt.PurchasedBy.FullName.Contains(textBoxVisitor.Text)),
                appointments.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text)),
                bookedTents.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text)),
                deposits.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }
                
            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                rentableItems.Where(x => x.RentedAt.Day== day),
                receiptItems.Where(x => x.Receipt.PurchasedOn.Day == day),
                appointments.Where(x => x.AppointedOn.Day == day),
                bookedTents.Where(x => x.BookedOn.Day == day),
                deposits.Where(x => x.Date.Day== day));
                }
                else
                {

                    listToShow.AddRange(
                rentableItems.Where(x =>  x.RentedAt.Day== day && x.RentedBy.FullName.Contains(textBoxVisitor.Text)),
                receiptItems.Where(x => x.Receipt.PurchasedOn.Day == day && x.Receipt.PurchasedBy.FullName.Contains(textBoxVisitor.Text)),
                appointments.Where(x => x.AppointedOn.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)),
                bookedTents.Where(x => x.BookedOn.Day == day && x.BookedBy.FullName.Contains(textBoxVisitor.Text)),
                deposits.Where(x => x.Date.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }
            }

            currentButton.BackColor = defaultColor;
            currentButton = buttonAll;
            currentButton.BackColor = Color.Bisque;


            

           // listToShow.AddRange(visitors,
            //    rentableItems,
            //    receiptItems.Where(x => x.Receipt.PurchasedOn.Day == int.Parse(comboBoxDate.Text)),
           //     appointments,
           //     bookedTents,
           //     deposits);
            
            
            AddToListBox(listToShow);



        }

        private void buttonloaned_Click(object sender, EventArgs e)
        {
            listToShow = new List<Record>();

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "")
            {
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                rentableItems);
                }
                else
                {

                    listToShow.AddRange(
                rentableItems.Where(x => x.RentedBy.FullName.Contains(textBoxVisitor.Text))
                );
                }

            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                rentableItems.Where(x => x.RentedAt.Day == day)
                );
                }
                else
                {

                    listToShow.AddRange(
                rentableItems.Where(x => x.RentedAt.Day == day && x.RentedBy.FullName.Contains(textBoxVisitor.Text)));
                }
            }
            currentButton.BackColor =defaultColor;
            currentButton = buttonloaned;
            currentButton.BackColor = Color.Bisque;

            AddToListBox(listToShow);


        }

        private void buttonTransactions_Click(object sender, EventArgs e)
        {
            /*List<string> listToShow = new List<string>();

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "")
            {
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                rentableItems.Select(x=> "Loaned a " + x.RentedItem.Brand + " " + x.RentedItem.Model + " for " + x.Price),
                receiptItems.Select(x => "Purchased a " + x.Item.Brand + " " + x.Item.Model + " for " + x.PricePerItem + " X " +x.Times),
                appointments.Select(x=> "Appointment by "+ x.Visitor + " for " + x.Price + " " ),
                bookedTents.Select(x=> "Booked by " + x.BookedBy+ " for " + x.NumberOfPeople+ " people, Price = "+ x.Price),
                deposits.Select(x => "Deposit by " +x.Visitor + " amount=  "+x.Amount + " on " + x.Date));
                }
                else
                {

                    listToShow.AddRange(
                rentableItems.Select(x => x.RentedBy.FullName.Contains(textBoxVisitor.Text)),
                receiptItems.Where(x => x.Receipt.PurchasedBy.FullName.Contains(textBoxVisitor.Text)),
                appointments.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text)),
                bookedTents.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text)),
                deposits.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }

            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                rentableItems.Where(x => x.RentedAt.Day == day),
                receiptItems.Where(x => x.Receipt.PurchasedOn.Day == day),
                appointments.Where(x => x.AppointedOn.Day == day),
                bookedTents.Where(x => x.BookedOn.Day == day),
                deposits.Where(x => x.Date.Day == day));
                }
                else
                {

                    listToShow.AddRange(
                rentableItems.Where(x => x.RentedAt.Day == day && x.RentedBy.FullName.Contains(textBoxVisitor.Text)),
                receiptItems.Where(x => x.Receipt.PurchasedOn.Day == day && x.Receipt.PurchasedBy.FullName.Contains(textBoxVisitor.Text)),
                appointments.Where(x => x.AppointedOn.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)),
                bookedTents.Where(x => x.BookedOn.Day == day && x.BookedBy.FullName.Contains(textBoxVisitor.Text)),
                deposits.Where(x => x.Date.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }
            }
            currentButton.BackColor =defaultColor;
            currentButton = buttonTransactions;
            currentButton.BackColor = Color.Bisque;

            AddToListBox(listToShow);*/
        }

        private void buttonPurchased_Click(object sender, EventArgs e)
        {
            listToShow = new List<Record>();

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "")
            {
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                receiptItems);
                }
                else
                {

                    listToShow.AddRange(
                receiptItems.Where(x => x.Receipt.PurchasedBy.FullName.Contains(textBoxVisitor.Text))
                );
                }

            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                receiptItems.Where(x => x.Receipt.PurchasedOn.Day == day)
                );
                }
                else
                {

                    listToShow.AddRange(
                receiptItems.Where(x => x.Receipt.PurchasedOn.Day == day && x.Receipt.PurchasedBy.FullName.Contains(textBoxVisitor.Text)));
                }
            }
            currentButton.BackColor =defaultColor;
            currentButton = buttonPurchased;
            currentButton.BackColor = Color.Bisque;

            AddToListBox(listToShow);
        }

        private void buttonAppointment_Click(object sender, EventArgs e)
        {
            listToShow = new List<Record>();

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "")
            {
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                appointments);
                }
                else
                {

                    listToShow.AddRange(
                appointments.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text))
                );
                }

            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                appointments.Where(x => x.AppointedOn.Day == day)
                );
                }
                else
                {

                    listToShow.AddRange(
                appointments.Where(x => x.AppointedOn.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }
            }
            currentButton.BackColor =defaultColor;
            currentButton = buttonAppointment;
            currentButton.BackColor = Color.Bisque;

            AddToListBox(listToShow);
        }

        private void buttonTopUps_Click(object sender, EventArgs e)
        {
            listToShow = new List<Record>();

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "")
            {
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                deposits);
                }
                else
                {

                    listToShow.AddRange(
                deposits.Where(x => x.Visitor.FullName.Contains(textBoxVisitor.Text))
                );
                }

            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                deposits.Where(x => x.Date.Day == day)
                );
                }
                else
                {

                    listToShow.AddRange(
                deposits.Where(x => x.Date.Day == day && x.Visitor.FullName.Contains(textBoxVisitor.Text)));
                }
            }
            currentButton.BackColor =defaultColor;
            currentButton = buttonTopUps;
            currentButton.BackColor = Color.Bisque;

            AddToListBox(listToShow);
        }

        private void buttonTent_Click(object sender, EventArgs e)
        {
            listToShow = new List<Record>();

            if (comboBoxDate.Text == "All" || comboBoxDate.Text == "")
            {
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                bookedTents);
                }
                else
                {

                    listToShow.AddRange(
                bookedTents.Where(x => x.BookedBy.FullName.Contains(textBoxVisitor.Text))
                );
                }

            }
            else
            {
                int day = int.Parse(comboBoxDate.Text);
                if (textBoxVisitor.Text == "")
                {
                    listToShow.AddRange(
                bookedTents.Where(x => x.BookedOn.Day == day)
                );
                }
                else
                {

                    listToShow.AddRange(
                bookedTents.Where(x => x.BookedOn.Day == day && x.BookedBy.FullName.Contains(textBoxVisitor.Text)));
                }
            }
            currentButton.BackColor =defaultColor;
            currentButton = buttonTent;
            currentButton.BackColor = Color.Bisque;

            AddToListBox(listToShow);
        }

    }

    static class Extentions
    {
        public static void AddRange<T>(this List<T> list, params IEnumerable<T>[] items)
        {
            foreach (var item in items)
            {
                list.AddRange(item);
            }
        }
    }
}
