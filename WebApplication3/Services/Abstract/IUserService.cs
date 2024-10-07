using WebApplication3.Model;

namespace WebApplication3.Services.Abstract
{
    public interface IUserService
    {
        Result Register(Register register);
        Result Login(Login login);
    }
}
