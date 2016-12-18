using Spider.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces
{
    public interface IBusinessLogic
    {
        IUserAuthenticationBusinessLogic UserAuthenticationBusinessLogic { get; }
        IUserBusinessLogic UserBusinessLogic { get; }
    }
}
