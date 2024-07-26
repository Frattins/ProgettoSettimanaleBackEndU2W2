using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Interface
{
    public interface IServizioDao
    {
        Task<IEnumerable<AdditionalService>> GetAllAsync();
        Task<AdditionalService> GetByIdAsync(int id);
        Task AddAsync(AdditionalService servizio);
        Task UpdateAsync(AdditionalService servizio);
        Task DeleteAsync(int id);
    }
}
