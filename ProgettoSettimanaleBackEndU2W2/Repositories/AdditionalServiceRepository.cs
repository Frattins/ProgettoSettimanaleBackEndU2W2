using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgettoSettimanaleBackEndU2W2.Data;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgettoSettimanaleBackEndU2W2.Repositories
{
    public class AdditionalServiceRepository : IAdditionalServiceRepository
    {
        private readonly HotelContext _context;

        public AdditionalServiceRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdditionalService>> GetAllAdditionalServices()
        {
            return await _context.AdditionalServices.ToListAsync();
        }

        public async Task<AdditionalService> GetAdditionalServiceById(int id)
        {
            return await _context.AdditionalServices.FindAsync(id);
        }

        public async Task AddAdditionalService(AdditionalService additionalService)
        {
            _context.AdditionalServices.Add(additionalService);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdditionalService(AdditionalService additionalService)
        {
            _context.Entry(additionalService).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdditionalService(int id)
        {
            var additionalService = await _context.AdditionalServices.FindAsync(id);
            _context.AdditionalServices.Remove(additionalService);
            await _context.SaveChangesAsync();
        }
    }
}
