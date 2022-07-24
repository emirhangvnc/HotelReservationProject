using Core.Entities;

namespace Entities.DTOs.Concrete.ReservationDTO
{
    public class ReservationUpdateDTO : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
    }
}