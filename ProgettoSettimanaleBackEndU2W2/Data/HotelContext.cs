using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanaleBackEndU2W2.Models;

namespace ProgettoSettimanaleBackEndU2W2.Data
{
    public class HotelContext : IdentityDbContext<ApplicationUser>
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<ReservationDetail> ReservationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurazioni specifiche per le entità
            modelBuilder.Entity<AdditionalService>()
                .HasKey(a => a.ServiceID); // Definisci ServiceID come chiave primaria
        }
    }
}
