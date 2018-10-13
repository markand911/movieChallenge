using API.Interface;
using API.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebJetAPI.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieProviderFactory _movieProviderFactory;
        public MovieController(IMovieProviderFactory movieProviderFactory)
        {
            _movieProviderFactory = movieProviderFactory;
        }

        [ResponseType(typeof(MoviesResponse))]
        public async Task<IHttpActionResult> Get(string source)
        {
            if (string.IsNullOrEmpty(source))
                return BadRequest();

            MovieProviderEnum provider;
            if (!Enum.TryParse(source, out provider))
                return BadRequest();
            if (!Enum.IsDefined(typeof(MovieProviderEnum), provider))
                return BadRequest();
            var processor = _movieProviderFactory.GetMovieProvider(provider);
            if (processor == null)
                return BadRequest();
            var result = await processor.GetMovies();
            return Ok(result);
        }

        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> Get(string source, string id)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(id))
                return BadRequest();
            MovieProviderEnum provider;
            if (!Enum.TryParse(source, out provider))
                return BadRequest();
            if (!Enum.IsDefined(typeof(MovieProviderEnum), provider))
                return BadRequest();
            var processor = _movieProviderFactory.GetMovieProvider(provider);
            if (processor == null)
                return BadRequest();
            var result = await processor.GetMovie(id);
            return Ok(result);
        }
    }
}
