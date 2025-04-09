using Hello_World_efcore.Data;
using Hello_World_efcore.Models.Domain;
using Hello_World_efcore.Data;
using Hello_World_efcore.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // POST: {apibaseurl}/api/blogposts
        [HttpPost]
        //[Authorize(Roles = "Writer")]
        [Route("AddBlogPost")]
        public async Task<IActionResult> CreateBlogPost([FromBody] BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return Ok(blogPost);
        }
    }
}
