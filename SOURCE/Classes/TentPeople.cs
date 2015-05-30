using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class TentPerson : Record
    {
        public Visitor Visitor { get; private set; }
        public Tent Tent { get; private set; }
        public DateTime CheckedInTime { get; private set; }

        public TentPerson(int id, Visitor visitor, Tent tent, DateTime checkedInTime)
            : base(id)
        {
            this.Tent = tent;
            this.Visitor = visitor;
            this.CheckedInTime = checkedInTime;
        }

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
