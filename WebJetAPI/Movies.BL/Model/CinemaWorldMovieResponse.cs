using System;
using System.Collections.Generic;

namespace Movies.BL.Model
{
    public class CinemaWorldMovieResponse
    {
        public List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public Uri Poster { get; set; }
    }
}
