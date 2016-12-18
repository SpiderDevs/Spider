using Spider.Helpers;
using Spider.Utility.Encryption.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Spider.Utility.Encryption
{
    /// <summary>
    /// Created basing on
    /// https://docs.asp.net/en/latest/security/data-protection/consumer-apis/password-hashing.html
    /// </summary>
    public class PasswordHash
    {
        private readonly int _saltByteLength;
        private readonly int _encryptedPasswordLenght;
        private readonly int _numberOfIterations = 1000;
        private readonly KeyDerivationPrf _pseudoRandomFunction = KeyDerivationPrf.HMACSHA512;

        private byte[] _salt;

        public static PasswordHash New()
        {
            return new PasswordHash();
        }

        public PasswordHash()
        {
            this._saltByteLength = (int) EncryptionLenghtEnum.Medium32;
            this._encryptedPasswordLenght = (int)EncryptionLenghtEnum.Long64;
        }

        public PasswordHash(EncryptionLenghtEnum saltByteLength, EncryptionLenghtEnum  encryptedPasswordLenght)
        {
            this._saltByteLength = (int)saltByteLength;
            this._encryptedPasswordLenght = (int)encryptedPasswordLenght;
        }


        public void SetSalt(byte[] salt)
        {
            this._salt = salt;
        }

        public void SetSalt(string salt)
        {
            this._salt = BytesHelper.StringToBytes(salt);
        }

        public string GetSalt()
        {
            return BytesHelper.BytesToString(this._salt);
        }

        public void GenerateSalt()
        {
            this._salt = GenerateRandomSalt();
        }

        private byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[_saltByteLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public string CreatePasswordHash(string password)
        {
            if(this._salt== null)
            {
                throw new SaltIsNullException("Salt canot be null. Set value or generate new one.");
            }
            byte[] hashed = GenerateHash(password);
            return BytesHelper.BytesToString(hashed);
        }
             
        private byte[] GenerateHash(string input)
        {
            byte[] hashed = KeyDerivation.Pbkdf2(
                 password: input,
                 salt: _salt,
                 prf: _pseudoRandomFunction,
                 iterationCount: _numberOfIterations,
                 numBytesRequested: this._encryptedPasswordLenght);
            return hashed;
        }

        
        public bool ValidatePassword(string password, string correctHash)
        {
            if (this._salt == null)
            {
                throw new SaltIsNullException("Salt canot be null. Set the value.");
            }

            var hashedPassword = GenerateHash(password);
            var savedPassword = BytesHelper.StringToBytes(correctHash);
            
            return SlowEquals(hashedPassword, savedPassword);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

      
    }

}
