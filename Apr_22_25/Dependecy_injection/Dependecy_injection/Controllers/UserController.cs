using Dependecy_injection.Data;
using Dependecy_injection.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dependecy_injection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // POST: api/user/add
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User newUserDTO)
        {
            var newUser = new User
            {
                Name = newUserDTO.Name,
                Email = newUserDTO.Email,
                ContactNumber = newUserDTO.ContactNumber,
                Password = newUserDTO.Password
            };
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await dbContext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
