using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Exceptions
{
    [Serializable]
    public class InvalidShopException : Exception
    {
        public InvalidShopException() { }
        public InvalidShopException(string message) : base(message) { }
        public InvalidShopException(string message, Exception inner) : base(message, inner) { }
        protected InvalidShopException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
