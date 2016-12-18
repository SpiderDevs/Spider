using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    public class UserSession : IUserSession
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
