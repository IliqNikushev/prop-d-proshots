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
        Visitor visitor;
        public Visitor Visitor
        {
            get
            {
                if(visitor == null)
                    visitor = Database.Find<Visitor>("Visitors.user_id = {0}", this.ID);
                else
                    if(visitor.ID != this.ID)
                        visitor = Database.Find<Visitor>("Visitors.user_id = {0}", this.ID);
                return visitor;
            }
        }

        public Deposit(int id, decimal amount, DateTime date, PayPalDocument document)
            : base(id)
        {
            this.Amount = amount;
            this.Date = date;
            this.Document = document;
        }

        protected override void Create()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
