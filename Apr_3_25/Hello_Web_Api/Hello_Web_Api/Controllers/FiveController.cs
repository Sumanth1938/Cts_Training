using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiveController : ControllerBase
    {
        [HttpGet]
        [Route("SUmapoausdoihasjkdntH")]
        public async Task<IActionResult> asjdhiausydiuashjd()
        {
            string blogId = "alsidhashdkjashd world";
            return Ok(blogId);

        }
    }
}
