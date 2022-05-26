using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MarvelMoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();


        [HttpPost]

        public void AddMovie([FromBody] Movie movie)
        {

            movies.Add(movie);
            Console.WriteLine(movie.Title);

        }

        [HttpGet]

        public IEnumerable<Movie> RecoverMovies()
        {
            return movies;
        }






    }
    
}
