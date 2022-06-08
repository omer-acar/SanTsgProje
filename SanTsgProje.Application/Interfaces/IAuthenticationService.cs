using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Task Authentication();

        public bool IsTokenExpired();
    }
}
