using System.Net.Http;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface IApiService
    {
        public Task Authentication();

        public bool IsTokenExpired();
        Task<HttpResponseMessage> Post(object input, string addurl);
    }
}
