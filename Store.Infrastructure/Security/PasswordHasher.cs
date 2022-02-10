using Store.Core.Interfaces;
using System;
using System.Security.Cryptography;

namespace Hotel.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int size = 96;
        public string GenerateSalt()
        {
            var salt = new byte[size];
            new RNGCryptoServiceProvider().GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        public string Hash(string password, string salt)
        {
            var rfc = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt));
            byte[] hash = rfc.GetBytes(size);

            return Convert.ToBase64String(hash);
        }

        public bool IsValid(string password, string hash, string salt)
        {
            return Hash(password, salt) == hash;
        }
    }
}
