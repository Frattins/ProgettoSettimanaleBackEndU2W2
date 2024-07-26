using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Interface
{
    public interface IClienteDao
    {
        Task<bool> AddClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
        Task<Client> GetByIdAsync(int id);
        Task<Client> GetClientByEmailAsync(string email);
        Task<IEnumerable<Client>> GetAllClientsAsync();
    }
}
