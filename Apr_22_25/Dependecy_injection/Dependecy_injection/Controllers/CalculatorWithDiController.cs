using Dependecy_injection.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dependecy_injection.Controllers
{
    [Route("api/[controller]")] // Changed route to follow convention
    [ApiController]
    public class CalculatorWithDiController : ControllerBase
    {
        private readonly ICalculator _calculator;

        // Inject the ICalculator dependency through the constructor
        public CalculatorWithDiController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("add/{a}/{b}", Name = "AddWithDi")] // More specific route for addition
        public IActionResult Add(int a, int b)
        {
            int sum = _calculator.Add(a, b);
            return Ok(sum);
        }

        [HttpGet("multiply/{a}/{b}", Name = "MultiplyWithDi")] // More specific route for multiplication
        public IActionResult Multiply(int a, int b)
        {
            int product = _calculator.Multiply(a, b);
            return Ok(product);
        }

        [HttpGet(Name = "GetCalcWithDi")] // Unique and descriptive route name
        public IActionResult GetCalc(int a, int b)
        {
            int add = _calculator.Add(a, b);
            int mul = _calculator.Multiply(a, b);
            var list = new List<int> { add, mul };
            return Ok(list);
        }
    }
}