using Spider.Interfaces.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Database.Entity.Models
{
    [Table("Users")]
    public class UserEntity : IUserEntity
    {
        [Key]
        public int UserId { get; set; }        
        public string Login { get; set; }        
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
