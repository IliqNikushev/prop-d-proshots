using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Deposit
    {
        public int ID { get; private set; }
        public decimal Amount { get; private set; }

        public Deposit(int id, decimal amount)
        {
            this.ID = id;
            this.Amount = amount;
        }
    }
}
