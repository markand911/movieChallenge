using System.Threading.Tasks;

namespace API.Interface
{
    public interface IProviderHelper
    {
        Task<string> RestAPICall(string url);
    }
}
