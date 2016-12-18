using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Interfaces
{
    public interface IRequest
    {
        string Chanel { get; set; }
        string Service { get; set; }
        string Method { get; set; }
        string Token { get; set; }
        string Request { get; set; }
    }
}
