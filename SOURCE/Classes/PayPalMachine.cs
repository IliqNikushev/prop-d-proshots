using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PayPalMachine : Landmark
    {
        protected override string Type
        {
            get { return "paypal"; }
        }

        public PayPalMachine(int id, int x, int y) : base(id, "PayPal machine", "PayPal machine to top-up your event account", "paypal-logo.jpg", x, y) { }

        public void TopUp(Visitor visitor, decimal amount)
        {
            new LogMessage("top-up", this.ID + " " + visitor.ID + " " + amount).Create();
        }
    }
}
