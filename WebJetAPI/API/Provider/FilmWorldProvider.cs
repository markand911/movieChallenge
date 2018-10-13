using API.Interface;
using API.Models;
using AutoMapper;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API.Provider
{
    public class FilmWorldProvider : IMovieProvider
    {
        private readonly IMapper _mapper;
        private readonly IProviderHelper _providerHelper;
        public FilmWorldProvider(IMapper mapper, IProviderHelper providerHelper)
        {
            _mapper = mapper;
            _providerHelper = providerHelper;
        }

        public async Task<Movie> GetMovie(string Id)
        {
            string RequestUrl = $"{Properties.Settings.Default.MoviesAPIPath}/api/{MovieProviderEnum.filmworld}/movie/{Id}";
            string result = await _providerHelper.RestAPICall(RequestUrl);
            FilmWorldMovieResponse filmMovies = JsonConvert.DeserializeObject<FilmWorldMovieResponse>(result);
            Movie movies = _mapper.Map<Movie>(filmMovies);
            return movies;
        }

        public async Task<MoviesResponse> GetMovies()
        {
            string RequestUrl = $"{Properties.Settings.Default.MoviesAPIPath}/api/{MovieProviderEnum.filmworld}/movies";
            string result = await _providerHelper.RestAPICall(RequestUrl);
            FilmWorldMoviesResponse filmMovies = JsonConvert.DeserializeObject<FilmWorldMoviesResponse>(result);
            MoviesResponse movies = _mapper.Map<MoviesResponse>(filmMovies);
            return movies;
        }
    }
}