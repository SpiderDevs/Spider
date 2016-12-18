using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces
{
    public interface IUserSession
    {
        int UserId { get; }
        string UserName { get; }
        
    }
}
