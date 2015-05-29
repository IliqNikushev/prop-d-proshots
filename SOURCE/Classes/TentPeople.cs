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

        protected override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
