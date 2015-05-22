using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class LogMessage : Record
    {
        public int ID { get; private set; }
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public LogMessage(int id, DateTime date, string name, string description)
        {
            this.ID = id;
            this.Date = date;
            this.Name = name;
            this.Description = description;
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
