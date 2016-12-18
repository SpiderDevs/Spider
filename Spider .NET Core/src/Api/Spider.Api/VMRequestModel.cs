using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Api
{
    public class VMRequestModel
    {
        public string Chanel { get; set; }
        public string Service { get; set; }
        public string Method { get; set; }
        public string Request { get; set; }
        public string Token { get; set; }
    }
}
