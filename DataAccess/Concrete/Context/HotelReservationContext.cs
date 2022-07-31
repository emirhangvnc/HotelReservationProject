using Entities.Concrete;
using Entities.Concrete.Image;
using Entities.Concrete.Info;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Concrete;

namespace DataAccess.Concrete.Context
{
    public class HotelReservationContext : DbContext
    {
        public HotelReservationContext()
        {
            Database.SetCommandTimeout(99999999);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelReservation;Trusted_Connection=True");
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}