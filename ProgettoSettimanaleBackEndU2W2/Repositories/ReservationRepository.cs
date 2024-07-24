using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgettoSettimanaleBackEndU2W2.Data;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgettoSettimanaleBackEndU2W2.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _context;

        public ReservationRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
