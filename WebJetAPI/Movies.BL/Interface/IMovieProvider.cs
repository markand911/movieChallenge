using Movies.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BL.Interface
{
    public interface IMovieProvider
    {
        Task<CinemaWorldMovieResponse> GetMovies(string source);
    }
}
