using System.Collections.Generic;
using System.Threading.Tasks;
using ProgettoSettimanaleBackEndU2W2.Models;

namespace ProgettoSettimanaleBackEndU2W2.Interfaces
{
    public interface IReservationDetailRepository
    {
        Task<IEnumerable<ReservationDetail>> GetAllReservationDetails();
        Task<ReservationDetail> GetReservationDetailById(int id);
        Task AddReservationDetail(ReservationDetail reservationDetail);
        Task UpdateReservationDetail(ReservationDetail reservationDetail);
        Task DeleteReservationDetail(int id);
    }
}
