using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class InformationKioskJob : Job
    {
        public InformationKioskJob(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public int NumberOfCardsAvailable
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int NumberOfCardsTaken
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void GiveIDCardToVisitor(Visitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}
