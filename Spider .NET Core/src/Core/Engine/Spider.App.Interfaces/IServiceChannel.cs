using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Interfaces
{
    public interface IServiceChannel
    {
        IServiceResponse Process(IRequest request);
    }
}
