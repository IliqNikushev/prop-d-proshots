using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class EmploymentPlace : Landmark
    {
        public EmploymentPlace(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }
    }
}
