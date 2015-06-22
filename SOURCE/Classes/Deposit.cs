using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Deposit made by Paypal Transaction
    /// </summary>
    public class Deposit : Record
    {
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public PayPalDocument Document { get; private set; }
        private int visitor_id = 0;
        public Visitor Visitor
        {
            get
            {
                if (visitor_id == 0) return null;
                return Database.Find<Visitor>("|T|.user_id = {0}", this.visitor_id);
            }
        }

        public Deposit(int id, decimal amount, DateTime date, PayPalDocument document, int visitor_id)
            : base(id)
        {
            this.Amount = amount;
            this.Date = date;
            this.Document = document;
            this.visitor_id = visitor_id;
        }

        public override Record Create()
        {
            return Database.Insert(this, "date, amount, visitor_id, paypal_document_id", this.Date, this.Amount, this.visitor_id, this.Document.ID);
        }
    }
}
