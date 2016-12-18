using Microsoft.EntityFrameworkCore;
using Spider.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces
{
    public interface IServiceContext
    {
        DateTimeOffset CreatedAt { get; }
        DbContext DbContext { get; }
        IBusinessLogic BusinessLogics { get; }
        IRepositories Repositories { get; }
        IUserSession User { get; }
        ILogger Logger { get; }
        ICacheService Cache { get; }
        string Language { get; }
        string CalledChannel { get; }
        string CalledService { get; }
        string CalledMethod { get; }
        string CalledParams { get; }
        string CallUid { get; }
        
        bool IsAuthorised();
        void LogInfo(string message, string longMessage = null);
        void LogError(string message, string longMessage = null);
    }
}
