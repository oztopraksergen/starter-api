namespace WebApplication3.Model
{
    public class LoanDetails
    {
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public DateTime BorrowDate  { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
