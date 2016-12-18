using Microsoft.EntityFrameworkCore;
using Spider.Database.Access;
using Spider.Database.Context;
using Spider.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    public class RepositoriesResolver : IRepositories
    {
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? resolveUserRepository();
            }
        }

        private IUserRepository resolveUserRepository()
        {
            _userRepository = new UserRepository();
            return _userRepository;
        }
    }
}
