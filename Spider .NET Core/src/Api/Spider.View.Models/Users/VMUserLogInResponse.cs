using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.View.Models.Users
{
    public class VMUserLogInResponse
    {
        public bool IsSuccess { get; set; }
        public string UserToken { get; set; }
        public VMUser User { get; set; }
    }
}
