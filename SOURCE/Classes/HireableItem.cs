using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class HireableItem : Item
    {
        public uint InStock { get; private set; }

        public User HiredBy { get; private set; }
        public DateTime HiredOn { get; private set; }
        public DateTime ReturnedOn { get; private set; }

        public HireableItem(int id, string name, decimal price, uint inStock) : base(id, name, price) 
        {
            this.InStock = InStock;
        }

        public void Hire(User user)
        {
            user.Hire(this);
            this.HiredBy = user;
            this.HiredOn = DateTime.Now;
        }

        public void Return()
        {
            this.HiredBy.Return(this);
            this.HiredBy = null;
            this.ReturnedOn = DateTime.Now;
        }
    }
}
