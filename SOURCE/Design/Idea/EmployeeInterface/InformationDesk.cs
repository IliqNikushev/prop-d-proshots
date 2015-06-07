﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Design.Idea.EmployeeInterface
{
    public partial class InformationDesk : Menu
    {
        List<Visitor> Visitors = Database.All<Visitor>();


        public InformationDesk()
        {
            InitializeComponent();
            UpdateListBox();


        }

        private void UpdateListBox()
        {
            Visitors = Database.All<Visitor>();
            int Max = -1;
            foreach (var item in Visitors)
            {
                int length = item.ToString().Length;
                if (length > Max)
                {
                    Max = length;
                }
            }
            listBox1.Items.Clear();
            foreach (Visitor I in Visitors)
            {
                string Vis = I.ToString();
                if (Vis.StartsWith(visitorSearchTbox.Text))
                {

                    Vis = Vis + new string(' ', (Max - Vis.Length) * 2);
                    listBox1.Items.Add(new ListboxVisitor(I));


                }
            }
        }

        private void visitorSearchTbox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void payTicketBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //((LoggedInUser as Employee).Workplace as InformationKioskWorkplace).GiveIDCardToVisitor;
                decimal Price;
                DateTime EventDate = new DateTime(2015, 6, 24);
                if (DateTime.Today > EventDate)
                {
                    Price = 65;
                }
                else
                {
                    Price = 55;
                }
                Visitor I = (listBox1.SelectedItem as ListboxVisitor).CurrentVisitor;
                decimal VisitorBalance = I.Balance;
                try
                {

                    if (I.Ticket == false)
                    {
                        I.PayTicket(VisitorBalance, Price);
                        MessageBox.Show("Ticket payed!");
                        UpdateListBox();
                    }
                    else
                    {
                        MessageBox.Show("Visitor already have a ticket!");
                    }
                }
                catch (Exception ex) { MessageBox.Show("error, " + ex.Message); }


            }
            else { MessageBox.Show("Please select visitor"); }
        }


        private void giveTagBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string RTag = reader.LastTag;
                Visitor I = (listBox1.SelectedItem as ListboxVisitor).CurrentVisitor;
                int VisID = I.ID;
                Visitor vis = Database.Find<Visitor>("id = {0}", VisID);
                InformationKioskWorkplace d = new InformationKioskWorkplace(0, 0, 0);
                try
                {
                    d.GiveIDCardToVisitor(vis, RTag);
                }
                catch (Exception ex) { MessageBox.Show("error," + ex.Message); }
                UpdateListBox();
            }
            else { MessageBox.Show("Please select visitor"); }
        }

        private void closeAccountBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ListboxVisitor SelectedItem = listBox1.SelectedItem as ListboxVisitor;

                Visitor vis = SelectedItem.CurrentVisitor;
                try
                {
                    vis.CloseAccount();
                    Visitors = Database.All<Visitor>();
                    MessageBox.Show("Account successfully closed");

                }
                catch (Exception ex) { MessageBox.Show("error," + ex.Message); }

                UpdateListBox();
            }
            else { MessageBox.Show("Please select visitor"); }
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class ListboxVisitor
    {
        public Visitor CurrentVisitor;
        string Ticket = "No ticket";
        string RFID = "RFID:  ";
        public ListboxVisitor(Visitor Visitor)
        {
            this.CurrentVisitor = Visitor;
            if (Visitor.Ticket == true)
            {
                Ticket = "Have ticket";
            }

            if (CurrentVisitor.RFID == null || CurrentVisitor.RFID == "")
            {
                RFID = "No RFID";
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-50}{1,-5}{2,25}{3}", CurrentVisitor.FullName, Ticket, RFID, CurrentVisitor.RFID);
        }
    }
}
