using Microsoft.EntityFrameworkCore;
using Spider.BusinessLogic.Interfaces;
using Spider.Core.Models.User;
using Spider.Interfaces;
using Spider.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces.Database
{
    public interface IUserRepository
    {
        int CreateUser(IServiceContext serviceContext, User request, IPasswordHash passwordHashData);
        IPasswordHash GetUserPasswordHashForLogin(IServiceContext serviceContext, string userEmail);
        User GetUser(IServiceContext serviceContext, string userEmail);
    }
}
