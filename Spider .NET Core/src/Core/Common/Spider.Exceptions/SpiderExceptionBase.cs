using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Exceptions
{
    public class SpiderExceptionBase : Exception
    {
        public SpiderExceptionBase() : base()
        { }
     
        public SpiderExceptionBase(string message) : base(message)
        { }

        public SpiderExceptionBase(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
