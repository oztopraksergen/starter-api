using WebApplication3.Model;
using WebApplication3.Services.Abstract;

namespace WebApplication3.Services.Concrete
{
    public class BookService : IBookServices
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return new Result(true, "Book added successfully");
        }

        public Book GetBook(int id)
        {
            return _context.Books.Find(id);
        }

    }
}
