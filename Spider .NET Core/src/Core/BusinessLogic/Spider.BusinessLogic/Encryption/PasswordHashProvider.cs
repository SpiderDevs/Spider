using Spider.BusinessLogic.Interfaces;
using Spider.BusinessLogic.Models.Encryption;
using Spider.Exceptions;
using Spider.Utility.Encryption;
using Spider.Utility.Encryption.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.BusinessLogic.Encryption
{
    public class PasswordHashProvider : IPasswordHashProvider
    {
        public static PasswordHashProvider Instance
        {
            get
            {
                return new PasswordHashProvider();
            }
        }

        public IPasswordHash CreatePasswordHash(string password)
        {
            try
            {
                Utility.Encryption.PasswordHash hashProvider = Utility.Encryption.PasswordHash.New();
                hashProvider.GenerateSalt();
                var passwordHashResult = hashProvider.CreatePasswordHash(password);
                var salt = hashProvider.GetSalt();
                return new Models.Encryption.PasswordHash
                {
                    Hash = passwordHashResult,
                    Salt = salt,
                };
            }
            catch (Exception ex)
            {
                throw new SpiderPasswordHashProviderException(ex);
            }
        }

        public bool ValidatePassword(string password, IPasswordHash oldPasswordHashData)
        {
            try
            {
                Utility.Encryption.PasswordHash hashProvider = Utility.Encryption.PasswordHash.New();
                hashProvider.SetSalt(oldPasswordHashData.Salt);
                var result = hashProvider.ValidatePassword(password, oldPasswordHashData.Hash);
                return result;
            }
            catch (Exception ex)
            {
                throw new SpiderPasswordHashProviderException(ex);
            }
        }
    }
}
