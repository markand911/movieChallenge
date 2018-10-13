using System;
using System.Collections.Generic;

namespace API.Models
{
    public class CinemaWorldMoviesResponse
    {
        public List<CinemaWorldMovie> Movies { get; set; }
    }

    public class CinemaWorldMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public Uri Poster { get; set; }
    }
}
