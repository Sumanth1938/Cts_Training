using HelloWorldWebApi_2.Data;
using HelloWorldWebApi_2.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldWebApi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ActorController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("addActor")]
        public async Task<IActionResult> AddActor([FromBody] Actor actor)
        {
            await dbContext.Actors.AddAsync(actor);
            await dbContext.SaveChangesAsync();
            return Ok(actor);
        }

        [HttpGet]
        [Route("getActors")]
        public async Task<IActionResult> GetActors()
        {
            var response = await dbContext.Actors.ToListAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("getActor/{id}")]
        public async Task<IActionResult> GetMoviesById(Guid id)
        {
            var response = await dbContext.Actors.FindAsync(id);
            if (response == null)
            {
                return NotFound("This actor  is not found in the database");
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpPut]
        [Route("UpdateActor{id}")]
        public async Task<IActionResult> UpdateActorDetails(Guid id, [FromBody] Actor updatedActor)
        {
            var existingActor = await dbContext.Actors.FindAsync(id);
            if (existingActor == null)
            {
                return NotFound($"Actor with Id {id} not found");
            }
            existingActor.Name = updatedActor.Name;
            existingActor.Age = updatedActor.Age;
            existingActor.Experience = updatedActor.Experience;
            existingActor.Awards = updatedActor.Awards;
            existingActor.Movies = updatedActor.Movies;
            await dbContext.SaveChangesAsync();
            return Ok(updatedActor);
        }

        [HttpDelete]
        [Route("deleteActor{id}")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var actor = await dbContext.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound("The movie is not found in the database");
            }
            dbContext.Actors.Remove(actor);
            await dbContext.SaveChangesAsync();
            return Ok($"Actor with id : {id} was deleted");
        }
    }
}
