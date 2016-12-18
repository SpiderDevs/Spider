using Spider.App.Interfaces;
using Spider.App.Models;
using Spider.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    //I think it can be used in singlethon. But nedd to be implemented mehanism to clean up not used chanels. example more than 10 minutes. 
    public class Engine
    {
        private IServiceChannel channel_1 = new Channel_1();

        public IServiceResponse Process(IRequest request)
        {
            try
            {
                var chanelName = request.Chanel.Trim().ToUpper();
                switch (chanelName)
                {
                    case "CHANNEL_1":
                        {
                            var response = channel_1.Process(request);
                            return response;
                        }
                    default:
                        {
                            //TODO: think what to do .....
                            throw new NotImplementedException("Channel not found: " + chanelName);
                        }
                }
            }
            catch (SpiderExceptionBase ex)
            {
                //TODO: add log. 
                //Ussage. Walidation errors, unexpected flow errors. Other user results scholud be build innside of result
                return new ServiceResponse(Message.Error(new Fault(ex.ToString(), ex.Message)));
            }
            catch (Exception ex)
            {
                //TODO: add log. 

                //Should newer occur. We shoul't show error to protect hack by detailed message, example from database. 
                //Expected erroprs should be wraped by SpiderExceptionBase
                return new ServiceResponse(Message.Error(new Fault("Unexpected error", "Unexpected error when processing. Can't show details.")));
            }

        }


    }
}
