using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Service.Models.TransportModels.User
{
    public class LoginRequest : IValidate
    {
        public LoginRequest()
        {
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            //TODO:
            return true;
        }
    }
}
