using Spider.Database.Context;
using Spider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Database.Access
{
    public class SpiderRepositoryBase
    {
        public SpiderDbContext DbContext(IServiceContext serviceContext)
        {
            return (SpiderDbContext)serviceContext.DbContext;
        }
    }
}
