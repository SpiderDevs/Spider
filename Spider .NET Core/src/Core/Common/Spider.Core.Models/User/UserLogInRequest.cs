using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Core.Models.User
{
    public class UserLogInRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
