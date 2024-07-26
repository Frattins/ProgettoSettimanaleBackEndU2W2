using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.DAO
{
    public interface IPrenotazioneDao
    {
        Task<bool> AddAsync(Reservation reservation);
        Task<bool> UpdateAsync(Reservation reservation);
        Task<bool> DeleteAsync(int id);
        Task<Reservation> GetByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetAllAsync();
    }
}
