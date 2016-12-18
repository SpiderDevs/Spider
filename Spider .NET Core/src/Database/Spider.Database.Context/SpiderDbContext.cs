using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spider.Database.Entity.Models;
using Spider.Interfaces.Database;
using Spider.Interfaces.Database.Entities;

namespace Spider.Database.Context
{
    public class SpiderDbContext : DbContext
    {
        public SpiderDbContext(DbContextOptions<SpiderDbContext> options) : base(options)
        { }

        public DbSet<UserEntity> Users { get; set; }
              
    }
}
