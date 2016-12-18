using Spider.Core.Models.User;
using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.BusinessLogic.Cache
{
    public static class UserAuthenticationCache
    {
        private static int userSessionTimeout = 360;
        private static readonly string prefix = "USER_TOKEN_";

        public static User GetUser(IServiceContext serviceContext, string token)
        {
            return serviceContext.Cache.Get<User>(prefix+token);
        }

        public static void PutUser(IServiceContext serviceContext, User user, string token)
        {
            serviceContext.Cache.Store(prefix+token, user,userSessionTimeout);
        }
    }
}
