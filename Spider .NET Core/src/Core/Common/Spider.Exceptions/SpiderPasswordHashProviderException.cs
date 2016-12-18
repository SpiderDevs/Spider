using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Exceptions
{
    public class SpiderPasswordHashProviderException : SpiderExceptionBase
    {
        public SpiderPasswordHashProviderException(Exception innerException, string message = null) : base(message ?? "Unexpected error", innerException)
        { }
    }
}
