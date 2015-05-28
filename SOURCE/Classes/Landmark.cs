using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Landmark : Record
    {
        public Landmark(int id, string label, string description, int x, int y) : base(id)
        {
            
            this.Label = label;
            this.Description = description;
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Label { get; private set; }
        public string Description { get; private set; }

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
