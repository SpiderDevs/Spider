using Spider.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.BusinessLogic.Models.Encryption
{
    public class PasswordHash : IPasswordHash
    {
        public string Hash { get; set; }
        public string Salt { get; set; }       
    }
}
