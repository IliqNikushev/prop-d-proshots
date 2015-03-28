using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public class Visitor : Record<Visitor>
    {
        public string Name { get { return this.Attributes["Name"] as string; } set { this.Attributes["Name"] = value; } }
        public string ID { get { return this.Attributes["ID"] as string; } set { this.Attributes["ID"] = value; } }

        public override string[] IdentificatorFields
        {
            get { return new string[] { "ID" }; }
        }

        public override object IdentificatorValue
        {
            get { return this.ID; }
        }

        public Visitor() : base() { }

        public Visitor(string name, string id) { this.Name = name; this.ID = id; }
    }
}
