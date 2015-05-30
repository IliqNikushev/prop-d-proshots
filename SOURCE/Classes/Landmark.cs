using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Landmark : Record
    {
        protected abstract string Type { get; }
        public Landmark(int id, string label, string description, string icon, int x, int y) : base(id)
        {
            this.Label = label;
            this.Description = description;
            this.X = x;
            this.Y = y;
            this.Icon = icon;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Icon { get; private set; }
        public string Label { get; private set; }
        public string Description { get; private set; }

        public override Record Create()
        {
            Record inserted = Database.Insert(this, "label, description, x, y, type", this.Label, this.Description, this.X, this.Y, this.Type);

            return inserted;
        }
    }
}
