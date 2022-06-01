using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data.Dtos;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MarvelMoviesController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MarvelMoviesController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecoverById), new { Id = movie.Id }, movie);

        }

        [HttpGet]

        public IEnumerable<Movie> RecoverMovies()
        {
            return _context.Movies;
        }


        [HttpGet("{id}")]

        public IActionResult RecoverById(int id)
        {

            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);


            if (movie != null)
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movieDto);
            }
            return NotFound();
        }


        [HttpPut("{id}")]

        public IActionResult UpdateById(int id, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);


            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieDto, movie);
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