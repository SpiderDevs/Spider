using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.BusinessLogic.Interfaces
{
    public interface IPasswordHash
    {
        string Hash { get; set; }
        string Salt { get; set; }
    }
}
