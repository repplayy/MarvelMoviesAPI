using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MarvelMoviesController : ControllerBase
    {
        private MovieContext _context;

        public MarvelMoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult AddMovie([FromBody] Movie movie)
        {

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecoverById), new { Id = movie.Id }, movie);

        }

        [HttpGet]

        public IActionResult RecoverMovies()
        {
            return Ok(_context.Movies);
        }


        [HttpGet("{id}")]

        public IActionResult RecoverById(int id)
        {

            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);


            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }


        [HttpPut("{id}")]

        public IActionResult UpdateById(int id, [FromBody] Movie newMovie)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);


            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = newMovie.Title;
            movie.time = newMovie.time;
            movie.Director = newMovie.Director;
            movie.Date = newMovie.Date;
            movie.Gender = newMovie.Gender;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult RemoveById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);


            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();


        }
    }

}