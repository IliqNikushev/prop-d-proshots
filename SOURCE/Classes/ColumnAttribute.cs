using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    sealed class ColumnAttribute : Attribute
    {
        public string Name { get; private set; }
        public ColumnAttribute(string name)
        {
            this.Name = name;
        }
    }
}
