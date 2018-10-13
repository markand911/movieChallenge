using System.Threading.Tasks;
using API.Interface;
using API.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace API.Provider
{
    public class CinemaWorldProvider : IMovieProvider
    {
        private readonly IMapper _mapper;
        private readonly IProviderHelper _providerHelper;
        public CinemaWorldProvider(IMapper mapper, IProviderHelper providerHelper)
        {
            _mapper = mapper;
            _providerHelper = providerHelper;
        }

        public async Task<Movie> GetMovie(string Id)
        {
            string RequestUrl = $"{Properties.Settings.Default.MoviesAPIPath}/api/{MovieProviderEnum.cinemaworld}/movie/{Id}";
            string result = await _providerHelper.RestAPICall(RequestUrl);
            CinemaWorldMovieResponse filmMovies = JsonConvert.DeserializeObject<CinemaWorldMovieResponse>(result);
            Movie movies = _mapper.Map<Movie>(filmMovies);
            return movies;
        }

        public async Task<MoviesResponse> GetMovies()
        {
            string RequestUrl = $"{Properties.Settings.Default.MoviesAPIPath}/api/{MovieProviderEnum.cinemaworld}/movies";
            string result = await _providerHelper.RestAPICall(RequestUrl);
            CinemaWorldMoviesResponse cinemaMovies = JsonConvert.DeserializeObject<CinemaWorldMoviesResponse>(result);
            MoviesResponse movies = _mapper.Map<MoviesResponse>(cinemaMovies);
            return movies;
        }
    }
}
