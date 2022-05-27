using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MarvelMoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int id = 1;

        [HttpPost]

        public IActionResult AddMovie([FromBody] Movie movie)
        {

            movie.Id = id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(RecoverById), new {Id = movie.Id}, movie);

        }

        [HttpGet]

        public IActionResult RecoverMovies()
        {
            return Ok(movies);
        }


        [HttpGet("{id}")]

        public IActionResult RecoverById(int id )
        {

            Movie movie = movies.FirstOrDefault(movie => movie.Id == id);


            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }



    }
    
}
