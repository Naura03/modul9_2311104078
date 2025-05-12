using Microsoft.AspNetCore.Mvc;
using modul9_2311104078.Models;

namespace modul9_2311104078.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static List<Movie> movies = new List<Movie>
        {
            new Movie { Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = new List<string>{ "Tim Robbins", "Morgan Freeman" }, Description = "Two imprisoned men bond over years..." },
            new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", Stars = new List<string>{ "Marlon Brando", "Al Pacino" }, Description = "The aging patriarch of an organized crime dynasty..." },
            new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Stars = new List<string>{ "Christian Bale", "Heath Ledger" }, Description = "Batman raises the stakes in his war on crime." }
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetAll() => movies;

        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound();
            return movies[id];
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound();
            movies.RemoveAt(id);
            return Ok();
        }
    }
}
