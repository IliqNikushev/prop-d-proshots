using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class LogMessage : Record
    {
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public LogMessage(int id, DateTime date, string name, string description)
            : base(id)
        {
            this.Date = date;
            this.Name = name;
            this.Description = description;
        }

        public LogMessage(string name, string description) : base(0)
        {
            this.Name = name;
            this.Description = description;
            this.Date = DateTime.Now;
        }

        protected override void Save()
        {
            Database.Insert(this, "date, name, description", this.Date, this.Name, this.Description);
        }

        protected override void Update()
        {
            Database.Update(this, 
                "name = {0}, date = {1}, description = {2}".
                Arg(this.Name, this.Date, this.Description),
                "id = {0}".Arg(ID));
        }
    }
}
