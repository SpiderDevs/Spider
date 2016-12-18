using Spider.App.Interfaces;
using Spider.App.Models;
using Spider.Constant;
using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Services
{
    [PublicInterface]
    public interface ITestService : IService
    {
        IMessage Test_1(IServiceContext serviceContext);
    }

    public class TestService : ServiceBase, ITestService
    {
        [RequirePermission(PermissionEnum.Public)]
        public IMessage Test_1(IServiceContext serviceContext)
        {
            if(serviceContext.IsAuthorised())           
                return Message.Success("Success!! From authorised !!!");
            else
                return Message.Success("Success!! But you are not authorised");
        }
    }
}
