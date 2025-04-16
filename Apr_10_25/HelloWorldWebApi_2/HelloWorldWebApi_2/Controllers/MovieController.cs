using HelloWorldWebApi_2.Data;
using HelloWorldWebApi_2.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldWebApi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddMovie")]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpGet]
        [Route("getMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var response = await dbContext.Movies.ToListAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("getMovie/{id}")]
        public async Task<IActionResult> GetMoviesById(Guid id)
        {
            var response = await dbContext.Movies.FindAsync(id);
            if(response == null)
            {
                return NotFound("The movie is not found in the database");
            }
            else
            {
                return Ok(response);
            }
                
        }


        [HttpPut]
        [Route("UpdateMovie{id}")]
        public async Task<IActionResult> UpdateMovieDetails(Guid id, [FromBody] Movie updatedMovie)
        {
            var existingMovie = await dbContext.Movies.FindAsync(id);
            if (existingMovie == null)
            {
                return NotFound($"Movie with Id {id} not found");
            }
            existingMovie.Title = updatedMovie.Title;
            existingMovie.ReleaseYear = updatedMovie.ReleaseYear;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.PosterLink = updatedMovie.PosterLink;
            await dbContext.SaveChangesAsync();
            return Ok(existingMovie);
        }

        [HttpDelete]
        [Route("deleteMovie{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var movie = await dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound("The movie is not found in the database");
            }
            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();
            return Ok($"Movie with id : {id} was deleted");
        }
    }
}
