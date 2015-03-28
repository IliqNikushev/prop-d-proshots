using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    public class DeleteQueryBuilder<T> : WhereQueryBuilder<T> where T : Record
    {
        protected override string Build
        {
            get
            {
                return "Delete From {0}\n" + base.Build;
            }
        }

        public DeleteQueryBuilder<T> Delete(string whereClause)
        {
            base.Where(whereClause);
            return this;
        }

        public DeleteQueryBuilder<T> Delete(Record record)
        {
            base.Where(record);
            return this;
        }
    }
}
