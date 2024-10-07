namespace WebApplication3.Services.Abstract
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}
