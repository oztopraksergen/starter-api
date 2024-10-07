using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;
using WebApplication3.Services.Abstract;

namespace WebApplication3.Services.Concrete
{
    public class LoanService : ILoanServices    

    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Result BorrowBook(int userId, int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book == null || book.CopiesAvailable < 1)
                return new Result(false, "Book is not available.");

            var loan = new Loan
            {
                UserId = userId,
                BookId = bookId,
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14) // 2 hafta
            };

            book.CopiesAvailable -= 1;
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return new Result(true, "Book borrowed successfully.");
        }

        public Result ReturnBook(int loanId)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == loanId);
            if (loan == null)
                return new Result(false, "Loan record not found.");

            var book = _context.Books.FirstOrDefault(b => b.Id == loan.BookId);
            if (book != null)
                book.CopiesAvailable += 1;

            _context.Loans.Remove(loan);
            _context.SaveChanges();

            return new Result(true, "Book returned successfully.");
        }

        public IEnumerable<LoanDetails> GetLoansByUserId(int userId)
        {
            var userLoans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .Where(l => l.UserId == userId)
                .Select(l => new LoanDetails
                {
                    BookTitle = l.Book.Title,
                    UserName = l.User.FullName,
                    BorrowDate = l.LoanDate, // Güncellenmiş: BorrowDate yerine LoanDate
                    ReturnDate = l.ReturnDate
                })
                .ToList();

            return userLoans;
        }

        public IEnumerable<LoanDetails> GetAllLoans()
        {
            var allLoans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .Select(l => new LoanDetails
                {
                    BookTitle = l.Book.Title,
                    UserName = l.User.FullName,
                    BorrowDate = l.LoanDate, // Güncellenmiş: BorrowDate yerine LoanDate
                    ReturnDate = l.ReturnDate
                })
                .ToList();

            return allLoans;
        }
    }
}


