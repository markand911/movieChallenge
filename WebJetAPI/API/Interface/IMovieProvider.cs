using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface IMovieProvider
    {
        Task<Movie> GetMovie(string Id);
        Task<MoviesResponse> GetMovies();
    }
}
