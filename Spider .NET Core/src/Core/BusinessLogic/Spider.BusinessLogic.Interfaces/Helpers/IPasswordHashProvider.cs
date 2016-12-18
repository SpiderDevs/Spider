using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.BusinessLogic.Interfaces
{
    public interface IPasswordHashProvider
    {
        /// <summary>
        /// Hash pasword and return result with the salt
        /// </summary>
        /// <param name="password"></param>
        /// <returns>
        ///  Salt and  Hashed password
        /// </returns>
        IPasswordHash CreatePasswordHash(string password);
        bool ValidatePassword(string password, IPasswordHash oldPasswordHashData);
    }
}
