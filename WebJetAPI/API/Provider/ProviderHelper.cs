using API.Interface;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace API.Provider
{
    public class ProviderHelper : IProviderHelper
    {
        public async Task<string> RestAPICall(string url)
        {
            RestRequest req = new RestRequest(url, Method.GET);
            req.AddHeader("x-access-token", Properties.Settings.Default.APIToken);
            RestClient client = new RestClient(Properties.Settings.Default.MoviesAPIPath);
            var cancellationTokenSource = new CancellationTokenSource();
            Task<IRestResponse> response = client.ExecuteTaskAsync(req, cancellationTokenSource.Token);
            string result = response.Result.Content;
            return result;
        }
    }
}