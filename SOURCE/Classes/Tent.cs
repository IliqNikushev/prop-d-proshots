using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Tent
    {
        public Tent(Visitor bookedBy, params Visitor[] people)
        {
            throw new System.NotImplementedException();
        }
    
        public int NumberOfPeople
        {
            get { return BookedFor.Length; }
        }

        public Visitor BookedBy
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Visitor[] BookedFor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool IsPaid
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public decimal Price
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Pay()
        {
            throw new System.NotImplementedException();
        }
    }
}
