using Microsoft.EntityFrameworkCore;
using Spider.App.Interfaces;
using Spider.BusinessLogic.Cache;
using Spider.Database.Access;
using Spider.Database.Context;
using Spider.Interfaces;
using Spider.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    public class ServiceContext : IServiceContext
    {
        private readonly string userToken;
        private DbContext _dbContext;
        private IBusinessLogic _businessLogics;
        private IRepositories _repositories;
        private IUserSession _user;


        protected ServiceContext()
        {
            this.CallUid = Guid.NewGuid().ToString();
            this.CreatedAt = DateTimeOffset.Now;
        }

        protected ServiceContext(string channel, string serviceName, string methodName, string param, string userToken) : this()
        {
            this.CalledChannel = channel;
            this.CalledMethod = methodName;
            this.CalledParams = param;
            this.CalledService = serviceName;
            this.userToken = userToken;

            TryAuthorise();
        }

        public void TryAuthorise()
        {
            if (userToken != null && userToken.Trim() != String.Empty)
            {
                var user = UserAuthenticationCache.GetUser(this, userToken);
                if (user != null)
                {
                    //TODO: Create converter.
                    var autorisedUser = new UserSession()
                    {
                        UserId = user.UserId,
                        UserName = user.Login,
                    };
                    this._user = autorisedUser;
                }
            }
        }


        public static ServiceContext Prepare(IRequest request)
        {
            return new ServiceContext(request.Chanel, request.Service, request.Method, request.Request, request.Token);
        }

        public DateTimeOffset CreatedAt { get; }

        public IBusinessLogic BusinessLogics
        {
            get
            {
                return _businessLogics ?? ResolveBusinessLogics();
            }
        }

        private IBusinessLogic ResolveBusinessLogics()
        {
            _businessLogics = new BusinessLogicsResolver();
            return _businessLogics;
        }

        public string Language
        {
            get
            {
                //TODO: 
                return "en-GB";
            }
        }

        public IRepositories Repositories
        {
            get
            {
                return _repositories ?? ResolveRepositories();
            }
        }

        private IRepositories ResolveRepositories()
        {
            _repositories = new RepositoriesResolver();
            return _repositories;
        }

        public DbContext DbContext
        {
            get
            {
                return _dbContext ?? ResolveDbContext();
            }
        }

        private DbContext ResolveDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpiderDbContext>();
            optionsBuilder.UseSqlServer(Constant.Settings.Values().DatabaseConnectionString);
            _dbContext = new SpiderDbContext(optionsBuilder.Options);
            return _dbContext;
        }



        public IUserSession User
        {
            get
            {
                return _user;
            }
        }

        public ILogger Logger
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string CalledChannel { get; }

        public string CalledService { get; }

        public string CalledMethod { get; }

        public string CalledParams { get; }

        public string CallUid { get; }

        public ICacheService Cache
        {
            get
            {
                return CacheSingleton.Instance;
            }
        }

        public void LogInfo(string message, string longMessage)
        {
            //TODO:
            // Logger.Log()
        }

        public void LogError(string message, string longMessage)
        {
            //TODO:
            // Logger.Log()
        }

        public bool IsAuthorised()
        {
            return _user != null;
        }
    }
}
