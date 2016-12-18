using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Core.Models.User
{
    public class User
    {
        public User()
        {
            CreateDate = DateTime.UtcNow;
            IsActive = false;
        }
        public int UserId { get; set; }
        public string Login { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
