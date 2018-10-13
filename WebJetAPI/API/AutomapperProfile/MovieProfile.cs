using API.Models;
using AutoMapper;

namespace API.AutomapperModule
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<FilmWorldMovieResponse, Movie>();
            CreateMap<CinemaWorldMovieResponse, Movie>();
            CreateMap<CinemaWorldMovie, Movie>();
            CreateMap<FilmWorldMovie, Movie>();
            CreateMap<CinemaWorldMoviesResponse, MoviesResponse>();
            CreateMap<FilmWorldMoviesResponse, MoviesResponse>();
        }
    }
}