using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgettoSettimanaleBackEndU2W2.Data;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgettoSettimanaleBackEndU2W2.Repositories
{
    public class ReservationDetailRepository : IReservationDetailRepository
    {
        private readonly HotelContext _context;

        public ReservationDetailRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservationDetail>> GetAllReservationDetails()
        {
            return await _context.ReservationDetails.ToListAsync();
        }

        public async Task<ReservationDetail> GetReservationDetailById(int id)
        {
            return await _context.ReservationDetails.FindAsync(id);
        }

        public async Task AddReservationDetail(ReservationDetail reservationDetail)
        {
            _context.ReservationDetails.Add(reservationDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationDetail(ReservationDetail reservationDetail)
        {
            _context.Entry(reservationDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationDetail(int id)
        {
            var reservationDetail = await _context.ReservationDetails.FindAsync(id);
            _context.ReservationDetails.Remove(reservationDetail);
            await _context.SaveChangesAsync();
        }
    }
}
