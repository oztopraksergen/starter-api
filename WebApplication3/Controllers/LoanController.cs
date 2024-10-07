using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services.Abstract;
using WebApplication3.Services.Concrete;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanServices _loanService;

        public LoanController(ILoanServices loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("borrow")]
        public IActionResult BorrowBook([FromQuery] int userId, [FromQuery] int bookId)
        {
            var result = _loanService.BorrowBook(userId, bookId);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("return")]
        public IActionResult ReturnBook([FromQuery] int loanId)
        {
            var result = _loanService.ReturnBook(loanId);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("user-loans")]
        public IActionResult GetLoansByUserId([FromQuery] int userId)
        {
            var loans = _loanService.GetLoansByUserId(userId);
            return Ok(loans);
        }

        [HttpGet("all-loans")]
        public IActionResult GetAllLoans()
        {
            var allLoans = _loanService.GetAllLoans();
            return Ok(allLoans);
        }
    }
}
