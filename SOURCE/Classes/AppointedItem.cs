using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class AppointedItem : Item
    {
        public AppointedItem(int id, string brand, string model, string type, string group, string description, string icon) : base(id, brand, model, type, group, description, icon) { }
       
        public AppointedItem(string brand, string model) : this(0, brand, model, "Appointed", "Appointment", "", "") 
        {
        }

        public override Record Create()
        {
            int id = 0; 
            Database.ExecuteSQL("INSERT INTO `dbi317294`.`items` (`Brand`, `Model`, `Type`, `Description`) VALUES ('{0}', '{1}', '{2}', '{3}');",this.Brand,this.Model,this.Type,this.Description);
            Database.ExecuteSQLWithResult("SELECT ID FROM `items` WHERE Brand = '{0}' AND Model = '{1}' AND Type = '{2}' ORDER BY ID DESC limit 1;", x => { x.Read(); id = x.GetInt("ID"); },this.Brand,this.Model,this.Type);
            return Database.Find<AppointedItem>("|T|.ID = {0}", id);
        }
        public override string ToString()
        {
            return Brand + " " + Model;
        }
    }
}
