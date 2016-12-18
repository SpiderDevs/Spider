using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces.Database.Entities
{
    public interface IUserEntity
    {
        int UserId { get; set; }
        string Login { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
        bool IsActive { get; set; }
        DateTime CreateDate { get; set; }
    }
}
