using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            string saltedPassword = password + salt;
            var hashOfInput = HashPassword(saltedPassword);
            return hashOfInput == hashedPassword;
        }

        public static string GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }
        }

        public static (string hash, string salt) HashPasswordWithSalt(string password)
        {
            string salt = GenerateSalt();
            string saltedPassword = password + salt;
            string hash = HashPassword(saltedPassword);
            return (hash, salt);
        }
    }
}
