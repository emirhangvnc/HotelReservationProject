using Core.Entities;

namespace Entities.Concrete
{
    public class Reservation:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserNumber { get; set; }
        public int RoomId { get; set; }
        public decimal Total { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
    }
}