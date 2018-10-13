using API.Interface;
using API.Models;
using AutoMapper;

namespace API.Provider
{
    public class MovieProviderFactory : IMovieProviderFactory
    {
        private readonly IMapper _mapper;
        private readonly IProviderHelper _providerHelper;
        public MovieProviderFactory(IMapper mapper, IProviderHelper providerHelper)
        {
            _mapper = mapper;
            _providerHelper = providerHelper;
        }

        public IMovieProvider GetMovieProvider(MovieProviderEnum provider)
        {
            IMovieProvider movieProvider;
            switch (provider)
            {
                case MovieProviderEnum.cinemaworld:
                    movieProvider = new CinemaWorldProvider(_mapper, _providerHelper);
                    break;
                default:
                    movieProvider = new FilmWorldProvider(_mapper, _providerHelper);
                    break;
            }
            return movieProvider;
        }
    }
}