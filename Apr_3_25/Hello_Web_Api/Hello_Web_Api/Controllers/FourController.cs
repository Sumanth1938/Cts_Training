using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hello_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FourController : ControllerBase
    {
        [HttpGet]
        [Route("askjudhgasukdghjasn;daksdojuassd")]
        public async Task<IActionResult> helloWakdsukyuasghdorld()
        {
            string blogId = "skujdgiuastydkjabsd";
            return Ok(blogId);

        }
    }
}
