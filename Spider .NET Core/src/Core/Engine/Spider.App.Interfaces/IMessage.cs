using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Interfaces
{
    /// <summary>
    /// Like in here: http://docs.jboss.org/jbossesb/docs/4.12/manuals/html/Programmers_Guide/index.html
    /// </summary>
    public interface IMessage
    {
        IBody Body { get;  }
        IFault Fault { get; }
        bool IsSuccess { get; }
        
    }
}
