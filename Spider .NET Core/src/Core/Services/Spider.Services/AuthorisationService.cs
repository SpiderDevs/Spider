using Spider.App.Interfaces;
using Spider.App.Models;
using Spider.Core.Models.User;
using Spider.Extensions.Mapper;
using Spider.Interfaces;
using Spider.View.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Services
{
    [PublicInterface]
    public interface IAuthorisationService : IService
    {
        IMessage UserRegister(IServiceContext serviceContext, VMUserRegisterRequest input);
        IMessage LogIn(IServiceContext serviceContext, VMUserLogInRequest input);
    }

    /// <summary>
    /// For performance improvement you Can build yours own object mappers. This concept its faster to develop.
    /// </summary>
    public class AuthorisationService : ServiceBase, IAuthorisationService
    {
        public IMessage UserRegister(IServiceContext serviceContext, VMUserRegisterRequest input)
        {
            var request = input.Map<UserRegisterRequest>();
            serviceContext.BusinessLogics.UserAuthenticationBusinessLogic.Register(serviceContext, request);             
            return Message.Success();

        }

        public IMessage LogIn(IServiceContext serviceContext, VMUserLogInRequest input)
        {
            var request = input.Map<UserLogInRequest>();

            if (!serviceContext.BusinessLogics.UserAuthenticationBusinessLogic.CheckPassword(serviceContext, request))
            {
                return Message.Success(new VMUserLogInResponse()
                {
                    IsSuccess = false,
                });
            }
            else
            {
                var user = serviceContext.Repositories.UserRepository.GetUser(serviceContext, request.Login);
                string userToken = serviceContext.BusinessLogics.UserAuthenticationBusinessLogic.ConfirmUserSession(serviceContext, user);
                return Message.Success(new VMUserLogInResponse()
                {
                    IsSuccess = true,
                    UserToken = userToken,
                    User = user.Map<VMUser>()
                });
            }


        }

        
    }
}
