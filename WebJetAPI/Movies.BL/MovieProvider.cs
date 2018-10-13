using Movies.BL.Interface;
using Movies.BL.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.BL
{
    public class MovieProvider : IMovieProvider
    {
        public MovieProvider()
        {
        }

        public async Task<CinemaWorldMovieResponse> GetMovies(string source)
        {
            var RequestUri = new Uri($"{Properties.Settings.Default.MoviesAPIPath}{source}/movies");
            RestRequest req = new RestRequest(RequestUri, Method.GET);
            req.AddHeader("x-access-token", Properties.Settings.Default.APIToken);
            RestClient client = new RestClient();
            var cancellationTokenSource = new CancellationTokenSource();
            Task<IRestResponse> response = client.ExecuteTaskAsync(req, cancellationTokenSource.Token);
            string result = response.Result.Content;

            CinemaWorldMovieResponse movies = Newtonsoft.Json.JsonConvert.DeserializeObject<CinemaWorldMovieResponse>(result);
            return movies;
        }
    }
}
