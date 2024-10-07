using System.Text;
using System.Security.Cryptography;
using WebApplication3.Services.Abstract;

namespace WebApplication3.Services.Concrete
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            var hashedPasswordAttempt = HashPassword(password);
            return hashedPassword == hashedPasswordAttempt;
        }
    }
}
