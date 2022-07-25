using Entities.Concrete;
using Entities.Concrete.Image;
using Entities.Concrete.Info;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Concrete;

namespace DataAccess.Concrete.Context
{
    public class HotelReservationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelReservation;Trusted_Connection=True");
        }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<HotelImage> hotelImages { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<RoomImage> roomImages { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserOperationClaim> userOperationClaims { get; set; }
        public DbSet<OperationClaim> operationClaims { get; set; }
    }
}