using System;
using System.Security.Cryptography;
using System.Text;

namespace IT59_Pharmacy.Services {
    public class AuthenticationService {
        public static string HashPassword(string password) {
            using (var sha256 = SHA256.Create()) {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}