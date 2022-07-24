using Core.Entities;

namespace Entities.DTOs.Concrete.RoomDTO
{
    public class RoomUpdateDTO:IDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StandartBad { get; set; }
    }
}