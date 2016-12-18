using System;
using Spider.App.Interfaces;

namespace Spider.App.Models
{
    public class Message : IMessage
    {
        public IBody Body { get; set; }

        public IFault Fault { get; set; }

        public bool IsSuccess { get; set; }

        public static Message Success(IBody body)
        {
            var resut = new Message();
            resut.Body = body;
            resut.Fault = null;
            resut.IsSuccess = true;
            return resut;
        }

        public static Message Success(object result = null)
        {
            var resut = new Message();
            resut.Body = new Body(result);
            resut.Fault = null;
            resut.IsSuccess = true;
            return resut;
        }

     
        public static Message Error(IFault fault)
        {
            var resut = new Message();
            resut.Body = null;
            resut.Fault = fault;
            resut.IsSuccess = false;
            return resut;
        }

       
    }
}