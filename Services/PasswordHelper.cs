using System;
using System.Security.Cryptography;
using System.Text;

namespace IT59_Pharmacy.Services
{
    /// <summary>
    /// Simple password hashing service using SHA256
    /// Note: For production, please install BCrypt.Net-Next package and use BCrypt.Net.BCrypt.HashPassword() instead
    /// </summary>
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            using (var sha256 = SHA256.Create())
            {
                // Add a salt to make it more secure
                var saltedPassword = password + "SweetSaltValue"; // Ideally, use a unique salt per user
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash))
                return false;

            var hashOfInput = HashPassword(password);
            return string.Equals(hashOfInput, hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}

