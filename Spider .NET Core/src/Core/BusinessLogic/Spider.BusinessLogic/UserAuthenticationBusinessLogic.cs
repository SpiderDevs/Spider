using Spider.BusinessLogic.Cache;
using Spider.BusinessLogic.Encryption;
using Spider.Core.Models.User;
using Spider.Interfaces;
using Spider.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.BusinessLogic
{ 
    public class UserAuthenticationBusinessLogic : IUserAuthenticationBusinessLogic
    { 
        public bool CheckPassword(IServiceContext serviceContext, UserLogInRequest request)
        {
            var passwordHash = serviceContext.Repositories.UserRepository.GetUserPasswordHashForLogin(serviceContext, request.Login);
            if (passwordHash == null)
                return false;
            return PasswordHashProvider.Instance.ValidatePassword(request.Password, passwordHash);
        }

        /// <summary>
        /// ConfirmUserSession requie cal method CheckPassword before.
        /// </summary>
        /// <returns></returns>
        public string ConfirmUserSession(IServiceContext serviceContext, User user)
        {
            var token = Guid.NewGuid().ToString();
            UserAuthenticationCache.PutUser(serviceContext, user, token);
            return token;
        }

        public void Register(IServiceContext serviceContext, UserRegisterRequest request)
        {
            var user = new User();
            user.Login = request.Login;
            var passwordData  = PasswordHashProvider.Instance.CreatePasswordHash(request.Password);
            serviceContext.Repositories.UserRepository.CreateUser(serviceContext, user, passwordData);
        }

     
    }
}
