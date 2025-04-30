using Dependecy_injection.Repositories.Implementations;
using Dependecy_injection.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dependecy_injection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet(Name ="GetCalc")]
        public IActionResult GetCalc(int a, int b)
        {
            ICalculator calculator = new CalculatorRepository();
            int add = calculator.Add(a, b);
            int mul = calculator.Multiply(a, b);
            var list = new List<int> { add, mul };
            return Ok(list);
        }
    }
}
