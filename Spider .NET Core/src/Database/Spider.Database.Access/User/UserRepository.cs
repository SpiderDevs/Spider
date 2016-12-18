using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Core.Models.User;
using Spider.Database.Entity.Models;
using Spider.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Spider.BusinessLogic.Models.Encryption;
using Spider.Interfaces.Database;
using Spider.Database.Context;

namespace Spider.Database.Access
{   
    public class UserRepository  : SpiderRepositoryBase, IUserRepository
    {
        public int CreateUser(IServiceContext serviceContext, User request, IPasswordHash passwordHashData)
        {
            var dbContext = DbContext(serviceContext);

            var entity = new UserEntity()
            {
                CreateDate = DateTime.UtcNow,
                Login = request.Login,
                PasswordSalt = passwordHashData.Salt,
                PasswordHash = passwordHashData.Hash,
                IsActive = false,
            };

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();
            return entity.UserId;
        }

        public User GetUser(IServiceContext serviceContext, string userEmail)
        {
            var dbContext = DbContext(serviceContext);

            var query = (from u in dbContext.Users
                         where u.Login == userEmail && u.IsActive
                         select
                         new User
                         {
                            CreateDate = u.CreateDate,
                            Login = u.Login,
                            IsActive = u.IsActive,
                            UserId = u.UserId,
                         });
            return query.First();
        }

        public IPasswordHash GetUserPasswordHashForLogin(IServiceContext serviceContext, string userEmail)
        {
            var dbContext = DbContext(serviceContext);

            var query = (from u in dbContext.Users
                         where u.Login == userEmail
                         select
                         new PasswordHash
                         {
                             Hash = u.PasswordHash,
                             Salt = u.PasswordSalt,
                         });
            return query.FirstOrDefault();
        }
    }
}
