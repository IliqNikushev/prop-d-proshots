﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Deposit made by Paypal Transaction
    /// </summary>
    public class Deposit
    {
        public string ID { get; private set; }
        public decimal Amount { get; private set; }

        public Visitor Visitor
        {
            get
            {
                return User.Authenticate(this.ID) as Visitor;
            }
        }

        public Deposit(string id, decimal amount)
        {
            this.ID = id;
            this.Amount = amount;
        }
    }
}
