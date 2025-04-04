using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EightController : ControllerBase
    {
        [HttpGet]
        [Route("kasjhdkjashdk")]
        public async Task<IActionResult> asjdakjshdkjas()
        {
            string blogId = "askdhiowydhkjashdas";
            return Ok(blogId);

        }
    }
}
