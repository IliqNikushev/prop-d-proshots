using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class ITService : EmploymentPlace
    {
        public ITService(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }
    }
}
