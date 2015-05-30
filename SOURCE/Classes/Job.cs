using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Job : Landmark
    {
        public Job(int id, string label, string description, string logo, int x, int y) : base(id, label, description, logo, x, y) { }

        public List<Employee> Employees
        {
            get
            {
                return Database.Where<Employee>("Employees.workplace_id = {0}", this.ID);
            }
        }

        public override Record Create()
        {
            throw new NotToBeSentToDatabaseException();
        }
    }
}
