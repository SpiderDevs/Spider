using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Interfaces
{
    public interface IServiceResponse
    {
        IMessage Message { get; set; }
    }
}
