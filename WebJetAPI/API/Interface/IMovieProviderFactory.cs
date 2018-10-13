using API.Models;

namespace API.Interface
{
    public interface IMovieProviderFactory
    {
        IMovieProvider GetMovieProvider(MovieProviderEnum provider);
    }
}
