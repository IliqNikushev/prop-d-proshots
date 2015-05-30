using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Warning : Record
    {
        public Warning(int id, string name, string description) : base(id)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
