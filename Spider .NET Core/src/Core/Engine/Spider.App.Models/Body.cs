using System;
using Spider.App.Interfaces;

namespace Spider.App.Models
{
    public class Body : IBody
    {
        public object Result { get; set; }

        public Body(object result)
        {
            this.Result = result;
        }

    }
}