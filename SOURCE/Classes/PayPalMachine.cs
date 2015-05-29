using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PayPalMachine : Landmark
    {
        public PayPalMachine(int id, int x, int y) : base(id, "PayPal machine", "PayPal machine to top-up your event account", x, y) { }

        public void TopUp(Visitor visitor, decimal amount)
        {
            new LogMessage("top-up", this.ID + " " + visitor.ID + " " + amount).SendToDatabase();
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
