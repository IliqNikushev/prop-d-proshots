using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class InformationKioskJob : Job
    {
        public InformationKioskJob(string id, string label, string description, int x, int y, int availableCards) : base(id, label, description, x, y) { this.NumberOfCardsAvailable = availableCards; }

        public int NumberOfCardsAvailable { get; private set; }
        public int NumberOfCardsTaken { get; private set; }

        public void GiveIDCardToVisitor(Visitor visitor, string tag)
        {
            if (visitor.RFID != null)
                throw new InvalidOperationException("User already has RFID");

            Database.ExecuteSQL("UPDATE visitors SET rfid = '{0}' WHERE visitors.user_id = {1}", tag, visitor.Id);
        }
    }
}
