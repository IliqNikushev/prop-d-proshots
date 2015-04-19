using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Landmark
    {
        public Landmark(string id, string label, string description, int x, int y)
        {
            this.ID = id;
            this.Label = label;
            this.Description = description;
            this.X = x;
            this.Y = y;
        }
    
        public int X
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Y
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Label
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Description
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string ID
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
