using WebApplication3.Model;

namespace WebApplication3.Services.Abstract
{
    public interface IBookServices
    {
        Result AddBook(Book book);
        Book GetBook(int id);
    }
}
