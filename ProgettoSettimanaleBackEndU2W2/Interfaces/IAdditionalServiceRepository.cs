using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Interfaces
{
    public interface IAdditionalServiceRepository
    {
        Task<IEnumerable<AdditionalService>> GetAllAdditionalServices();
        Task<AdditionalService> GetAdditionalServiceById(int id);
        Task AddAdditionalService(AdditionalService additionalService);
        Task UpdateAdditionalService(AdditionalService additionalService);
        Task DeleteAdditionalService(int id);
    }
}
