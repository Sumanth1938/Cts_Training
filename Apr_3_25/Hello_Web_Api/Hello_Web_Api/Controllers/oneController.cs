using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class oneController : ControllerBase
    {
        [HttpGet]
        [Route("asliduajkshdkjasbdjkashnd")]
        public async Task<IActionResult> akjsdghkujasjgdjasndlkjasl()
        {
            string blogId = "akjusdghiouasydoiasjkckashfkiuayhissodjaslkfhkasydklashd";
            return Ok(blogId);

        }
    }
}
