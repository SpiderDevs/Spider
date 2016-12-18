using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Service.Models.TransportModels.User
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }

        public string Token { get; set; }
    }
}
