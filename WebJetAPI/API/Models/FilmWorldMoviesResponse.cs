using System;
using System.Collections.Generic;

namespace API.Models
{
    public class FilmWorldMoviesResponse
    {
        public List<FilmWorldMovie> Movies { get; set; }
    }

    public class FilmWorldMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public Uri Poster { get; set; }
    }
}