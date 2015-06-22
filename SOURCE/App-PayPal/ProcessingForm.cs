using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_PayPal
{
    public partial class ProcessingForm : App_Common.Menu
    {
        private decimal alteredBalance = 0;
        private decimal Difference { get { return alteredBalance - LoggedInVisitor.Balance; } }

        public ProcessingForm(App_Common.Menu parent)
            : base(parent)
        {
            InitializeComponent();
            withdrawNotAllowedLbl.Visible = false;
            this.profilePBox.ImageLocation = LoggedInVisitor.Picture;
            this.nameLbl.Text = LoggedInUser.FullName;
            this.balanceLbl.Text = LoggedInVisitor.Balance.ToString() + App_Common.Constants.Currency;

            this.amountTbox.SetToNumeric("value");

            this.amountTbox.TextChanged += (x, y) => 
            {
                UpdateResult();
            };

            this.resultLbl.Text = this.balanceLbl.Text;

            this.amountTbox.Text = "";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(
                "You are about to cancel your top-up", "Top-up cancel", MessageBoxButtons.OKCancel
                ) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }

        private void topUpBtn_Click(object sender, EventArgs e)
        {
            if (Difference == 0)
            {
                if (MessageBox.Show(
                    "You have not made any changes to your balance, is this correct?", "Top-up confirm", MessageBoxButtons.YesNo
                    ) == System.Windows.Forms.DialogResult.Yes)
                    this.cancelBtn_Click(sender, e);
                return;
            }
            if (Difference < 5)
            {
                this.amountTbox.Text = old;
                MessageBox.Show("Minimum deposit is 5" + App_Common.Constants.Currency);
                return;
            }

            if (MessageBox.Show(
                "You are about to change your balance with " + Difference + App_Common.Constants.Currency+ " making it " + alteredBalance+App_Common.Constants.Currency+ "\nContinue with the top-up?", "Top-up confirm", MessageBoxButtons.YesNo
                ) == System.Windows.Forms.DialogResult.Yes)
            {
                //todo get user permission / passcode for the transaction
                MessageBox.Show("Please enter your Pay-Pal details for the top-up in the terminal");
                Install.Machine.TopUp(LoggedInVisitor, alteredBalance);
                MessageBox.Show("Your request has been sent. Waiting for paypal to confirm. Check your balance in a minute");

                Classes.PayPalDocument d = Classes.Database.Insert<Classes.PayPalDocument>("date, raw", DateTime.Now, "");
                Classes.Database.Insert<Classes.Deposit>("date, amount, visitor_id, paypal_document_id", d.Date, alteredBalance - LoggedInVisitor.Balance, LoggedInVisitor.ID, d.ID);

                LoggedInVisitor.ChangeBalanceTo(alteredBalance, "top-up");
                this.Close();
            }
        }

        private string old = "";

        private void UpdateResult()
        {
            decimal amount = 0;
            if (!decimal.TryParse(this.amountTbox.Text, out amount))
                return;
            if(amount > 5000)
            {
                this.amountTbox.Text = old;
                MessageBox.Show("The number is too big for an event of this size.");
                return;
            }
            
            old = this.amountTbox.Text;

            if (addCBox.Checked)
                alteredBalance = amount + LoggedInVisitor.Balance;
            else if (setCBox.Checked)
                alteredBalance = amount;
            if (Difference < 0)
            {
                alteredBalance = LoggedInVisitor.Balance;
                withdrawNotAllowedLbl.Visible = true;
            }
            else
                if (withdrawNotAllowedLbl.Visible)
                    withdrawNotAllowedLbl.Visible = false;
            if (setCBox.Checked)
                resultLbl.Text = "+" + Difference.ToString() + App_Common.Constants.Currency;
            else
                resultLbl.Text = alteredBalance.ToString() + App_Common.Constants.Currency;
        }

        private void addCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (setCBox.Checked && addCBox.Checked) setCBox.Checked = false;
            UpdateResult();
        }

        private void setCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (setCBox.Checked && addCBox.Checked) addCBox.Checked = false;
            UpdateResult();
        }
    }
}
