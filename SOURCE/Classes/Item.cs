﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Item : Record
    {
        #region examples
        /*    
         * 0, Lays, Salted 200g, Potato Chips, 1.20
        */
        #endregion

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Type { get; private set; }
        public string Group { get; private set; }
        public string Description { get; private set; }
        //public Image Icon{get; private set;}

        public Item(int id, string brand, string model, string type, string group, string description)
            : base(id)
        {
            this.Brand = brand;
            this.Model = model;
            this.Type = type;
            this.Group = group;
            this.Description = description;
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
