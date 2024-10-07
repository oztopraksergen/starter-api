using WebApplication3.Model;

namespace WebApplication3.Services.Abstract
{
    public interface ILoanServices
    {
        Result BorrowBook(int userId, int bookId);
        Result ReturnBook(int loanId);
        IEnumerable<LoanDetails> GetLoansByUserId(int userId);
        IEnumerable<LoanDetails> GetAllLoans();
    }
}
