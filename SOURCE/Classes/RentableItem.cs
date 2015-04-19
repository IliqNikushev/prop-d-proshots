using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class RentableItem : Item
    {
        public DateTime RentedAt { get; private set; }
        public DateTime ReturnedAt { get; private set; }

        public Visitor RentedBy
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public RentableItem(int id, decimal price, string brand, string model, string type): base(id, price, brand, model, type)
        {
        }

        public void Hire(Classes.Visitor visitor)
        {
            visitor.Hire(this);
            this.RentedBy = visitor;
            this.RentedAt = DateTime.Now;
        }

        public void Return()
        {
            this.RentedBy.Return(this);
            this.RentedBy = null;
            this.ReturnedAt = DateTime.Now;
        }
    }
}
