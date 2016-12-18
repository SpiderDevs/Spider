using Spider.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Models
{
    public class ServiceResponse : IServiceResponse
    {
        public IMessage Message { get; set; }

        public ServiceResponse(IMessage message)
        {
            this.Message = message;
        }

        public ServiceResponse()
        {
        }
    }
}
