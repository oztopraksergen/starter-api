using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")] // api/Math/..
    [ApiController]
    public class MathController : ControllerBase
    {
        public class CalculationRequest
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [HttpPost("add")]
        public int Add([FromBody] CalculationRequest request)
        {
            return request.X + request.Y;
        }
        [HttpPost("subtract")]
        public int Subtract ([FromBody] CalculationRequest request)
        {
            return request.X - request.Y;
        }
        [HttpPost("multiply")]
        public int Multiply([FromBody] CalculationRequest request)
        {
            return request.X * request.Y;
        }
        [HttpPost("divide")]
        public int Divide([FromBody] CalculationRequest request)
        {
            return request.X / request.Y;
        }
    }
}
