using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointedItem : Item
    {
        public AppointedItem(int id, string brand, string model, string type, string group, string description, string icon) : base(id, brand, model, type, group, description, icon) { }
       
        public AppointedItem(string brand, string model) : this(0, brand, model, "Appointed", "Appointment", null, null) 
        {
        }
        
        public override Record Create()
        {
            return Database.Insert(this, "brand, model,type, group,description,icon",Brand,Model,Type,Group, Description,Icon);
        }
    }
}
