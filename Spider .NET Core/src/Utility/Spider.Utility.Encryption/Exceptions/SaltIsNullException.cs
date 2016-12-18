using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Utility.Encryption.Exceptions
{
    public class SaltIsNullException : Exception
    {
        public SaltIsNullException(string message): base(message)
        {}
    }
}
