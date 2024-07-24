using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetReservationById(int id);
        Task AddReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int id);
    }
}
