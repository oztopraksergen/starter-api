namespace WebApplication3.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
      
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }   
}
