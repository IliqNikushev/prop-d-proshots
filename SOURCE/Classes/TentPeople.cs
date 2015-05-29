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
        public TentPitch TentPitch { get; private set; }
        public DateTime CheckedInTime { get; private set; }

        public Tent Tent { get { return Database.GetTent(this.TentPitch); } }

        public TentPerson(int id, Visitor visitor, TentPitch tent, DateTime checkedInTime)
            : base(id)
        {
            this.TentPitch = tent;
            this.Visitor = visitor;
            this.CheckedInTime = checkedInTime;
        }

        protected override void Create()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
