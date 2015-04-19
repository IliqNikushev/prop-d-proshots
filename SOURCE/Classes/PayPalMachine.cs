using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PayPalMachine : Landmark
    {
        public PayPalMachine(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public void TopUp(Visitor visitor, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
