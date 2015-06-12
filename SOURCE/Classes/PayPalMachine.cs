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
            new LogMessage("top-up", "at:{0} from:{1} previously:{2} changed:{3}".Args(this.ID, visitor.ID, visitor.Balance, amount)).Create();
        }
    }
}
