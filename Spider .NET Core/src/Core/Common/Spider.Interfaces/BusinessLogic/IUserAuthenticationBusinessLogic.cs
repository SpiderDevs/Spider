using Spider.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces.BusinessLogic
{
    public interface IUserAuthenticationBusinessLogic
    {
        void Register(IServiceContext serviceContext, UserRegisterRequest request);
        bool CheckPassword(IServiceContext serviceContext, UserLogInRequest request);
        string ConfirmUserSession(IServiceContext serviceContext, User user);
    }
}
