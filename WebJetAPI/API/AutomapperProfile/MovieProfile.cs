using API.Models;
using AutoMapper;

namespace API.AutomapperModule
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CinemaWorldMovie, Movie>()
                    .ForMember(dest => dest.Link, opt => opt.MapFrom(src => $"/{src.Id}?source=cinemaworld"));
            CreateMap<FilmWorldMovie, Movie>()
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => $"/{src.Id}?source=filmworld"));

            CreateMap<FilmWorldMovieResponse, Movie>();
            CreateMap<CinemaWorldMovieResponse, Movie>();
            CreateMap<CinemaWorldMoviesResponse, MoviesResponse>();
            CreateMap<FilmWorldMoviesResponse, MoviesResponse>();
        }
    }
}