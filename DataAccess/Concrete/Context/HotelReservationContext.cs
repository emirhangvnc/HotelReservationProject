using Entities.Concrete;
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
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> HotelImages { get; set; }
        public DbSet<Room> RoomImages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}