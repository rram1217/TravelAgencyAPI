using Microsoft.EntityFrameworkCore;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Data
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
            : base(options)
        {
        }

        // DbSet properties for the entities
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hotel entity configuration
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.HotelId);
                entity.Property(h => h.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(h => h.City)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(h => h.IsEnabled)
                      .IsRequired();
            });

            // Room entity configuration
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(r => r.RoomId);
                entity.Property(r => r.Description)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(r => r.Capacity)
                      .IsRequired();
                entity.Property(r => r.Price)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(r => r.IsEnabled)
                      .IsRequired();

            });

            // Reservation entity configuration
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(res => res.ReservationId);
                entity.Property(res => res.CheckInDate)
                      .IsRequired();
                entity.Property(res => res.CheckOutDate)
                      .IsRequired();
                entity.Property(res => res.TotalPrice)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

            });

            // Guest entity configuration
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(g => g.GuestId);
                entity.Property(g => g.FullName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(g => g.Email)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(g => g.Phone)
                      .IsRequired()
                      .HasMaxLength(15);
            });
        }
    }
}
