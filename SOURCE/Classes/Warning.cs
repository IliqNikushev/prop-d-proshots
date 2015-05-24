using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Warning : Record
    {
        public Warning(int id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
