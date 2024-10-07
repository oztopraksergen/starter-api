using Microsoft.AspNetCore.Identity;
using WebApplication3.Model;
using WebApplication3.Services.Abstract;


namespace WebApplication3.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(ApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public Result Register(Register register)
        {
            // 1. Kullanıcı adı zaten var mı kontrol et
            if (_context.Users.Any(u => u.UserName == register.UserName))
            {
                return new Result(false, "Kullanıcı adı zaten mevcut.");
            }

            // 2. Kullanıcı bilgilerini oluştur
            var user = new User
            {
               FullName = register.FullName,
                Age = register.Age,
                UserName = register.UserName,
                Email = register.Email,
                PasswordHash = _passwordHasher.HashPassword(register.Password)
            };

            // 3. Kullanıcıyı veritabanına ekle ve kaydet
            _context.Users.Add(user);
            _context.SaveChanges();

            // 4. Başarılı mesajını döndür
            return new Result(true, "Kayıt başarılı.");

        }

        public Result Login(Login login)
        {
            // 1. Kullanıcı adı ile veritabanından kullanıcıyı bul
            var user = _context.Users.FirstOrDefault(u => u.UserName == login.UserName);
            if (user == null)
            {
                return new Result(false, "Kullanıcı adı veya şifre hatalı.");
            }

            // 2. Şifreyi doğrula
            var passwordValid = _passwordHasher.VerifyPassword(user.PasswordHash, login.Password);
            if (!passwordValid)
            {
                return new Result(false, "Kullanıcı adı veya şifre hatalı.");
            }

            // 3. Başarılı giriş mesajını döndür
            return new Result(true, "Giriş başarılı.");

        }
    }
}
