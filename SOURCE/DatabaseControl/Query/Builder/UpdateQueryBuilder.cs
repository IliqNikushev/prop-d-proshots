using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public class UpdateQueryBuilder<T> : WhereQueryBuilder<T> where T : Record
    {
        private List<string> updateFields = new List<string>();

        public UpdateQueryBuilder(T record)
        {
            this.Set(record).Find(record);
        }

        protected override string Build
        {
            get
            {
                return "Update {0}\nSet {1}\n" + base.Build;
            }
        }

        public UpdateQueryBuilder<T> Set(Record record)
        {
            //bascially where
            //set name = 'test' where name ='Test'

#warning TODO : Update Query
            return this;
        }
    }
}
