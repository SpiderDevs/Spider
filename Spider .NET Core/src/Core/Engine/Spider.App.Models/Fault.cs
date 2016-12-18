using System;
using Spider.App.Interfaces;

namespace Spider.App.Models
{
    public class Fault : IFault
    {
        public string ShortMessage { get; set; }

        public string LongMessage { get; set; }

        //Think about it. Build by error source line code  ??
        //public string Code { get; set; }

        public Fault() { }
        public Fault(string shortMessage, string longMessage)
        {
            this.ShortMessage = shortMessage;
            this.LongMessage = longMessage;
        }
      
     

    }
}