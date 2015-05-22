using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class InformationKioskJob : Job
    {
        public InformationKioskJob(int id, int x, int y) : base(id, "Information desk", "Here you can get information about the event and your card", x, y) { }

        private long numberOfCardsTaken;
        private int numberOfCardsTotal;

        public long NumberOfCardsAvailable {get{return this.NumberOfCardsTotal - this.NumberOfCardsTaken;}}
        public long NumberOfCardsTaken {get {return this.numberOfCardsTaken;}}
        public int NumberOfCardsTotal { get { return this.numberOfCardsTotal; } }

        public void RefreshCards()
        {
            Database.MiscTable misc = Database.Misc;
            this.numberOfCardsTotal = misc.NumberOfCardsTotal;
            this.numberOfCardsTaken = misc.NumberOfCardsTaken;
        }

        public void GiveIDCardToVisitor(Visitor visitor, string tag)
        {
            if (visitor.RFID != null)
                throw new InvalidOperationException("User already has RFID");

            Database.ExecuteSQL("UPDATE visitors SET rfid = '{0}' WHERE visitors.user_id = {1}", tag, visitor.Id);

            this.RefreshCards();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
