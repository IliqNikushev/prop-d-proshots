using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Job : Landmark
    {
        public Job(string id, string label, string description, int x, int y) : base(id, label, description, x, y) { }

        public int Employees
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
