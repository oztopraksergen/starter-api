namespace WebApplication3.Model
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public DateTime BorrowDate { get; set; }
        public Book Book { get; set; }
        
    }
}
