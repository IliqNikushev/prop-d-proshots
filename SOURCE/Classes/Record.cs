﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public abstract class Record
    {
        protected string Table { get { return Database.TableNameFor(this.GetType()); } }
        public abstract void Save();
        public abstract void Update();
    }
}