using ProgettoSettimanaleBackEndU2W2.Models;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(Client client);
    }
}
