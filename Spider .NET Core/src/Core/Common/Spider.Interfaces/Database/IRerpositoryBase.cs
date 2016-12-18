using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces.Database
{
    public interface IRerpositoryBase<T> where T : DbContext
    {
    }
}
